using System.Collections.Generic;using System;using Players;using System.Text;namespace CardEngine{    public class Player : Owner {        public Team team; 		public AIPlayer decision; // Don't include this

        public Player(string name) : base(name){}        // FIX ME!!!        public Player Clone(){            Player other = new Player(name)
            {
                intBins = intBins.Clone(),
                cardBins = cardBins.Clone()
            };
            other.cardBins.owner = other;            other.decision = decision;            return other;
        }        public override bool Equals(System.Object obj)        {            if (obj == null)            { return false; }            Player otherplayer = obj as Player;            if ((System.Object)otherplayer == null)            { return false; }            if (!(intBins.Equals(otherplayer.intBins)) || !(cardBins.Equals(otherplayer.cardBins)))             { return false; }            if (name != otherplayer.name || team.name != otherplayer.team.name)            { return false; }            return true;        }        public override int GetHashCode() // XORs relevant hashcodes        {            return name.GetHashCode() ^ team.GetHashCode() ^ intBins.GetHashCode() ^ cardBins.GetHashCode();        }    }}