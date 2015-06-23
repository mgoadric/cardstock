using System.Collections.Generic;

namespace CardEngine{
	public class TeamCycle{
		public List<Team> teamList;
		public bool turnEnded;
		public int idx = 0;
		public TeamCycle(List<Team> tList){
			teamList = tList;
		}
		public TeamCycle(TeamCycle clone){
			teamList = clone.teamList;
			idx = clone.idx;
			turnEnded = clone.turnEnded;
		}
		public void Next(){
			turnEnded = false;
			++idx;
			if (idx >= teamList.Count){
				idx = 0;
			}
		}
		public void Previous(){
			turnEnded = false;
			--idx;
			if (idx < 0){
				idx = teamList.Count - 1;
			}
		}
		public void SetTeam(int index){
			turnEnded = false;
			idx = index;
		}
		public void EndTurn(){
			turnEnded = true;
		}
		public Team Current(){
			return teamList[idx];
		}
	}
}