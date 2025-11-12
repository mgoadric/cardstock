using CardStock.CardEngine;
using CardStock.Evaluation;
using CardStock.Players;

string game = "BustedJunk/Nanuk";
int numPlayers = 6;

runExperiment(game, numPlayers);
//runAllGames();

static void runExperiment(string game, int numPlayers)
{
    Experiment exp = new()
    {
        Game = game,
        PlayerCount = numPlayers,
        NumGames = 1,
        Players = [PlayerType.PIPMC],
        Logging = true,
        numTests = 20,
        numSamples = 10,
        imperfectLevel = ImperfectLevel.TAKEN,
    };

    Console.WriteLine(exp.Game + ", " + exp.PlayerCount);

    GameSimulator engine = new(exp);
    engine.LoadGame();
    engine.RunExperiment();
}

static void runAllGames()
{
    string[] files = Directory.GetFiles("games/TraditionalTestbed/", "*.rcy");
    //string[] files = Directory.GetFiles("games/", "*.rcy");
    Array.Sort(files);
    foreach (string filename in files)
    {
        Console.WriteLine(filename);
        string game = filename[6..^5];
        int numPlayers = filename[^5] - '0';
        runExperiment(game, numPlayers);
        
    }
}





