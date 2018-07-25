using System.Collections.Generic;
using System.Linq;

namespace CardEngine{

    /********
     * A StageCycle lets you iterate repeatedly through the Players or
     * Teams as part of a Stage in the game. The language in these 
     * comments will assume a clockwise order to the players, so 
     * that the person to your left is next to play, and the person
     * to your right is the previous player.
     */
	public class StageCycle<T>{

        // Who is in your cycle
		public readonly List<T> memberList;

        // The current player
		public int idx = 0;

        // The index of a player queued up to go next instead of idx++
		public int queuedNext = -1;

        // For Logging of the turn cycle in the transcript
        public CardGame cg;

		public StageCycle(List<T> pList, CardGame cg){
            memberList = pList;
            var p = pList[0];
            this.cg = cg; 
			WriteMember();
		}

        /********
         * A way to ShallowCopy the given source StageCycle
         */
        public StageCycle(StageCycle<T> source){
			memberList = source.memberList;
			idx = source.idx;
            cg = source.cg;
        }

        /*******
         * Return the current player based on the index into the Cycle
         */
        public T Current()
        {
            return memberList[idx];
        }

        /******
         * Who is currently scheduled to play next?
         */
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

        /******
         * Who is the right of the current player?
         */
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

		public void SetMember(int index){
			idx = index;
            WriteMember();
        }

		public void SetNext(int index){
			queuedNext = index;
		}

        public void RevertNext(){
			queuedNext = -1;
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