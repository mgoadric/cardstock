using System.Collections.Generic;
using System;

namespace CardEngine{
	public class IntStorage{
		public int this[string key]
		{
		    get
		    {
				if (!binDict.ContainsKey(key)) {
					AddKey(key);
				}
		        return storage[binDict[key]];
		    }
		    set
		    {
				
				if (!binDict.ContainsKey(key)) {
					AddKey(key);
				}
	       		storage[binDict[key]] = value;

                ////
				if (triggerDict.ContainsKey(key)){
					foreach (var trigger in triggerDict[key]){
						trigger.Evaluate(storage[binDict[key]]);
					}
				}
	    	}
		}
        public Player owner;
        public Team teamOwner;

        public int[] storage;
		public int binCounter = 0;
		Dictionary<string,List<Trigger>> triggerDict = new Dictionary<string, List<Trigger>>();
		public Dictionary<string,int> binDict = new Dictionary<string,int>();
		public IntStorage(){
			storage = new int[32];
		}
		public IntStorage Clone(){
			var raw = new IntStorage ();
			raw.storage = storage.Clone () as int[];
			foreach (var key in binDict.Keys) {
				raw.AddKey (key);
			}
			foreach (var key in triggerDict.Keys) {
				foreach (var trig in triggerDict[key]) {
					raw.AddTrigger (trig, key);
				}
			}
			return raw;
		}
        public string GetOwnerName()
        {
            if (owner != null)
            { return owner.name; }
            else if (teamOwner != null)
            { return "t" + teamOwner.name; }
            else { return "Table"; }      
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
            IntStorage p = obj as IntStorage;
            if ((System.Object)p == null)
            {
                return false;
            }

            if (p.binCounter != binCounter) // if storage locations are not the same size
            {
                return false;
            }

            foreach (var bin in binDict.Keys)
            {
                {
                    if ((storage[binDict[bin]] !=(p.storage[binDict[bin]]))) // For each storage location, points must be equal
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
    
        public void AddTrigger(Trigger trig, string key)
        {
            if (!triggerDict.ContainsKey(key))
            {
                triggerDict[key] = new List<Trigger>();
            }
            triggerDict[key].Add(trig);
        }
	}
}