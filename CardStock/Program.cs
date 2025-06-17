int numRndvRnd = 1;
int numAIvRnd = 0;
int numAIvAI = 0;
string game = "Test-Subset";
int players = 2;

var p = new CardStock.Scoring.Scorer(game, players, numRndvRnd, numAIvRnd, numAIvAI);
var score = p.Score();