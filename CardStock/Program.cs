using CardStock.CardEngine;
using CardStock.Evaluation;
using CardStock.Players;

static async Task RunExperiment(Experiment exp)
{
    Console.WriteLine(exp.Game + ", " + exp.PlayerCount);
    GameSimulator.exp = exp;
    GameSimulator engine = new();
    engine.LoadGame();
    bool result = await engine.RunExperiment();

    Console.WriteLine("Explored " + PIPMCPlayer.explored + " choices");
    Console.WriteLine("But only saw " + PIPMCPlayer.choicesTotal + " in total");
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
            case 'I': { ps.Add(PlayerType.ISMCTS); break; }
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
    Seed = args.Length > 6 ? Int64.Parse(args[6]) : DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
    numSamples = args.Length > 7 ? Int32.Parse(args[7]) : 10,
    imperfectLevel = args.Length > 8 ? Enum.Parse<ImperfectLevel>(args[8]) : ImperfectLevel.TAKEN,
};

await RunExperiment(exp);

