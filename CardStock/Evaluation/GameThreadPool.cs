using System.Collections.Concurrent;
using System.Threading.Channels;
using CardStock.CardEngine;
using CardStock.FreezeFrame;
using CardStock.Players;

namespace CardStock.Evaluation;

public class GameThreadPool
{
    private readonly int _experimentCount, _threadCount;
    private readonly Experiment _experiment;
    private readonly RecycleParser.GameContext _tree;
    private readonly string _path;
    private readonly Channel<Tuple<int, GameIterator>> _channel;
    private readonly Random _random;
    private readonly DataCollector _dc;

    public GameThreadPool(int experimentCount, int threadCount, Experiment experiment, RecycleParser.GameContext tree)
    {
        _experimentCount = experimentCount;
        _threadCount = threadCount;
        _experiment = experiment;
        _tree = tree;
        _path = "output/" + _experiment.Game + "/" + _experiment.PlayerCount + "/" + _experiment.PlayerAbv() + "/simulation/";
        _random = new Random((int) experiment.Seed);
        _dc = new DataCollector(_experiment);

        _channel = Channel.CreateUnbounded<Tuple<int, GameIterator>>();
    }

    public async void Start()
    {
        for (int i = 0; i < _experimentCount; i++)
        {
            var gamePlay = CreateGame(i);

            await _channel.Writer.WriteAsync(new Tuple<int, GameIterator>(i, gamePlay));
        }

        _channel.Writer.Complete();

        List<Task> tasks = new List<Task>();
        for (int i = 0; i < Environment.ProcessorCount; i++)
        {
            var worker = Task.Factory.StartNew(
                async () =>
                {
                    await foreach (var iterator in _channel.Reader.ReadAllAsync())
                    {
                        ProcessGame(iterator);
                    }
                },
                CancellationToken.None,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Default
            );

            tasks.Add(worker);
        }

        await Task.WhenAll(tasks);
    }

    private GameIterator CreateGame(int index)
    {
        CardGame game = new(_experiment);
        var gamePlay = new FreezeFrame.GameIterator(_tree, game, _path + (index + 1), _experiment);

        for (int j = 0; j < game.players.Length; j++)
        {
            Perspective perspective = new(j, gamePlay);

            if (j < _experiment.Players.Count)
            {
                game.players[j].decision = _experiment.Players[j].AI(perspective, _dc);
            }
            else
            {
                game.players[j].decision = PlayerType.RANDOM.AI(perspective, _dc);
            }
        }

        return gamePlay;
    }

    private void ProcessGame(Tuple<int, GameIterator> iterator)
    {
        Console.WriteLine("Starting game " + iterator.Item1);
    }
}