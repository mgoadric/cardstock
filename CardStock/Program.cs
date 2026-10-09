using System.Diagnostics;
using CardStock.CardEngine;
using CardStock.Evaluation;
using CardStock.FreezeFrame;
using CardStock.FreezeFrame.Tree;
using CardStock.FreezeFrame.Tree.Operation;
using CardStock.FreezeFrame.Tree.State;
using CardStock.FreezeFrame.Tree.Storage;
using CardStock.FreezeFrame.Tree.Values;
using CardStock.Players;

static void RunExperiment(Experiment exp)
{
    Console.WriteLine(exp.Game + ", " + exp.PlayerCount);
    GameSimulator.exp = exp;
    GameSimulator engine = new();
    engine.LoadGame();
    engine.RunExperiment();
}

/***
 * Convert the string from PRR into PlayerType enums
 **/
static List<PlayerType> MakePlayers(string players)
{
    List<PlayerType> ps = [];
    foreach (char c in players)
    {
        switch (c)
        {
            case 'P': { ps.Add(PlayerType.PIPMC); break; }
            case 'M': { ps.Add(PlayerType.MCTS); break; }
            default: { ps.Add(PlayerType.RANDOM); break; }
        }
    }
    return ps;
}

Experiment exp = new()
{
    Game = args.Length > 0 ? args[0] : "Agram",
    PlayerCount = args.Length > 1 ? Int32.Parse(args[1]) : 2,
    NumGames = args.Length > 2 ? Int32.Parse(args[2]) : 1,
    Players = args.Length > 3 ? MakePlayers(args[3]) : [],
    Logging = args.Length > 4 ? Boolean.Parse(args[4]) : false,
    numTests = args.Length > 5 ? Int32.Parse(args[5]) : 1000,
    numSamples = args.Length > 6 ? Int32.Parse(args[6]) : 10,
    imperfectLevel = args.Length > 7 ? Enum.Parse<ImperfectLevel>(args[7]) : ImperfectLevel.PRIVATE,
};

static void RunBenchmark()
{
    IGameNode[] node = {
        new PushValueNode(new(10)),
        new PushValueNode(new(20)),
        new AdditionNode()
    };

    GameContext context = new();
    int passes = 100_000_000;
    Stopwatch watch = new();

    watch.Start();
    long store = 0;

    for (int i = 0; i < passes; i++)
    {
        for (int j = 0; j < node.Length; j++)
        {
            node[j].Process(context);
        }

        store += context.Local().Pop().Int();
    }

    /*Stack<int> stack = new(4);

    for (int i = 0; i < passes; i++)
    {
        stack.Push(10);
        stack.Push(20);

        store += stack.Pop() + stack.Pop();
    }*/

    watch.Stop();

    Console.WriteLine("took " + (watch.Elapsed.TotalMilliseconds) + " ms");
    Console.WriteLine("store: " + store);
}

RunBenchmark();
//RunExperiment(exp);

