using System.Collections.Generic;

namespace CardEngine
{
    public class PointsStorage
    {
        public CardScore this[string key]
        {
            get
            {
                return storage[binDict[key]];
            }
            set
            {
                storage[binDict[key]] = value;
            }
        }
        public CardScore[] storage;
        int binCounter = 0;
        public Dictionary<string, int> binDict = new Dictionary<string, int>();
        public PointsStorage()
        {
            storage = new CardScore[32];
        }
        public PointsStorage Clone()
        {
            var ret = new PointsStorage();
            foreach (var bin in binDict.Keys)
            {
                ret.AddKey(bin);
                ret[bin] = storage[binDict[bin]];
            }
            return ret;
        }
        public void AddKey(string key)
        {
            binDict.Add(key, binCounter);
            binCounter++;
        }

        public override bool Equals(System.Object obj)
        {

            if (obj == null)
            {
                return false;
            }
            PointsStorage p = obj as PointsStorage;
            if ((System.Object)p == null)
            {
                return false;
            }

            if (p.binCounter != binCounter) // if dictionary lists are not the same size
            {
                return false;
            }

            foreach (var bin in binDict.Keys)
            {
                {
                    if (!(storage[binDict[bin]].Equals(p.storage[binDict[bin]]))) // Uses CardScore equals to see PointStorage equals
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            foreach (var bin in binDict.Keys)
            {
                hash ^= storage[binDict[bin]].GetHashCode();
            }
            return hash;
        }
    }


}