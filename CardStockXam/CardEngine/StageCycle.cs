using System.Collections.Generic;

namespace CardEngine{
	public class StageCycle<T>{
		public List<T> playerList;
		public bool turnEnded;
		public int idx = 0;
		public int queuedNext = -1;
        public CardGame cg;

		public StageCycle(List<T> pList, CardGame cg){
            playerList = pList;
            var p = pList[0];
            this.cg = cg; // Unchecked in the equals and hash methods
			WritePlayer();
		}
        public StageCycle(StageCycle<T> source){
			playerList = source.playerList;
			idx = source.idx;
			turnEnded = source.turnEnded;
            cg = source.cg;
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
                cg.WriteToFile("t:" + who.name);
            }			
		}

        public override bool Equals(System.Object obj)
        {
            if (obj == null )
            { return false; }

            StageCycle<T> othercycle = obj as StageCycle<T>;
            if ((System.Object)othercycle == null)
            { return false; }

            // Compare the StageCycles
            if (!(playerList[0].GetType().Equals(othercycle.playerList[0].GetType())))
            { return false; }

            if (idx != othercycle.idx)
            { return false; }

            if (queuedNext != othercycle.queuedNext)
            { return false; }

            if (playerList.Count != othercycle.playerList.Count)
            { return false; }

            for (int i = 0; i < playerList.Count; i++)
            {
                if (!(playerList[i].Equals(othercycle.playerList[i]))) // Should work for teams/players
                    { return false; }
            }

            return true;
            }
        public override int GetHashCode()
        {
            int hash = 0;
            foreach (var player in playerList)
            {
                hash ^= player.GetHashCode();
            }
            return idx.GetHashCode() ^ hash ^ queuedNext.GetHashCode();
        }

    }
}