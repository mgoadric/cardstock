using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardEngine
{
    /********
     * A Dictionary with a default value provided, specific to
     * CardCollections because they act differently
     */
    public class CardStorage
    {
        private readonly Dictionary<string, CardCollection> dict = new Dictionary<string, CardCollection>();
        private CardCollection defaultCC;
        public Owner owner;

        /*******
         * Save the default value given in the constructor
         */
        public CardStorage(CardCollection defaultCC, Owner owner)
        {
            this.defaultCC = defaultCC;
            this.owner = owner;
            defaultCC.owner = this;
        }

        /*******
         * Access methods, that have the KeyCheck
         */
        public CardCollection this[string key]
        {
            get
            {
                KeyCheck(key);
                return dict[key];
            }
            set
            {
                KeyCheck(key);
                dict[key] = value;
            }
        }

        /********
         * Checks that the key is valid. If not, a clone of the
         * default value is added to the dictionary
         */
        private void KeyCheck(string key)
        {
            if (!dict.ContainsKey(key))
            {
                CardCollection ncc = GetDefault();
                ncc.name = key;
                dict[key] = ncc;

            }
        }

        /**********
         * Abstracts this in case we need to do something else
         * when getting the default value
         */
        private CardCollection GetDefault()
        { return defaultCC.Clone(); }

        /*******
         * Returns the keys from the internal dictionary
         */
        public IEnumerable<string> Keys()
        {
            return dict.Keys;
        }

        /*******
         * Make a hollow clone of keys
         */
        public CardStorage Clone(Owner other)
        {
            var cloneDefaultCC = GetDefault();
            var ret = new CardStorage(cloneDefaultCC, other);
            cloneDefaultCC.owner = ret;

            foreach (var bin in dict.Keys)
            {
                ret.KeyCheck(bin);
            }
            return ret;

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
            
            if (!cs.defaultCC.Equals(defaultCC))
            { Console.WriteLine("DefaultCC not equal"); return false; }
            
            if (!cs.dict.SequenceEqual(dict))
            { Console.WriteLine("Dictionary of Card Collections not equal"); return false; }
        
            return true;
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
