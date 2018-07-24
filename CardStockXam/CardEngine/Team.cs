using System.Collections.Generic;
using System.Linq;

namespace CardEngine{
    public class Team : Owner
    {
        public List<Player> teamPlayers = new List<Player>();

        public Team(string name, int id) : base(name, id) { }

        new public Team Clone()
        {
            return (Team)CloneImpl();
        }

        protected override Owner CloneImpl()
        {
            Team other = (Team)base.CloneImpl();
            other.teamPlayers = new List<Player>();
            return other;
        }

        public override bool Equals(System.Object obj)
        { 
            if (obj == null)
            { return false; }

            Team otherteam = obj as Team;
            if ((System.Object)otherteam == null)
            { return false; }
            
            if (!(name.Equals(otherteam.name)))
            { return false; }

            if (!(intBins.Equals(otherteam.intBins))) 
            { return false; }
            
            if (!(teamPlayers.SequenceEqual(otherteam.teamPlayers)))
            { return false; }

            return true;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            hash ^= name.GetHashCode() ^ intBins.GetHashCode();
            foreach(var player in teamPlayers)
            {
                hash ^= player.GetHashCode();
            }
            return hash;
        }
    }

   

}