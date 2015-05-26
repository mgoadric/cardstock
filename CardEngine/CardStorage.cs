using System.Collections.Generic;

namespace CardEngine{
	public class CardStorage{
		
	}
	public abstract class CardCollection{
		public abstract List<Card> AllCards();
	}	
	public class CardListCollection : CardCollection{
		public List<Card> cards = new List<Card>();
		public override List<Card> AllCards(){
			return new List<Card>(cards);
		}
	}
	public class CardStackCollection : CardCollection {
		public Stack<Card> cards = new Stack<Card>();
		public override List<Card> AllCards(){
			return new List<Card>(cards);
		}
	}
	public class CardQueueCollection : CardCollection {
		public Queue<Card> cards = new Queue<Card>();
		
		public override List<Card> AllCards(){
			return new List<Card>(cards);
		}
	}
}