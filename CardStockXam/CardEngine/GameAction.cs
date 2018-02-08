using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Linq;
using ParseTreeIterator;

namespace CardEngine {
    public class GameActionCollection : List<GameAction> {
        public GameActionCollection() : base() {

        }
        public void ExecuteAll() {
            foreach (var gameColl in this)
            {
                gameColl.ExecuteActual();
            }
        }
        public void UndoAll()
        {
            foreach (var gameColl in this)
            {
                Debug.WriteLine("Undoing actions in gameActionCollection" + gameColl);
                gameColl.Undo();
            }
        }
		public override string ToString()
		{
            string toReturn = "";
			foreach (var g in this)
			{
                toReturn += g.ToString();
			}
            return toReturn;
		}

	}
    public abstract class GameAction {
        public bool actual = true;
        public bool complete;
        public CardGame cg;
        public void ExecuteActual(){
            actual = true;
            Execute();
        }
        public void TempExecute()
        {
            actual = false;
            Execute();
        }
        public abstract void Execute();
        public abstract void Undo();
        public String Serialize() {
            return "";
        }
       

    }
    public class FancyCardMoveAction : GameAction {
        public FancyCardLocation startLocation;
        public FancyCardLocation endLocation;
        public CardCollection owner;
        public bool actualloc;

        public FancyCardMoveAction(FancyCardLocation start, FancyCardLocation end, CardGame cg) {
            
            if (start.name != null) {
                //Console.WriteLine(start.name);
                if (start.name.Contains("{mem}") && !start.actual) {
                    Debug.WriteLine(start.name + ", " + end.name);
                    throw new NotSupportedException();
                }
            }
            else if (end.nonPhysical) {
				Debug.WriteLine("end is not physical");

				throw new NotSupportedException();
            }
            else if (end.name != null) {
                if (end.name.Contains("{mem}")) {
					Debug.WriteLine("end name is mem loc");

					throw new NotSupportedException();
                }
            }
            this.cg = cg;
            startLocation = start;
            endLocation = end;
            //Console.WriteLine(startLocation.name);
            //Console.WriteLine(endLocation.name);
            // writes graph file in the bin/Debug/graphs folder  
            var moveString = startLocation.name.Split('{')[0] + "_" + startLocation.name.Substring(startLocation.name.IndexOf("}") + 1).Split(' ')[0]
                                          + " -> " + endLocation.name.Split('{')[0] + "_" + endLocation.name.Substring(endLocation.name.IndexOf("}") + 1).Split(' ')[0];
            //Debug.WriteLine(moveString);
            // dumb case to handle pairs & continuous pairs error 
            if (moveString.Contains("POINTS")) {
                moveString = "POINTS ->" + moveString.Split('>')[1];
            }
            cg.builder.AppendLine(moveString);
            
           
		}



        public override void Execute() {
            try {
                if (startLocation.Count() != 0) {
                    //DEBUG
                    /*if (startLocation.ToString().Contains("STOCK")){
                        Console.WriteLine("Stock size to " + startLocation.Count());
                    }
                    if (endLocation.ToString().Contains("STOCK")){
                        Console.WriteLine("Stock size from " + startLocation.Count());
                    }*/
                    //

                    Card cardToMove = startLocation.Remove();
                    if (startLocation.actual) {
                        
                        actualloc = true;
                    }
                    var prefix = "M:";
                    if (!actual) { prefix = "N:"; }
                    if (cardToMove.owner != null) {
                        cg.WriteToFile(prefix + cardToMove.ToOutputString() + " " + cardToMove.owner.name + " " + endLocation.name);
                    }
                    else {
                        cg.WriteToFile(prefix + cardToMove.ToOutputString() + " " + startLocation.name + " " + endLocation.name);
                    }
                    endLocation.Add(cardToMove);
                    owner = cardToMove.owner;
                    cardToMove.owner = endLocation.cardList;
                    Debug.WriteLine("Moved Card '" + cardToMove + " to " + endLocation.locIdentifier);
                }
                else {
                    Debug.WriteLine("error: attempting to move from empty location " + startLocation.ToString()); //TODO debug here
                    Debug.WriteLine("moving to " + endLocation.ToString());
                    //throw new Exception();
                }
            }
            catch
            {
                Debug.WriteLine(startLocation.name);
                foreach (var card in startLocation.cardList.AllCards())
                {
                    Debug.WriteLine(card);
                }
                throw;
            }
            complete = true;
        }

