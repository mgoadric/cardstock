using System.Collections.Generic;
using System.Text;

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
			var tempRet = new StringBuilder("");
			foreach (var i in treeLoc){
				tempRet.Insert(0, "-" + i);
				//tempRet =  "-" + i + tempRet;
			}
			if (tempRet.Length > 0){
				//tempRet = tempRet.Substring(1);
				tempRet.Remove(0, 1);
			}
			return tempRet.ToString();
		}
		public string GetTimeStep(){
			var tempRet = new StringBuilder("");
			foreach (var i in timeStep){
				tempRet.Insert(0, "-" + i);
			}
			if (tempRet.Length > 0){
				//tempRet = tempRet.Substring(1);
				tempRet.Remove(0, 1);
			}
			return tempRet.ToString();
		}
		public override string ToString(){
			var ret = new StringBuilder("");
			ret.Append("loc ");
			/*var tempRet = "";
			foreach (var i in treeLoc){
				tempRet =  "-" + i + tempRet;
			}
			tempRet = tempRet.Substring(1);*/
			ret.Append(GetTreeLoc() + "\ntime ");
			/*tempRet = "";
			foreach (var i in timeStep){
				tempRet =  "-" + i + tempRet;
			}
			tempRet = tempRet.Substring(1);*/
			ret.Append(GetTimeStep() + "\n");
			return ret.ToString();
		}
	}
	
}