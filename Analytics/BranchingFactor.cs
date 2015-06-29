using System.Collections.Generic;
namespace Analytics{
	public class BranchingFactor{
		private static BranchingFactor instance;
		public static BranchingFactor Instance
   		{
	  		get 
	  		{
		         if (instance == null)
		         {
		            instance = new BranchingFactor();
		         }
		         return instance;
		     }
		}
		Dictionary<int,List<int>> counter = new Dictionary<int,List<int>>();
		public BranchingFactor(){
			
		}
		public void AddCount(int numChoices, int playerNum){
			if (counter.ContainsKey(playerNum)){
				counter[playerNum].Add(numChoices);
			}
			else{
				counter[playerNum] = new List<int>{
					numChoices
				};
			}
		}
		public override string ToString(){
			string ret = "";
			foreach (var key in counter.Keys){
				ret += "Player " + (key + 1) + "\n";
				foreach (var choices in counter[key]){
					ret += choices + "\n";
				}
			}
			return ret;
		}
	}
	
}