using System.Collections.Generic;

namespace CardEngine{
	public class PlayerCycle{
		public List<Player> playerList;
		public bool turnEnded;
		public int idx = 0;
		int queuedNext = -1;
		public PlayerCycle(List<Player> pList){
			playerList = pList;
		}
		public PlayerCycle(PlayerCycle clone){
			playerList = clone.playerList;
			idx = clone.idx;
			turnEnded = clone.turnEnded;
		}
		public Player PeekNext(){
			var saved = idx;
			if (queuedNext != -1){
				idx = queuedNext;
			}
			var ret = Current();
			idx = saved;
			return ret;
		}
		public void Next(){
			turnEnded = false;
			if (queuedNext != -1){
				idx = queuedNext;
			}
			else{
				++idx;
			}
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
		public void SetNext(int index){
			queuedNext = index;
		}
		public void EndTurn(){
			turnEnded = true;
		}
		public Player Current(){
			return playerList[idx];
		}
	}
}