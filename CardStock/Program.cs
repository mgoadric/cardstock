using CardStock.Evaluation;
using CardStock.Players;

string game = "Scopa";
int numPlayers = 2;


/*
// Test them all
string[] files = Directory.GetFiles("games/", "*.rcy");
Array.Sort(files);
foreach (string filename in files)
{
    string game = filename[6..^5];
    int numPlayers = filename[^5] - '0';
*/

Experiment exp = new()
{
    Game = game,
    PlayerCount = numPlayers,
    NumGames = 100,
    type = GameType.AllRnd, // GameType.AllRnd or GameType.AllAI
    AI = PlayerType.RANDOM,
};

Console.WriteLine(exp.Game + ", " + exp.PlayerCount);

GameSimulator engine = new(exp);
engine.LoadGame();
engine.RunExperiment();


//}





