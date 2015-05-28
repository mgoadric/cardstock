using System.Collections.Generic;
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
			startLocation.Remove(cardToMove);
			endLocation.Add(cardToMove);
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
	
}