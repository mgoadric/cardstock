using System.Collections;
using System.Diagnostics;

namespace CardStock.CardEngine
{
    public class Card(Dictionary<string, string> atts, int id, string n)
    {

        private readonly Dictionary<string, string> cardAtts = atts;
        public CardCollection owner { get; set; }
        public readonly int id = id;
        public string name = n;

        public Card Clone()
        {
            return new Card(cardAtts, id, name); ;
        }

        public override string ToString()
        {
            //https://stackoverflow.com/questions/3871760/convert-dictionarystring-string-to-semicolon-separated-string-in-c-sharp
            return id + "!" + string.Join(";", cardAtts.Select(x => x.Key + "=" + x.Value)) + ":" + name;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Card c)
            {
                return Equals(c);
            }
            return false;
        }

        public bool Equals(Card c)
        {
            if ((c.id != this.id) || (c.name != this.name))
            { return false; }

            return true;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public string ReadAttribute(string attributeName)
        {

            try
            {
                return cardAtts[attributeName];
            }
            catch
            {
                Debug.WriteLine("KEYS");
                foreach (var key in cardAtts.Keys)
                {
                    Debug.WriteLine(key);
                }
                return "";
            }
        }
    }
    
    public class CardComparer : IComparer
    {
        public PointMap scoring;

        public int Compare(object? x, object? y)
        {

            if (x is Card cx)
            {
                if (y is Card cy)
                {
                    return scoring.GetScore(cx) - scoring.GetScore(cy);
                }
            }
            return -1;
        }
    }
}
