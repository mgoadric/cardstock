using System.Collections.Generic;
using System.Linq;

namespace CardStock.CardEngine{
    /**********
     * Teams are Owners that have a list of Players who form a team in the game.
     */
    public class Team : Owner
    {
        public List<Player> teamPlayers = new List<Player>();

        public Team(string name, int id) : base(name, id) { }

        public bool IsMember(int playerIdx) {
            foreach (Player p in teamPlayers) {
                if (p.id == playerIdx) {
                    return true;
                }
            }
            return false;
        }

        public Team Clone()
        {
            Team other = new Team(name, id);
            other.intBins = intBins.Clone(other);
            other.stringBins = stringBins.Clone(other);
            other.pointBins = pointBins.Clone(other);
            other.cardBins = new CardStorage(other);
            other.teamPlayers = new List<Player>();
            return other;
        }
    }
}