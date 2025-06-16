int numRndvRnd = 1;
int numAIvRnd = 0;
int numAIvAI = 0;
string game = "KuhnPoker";
int players = 2;

var p = new CardStock.Scoring.Scorer("games/" + game + players + ".gdl", 
    numRndvRnd, numAIvRnd, numAIvAI);
var score = p.Score();