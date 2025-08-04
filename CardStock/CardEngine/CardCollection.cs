using System.Text;

namespace CardStock.CardEngine
{
    public enum CCType {
        VISIBLE, INVISIBLE, HIDDEN, OTHERS, VIRTUAL, MEMORY
    }

    public class CardCollection
    {
        public string name;
        public CCType type;
        public CardStorage owner;
        private List<Card> cards = [];

        public CardCollection(CCType type) {
            this.type = type;
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

        public Card Peek()
        {
            if (cards.Count > 0)
            {
                return cards.Last();
            }
            throw new InvalidOperationException();
            //return null;
        }

        public Card Remove()
        {
            var ret = cards.Last();
            cards.RemoveAt(cards.Count - 1);
            return ret;
        }

        public void Remove(Card c)
        {
            cards.Remove(c);
        }

        public Card RemoveAt(int idx)
        {
            var ret = cards[idx];
            cards.RemoveAt(idx);
            return ret;
        }

        public void SetName(string name)
        { this.name = name; }

        public CardCollection ShallowCopy()
        {

            return new CardCollection(type)
            {
                name = name,
                owner = owner,
                cards = cards
            };
        }

        public void Shuffle()
        {
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.Next(n + 1);
                (cards[n], cards[k]) = (cards[k], cards[n]);
            }
        }
 
        public string TranscriptName()
        {
            return owner.owner.name + ":" + type + ":" + name;
        }

        public CardCollection Clone()
        {

            return new CardCollection(type)
            {
                name = name,
                cards = [],
                owner = owner
            };
        }

        public CardCollection DeepCopy()
        {
            var cc = new CardCollection(type)
            {
                name = name,
                cards = [],
                owner = owner
            };
            foreach (Card c in cards)
            {
                cc.Add(c);
            }
            return cc;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append("CardCollection " + name + " (CC TYPE: " + type.ToString() + ")\r\n");
            if (cards.Count == 0) { ret.Append("|CardCollection is empty|\r\n"); }
            foreach (Card card in cards)
            {
                ret.Append(card.ToString() + "\r\n");
            }
            return ret.ToString();
        }

        public override bool Equals(object? obj) 
        {
            if (obj is null)
            { return false; }
         
            if (obj is not CardCollection othercardcollection)
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

        public bool Contains(Card c)
        {
            return cards.Contains(c);
        }
    }
}

