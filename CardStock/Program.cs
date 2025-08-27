using CardStock;
using CardStock.Evaluation;

string game = "GolfSix";
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
    NumGames = 1,
    NumEpochs = 1,
    type = GameType.RndandAI,
    ai = CardStock.Players.PlayerType.PIPMCNEW,
};

Console.WriteLine(exp.Game + ", " + exp.PlayerCount);

var gameWorld = new World();
GameSimulator engine = new(exp, gameWorld);
var tup = engine.Loader();
var compiling = engine.Experimenter();



//}





