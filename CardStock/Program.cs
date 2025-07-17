int numRndvRnd = 1;
int numAIvRnd = 0;
int numAIvAI = 0;
string game = "LostCities";
int players = 2;
CardStock.Players.PlayerType ai = CardStock.Players.PlayerType.PIPMCNEW;

var p = new CardStock.Scoring.Scorer(game, players, numRndvRnd, numAIvRnd, numAIvAI, ai);
var score = p.Score();