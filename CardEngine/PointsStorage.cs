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
		public void AddKey(string key){
			binDict.Add(key,binCounter);
			binCounter++;
		}
	}
}