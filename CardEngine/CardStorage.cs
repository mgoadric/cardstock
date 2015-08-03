using System.Collections.Generic;
using System.Linq;
using System;
namespace CardEngine{
	
	public class CardStorage{
		public CardCollection this[string key]
		{
		    get
		    {
				if (!binDict.ContainsKey(key)) {
					AddKey(key);
					storage[binDict[key]] = new CardListCollection();
					storage[binDict[key]].container = this;
				}
		        return storage[binDict[key]];
		    }
		    set
		    {
				if (!binDict.ContainsKey(key)) {
					AddKey(key);
				}
	       		storage[binDict[key]] = value;
				value.container = this;
	    	}
		}
		public Player owner {get; set;}
		int binCounter = 0;
		Dictionary<string,int> binDict = new Dictionary<string,int>();
		public CardCollection[] storage = new CardCollection[32];
		public CardStorage(){
			
		}
		public IEnumerable<string> Keys(){
			return binDict.Keys;
		}
		public void AddKey(string key){
			binDict.Add(key,binCounter);
			binCounter++;
		}
		
	}
	public abstract class CardCollection{
		public abstract IEnumerable<Card> AllCards();
		public abstract void AddBottom(Card c);
		public abstract void Add(Card c);
		public abstract Card Remove();
		public abstract Card Peek();
		public abstract void Clear();
		public abstract Card RemoveAt(int idx);
		public abstract void Remove(Card c);
		public abstract int Count {get;}
		public abstract void Shuffle();
		public CardStorage container {get; set;}
		public void Shuffle(List<Card> list)  
		{  
		    Random rng = new Random();  
		    int n = list.Count;  
		    while (n > 1) {  
		        n--;  
		        int k = rng.Next(n + 1);  
		        Card value = list[k];  
		        list[k] = list[n];  
		        list[n] = value;  
		    }  
		}
	}	
	
	public class CardListCollection : CardCollection{
		public override int Count {get{
			return cards.Count;
		}}
		public List<Card> cards = new List<Card>();
		public override IEnumerable<Card> AllCards(){
			return cards;
		}
		public override void Add(Card c){
			cards.Add(c);
		}
		public override void AddBottom(Card c){
			cards.Insert(0,c);
		}
		public override void Clear(){
			cards.Clear();
		}
		public override Card Remove(){
			var ret = cards.Last();
			cards.RemoveAt(cards.Count - 1);
			return ret;
		}
		public override Card Peek(){
			return cards.Last();
			
		}
		public override Card RemoveAt(int idx){
			var ret = cards[idx];
			cards.RemoveAt(idx);
			return ret;
		}
		public override void Remove(Card c){
			cards.Remove(c);
		}
		public override void Shuffle(){
			Shuffle(cards);
		}
	}
	public class CardStackCollection : CardCollection {
		public override int Count {get{
			return cards.Count;
		}}
		public Stack<Card> cards = new Stack<Card>();
		public override IEnumerable<Card> AllCards(){
			return cards;
		}
		public override void Add(Card c){
			cards.Push(c);
		}
		public override void AddBottom(Card c){
			cards.Reverse();
			cards.Push(c);
			cards.Reverse();
		}
		public override Card Remove(){
			return cards.Pop();
		}
		public override void Clear(){
			cards.Clear();
		}
		public override Card Peek(){
			return cards.Peek();
			
		}
		public override Card RemoveAt(int idx){
			throw new NotImplementedException();
		}
		public override void Remove(Card c){
			throw new NotImplementedException();
		}
		public override void Shuffle(){
			var all = new List<Card>(cards);
			Shuffle(all);
			cards.Clear();
			foreach (var card in all){
				cards.Push(card);
			}
		}
	}
	public class CardQueueCollection : CardCollection {
		public override int Count {get{
			return cards.Count;
		}}
		public Queue<Card> cards = new Queue<Card>();
		
		public override IEnumerable<Card> AllCards(){
			return cards;
		}
		public override void Clear(){
			cards.Clear();
		}
		public override void Add(Card c){
			cards.Reverse();
			cards.Enqueue(c);
			cards.Reverse();
		}
		public override void AddBottom(Card c){
			cards.Enqueue(c);
		}
		public override Card Remove(){
			return cards.Dequeue();
		}
		public override Card Peek(){
			return cards.Peek();
			
		}
		public override Card RemoveAt(int idx){
			throw new NotImplementedException();
		}
		public override void Remove(Card c){
			throw new NotImplementedException();
		}
		public override void Shuffle(){
			var all = new List<Card>(cards);
			Shuffle(all);
			cards.Clear();
			foreach (var card in all){
				cards.Enqueue(card);
			}
		}
	}
}