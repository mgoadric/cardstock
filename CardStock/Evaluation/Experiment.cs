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

        public string PlayerAbv()
        {
            var ps = Players.Select(s => s.ToString()[0]);
            return string.Join("", ps) + new String('R', Math.Max(0, PlayerCount - Players.Count));
        }

    }
}
