using System.Collections.Generic;
namespace Analytics{
	public class StageCount{
		private static StageCount instance;
		public static StageCount Instance
   		{
	  		get 
	  		{
		         if (instance == null)
		         {
		            instance = new StageCount();
		         }
		         return instance;
		     }
		}
		Dictionary<CardLanguageParser.StageContext,int> counter = new Dictionary<CardLanguageParser.StageContext,int>();
		public StageCount(){
			
		}
		public void IncCount(CardLanguageParser.StageContext stage){
			if (counter.ContainsKey(stage)){
				counter[stage] += 1;
			}
			else{
				counter[stage] = 1;
			}
		}
		public override string ToString(){
			string ret = "";
			foreach (var key in counter.Keys){
				ret += "stage: " + key.GetText().Substring(0,75) + " , " + counter[key];
				ret += "\n";
			}
			return ret;
		}
	}
	
}