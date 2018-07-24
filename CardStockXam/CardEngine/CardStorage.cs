//using System.Collections.Generic;
//using System.Linq;
//using System;
//using System.Diagnostics;
//using System.Text;
//namespace CardEngine {

//    public class CardStorage {
//        public CardCollection this[string key]
//        {
//            get
//            {
//                if (!binDict.ContainsKey(key)) {
//                    AddKey(key);
//                    storage[binDict[key]] = new CardListCollection() { name = (owner == null ? "t" : owner.name) + key };
//                    storage[binDict[key]].container = this;
//                } else if (storage[binDict[key]] == null) {
//                    storage[binDict[key]] = new CardListCollection() { name = (owner == null ? "t" : owner.name) + key };
//                    storage[binDict[key]].container = this;
//                }
//                return storage[binDict[key]];
//            }
//            set
//            {
//                if (!binDict.ContainsKey(key)) {
//                    AddKey(key);
//                }
//                storage[binDict[key]] = value;
//                value.container = this;
//            }
//        }

//        public Player owner { get; set; }
//        public int binCounter = 0; 
//        Dictionary<string, int> binDict = new Dictionary<string, int>();
//        public CardCollection[] storage = new CardCollection[32];

//        public IEnumerable<string> Keys() {
//            return binDict.Keys;
//        }
//        public void AddKey(string key) {
//            binDict.Add(key, binCounter);
//            binCounter++;
//        }
//        public CardStorage Clone() {
//            var ret = new CardStorage();
//            foreach (var key in binDict) {
//                ret.AddKey(key.Key);
//            }
//            return ret;
//        }
//        public override String ToString() {
//            StringBuilder ret = new StringBuilder();
//            for (int i = 0; i < binCounter; ++i) {
//                ret.Append(binDict.Where(itm => itm.Value == i).First() + "\n");
//                if (storage == null)
//                {
//                    Debug.WriteLine("empty storage " + ret);
//                    break;
//                }
//                if (storage[i] == null) {
//                    Debug.WriteLine("empty storage in storage " + ret + "[" + i + "]");
//                    break;
//                }
//                foreach (var card in storage[i].AllCards()) {
//                    ret.Append("Card:" + card + "\n");
//                }
//                ret.Append("\n");
//            }
//            return ret.ToString();
//        }
//        public override bool Equals(System.Object obj)
//        {
//            if (obj == null)
//            { return false; }
//            CardStorage p = obj as CardStorage;
//            if ((System.Object)p == null)
//            { return false; }

//            if (p.binCounter != binCounter) 
//            { return false; }

//            foreach (var bin in binDict.Keys)
//            {
//                {
//                    if (!(storage[binDict[bin]].Equals(p.storage[binDict[bin]])))
//                    { return false; }
//                }
//            }
            
//            return true;
//        }
//        public override int GetHashCode()
//        {
//            int hash = 0;
//            foreach (var bin in binDict.Keys)
//            {
//                hash ^= storage[binDict[bin]].GetHashCode();
//            }
//            return hash;
//        } 
//    }
//}
