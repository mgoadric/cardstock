using System.Collections.Generic;

namespace CardEngine{
	public class StageCycle<T>{
		public List<T> playerList;
		public bool turnEnded;
		public int idx = 0;
		public int queuedNext = -1;

		public StageCycle(List<T> pList){
            playerList = pList;
            var p = pList[0];
			WritePlayer();
		}
        public StageCycle(StageCycle<T> source){
			playerList = source.playerList;
			idx = source.idx;
			turnEnded = source.turnEnded;
        }

		public T PeekNext(){
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
		public T PeekPrevious(){
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
			WritePlayer();
		}
		public void Previous(){
			turnEnded = false;
			--idx;
			if (idx < 0){
				idx = playerList.Count - 1;
			}
			WritePlayer();
        }
		public void SetPlayer(int index){
			turnEnded = false;
			idx = index;
            WritePlayer();
        }
		public void SetNext(int index){
			queuedNext = index;
		}
        public void RevertNext(){
			queuedNext = -1;
		}
		public void EndTurn(){
			turnEnded = true;
		}
		public T Current(){
			return playerList[idx];
		}
        private void WritePlayer() {
			var who = playerList[idx] as Player;
            if (who != null)
            {
                CardGame.Instance.WriteToFile("t:" + who.name);
            }			
		}
	}
}