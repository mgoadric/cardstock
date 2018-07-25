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

        public Player(string name, int id) : base(name, id){
        }

        // Not much happening here, everything taken care of in the 
        // Owner class, again decisions are handled later 
        // with the GameIterator for this CardGame

        new public Player Clone()
        {
            return (Player)CloneImpl();
        }

        protected override Owner CloneImpl() 
        {
            Player other = (Player)base.CloneImpl();
            return other;
        }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            { return false; }

            Player otherplayer = obj as Player;
            if ((System.Object)otherplayer == null)
            { return false; }

            if (!(intBins.Equals(otherplayer.intBins)) || !(cardBins.Equals(otherplayer.cardBins))) 
            { return false; }

            if (name != otherplayer.name || team.name != otherplayer.team.name)
            { return false; }

            return true;
        }

        public override int GetHashCode() // XORs relevant hashcodes
        {
            return name.GetHashCode() ^ team.GetHashCode() ^ intBins.GetHashCode() ^ cardBins.GetHashCode();
        }

    }
}
