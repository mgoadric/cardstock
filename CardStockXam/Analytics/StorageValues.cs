using System.Collections.Generic;
using System;
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
			set{
				instance = value;
			}
		}
		Dictionary<string,List<Tuple<int,string,string>>> counter = new Dictionary<string,List<Tuple<int,string,string>>>();
		public StorageValues(){
			
		}
		public void AddCount(int value, string key){
			if (counter.ContainsKey(key)){
				counter[key].Add(new Tuple<int,string,string>(value,TimeStep.Instance.GetTreeLoc(),TimeStep.Instance.GetTimeStep()));
			}
			else{
				counter[key] = new List<Tuple<int,string,string>>{
					new Tuple<int,string,string>(value,TimeStep.Instance.GetTreeLoc(),TimeStep.Instance.GetTimeStep())
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