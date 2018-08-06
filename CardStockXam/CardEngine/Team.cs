using System.Collections.Generic;
using System.Linq;

namespace CardEngine{
    /**********
     * Teams are Owners that have a list of Players who form a team in the game.
     */
    public class Team : Owner
    {
        public List<Player> teamPlayers = new List<Player>();

        public Team(string name, int id) : base(name, id) { }

        public Team Clone()
        {
            Team other = new Team(name, id);
            other.intBins = intBins.Clone(other);
            other.stringBins = stringBins.Clone(other);
            other.pointBins = pointBins.Clone(other);
            other.cardBins = cardBins.Clone(other);
            other.teamPlayers = new List<Player>();
            return other;
        }
    }
}