using System;
using System.Collections.Generic;
using System.Linq;

namespace CardEngine
{
    /********
     * A Dictionary with a default value provided. Useful for
     * storing ScoreMaps, integers, strings, and CardCollections
     */
    public class DefaultStorage<T> where T : ICloneable
    {
        private T defaultT;
        private readonly Dictionary<string, T> dict = new Dictionary<string, T>();

        /*******
         * Save the default value given in the constructor
         */
        public DefaultStorage(T defaultT)
        {
            this.defaultT = defaultT;
        }

        /*******
         * Access methods, that have the KeyCheck
         */
        public T this[string key]
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
                dict[key] = (T)defaultT.Clone();
            }
        }

        public DefaultStorage<T> Clone()
        {
            var ret = new DefaultStorage<T>(defaultT);
            foreach (var bin in dict.Keys)
            {
                ret[bin] = (T)dict[bin].Clone();
            }
            return ret;
        }

        public override bool Equals(System.Object obj)
        {

            if (obj == null)
            {
                return false;
            }
            if (obj is DefaultStorage<T> p)
            {
                return dict.SequenceEqual(p.dict);
            }
            return false;
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

    }
}
