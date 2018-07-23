using System;
using System.Collections.Generic;
using System.Linq;

namespace CardEngine
{
    /********
     * A Dictionary with a default value provided. Useful for
     * storing PointMaps, integers, strings, and CardCollections
     */
    public class DefaultStorage<T>
    {
        private readonly Dictionary<string, T> dict = new Dictionary<string, T>();
        private T defaultT;
        public Owner owner;

        /*******
         * Save the default value given in the constructor
         */
        public DefaultStorage(T defaultT, Owner owner)
        {
            this.defaultT = defaultT;
            this.owner = owner;
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
                dict[key] = GetDefault();
            }
        }

        private T GetDefault() {
            if (defaultT is ICloneable dt)
            {
                return (T)dt.Clone();
            }
            else
            {
                return default(T);
            }
        }

        public IEnumerable<string> Keys()
        {
            return dict.Keys;
        }

        public DefaultStorage<T> Clone()
        {
            var ret = new DefaultStorage<T>(defaultT, owner);
            foreach (var bin in dict.Keys)
            {
                if (defaultT is ICloneable dt)
                {
                    ret[bin] = (T)dt.Clone();
                }
                else
                {
                    ret[bin] = dict[bin];
                }
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

    /**********
     **********
     * Triggers are meant for a way to exit a stage without completing it,
     * a break for the Recycle language. Implemented but never fully
     * connected, and need to be expanded to be truly useful. Created 
     * for trying to implement Cribbage. RETURN TO THIS SOMEDAY.
     */
    public class Trigger
    {
        public TriggerException exception;
        public string op;
        public int value;
        public void Evaluate(int v)
        {
            var shouldTrigger = false;
            // Need many more op choices to be truly flexible...
            if (op == ">=")
            {
                if (v >= value)
                {
                    shouldTrigger = true;
                }
            }
            if (shouldTrigger)
            {
                throw exception;
            }
        }

    }
    public class TriggerException : Exception
    {
        public string Level { get; set; }
        public TriggerException()
            : base() { }

        public TriggerException(string message)
            : base(message) { }

        public TriggerException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public TriggerException(string message, Exception innerException)
            : base(message, innerException) { }

        public TriggerException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
