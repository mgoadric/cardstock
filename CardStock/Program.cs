int numRndvRnd = 100;
int numAIvRnd = 100;
int numAIvAI = 0;
string game = "Pitch";
int players = 4;
CardStock.Players.PlayerType ai = CardStock.Players.PlayerType.PIPMCNEW;

var p = new CardStock.Scoring.Scorer(game, players, numRndvRnd, numAIvRnd, numAIvAI, ai);
var score = p.Score();