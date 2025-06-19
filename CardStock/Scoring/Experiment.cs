using System;
using CardStock.Players;
namespace CardStock.Scoring
{
    public record Experiment
    {
        public required string Game;
        public required int PlayerCount;
        public required int NumGames;
        public required int NumEpochs;
        public required bool Logging;
        public required bool Evaluating;
        public required PlayerType ai;

        public GameType type = GameType.AllRnd;
    }

    public enum GameType {
        AllAI, AllRnd, RndandAI, TOURNAMENT
    }
}