        public override void Undo()
        {
            if (complete) {
                Debug.WriteLine("Undoing FancyCardMoveAction. Putting back in: " + startLocation.name); 
                var cardToMove = endLocation.Remove();
                startLocation.Add(cardToMove);
                if (actualloc) {
                    owner.Add(cardToMove);
                }
                cardToMove.owner = owner;
            }
            else {
                Debug.WriteLine("move has not been executed yet");
                throw new NotSupportedException();
            }
        }
        public override string ToString()
        {
            return "FancyCardMoveAction: StartLocation: "
                                                         + startLocation.name + "; EndLocation: " + endLocation.name;
            
        }
    }
    public class ShuffleAction : GameAction
    {
        private FancyCardLocation locations;
        private CardCollection unshuffled;

        public ShuffleAction(FancyCardLocation locations, CardGame cg)
        {
            this.locations = locations;
            unshuffled = new CardListCollection();
            this.cg = cg;
        }

        public override void Execute() {
            foreach (Card c in locations.cardList.AllCards())
            {
                unshuffled.Add(c);
            }
            locations.cardList.Shuffle();
			cg.WriteToFile("O:" + locations.cardList);

		}
        public override void Undo()
        {
            locations.cardList.Clear();
            foreach (Card c in unshuffled.AllCards())
            {
                locations.Add(c);
            }
        }
		public override string ToString()
		{
            return "ShuffleAction. Location: " + locations.name;
		}
    }


    public class TurnAction : GameAction {
        public TurnAction() { }

        public override void Execute(){
        }
        public override void Undo() {

        }
		public override string ToString()
		{
            return "TurnAction";
		}
    }

    public class TeamCreateAction : GameAction {
        private RecycleParser.TeamcreateContext teamcreate;
        public TeamCreateAction(RecycleParser.TeamcreateContext teamcreate, CardGame cg) {
            this.teamcreate = teamcreate;
            this.cg = cg;
        }

        public override void Execute()
        {
			var numTeams = teamcreate.teams().Count();
			for (int i = 0; i < numTeams; ++i)
			{
				var newTeam = new Team(i, cg);
				var teamStr = "T:";
				foreach (var p in teamcreate.teams(i).INTNUM())
				{
					var j = Int32.Parse(p.GetText());
					newTeam.teamPlayers.Add(cg.players[j]);
					cg.players[j].team = newTeam;
					teamStr += j + " ";
				}
				cg.teams.Add(newTeam);
				cg.WriteToFile(teamStr);
			}

			cg.currentTeam.Push(new StageCycle<Team>(cg.teams, cg));
			Debug.WriteLine("NUMTEAMS:" + cg.teams.Count);
		}

        public override void Undo()
        {
            throw new NotImplementedException();
        }
		public override string ToString()
		{
            return "TeamCreateAction: " + teamcreate.GetText();
		}
    }
    public class InitializeAction : GameAction {
        CardCollection location;
        CardCollection before;
        Tree deck;
        public InitializeAction(CardCollection loc, Tree d, CardGame cg) {
            location = loc;
            before = new CardListCollection();
            deck = d;
            this.cg = cg;
        }
        public override void Execute() {
            foreach (Card c in location.AllCards())
            {
                before.Add(c);
            }
            cg.SetDeck(deck, location);
        }
        public override void Undo()
        {
            location.Clear();
            foreach (Card c in before.AllCards())
            {
                location.Add(c);
            }
        }
		public override string ToString()
		{
            return "InitializeAction: " + "Location: " + location.name + "; Cards: " + location.AllCards();
		}
    }
    public class FancyCardCopyAction : GameAction {
        FancyCardLocation startLocation;
        FancyCardLocation endLocation;
        public FancyCardCopyAction(FancyCardLocation start, FancyCardLocation end, CardGame cg) {
            startLocation = start;
            endLocation = end;
            this.cg = cg;
            if (endLocation.nonPhysical ||
                !endLocation.name.Contains("{mem}") ||
                endLocation.name.Contains("{MAX}")  ||
                endLocation.name.Contains("{MIN}") ||
                endLocation.name.Contains("{filter}") ||
                endLocation.name.Contains("{UNION}")) {
                throw new InvalidOperationException(); }

        }
        public override void Execute() {
            endLocation.Add(startLocation.Get());
            cg.WriteToFile("m:" + endLocation.ToOutputString());
        }

