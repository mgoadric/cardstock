using System.Collections.Generic;

namespace CardEngine{
	public class PlayerCycle{
		public List<Player> playerList;
		public bool turnEnded;
		public int idx = 0;
		public int queuedNext = -1;
		public PlayerCycle(List<Player> pList){
            playerList = pList;
            var p = pList[0];
            CardGame.Instance.WriteToFile("t:" + playerList[idx].name);
        }
        public PlayerCycle(PlayerCycle source){
			playerList = source.playerList;
			idx = source.idx;
			turnEnded = source.turnEnded;
            

        }
		public Player PeekNext(){
			var saved = idx;
            if (queuedNext != -1)
            {
                idx = queuedNext;
            }
            else{
                idx++;
                //Next();
                if (idx >= playerList.Count) {
                    idx = 0;
                }
			}
			var ret = Current();
			idx = saved;
			return ret; 
		}
		public Player PeekPrevious(){
			var saved = idx;
			idx--;
			if (idx < 0){
				idx = playerList.Count - 1;
			}
			var ret = Current();
			idx = saved;
			return ret;
		}
		public void Next(){
            //System.Console.WriteLine("CYCLE current is " + idx);
            turnEnded = false;
			if (queuedNext != -1){
				idx = queuedNext;
                queuedNext = -1; //-AH
			}
			else{
				++idx;
			}
            if (idx >= playerList.Count){
                idx = 0;
			}
            // System.Console.WriteLine("CYCLE up next is " + idx);
            CardGame.Instance.WriteToFile("t:" + Current().name);
        }
		public void Previous(){
			turnEnded = false;
			--idx;
			if (idx < 0){
				idx = playerList.Count - 1;
			}
            CardGame.Instance.WriteToFile("t:" + playerList[idx].name);
        }
		public void SetPlayer(int index){
			turnEnded = false;
			idx = index;
            CardGame.Instance.WriteToFile("t:" + playerList[idx].name);
        }
		public void SetNext(int index){
			queuedNext = index;
            //System.Console.WriteLine("CYCLE Queing up " + queuedNext);
		}
        public void RevertNext(){
			queuedNext = -1;
			//System.Console.WriteLine("CYCLE Reverting to " + idx);
		}
		public void EndTurn(){
			turnEnded = true;
		}
		public Player Current(){
			return playerList[idx];
		}
	}
}