int numRndvRnd = 0;
int numAIvRnd = 0;
int numAIvAI = 1;
string game = "Hearts";
int players = 4;

var p = new CardStock.Scoring.Scorer(game, players, numRndvRnd, numAIvRnd, numAIvAI);
var score = p.Score();