        public override void Undo()
        {
            endLocation.Remove();
 		}
		public override string ToString()
		{
            return "FancyCardCopyAction: Starting location: " + startLocation.name 
                                                                             + "; Ending location: " + endLocation.name;
                                                                           
		}
    }
    public class FancyRemoveAction : GameAction {
        FancyCardLocation endLocation;
        public FancyRemoveAction(FancyCardLocation end, CardGame cg) {
            this.cg = cg;
            if (end.name.Contains("{mem}")) {
                endLocation = end;
            }
            else {
                Debug.WriteLine(end.name);
                throw new InvalidOperationException();
            }
        }
        public override void Execute() {
            endLocation.Remove();
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
		public override string ToString()
		{
            return "FancyRemoveAction: To be removed: " + endLocation.name;
		}
    }
    public class IntAction : GameAction {

        RawStorage bucket;
        string bucketKey;
        int value;
        int oldValue;

        public IntAction(RawStorage storage, string bKey, int v, CardGame cg) {
            bucket = storage;
            bucketKey = bKey;
            value = v;
            this.cg = cg;
        }
        public override void Execute() {
            oldValue = bucket[bucketKey];
            bucket[bucketKey] = value;
            complete = true;
            if (bucket.owner != null)
            {
                cg.WriteToFile("S:" + bucket.owner.name + " " + bucketKey + " " + value);
            }
            else if (bucket.teamOwner != null)
            {
                cg.WriteToFile("S:" + bucket.teamOwner + " " + bucketKey + " " + value);
            }
            else
            {
                cg.WriteToFile("S:" + bucket + " " + bucketKey + " " + value);
            }
        }
        public override void Undo() {
            if (complete)
            {
                bucket[bucketKey] = oldValue;
                complete = false;
            }
            else {
                throw new UnauthorizedAccessException();
            }
        }
		public override string ToString()
		{
            return "IntAction: value: " + value.ToString();
		}
    }
    public class NextAction : GameAction
    {
        private StageCycle<Player> playerCycle;
        private int idx;
        private int former = -1;

        public NextAction(StageCycle<Player> playerCycle, int idx, CardGame cg) {
            this.playerCycle = playerCycle;
            this.idx = idx;
            this.cg = cg;
        }

        public override void Execute()
        {
            // someone already in the queue
            if (playerCycle.queuedNext != -1) {
                former = playerCycle.queuedNext;
			} 
            playerCycle.SetNext(idx);
        }

        public override void Undo()
        {
            if (former != -1)
            {
                playerCycle.SetNext(former);
            } else {
                playerCycle.RevertNext();
            }
            //Console.WriteLine("Reverting: " + former);
         
        }
		public override string ToString()
		{
            return "NextAction: Next player: " + idx.ToString();
		}
    }
    public class SetPlayerAction : GameAction
    {
        private int idx;
        private int former;
        public SetPlayerAction(int idx, CardGame cg) {
            this.idx = idx;
            this.cg = cg;
        }

        public override void Execute()
        {
            former = cg.players.IndexOf(cg.CurrentPlayer().Current());
            cg.CurrentPlayer().SetPlayer(idx);
        }

        public override void Undo()
        {
            cg.CurrentPlayer().SetPlayer(former);
        }

		public override string ToString()
		{
            return "SetPlayerAction: Set player: " + idx.ToString();
		}
    }

    public class LoopAction : GameAction{
        public string var;
        public object item;
        public int level;

        public LoopAction(string v, object item, int level){
            this.var = v;
            this.item = item;
            this.level = level;
        }

        public override void Execute()
        {
            throw new Exception();
        }

        public override void Undo()
        {
            throw new Exception();
        }
		public override string ToString()
		{
            return "LoopAction: " + var;
		}
    }
}