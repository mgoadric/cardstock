int numRndvRnd = 100;
int numAIvRnd = 100;
int numAIvAI = 100;
string name = "games/Pairs4.gdl";

var p = new CardStock.Scoring.Scorer(name, numRndvRnd, numAIvRnd, numAIvAI);
var score = p.Score();