int numRndvRnd = 100;
int numAIvRnd = 100;
int numAIvAI = 100;
string game = "Cuckoo";
int players = 6;

var p = new CardStock.Scoring.Scorer(game, players, numRndvRnd, numAIvRnd, numAIvAI);
var score = p.Score();