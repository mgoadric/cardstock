using System.Collections.Generic;
using System;
using System.Diagnostics;
using ParseTreeIterator;

namespace CardEngine{
	public class GameActionCollection: List<GameAction>{
		public GameActionCollection() : base(){
			
		}
		public void ExecuteAll(){
			foreach (var gameAction in this){
				gameAction.Execute();
			}
		}
	}
	public abstract class GameAction{
		
		public GameAction(){
			
		}
		public abstract void Execute();
		public abstract String Serialize();
	}
	public class LocationCreateAction : GameAction{
		CardCollection newColl;
		CardStorage location;
		string key;
		public LocationCreateAction(CardStorage loc, CardCollection coll, string k){
			newColl = coll;
			location = loc;
			key = k;
		}
		public override void Execute(){
			location.AddKey(key);
			location[key] = newColl;
		}
		public override String Serialize(){
			return "";
		}
	}
	public class StorageCreateAction : GameAction{
		RawStorage storage;
		string key;
		public StorageCreateAction(RawStorage sto, string k){
			storage = sto;
			key = k;
		}
		public override void Execute(){
			storage.AddKey(key);
		}
		public override String Serialize(){
			return "";
		}
	}
	public class CardMoveAction : GameAction{
		Card cardToMove;
		CardCollection startLocation;
		CardCollection endLocation;
		public CardMoveAction(Card c,CardCollection start, CardCollection end){
			cardToMove = c;
			startLocation = start;
			endLocation = end;
		}
		public override void Execute(){
			Debug.WriteLine("Moved Card '" + cardToMove);
			startLocation.Remove(cardToMove);
			endLocation.Add(cardToMove);
			cardToMove.owner = endLocation;
		}
		public override String Serialize(){
			return cardToMove.Serialize();
		}
	}
	public class FancyCardMoveAction : GameAction{
		public FancyCardLocation startLocation;
		public FancyCardLocation endLocation;
		public FancyCardMoveAction(FancyCardLocation start, FancyCardLocation end){
            //TODO disallow mems
            if (start.inMemory) { throw new NotSupportedException(); }
            if (end.nonPhysical) { throw new NotSupportedException(); }
            startLocation = start;
			endLocation = end;
		}
		public override void Execute(){
			Card cardToMove = null;
			try{
			if (startLocation.Count() != 0){
				cardToMove = startLocation.Remove();
                if (!startLocation.inMemory)
				endLocation.Add(cardToMove);
				cardToMove.owner = endLocation.cardList;
				Debug.WriteLine("Moved Card '" + cardToMove + " to " + endLocation.locIdentifier);
			}
			}
			catch{
				foreach (var card in startLocation.cardList.AllCards()){
					Console.WriteLine(card);
				}
				throw;
			}
		}
		public override String Serialize(){
			return "";
		}
	}
    public class ShuffleAction : GameAction
    {
        private FancyCardLocation locations;

        public ShuffleAction(FancyCardLocation locations)
        {
            this.locations = locations;
        }

        public override void Execute()
        {
            locations.cardList.Shuffle();
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
    }
    public class InitializeAction : GameAction{
		CardCollection location;
		Tree deck;
		public InitializeAction(CardCollection loc, Tree d){
			location = loc;
			deck = d;
		}
		public override void Execute(){
			CardGame.Instance.SetDeck(deck,location);
		}
		public override String Serialize(){
			return "";
		}
	}
	public class CardPopMoveAction : GameAction{
		Card cardToMove;
		CardCollection startLocation;
		CardCollection endLocation;
		public CardPopMoveAction(Card c,CardCollection start, CardCollection end){
			cardToMove = c;
			startLocation = start;
			endLocation = end;
		}
		public override void Execute(){
			startLocation.Remove();
			endLocation.Add(cardToMove);
			cardToMove.owner = endLocation;
		}
		public override String Serialize(){
			return "";
		}
	}
	public class CardCopyAction : GameAction{
		Card cardToMove;
		
		CardCollection endLocation;
		public CardCopyAction(Card c, CardCollection end){
			cardToMove = c;
			
			endLocation = end;
		}
		public override void Execute(){
			endLocation.Add(cardToMove);
		}
		public override String Serialize(){
			return "";
		}
	}
	public class FancyCardCopyAction : GameAction{
		FancyCardLocation startLocation;
		FancyCardLocation endLocation;
		public FancyCardCopyAction(FancyCardLocation start, FancyCardLocation end){
			startLocation = start;
			endLocation = end;
		}
		public override void Execute(){
			endLocation.Add(startLocation.Get());
		}
		public override String Serialize(){
			return "";
		}

	}
	public class FancyRemoveAction : GameAction{
		FancyCardLocation endLocation;
		public FancyRemoveAction(FancyCardLocation end){
			endLocation = end;
		}
		public override void Execute(){
			endLocation.Remove();
		}
		public override String Serialize(){
			return "";
		}
	} 
	public class IntAction : GameAction{
		
		RawStorage bucket;
		string bucketKey;
		int value;
		public IntAction(RawStorage storage, string bKey, int v) {
			bucket = storage;
			bucketKey = bKey; 
			value = v;
		}
		public override void Execute(){
			bucket[bucketKey] = value;
		}
		public override String Serialize(){
			return "";
		}
	}
	public class EndTurnAction : GameAction{
		
		PlayerCycle turnObject;
		
		public EndTurnAction(PlayerCycle currentTurn){
			turnObject = currentTurn;
		}
		public override void Execute(){
			turnObject.EndTurn();
		}
		public override String Serialize(){
			return "";
		}
		
	}
	
}