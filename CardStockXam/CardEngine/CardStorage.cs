using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
namespace CardEngine{
	
	public class CardStorage{
		public CardCollection this[string key]
		{
		    get
		    {
                Console.WriteLine("key: " + key);
				if (!binDict.ContainsKey (key)) {
					AddKey (key);
					storage [binDict [key]] = new CardListCollection() { name = (owner == null ? "t" : owner.name) + key };
					storage [binDict [key]].container = this;
				} else if (storage [binDict [key]] == null) {
					storage [binDict [key]] = new CardListCollection() { name = (owner == null ? "t" : owner.name) + key };
					storage [binDict [key]].container = this;
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
		public int binCounter = 0;
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
		public CardStorage Clone(){
			var ret = new CardStorage ();
			foreach (var key in binDict){
				ret.AddKey (key.Key);
			}
			return ret;
		}
		public override String ToString(){
			StringBuilder ret = new StringBuilder ();
			for (int i = 0; i < binCounter; ++i) {
				ret.Append (binDict.Where (itm => itm.Value == i).First () +"\n");
				foreach (var card in storage[i].AllCards()){
					ret.Append("Card:" + card.ToString() + "\n");
				}
				ret.Append ("\n");
			}
			return ret.ToString ();
		}
	}
	public abstract class CardCollection{
		public abstract IEnumerable<Card> AllCards();
		public abstract void AddBottom(Card c);
		public abstract void Add(Card c);
        public abstract void Add(Card c, int idx);
        public abstract Card Get(int idx);
		public abstract Card Remove();
		public abstract Card Peek();
		public abstract void Clear();
		public abstract Card RemoveAt(int idx);
		public abstract void Remove(Card c);
		public abstract int Count {get;}
		public abstract void Shuffle();
		public CardStorage container {get; set;}
        public string name = "undefined";
        public abstract override string ToString();
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
        public override void Add(Card c, int idx)
        {
            cards.Insert(idx, c);
        }
        public override void AddBottom(Card c){
			cards.Insert(0,c);
		}
		public override void Clear(){
			cards.Clear();
		}
        public override Card Get(int idx){
            return cards[idx];
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
            CardGame.Instance.WriteToFile("O:" + ToString());
        }
        public override string ToString()
        {
            var ret = name + "#";
            Console.WriteLine("length: " + cards.Count);
            foreach (var card in cards)
            {
                ret += card.ToOutputString() + " ";
                Console.WriteLine("output: " + card.ToOutputString() + "\n");
            }
            return ret.Substring(0, ret.Length - 1);
        }
    }
}