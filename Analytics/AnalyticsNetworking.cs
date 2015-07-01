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
				var ret = "{";
				ret += "\"GameID\" : " + GameId + ",";
				ret += "\"ExecutionTime\" : " + ExecutionTime + ",";
				ret += "\"branchingFactor\" : [ ";
				foreach (var item in branchingFactor){
					ret += "{";
					ret += "\"Item1\" : " + item.Item1 + ",";
					ret += "\"Item2\" : \"" + item.Item2 + "\",";
					ret += "\"Item3\" : \"" + item.Item3 + "\",";
					ret += "\"Item4\" : \"" + item.Item4 + "\"";
					ret += "},";
				}
				ret = ret.Substring(0,ret.Length - 1);
				ret += "]}";
				return ret;
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