using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Channels;
using CardStock.CardEngine;
using CardStock.FreezeFrame;
using CardStock.Players;

namespace CardStock.Evaluation;

public class GameThreadPool
{
    public const int MAXPLAYERS = 9; // This makes some things easier to store as arrays.
    public const int CHOICELIMIT = 500; // The upper bound on the number of moves in a game before it is called.
    public const int LOOPLIMIT = 200; // The upper bound on the number of actions without a choice interrupting

    private readonly int _experimentCount, _threadCount;
    private readonly Experiment _experiment;
    private readonly RecycleParser.GameContext _tree;
    private readonly string _path;
    private readonly Channel<Tuple<int, GameIterator>> _channel;
    private readonly Random _random;
    private readonly DataCollectorManager _dc;

    public GameThreadPool(int experimentCount, int threadCount, Experiment experiment, RecycleParser.GameContext tree)
    {
        _experimentCount = experimentCount;
        _threadCount = threadCount;
        _experiment = experiment;
        _tree = tree;
        _path = "output/" + _experiment.Game + "/" + _experiment.PlayerCount + "/" + _experiment.PlayerAbv() + "/simulation/";
        _random = new Random((int)experiment.Seed);
        _dc = new DataCollectorManager(_experiment);

        _channel = Channel.CreateUnbounded<Tuple<int, GameIterator>>();
    }

    public async Task Start()
    {
        Logger.Start();
        Console.WriteLine("Seeding games...");

        for (int i = 0; i < _experimentCount; i++)
        {
            var gamePlay = CreateGame(i);
            await _channel.Writer.WriteAsync(new(i, gamePlay));
        }

        _channel.Writer.Complete();

        Console.WriteLine("Seeded games!");

        Task[] tasks = new Task[_threadCount];

        Stopwatch stopwatch = new();
        stopwatch.Start();

        long allocatedBefore = GC.GetTotalAllocatedBytes(true);

        for (int i = 0; i < _threadCount; i++)
        {
            tasks[i] = Task.Factory.StartNew(
                () =>
                {
                    while (_channel.Reader.TryRead(out var item))
                    {
                        try
                        {
                            ProcessGame(item);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Game {item.Item1} failed: {e}");
                        }
                    }
                },
                CancellationToken.None,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Default
            );
        }

        await Task.WhenAll(tasks);

        Console.WriteLine("Finalizing Writing...");
        _dc.Write();
        Logger.Finish();
        Console.WriteLine("Finished Writing!");

        stopwatch.Stop();

        long allocatedAfter = GC.GetTotalAllocatedBytes(false);
        double megabytesAllocated = (allocatedAfter - allocatedBefore) / (1024 * 1024);
        double totalTime = stopwatch.Elapsed.TotalMilliseconds;

        Console.WriteLine("Took " + totalTime + "ms");
        Console.WriteLine("Allocation Count: " + megabytesAllocated + "MB");
        Console.WriteLine("Allocation Rate: " + (megabytesAllocated / (totalTime / 1000)) + "MB/s");
        Console.WriteLine("Amount of pointers needed: " + GameIterator.itemsTotal);
    }

    private GameIterator CreateGame(int index)
    {
        CardGame game = new(_experiment);
        var gamePlay = new FreezeFrame.GameIterator(_tree, game, _path + (index + 1), _experiment);
        var dc = _dc.GetCollector(index);

        for (int j = 0; j < game.players.Length; j++)
        {
            Perspective perspective = new(j, gamePlay);

            if (j < _experiment.Players.Count)
            {
                game.players[j].decision = _experiment.Players[j].AI(perspective, dc);
            }
            else
            {
                game.players[j].decision = PlayerType.RANDOM.AI(perspective, dc);
            }
        }

        return gamePlay;
    }

    private void ProcessGame(Tuple<int, GameIterator> iterator)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        int i = iterator.Item1;
        Console.WriteLine("Starting game " + (i + 1));

        var gamePlay = iterator.Item2;

        while (!gamePlay.AdvanceToChoice())
        {
            gamePlay.ProcessChoice();

            if (gamePlay.totalChoices > CHOICELIMIT)
            {
                Console.WriteLine("Game " + (i + 1) + " Choices not processed (probably infinite loop)");
                break;
            }
        }

        var results = gamePlay.ProcessScore();
        var mult = gamePlay.ProcessDirection();
        stopwatch.Stop();

        var dc = _dc.GetCollector(i);

        dc.FinishGameStatistics(results, mult, stopwatch.Elapsed.TotalMilliseconds);

        gamePlay.script?.WriteMovementFile();
        gamePlay.script?.Close();

        Console.WriteLine("Finished game " + (i + 1));
    }
}