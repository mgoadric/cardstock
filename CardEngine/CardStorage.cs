using System.Collections.Generic;
using System.Linq;
namespace CardEngine{
	
	public class CardStorage{
		public CardCollection[] storage = new CardCollection[32];
		public CardStorage(){
			
		}
	}
	public abstract class CardCollection{
		public abstract List<Card> AllCards();
		public abstract void Add(Card c);
		public abstract Card Remove();
	}	
	public class CardListCollection : CardCollection{
		public List<Card> cards = new List<Card>();
		public override List<Card> AllCards(){
			return new List<Card>(cards);
		}
		public override void Add(Card c){
			cards.Add(c);
		}
		public override Card Remove(){
			var ret = cards.Last();
			cards.RemoveAt(cards.Count - 1);
			return ret;
		}
	}
	public class CardStackCollection : CardCollection {
		public Stack<Card> cards = new Stack<Card>();
		public override List<Card> AllCards(){
			return new List<Card>(cards);
		}
		public override void Add(Card c){
			cards.Push(c);
		}
		public override Card Remove(){
			return cards.Pop();
		}
	}
	public class CardQueueCollection : CardCollection {
		public Queue<Card> cards = new Queue<Card>();
		
		public override List<Card> AllCards(){
			return new List<Card>(cards);
		}
		public override void Add(Card c){
			cards.Enqueue(c);
		}
		public override Card Remove(){
			return cards.Dequeue();
		}
	}
}