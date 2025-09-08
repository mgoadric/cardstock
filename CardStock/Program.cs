using CardStock.Evaluation;
using CardStock.Players;

string game = "Agram";
int numPlayers = 3;


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
    NumGames = 10,
    type = GameType.RndandAI, // GameType.AllRnd or GameType.AllAI
    AI = PlayerType.MCTS,
};

Console.WriteLine(exp.Game + ", " + exp.PlayerCount);

GameSimulator engine = new(exp);
engine.LoadGame();
engine.RunExperiment();


//}





