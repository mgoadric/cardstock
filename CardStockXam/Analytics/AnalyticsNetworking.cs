using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
namespace Analytics{
	public class AnalyticsNetworking{
		class PostClass{
			public int GameId{get; set;}
			public float ExecutionTime{get; set;}
			public List<Tuple<int,int,string,string>> branchingFactor = new List<Tuple<int,int,string,string>>();
			public override string ToString(){
				var ret = new StringBuilder("{");
				ret.Append("\"GameID\" : " + GameId + ",");
				ret.Append("\"ExecutionTime\" : " + ExecutionTime + ",");
				ret.Append("\"branchingFactor\" : [ ");
				foreach (var item in branchingFactor){
					ret.Append("{");
					ret.Append("\"Item1\" : " + item.Item1 + ",");
					ret.Append("\"Item2\" : \"" + item.Item2 + "\",");
					ret.Append("\"Item3\" : \"" + item.Item3 + "\",");
					ret.Append("\"Item4\" : \"" + item.Item4 + "\"");
					ret.Append("},");
				}
				var str = ret.ToString().Substring(0,ret.Length - 1);
				str += "]}";
				return str;
			}
		}
		public static void PostResults(){
			using (var client = new WebClient())
			{
			    
			    var send = new PostClass();
				send.GameId = 0;
				send.ExecutionTime = 3.5f;
				foreach (var playerNum in BranchingFactor.Instance.counter.Keys){
					Console.WriteLine(BranchingFactor.Instance.counter[playerNum].Count);
					send.branchingFactor.AddRange(BranchingFactor.Instance.counter[playerNum]);
				}
				var request = (HttpWebRequest)WebRequest.Create("https://cards.owl-apps.com/api/Run/");

				//Console.WriteLine(send.ToString());
				var data = Encoding.ASCII.GetBytes(send.ToString());
				
				request.Method = "POST";
				request.ContentType = "application/json";
				request.ContentLength = data.Length;
				request.Headers.Add("token","");
				Console.WriteLine(data.Length);
				using (var stream = request.GetRequestStream())
				{
				    stream.Write(data, 0, data.Length);
				}
				

				var response = (HttpWebResponse)request.GetResponse();
				
				var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
				Console.WriteLine(responseString);
			}
		}
	}
}