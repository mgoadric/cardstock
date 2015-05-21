using System.Collections.Generic;
namespace CardEngine{
	public abstract class GameAction{
		
		public GameAction(){
			
		}
		public abstract void Execute();
	}
	public class CardMoveAction : GameAction{
		Card cardToMove;
		List<Card> startLocation;
		List<Card> endLocation;
		public CardMoveAction(Card c, List<Card> start, List<Card> end){
			cardToMove = c;
			startLocation = start;
			endLocation = end;
		}
		public override void Execute(){
			startLocation.Remove(cardToMove);
			endLocation.Add(cardToMove);
		}
	}
}