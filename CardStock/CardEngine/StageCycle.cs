namespace CardStock.CardEngine{

    /********
     * A StageCycle lets you iterate repeatedly through the Players or
     * Teams as part of a Stage in the game. The language in these 
     * comments will assume a clockwise order to the players, so 
     * that the person to your left is next to play, and the person
     * to your right is the previous player.
     */
	public class StageCycle<T>{

        public readonly IReadOnlyList<T> memberList;

        // TODO should these be properties, so others can get but not set? Will this impact performance?
        // The current player
        public int idx = 0;

        // The index of a player queued up to go next instead of idx++
		public int queuedNext = -1;

        /********
         * Create a new StageCycle from a list of Teams or Players,
         * keep the cg for logging the transcript.
         */
        public StageCycle(IReadOnlyList<T> pList){
            memberList = pList;
   		}

        /********
         * A way to ShallowCopy the given source StageCycle when going into
         * a deeper stage
         */
        public StageCycle(StageCycle<T> source){
			memberList = source.memberList;
			idx = source.idx;
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
            if (queuedNext != -1) {
                return memberList[queuedNext];
            } else {
                int next = idx + 1;
                next %= memberList.Count;
                return memberList[next];
            }
        }

        /******
         * Who is to the right of the current player? NOT WHO WENT BEFORE
         */
		public T PeekPrevious(){
            int prev = idx - 1;
			if (prev < 0){
				prev = memberList.Count - 1;
			}
            return memberList[prev];
		}

        /*******
         * Iterate to the next player, and log it to the transcript
         */
		public void Next(){
            if (queuedNext != -1){
				idx = queuedNext;
                queuedNext = -1; //-AH
			}
			else{
				idx++;
                idx %= memberList.Count;
			}
   		}

        /******
         * Immediately change the current player within the current turn
         */
		public void SetMember(int index){
            idx = index;
        }

        /*******
         * Queues up the next player for when the the cycle iterates
         */
		public void SetNext(int index){
            queuedNext = index;
		}

        /******
         * A way to Undo the GameAction that queued up the next player
         */
        public void RevertNext(){
			queuedNext = -1;
		}

        public string CurrentName() {
            var who = memberList[idx] as Owner;
            if (who != null)
            {
                return who.name;
            }
            else {
                return null;
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

            return true;
        }

        public override int GetHashCode()
        {
            return idx.GetHashCode() ^ queuedNext.GetHashCode();
        }

    }
}
