using System.Collections.Generic;

namespace CardEngine{
	public class Team{
		public List<Player> teamPlayers = new List<Player>();
		public IntStorage teamStorage = new IntStorage();
        public string id;

        public Team() { }
		public Team(int id, CardGame cg){
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

     public override bool Equals(System.Object obj)  { // TODO
            if (obj == null)
            { return false; }

            Team otherteam = obj as Team;
            if ((System.Object)otherteam == null)
            { return false; }
                
            if (id != otherteam.id || !teamStorage.Equals(otherteam)) // if ids or storage are not same, equals is false
            { return false; }

            for (int i = 0; i < teamPlayers.Count; i++)
            {
                if (!teamPlayers[i].Equals(otherteam.teamPlayers[i]))
                    { return false; }
            }
            return true;
        }
}