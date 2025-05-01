using System.Text;

namespace CardStock.CardEngine
{
    /********
     * A Dictionary with default values provided, specific to
     * CardCollections because they act differently
     */
    public class CardStorage
    {
        private readonly Dictionary<string, CardCollection> dict = new Dictionary<string, CardCollection>();
        public Owner owner;

        /*******
         * Set up four CardCollection defaults
         */
        public CardStorage(Owner owner)
        {
            this.owner = owner;
        }

        /*******
         * Access methods, that have the KeyCheck
         */
        public CardCollection this[CCType type, string key]
        {
            get
            {
                KeyCheck(type, key);
                return dict[type + ":" + key];
            }
            set
            {
                KeyCheck(type, key);
                dict[type + ":" + key] = value;
            }
        }

        /********
         * Checks that the key is valid. If not, a clone of the
         * default value is added to the dictionary
         */
        private void KeyCheck(CCType type, string key)
        {
            string name = type + ":" + key;
            if (!dict.ContainsKey(name))
            {
                CardCollection ncc = new CardCollection(type)
                {
                    owner = this,
                    name = key
                };
                dict[name] = ncc;

            }
        }

        /*******
         * Returns the Values from the internal dictionary
         */
        public IEnumerable<CardCollection> Values() {
            return dict.Values;
        }

        public override bool Equals(System.Object obj)
        {
            //System.Console.WriteLine("INTO CARDSTORAGE EQUALITY");
            if (obj == null)
            { return false; }

            CardStorage cs = obj as CardStorage;
            if (cs == null)
            { return false; }

            if (cs.owner.GetType() != owner.GetType())
            { Console.WriteLine("Owner types not equal"); return false; }
            
            if (cs.owner.id != owner.id)
            { Console.WriteLine("Owner names not equal"); return false; }
            
            if (!cs.dict.SequenceEqual(dict))
            { //Console.WriteLine("Dictionary of Card Collections not equal");
                return false; }
        
            return true;
        }

    
            public bool InfoSetEqual(CardStorage s2, int playeridx)
            {
                foreach (string k in dict.Keys)
                {
                    CardCollection collection1 = dict[k];
                    if (collection1.type == CCType.VISIBLE || collection1.type == CCType.MEMORY
                        || (collection1.type == CCType.INVISIBLE && owner.GetType() == typeof(Player)
                        && owner.id == playeridx) || (owner.GetType() == typeof(Team)
                        && ((Team)owner).IsMember(playeridx)))
                    {
                        if (s2.dict.Keys.Contains(k))
                        {
                            if (!collection1.Equals(s2.dict[k]))
                            { return false; }
                        }
                        else
                        { return false; }
                    }
                    else
                    {
                        if (dict[k].Count != s2.dict[k].Count)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            public int GetInfoSetHashCode(int playeridx)
            {
                int ret = 0;

                foreach (string k in dict.Keys)
                {
                    CardCollection collection1 = dict[k];
                    if (collection1.type == CCType.VISIBLE || collection1.type == CCType.MEMORY
                        || (collection1.type == CCType.INVISIBLE && owner.GetType() == typeof(Player)
                        && owner.id == playeridx) || (owner.GetType() == typeof(Team)
                        && ((Team)owner).IsMember(playeridx)))
                    {
                        ret ^= dict[k].GetHashCode();
                    }
                    else
                    {
                        ret ^= dict[k].Count;
                    }
                }
                return ret;
            }
     

        public override int GetHashCode()
        {
            int hash = 0;
            foreach (var k in dict.Keys)
            {
                hash ^= dict[k].GetHashCode();
            }
            return hash;
        }
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            foreach (string s in dict.Keys)
            {
                ret.Append(dict[s].ToString());
            }
            return ret.ToString();
        }
    }
}
