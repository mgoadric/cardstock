using System;
namespace CardStock
{
    public record Experiment
    {
        public required string FileName;
        public required int NumGames;
        public required int NumEpochs;
        public required bool Logging;
        public required bool Evaluating;

        public GameType type = GameType.AllRnd;
    }

    public enum GameType {
        AllAI, AllRnd, RndandAI, TOURNAMENT
    }
}
