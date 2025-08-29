using CardStock;
using CardStock.Evaluation;

string game = "Agram";
int numPlayers = 3;


/*
// Test them all
string[] files = Directory.GetFiles("games/", "*.rcy");
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
    type = GameType.RndandAI, // GameType.AllRnd or GameType.AllAI
    ai = CardStock.Players.PlayerType.MCTS,
};

Console.WriteLine(exp.Game + ", " + exp.PlayerCount);

GameSimulator engine = new(exp);
engine.Loader();
var compiling = engine.Experimenter();



//}





