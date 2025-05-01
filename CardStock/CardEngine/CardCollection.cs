using System.Text;

namespace CardStock.CardEngine
{
    public enum CCType {
        VISIBLE, INVISIBLE, HIDDEN, MEMORY, VIRTUAL
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
            return null;
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

        public void SetName(String name)
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
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
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
                cards = new List<Card>(),
                owner = owner
            };
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

        public override bool Equals(System.Object obj) 
        {
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

        public bool Contains(Card c)
        {
            return cards.Contains(c);
        }
    }
}

