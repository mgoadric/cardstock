using System.Collections.Generic;
namespace CardEngine{
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
	
	public class IntAction : GameAction{
		
		int[] bucket;
		int bucketIdx;
		int value;
		public IntAction(int[] b, int i, int v) {
			bucket = b;
			bucketIdx = i; 
			value = v;
		}
		public override void Execute(){
			bucket[bucketIdx] = value;
		}
	}
	
}