int numRndvRnd = 100;
int numAIvRnd = 100;
int numAIvAI = 100;
string game = "Pairs";
int players = 4;

var p = new CardStock.Scoring.Scorer("games/" + game + players + ".gdl", 
    numRndvRnd, numAIvRnd, numAIvAI);
var score = p.Score();