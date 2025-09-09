using CardStock.Evaluation;
using CardStock.Players;

string game = "Cuckoo";
int numPlayers = 6;


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
    Players = []
};

Console.WriteLine(exp.Game + ", " + exp.PlayerCount);

GameSimulator engine = new(exp);
engine.LoadGame();
engine.RunExperiment();


//}





