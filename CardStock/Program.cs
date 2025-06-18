int numRndvRnd = 1;
int numAIvRnd = 1;
int numAIvAI = 1;
string game = "Golf";
int players = 4;

var p = new CardStock.Scoring.Scorer(game, players, numRndvRnd, numAIvRnd, numAIvAI);
var score = p.Score();