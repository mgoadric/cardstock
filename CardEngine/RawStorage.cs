using System.Collections.Generic;
namespace CardEngine{
	public class RawStorage{
		public int this[string key]
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
		public int[] storage;
		int binCounter = 0;
		Dictionary<string,int> binDict = new Dictionary<string,int>();
		public RawStorage(){
			storage = new int[32];
		}
		public void AddKey(string key){
			binDict.Add(key,binCounter);
			binCounter++;
		}
	}
}