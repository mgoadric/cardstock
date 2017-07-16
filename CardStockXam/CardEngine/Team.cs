using System.Collections.Generic;

namespace CardEngine{
	public class Team{
		public List<Player> teamPlayers = new List<Player>();
		public RawStorage teamStorage = new RawStorage();
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
    }
}