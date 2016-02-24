using System.Collections.Generic;

namespace CardEngine{
	public class PointsStorage{
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
		public Dictionary<string,int> binDict = new Dictionary<string,int>();
		public PointsStorage(){
			storage = new CardScore[32];
		}
		public PointsStorage Clone(){
			var ret = new PointsStorage ();
			foreach (var bin in binDict.Keys) {
				ret.AddKey (bin);
				ret [bin] = storage [binDict [bin]];
			}
			return ret;
		}
		public void AddKey(string key){
			binDict.Add(key,binCounter);
			binCounter++;
		}
	}
}