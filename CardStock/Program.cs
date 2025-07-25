int numRndvRnd = 0;
int numAIvRnd = 1;
int numAIvAI = 0;
string game = "GoFish";
int players = 4;
CardStock.Players.PlayerType ai = CardStock.Players.PlayerType.PIPMCNEW;

Console.WriteLine(game + ", " + players);
var p = new CardStock.Scoring.Scorer(game, players, numRndvRnd, numAIvRnd, numAIvAI, ai);
var score = p.Score();

// TEST THEM ALL
/*
string[] files = Directory.GetFiles("games/", "*.gdl");
foreach (string filename in files)
{
    string name = filename[6..^5];
    int play = filename[^5] - '0';
    Console.WriteLine(name + ", " + play);
    var p = new CardStock.Scoring.Scorer(name, play, numRndvRnd, numAIvRnd, numAIvAI, ai);
    var score = p.Score();
}
*/


