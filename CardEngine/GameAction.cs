using System.Collections.Generic;
using System;
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
			Console.WriteLine("Moved Card '" + cardToMove);
			startLocation.Remove(cardToMove);
			endLocation.Add(cardToMove);
			cardToMove.owner = endLocation;
		}
	}
	public class FancyCardMoveAction : GameAction{
		public FancyCardLocation startLocation;
		public FancyCardLocation endLocation;
		public FancyCardMoveAction(FancyCardLocation start, FancyCardLocation end){
			
			startLocation = start;
			endLocation = end;
		}
		public override void Execute(){
			Card cardToMove = null;
			try{
			if (startLocation.FilteredCount() != 0){
				cardToMove = startLocation.Remove();
				endLocation.Add(cardToMove);
				cardToMove.owner = endLocation.cardList;
				Console.WriteLine("Moved Card '" + cardToMove + " to " + endLocation.locIdentifier);
			}
			}
			catch{
				foreach (var card in startLocation.cardList.AllCards()){
					Console.WriteLine(card);
				}
				throw;
			}
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
	}
	public class FancyRemoveAction : GameAction{
		FancyCardLocation endLocation;
		public FancyRemoveAction(FancyCardLocation end){
			endLocation = end;
		}
		public override void Execute(){
			endLocation.Remove();
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
	}
	public class EndTurnAction : GameAction{
		
		PlayerCycle turnObject;
		
		public EndTurnAction(PlayerCycle currentTurn){
			turnObject = currentTurn;
		}
		public override void Execute(){
			turnObject.EndTurn();
		}
		
	}
	
}