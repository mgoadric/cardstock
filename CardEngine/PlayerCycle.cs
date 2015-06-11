using System.Collections.Generic;

namespace CardEngine{
	public class PlayerCycle{
		List<Player> playerList;
		public bool turnEnded;
		public int idx = 0;
		public PlayerCycle(List<Player> pList){
			playerList = pList;
		}
		public PlayerCycle(PlayerCycle clone){
			playerList = clone.playerList;
			idx = clone.idx;
			turnEnded = clone.turnEnded;
		}
		public void Next(){
			turnEnded = false;
			++idx;
			if (idx >= playerList.Count){
				idx = 0;
			}
		}
		public void Previous(){
			turnEnded = false;
			--idx;
			if (idx < 0){
				idx = playerList.Count - 1;
			}
		}
		public void SetPlayer(int index){
			turnEnded = false;
			idx = index;
		}
		public void EndTurn(){
			turnEnded = true;
		}
		public Player Current(){
			return playerList[idx];
		}
	}
}