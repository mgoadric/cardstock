using System.Collections.Generic;
using System.Linq;

namespace CardEngine{
    public class Team
    {
        public List<Player> teamPlayers = new List<Player>();
        public IntStorage teamStorage = new IntStorage();
        public string id;

        public Team() { }
        public Team(int id, CardGame cg)
        {
            this.id = id.ToString();
            cg.AddToMap(this);
        }
        public Team Clone()
        {
            Team other = new Team();
            other.id = id;
            other.teamStorage = teamStorage.Clone();
            return other;
        }
        public void IncrValue(int bin, int value)
        {
            teamStorage.storage[bin] += value;
        }

        public override bool Equals(System.Object obj)
        { 
            if (obj == null)
            { return false; }

            Team otherteam = obj as Team;
            if ((System.Object)otherteam == null)
            { return false; }

            if (id != otherteam.id || !(teamStorage.Equals(otherteam))) // if ids or storage are not same, equals is false
            { return false; }

            if (!(teamPlayers.SequenceEqual(otherteam.teamPlayers)))
            { return false; }

            return true;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            hash ^= id.GetHashCode() ^ teamStorage.GetHashCode();
            foreach(var player in teamPlayers)
            {
                hash ^= player.GetHashCode();
            }
            return hash;
        }
    }

   

}