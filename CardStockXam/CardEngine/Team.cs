using System.Collections.Generic;

namespace CardEngine{
	public class Team{
		public List<Player> teamPlayers = new List<Player>();
		public RawStorage teamStorage = new RawStorage();

		public Team(){
		}

        public void CopyStructure(Team other)
        {
            other.teamStorage = teamStorage.Clone();
        }
        public void IncrValue(int bin, int value)
        {
            teamStorage.storage[bin] += value;
        }
    }
}