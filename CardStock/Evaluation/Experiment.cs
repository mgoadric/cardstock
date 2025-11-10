using System;
using CardStock.Players;
namespace CardStock.Evaluation
{
    public record Experiment
    {
        public required string Game;
        public required int PlayerCount;
        public required int NumGames;
        public required List<PlayerType> Players;

        public bool Logging = true;
        public int numSamples = 1000; // rollouts per move
        public int numTests = 10; // determinizations

        public ImperfectLevel imperfectLevel = ImperfectLevel.PRIVATE;

        public string PlayerAbv()
        {
            var ps = Players.Select(s => s.ToString()[0]);
            return string.Join("", ps) + new String('R', Math.Max(0, PlayerCount - Players.Count));
        }

    }
}
