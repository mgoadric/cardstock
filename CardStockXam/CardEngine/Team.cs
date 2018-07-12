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

     /*  public bool EqualsTo(Team otherteam) { // TODO
            if (otherteam.teamStorage.binCounter == teamStorage.binCounter) {
                for (int i = 0; i <= teamStorage.storage.Length;)
                    if (this.teamStorage.storage[i] == teamStorage.storage[] // Is there an easier way to cross reference without using 2 for loops?
                     }


    */

    }
}