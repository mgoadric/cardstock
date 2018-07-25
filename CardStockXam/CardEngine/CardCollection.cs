using System;
using System.Collections.Generic;
using System.Linq;
using FreezeFrame;

namespace CardEngine
{
    public enum CCType {
        VISIBLE, INVISIBLE, HIDDEN, MEMORY, VIRTUAL
    }

    public abstract class CardCollection
    {
        public string name = "undefined";
        //public CardStorage container { get; set; }

        // HOPE WE CAN GET RID OF THIS....
        public CardLocReference loc;

        public CCType type;
        public DefaultStorage<CardCollection> owner;
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
        public abstract int Count { get; }
        public abstract void Shuffle();
        public abstract override string ToString();
        public abstract CardCollection ShallowCopy();

        public void Shuffle(List<Card> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    public class CardListCollection : CardCollection, ICloneable
    {
        public List<Card> cards = new List<Card>();

        public CardListCollection(CCType type, DefaultStorage<CardCollection> owner) {
            this.type = type;
            this.owner = owner;
        }

        public override CardCollection ShallowCopy()
        {
            return new CardListCollection(type, owner)
            {
                name = (string)name.Clone(),
                loc = loc,
                //TODO
                // find new cards, not clone
                //cards = CloneCards() 
                owner = owner,
                cards = cards
            };
        }
        public object Clone() {
            return new CardListCollection(type, owner)
            {
                name = (string)name.Clone(),
                loc = loc,
                cards = new List<Card>(),
                owner = owner
            };
        }

        public override int Count
        {
            get
            {
                return cards.Count;
            }
        }
        public override IEnumerable<Card> AllCards()
        {
            return cards;
        }
        public override void Add(Card c)
        {
            cards.Add(c);
        }
        public override void Add(Card c, int idx)
        {
            cards.Insert(idx, c);
        }
        public override void AddBottom(Card c)
        {
            cards.Insert(0, c);
        }
        public override void Clear()
        {
            cards.Clear();
        }
        public override Card Get(int idx)
        {
            return cards[idx];
        }
        public override Card Remove()
        {
            var ret = cards.Last();
            cards.RemoveAt(cards.Count - 1);
            return ret;
        }
        public override Card Peek()
        {
            if (cards.Count > 0)
            {
                return cards.Last();
            }
            return null;
        }
        public override Card RemoveAt(int idx)
        {
            var ret = cards[idx];
            cards.RemoveAt(idx);
            return ret;
        }
        public override void Remove(Card c)
        {
            cards.Remove(c);
        }
        public override void Shuffle()
        {
            Shuffle(cards);
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

        public override bool Equals(System.Object obj) // For CardListCollection
        {
            if (obj == null)
            { return false; }

            CardListCollection othercardcollection = obj as CardListCollection;
            if ((System.Object)othercardcollection == null)
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
