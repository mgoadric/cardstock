using System;
using CardStock.Players;
namespace CardStock.Evaluation
{
    public record Experiment
    {
        public required string Game;
        public required int PlayerCount;
        public required int NumGames;
        public required PlayerType AI;

        public GameType type = GameType.AllRnd;
    }

    public enum GameType {
        AllAI, AllRnd, RndandAI, TOURNAMENT
    }
}
