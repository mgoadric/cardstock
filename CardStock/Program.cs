int numRndvRnd = 0;
int numAIvRnd = 10;
int numAIvAI = 0;
string game = "Euchre";
int players = 4;
CardStock.Players.PlayerType ai = CardStock.Players.PlayerType.PIPMCNEW;

var p = new CardStock.Scoring.Scorer(game, players, numRndvRnd, numAIvRnd, numAIvAI, ai);
var score = p.Score();