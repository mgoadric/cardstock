int numRndvRnd = 100;
int numAIvRnd = 0;
int numAIvAI = 0;
string game = "LeducPoker";
int players = 2;

var p = new CardStock.Scoring.Scorer(game, players, numRndvRnd, numAIvRnd, numAIvAI);
var score = p.Score();