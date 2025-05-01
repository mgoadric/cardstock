using System;
namespace CardStock
{
    public record Experiment
    {
        public string FileName;
        public int NumGames;
        public int NumEpochs;
        public bool Logging;
        public bool Evaluating;

        public GameType type = GameType.AllRnd;
    }

    public enum GameType {
        AllAI, AllRnd, RndandAI, TOURNAMENT
    }
}
