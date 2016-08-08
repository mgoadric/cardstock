using System.Collections.Generic;
using System;
using System.Diagnostics;
using ParseTreeIterator;

namespace CardEngine{
	public class GameActionCollection: List<GameAction> {
		public GameActionCollection() : base(){
			
		}
		public void ExecuteAll(){
            foreach (var gameColl in this)
            {
                gameColl.Execute();
            }
        }
        public void UndoAll()
        {
            foreach (var gameColl in this)
            {
                gameColl.Undo();
            }
        }
        public string Serialize(){
            string ret = "[";
            foreach (var gameColl in this){
                ret += gameColl.Serialize();
                ret += ",";
            }
            ret.Remove(ret.Length - 1, 1);
            ret += "]";
            return ret;
        }
	}
	public abstract class GameAction {
		public bool complete;
		public abstract void Execute();
        public abstract void Undo();
		public abstract String Serialize();
	}
	public class FancyCardMoveAction : GameAction{
		public FancyCardLocation startLocation;
		public FancyCardLocation endLocation;
		public FancyCardMoveAction(FancyCardLocation start, FancyCardLocation end){
            if (start.name != null){
                if (start.name.Contains("{mem}") && !start.actual){
                    throw new NotSupportedException();
                }
            }
            else if (end.nonPhysical){
                throw new NotSupportedException();
            }
            else if (end.name != null){
                if (end.name.Contains("{mem}")){
                    throw new NotSupportedException();
                }
            }
            startLocation = start;
			endLocation = end;
		}
		public override void Execute(){
            Console.WriteLine("executing move");
            Console.WriteLine(startLocation.cardList.container.owner.ToString() + " " + endLocation.ToString());
			Card cardToMove = null;
            try{
                if (startLocation.Count() != 0){
                    cardToMove = startLocation.Remove();
                    if (!startLocation.actual){
                        endLocation.Add(cardToMove);
                        cardToMove.owner = endLocation.cardList;
                        CardGame.Instance.WriteToFile("M:" + cardToMove + " " + endLocation.locIdentifier);
                        Debug.WriteLine("Moved Card '" + cardToMove + " to " + endLocation.locIdentifier);
                    }
                }
            }
            catch
            {
                foreach (var card in startLocation.cardList.AllCards())
                {
                    Console.WriteLine(card);
                }
                throw;
            }
		}
		public override String Serialize(){
			return "";
		}

        public override void Undo()
        {
            throw new NotImplementedException();
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

        public override void Execute()
        {
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

		public override string Serialize()
        {
            return "";
        }
    }
    public class TurnAction : GameAction{
        public TurnAction() {}

        public override void Execute()
        {
            return;
        }
		public override void Undo()
		{

		}

		public override string Serialize()
        {
            return "";
        }
    }
    public class TeamCreateAction : GameAction{
        private RecycleParser.TeamcreateContext teamcreate;
        public TeamCreateAction(RecycleParser.TeamcreateContext teamcreate){
            this.teamcreate = teamcreate;
        }

        public override void Execute()
        {
            SetupIterator.ProcessTeamCreate(teamcreate);
        }

        public override string Serialize()
        {
            return "";
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
    public class InitializeAction : GameAction{
		CardCollection location;
		CardCollection before;
		Tree deck;
		public InitializeAction(CardCollection loc, Tree d){
			location = loc;
			before = new CardListCollection();
			deck = d;
            Console.WriteLine("init constructed");
		}
		public override void Execute(){
            Console.WriteLine("init executed");
			foreach (Card c in location.AllCards())
			{
				before.Add(c);
			}
			CardGame.Instance.SetDeck(deck,location);
		}
		public override void Undo()
		{
			location.Clear();
			foreach (Card c in before.AllCards())
			{
				location.Add(c);
			}
		}
		public override String Serialize(){
			return "";
		}
	}
	public class FancyCardCopyAction : GameAction{
		FancyCardLocation startLocation;
		FancyCardLocation endLocation;
        public FancyCardCopyAction(FancyCardLocation start, FancyCardLocation end) {
            startLocation = start;
            endLocation = end;
            if (endLocation.nonPhysical ||
                !endLocation.name.Contains("{mem}") ||
                endLocation.name.Contains("{MAX}") ||
                endLocation.name.Contains("{MIN}")){
                throw new InvalidOperationException(); }

        }
		public override void Execute(){
			endLocation.Add(startLocation.Get());
		}
		public override String Serialize(){
			return "";
		}

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
	public class FancyRemoveAction : GameAction{
		FancyCardLocation endLocation;
		public FancyRemoveAction(FancyCardLocation end){
            if (end.name.StartsWith("{mem}")){
                endLocation = end;
            }
            else{ throw new InvalidOperationException(); }
		}
		public override void Execute(){
			endLocation.Remove();
		}
		public override String Serialize(){
			return "";
		}

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    } 
	public class IntAction : GameAction{
		
		RawStorage bucket;
		string bucketKey;
		int value;
		int oldValue;

		public IntAction(RawStorage storage, string bKey, int v) {
			bucket = storage;
			bucketKey = bKey; 
			value = v;
		}
		public override void Execute(){
			oldValue = bucket[bucketKey];
			bucket[bucketKey] = value;
			complete = true;
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
		public override String Serialize(){
			return "";
		}
	}
}