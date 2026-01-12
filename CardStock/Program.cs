using CardStock.CardEngine;
using CardStock.Evaluation;
using CardStock.Players;

static void RunExperiment(Experiment exp)
{
    Console.WriteLine(exp.Game + ", " + exp.PlayerCount);
    GameSimulator engine = new(exp);
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
            case 'P':    {ps.Add(PlayerType.PIPMC); break;}
            case 'M':    {ps.Add(PlayerType.MCTS); break;}
            default:     {ps.Add(PlayerType.RANDOM); break;}
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

RunExperiment(exp);

