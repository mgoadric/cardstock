using System;
using CardEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Players
{
	public class SpadesPlayer : GeneralPlayer
	{
		Dictionary<String,int> scores = new Dictionary<String,int>{
			{"2",1},
			{"3",2},
			{"4",3},
			{"5",4},
			{"6",5},
			{"7",6},
			{"8",7},
			{"9",8},
			{"10",9},
			{"J",10},
			{"Q",11},
			{"K",12},
			{"A",13}
		};
		Dictionary<String,int> suitsScores = new Dictionary<String,int>{
			{"spades",100},
			{"hearts",0},
			{"clubs",0},
			{"diamonds",0}
		};
		public SpadesPlayer ()
		{
		}
		public override int MakeAction(List<GameActionCollection> possibles,Random rand){

			return rand.Next(0,possibles.Count);
		}
		public override int MakeAction(JObject possibles, Random rand){
			var items = (JArray)possibles ["items"];
			int maxCard = -1;
			int maxScore = 0;
			int count = 0;


			foreach (JArray sequence in items) {
				foreach (JObject card in sequence) {
					var root = (JArray) card ["children"];
					var r = "";
					var s = "";
					foreach (JObject baseAt in root) {
						var rank = baseAt ["rank"];
						var suit = baseAt ["suit"];
						if (rank != null) {
							r = rank.ToString ();
						}
						if (suit != null) {
							s = suit.ToString ();
						}

					}
					var score = scores [r] + suitsScores [s];
					if (score > maxScore) {
						maxScore = score;
						maxCard = count;
					}
				}
				++count;

			}
			if (maxCard != -1)
				return maxCard;
			return rand.Next (0,items.Count);
		}
	}
}

