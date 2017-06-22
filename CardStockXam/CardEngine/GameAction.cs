using System.Collections.Generic;
using System;
using System.Diagnostics;
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
        public bool actual;
        public FancyCardMoveAction(FancyCardLocation start, FancyCardLocation end) {
            if (start.name != null) {
                if (start.name.Contains("{mem}") && !start.actual) {
                    throw new NotSupportedException();
                }
            }
            else if (end.nonPhysical) {
                throw new NotSupportedException();
            }
            else if (end.name != null) {
                if (end.name.Contains("{mem}")) {
                    throw new NotSupportedException();
                }
            }
            startLocation = start;
            endLocation = end;
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
                        
                        actual = true;
                    }
                    var prefix = "M:";
                    if (!actual) { prefix = "N:"; }
                    if (cardToMove.owner != null) {
                        CardGame.Instance.WriteToFile(prefix + cardToMove.ToOutputString() + " " + cardToMove.owner.name + " " + endLocation.name);
                    }
                    else {
                        CardGame.Instance.WriteToFile(prefix + cardToMove.ToOutputString() + " " + startLocation.name + " " + endLocation.name);
                    }
                    endLocation.Add(cardToMove);
                    owner = cardToMove.owner;
                    cardToMove.owner = endLocation.cardList;
                    Debug.WriteLine("Moved Card '" + cardToMove + " to " + endLocation.locIdentifier);
                }
                else {
                    Debug.WriteLine("error: attempting to move from empty location " + startLocation.ToString()); //TODO debug here
                    Debug.WriteLine("moving to " + endLocation.ToString());
                    throw new Exception();
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
                if (actual) {
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

        public ShuffleAction(FancyCardLocation locations)
        {
            this.locations = locations;
            unshuffled = new CardListCollection();
        }

        public override void Execute() {
            foreach (Card c in locations.cardList.AllCards())
            {
                unshuffled.Add(c);
            }
            locations.cardList.Shuffle();
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
        public TeamCreateAction(RecycleParser.TeamcreateContext teamcreate) {
            this.teamcreate = teamcreate;
        }

        public override void Execute()
        {
            SetupIterator.ProcessTeamCreate(teamcreate);
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
        public InitializeAction(CardCollection loc, Tree d) {
            location = loc;
            before = new CardListCollection();
            deck = d;
        }
        public override void Execute() {
            foreach (Card c in location.AllCards())
            {
                before.Add(c);
            }
            CardGame.Instance.SetDeck(deck, location);
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
        public FancyCardCopyAction(FancyCardLocation start, FancyCardLocation end) {
            startLocation = start;
            endLocation = end;
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
            CardGame.Instance.WriteToFile("m:" + endLocation.ToOutputString());
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
        public FancyRemoveAction(FancyCardLocation end) {
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

        public IntAction(RawStorage storage, string bKey, int v) {
            bucket = storage;
            bucketKey = bKey;
            value = v;
        }
        public override void Execute() {
            oldValue = bucket[bucketKey];
            bucket[bucketKey] = value;
            complete = true;
            if (bucket.owner != null)
            {
                CardGame.Instance.WriteToFile("S:" + bucket.owner.name + " " + bucketKey + " " + value);
            }
            else if (bucket.teamOwner != null)
            {
                CardGame.Instance.WriteToFile("S:" + bucket.teamOwner.ToString() + " " + bucketKey + " " + value);
            }
            else
            {
                CardGame.Instance.WriteToFile("S:" + bucket + " " + bucketKey + " " + value);
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
        private PlayerCycle playerCycle;
        private int idx;
        private int former;

        public NextAction(PlayerCycle playerCycle, int idx) {
            this.playerCycle = playerCycle;
            this.idx = idx;
        }

        public override void Execute()
        {
            former = CardGame.Instance.players.IndexOf(playerCycle.PeekNext());
            playerCycle.SetNext(idx);
        }

        public override void Undo()
        {
            playerCycle.RevertNext(former);
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
        public SetPlayerAction(int idx) {
            this.idx = idx;
        }

        public override void Execute()
        {
            former = CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().Current());
            CardGame.Instance.CurrentPlayer().SetPlayer(idx);

        }

        public override void Undo()
        {
            CardGame.Instance.CurrentPlayer().SetPlayer(former);
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