using System.Collections.Generic;
using System.Linq;

namespace CardEngine{
	public class StageCycle<T>{
		public List<T> memberList;
		public bool turnEnded;
		public int idx = 0;
		public int queuedNext = -1;
        public CardGame cg;

		public StageCycle(List<T> pList, CardGame cg){
            memberList = pList;
            var p = pList[0];
            this.cg = cg; 
			WriteMember();
		}
        public StageCycle(StageCycle<T> source){
			memberList = source.memberList;
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
                if (idx >= memberList.Count) {
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
				idx = memberList.Count - 1;
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
            if (idx >= memberList.Count){
                idx = 0;
			}
			WriteMember();
		}
		public void Previous(){
			turnEnded = false;
			--idx;
			if (idx < 0){
				idx = memberList.Count - 1;
			}
			WriteMember();
        }
		public void SetMember(int index){
			turnEnded = false;
			idx = index;
            WriteMember();
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
			return memberList[idx];
		}
        private void WriteMember() {
			var who = memberList[idx] as Player; // TODO MAKE THIS GENERIC
            if (who != null)
            {
                cg.WriteToFile("t:" + who.name);
            }			
		}

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            { return false; }

            StageCycle<T> othercycle = obj as StageCycle<T>;
            if ((System.Object)othercycle == null)
            { return false; }

            // Compare the StageCycles
            if (idx != othercycle.idx)
            { return false; }

            if (queuedNext != othercycle.queuedNext)
            { return false; }

            if (!(memberList.SequenceEqual(othercycle.memberList)))
            { return false; }

            return true;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            foreach (var member in memberList)
            {
                hash ^= member.GetHashCode();
            }
            return idx.GetHashCode() ^ hash ^ queuedNext.GetHashCode();
        }

    }
}