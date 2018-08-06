using System.Collections.Generic;
using System;
using Players;
using System.Text;
namespace CardEngine
{
    /*******
     * Players are Owners of things that can also be on a team.
     * They have an AIPlayer that is called on to make a
     * decision when a "choice" is found in the game
     */
    public class Player : Owner {

        // Players can be part of Teams of Players, and can access
        // their shared storage
        public Team team;

        // The particular AI is supplied by the GameIterator later
        public AIPlayer decision;

        public Player(string name, int id) : base(name, id) {
        }

        // Not much happening here, everything taken care of in the 
        // Owner class, again decisions are handled later 
        // with the GameIterator for this CardGame

        public Player Clone()
        {
            Player other = new Player(name, id);
            other.intBins = intBins.Clone(other);
            other.stringBins = stringBins.Clone(other);
            other.pointBins = pointBins.Clone(other);
            other.cardBins = cardBins.Clone(other);
            return other;
        }
    }
}
