using System.Collections.Generic;
namespace Analytics{
	public class StorageValues{
		private static StorageValues instance;
		public static StorageValues Instance
   		{
	  		get 
	  		{
		         if (instance == null)
		         {
		            instance = new StorageValues();
		         }
		         return instance;
		     }
		}
		Dictionary<string,List<int>> counter = new Dictionary<string,List<int>>();
		public StorageValues(){
			
		}
		public void AddCount(int value, string key){
			if (counter.ContainsKey(key)){
				counter[key].Add(value);
			}
			else{
				counter[key] = new List<int>{
					value
				};
			}
		}
		public override string ToString(){
			string ret = "";
			foreach (var key in counter.Keys){
				ret += key + "\n";
				foreach (var choices in counter[key]){
					ret += choices + "\n";
				}
			}
			return ret;
		}
	}
	
}