using System;
using System.Collections.Generic;
using System.Linq;
using FreezeFrame;

namespace CardEngine
{
    public enum CCType {
        VISIBLE, INVISIBLE, HIDDEN, MEMORY, VIRTUAL
    }

    public class CardCollection
    {
        public string name;

        public CCType type;
        public CardStorage owner;

        public void Shuffle()
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
    

    
        public List<Card> cards = new List<Card>();

        public CardCollection(CCType type) {
            this.type = type;
        }

        public void SetName(String name)
        { this.name = name; }

        public CardCollection ShallowCopy()
        {

            return new CardCollection(type)
            {
                name = name,
                //TODO
                // find new cards, not clone
                //cards = CloneCards() 
                cards = cards
            };
        }
        public CardCollection Clone() {

            return new CardCollection(type)
            {
                name = name,
                cards = new List<Card>(),
                owner = owner
            };
        }

        public int Count
        {
            get
            {
                return cards.Count;
            }
        }
        public IEnumerable<Card> AllCards()
        {
            return cards;
        }
        public void Add(Card c)
        {
            cards.Add(c);
        }
        public void Add(Card c, int idx)
        {
            cards.Insert(idx, c);
        }
        public void AddBottom(Card c)
        {
            cards.Insert(0, c);
        }
        public void Clear()
        {
            cards.Clear();
        }
        public Card Get(int idx)
        {
            return cards[idx];
        }
        public Card Remove()
        {
            var ret = cards.Last();
            cards.RemoveAt(cards.Count - 1);
            return ret;
        }
        public Card Peek()
        {
            if (cards.Count > 0)
            {
                return cards.Last();
            }
            return null;
        }
        public Card RemoveAt(int idx)
        {
            var ret = cards[idx];
            cards.RemoveAt(idx);
            return ret;
        }
        public void Remove(Card c)
        {
            cards.Remove(c);
        }
        public override string ToString()
        {
            var ret = name + "#";
            foreach (Card card in cards)
            {
                ret += card.ToOutputString() + " ";
            }
            return ret.Substring(0, ret.Length - 1);
        }

        public override bool Equals(System.Object obj) 
        {
            //System.Console.WriteLine("COMPARING CARDCOLLECTIONS...");
            if (obj == null)
            { return false; }
         
            CardCollection othercardcollection = obj as CardCollection;
            if (othercardcollection == null)
            { return false; }
          
            if (owner.owner.GetType() != othercardcollection.owner.owner.GetType())
            { return false; }
           
            if (owner.owner.id != othercardcollection.owner.owner.id)
            { return false; }

            if (type != othercardcollection.type)
            { return false; }
            
            if (!cards.SequenceEqual(othercardcollection.cards))
            { return false; }

            return true;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < this.Count; i++)
            {
                hash ^= this.Get(i).GetHashCode();
            }
            return hash;
        }
    }
}
