using System.Collections.Generic;
namespace Analytics{
	public class TimeStep{
		private static TimeStep instance;
		public static TimeStep Instance
   		{
	  		get 
	  		{
		         if (instance == null)
		         {
		            instance = new TimeStep();
		         }
		         return instance;
		     }
		}
		public Stack<int> treeLoc = new Stack<int>();
		public Stack<int> timeStep = new Stack<int>();
		public TimeStep(){
			
		}
		public string GetTreeLoc(){
			var tempRet = "";
			foreach (var i in treeLoc){
				tempRet =  "-" + i + tempRet;
			}
			tempRet = tempRet.Substring(1);
			return tempRet;
		}
		public string GetTimeStep(){
			var tempRet = "";
			foreach (var i in timeStep){
				tempRet =  "-" + i + tempRet;
			}
			tempRet = tempRet.Substring(1);
			return tempRet;
		}
		public override string ToString(){
			string ret = "";
			ret += "loc ";
			var tempRet = "";
			foreach (var i in treeLoc){
				tempRet =  "-" + i + tempRet;
			}
			tempRet = tempRet.Substring(1);
			ret += tempRet + "\ntime ";
			tempRet = "";
			foreach (var i in timeStep){
				tempRet =  "-" + i + tempRet;
			}
			tempRet = tempRet.Substring(1);
			ret += tempRet + "\n";
			return ret;
		}
	}
	
}