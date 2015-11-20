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
			int maxOver = -1;
			int maxOver2 = -1;
			int maxUnderScore2 = 1000;
			int maxUnderScore = 1000;
			bool queenInPlay = false;
			int maxScore = 0;
			int count = 0;

			int minCard = -1;
			int minScore = 1000;

			int minHeart = -1;
			int minHeartScore = 114;


			JObject currentState = CardGame.Instance.GameState (0);


			foreach (var suit in new List<String>(suitsScores.Keys)) {

				if (suit == "spades") {
					suitsScores ["spades"] = 100;
				} else {
					suitsScores [suit] = 0;
				}

				try {
					if (suit == currentState ["gamecards"] [3] ["contents"] [0] ["children"] [1] ["suit"].ToString ()) {
						suitsScores [suit] = 50;
					}

				} catch (Exception ex) {
					//fail silently
				}
			}

			int otherScore = 0;
			for (int i = 1; i < 4; ++i) {//iterate over other players trick
				try{
					var rank = currentState["players"][i]["cards"][2]["contents"][0]["children"][0]["rank"].ToString();
					var suit = currentState["players"][i]["cards"][2]["contents"][0]["children"][1]["suit"].ToString();
					int score = scores [rank] + suitsScores [suit];
					if (score > otherScore){
						otherScore = score;
					}

				}
				catch (Exception ex){
					//fail silently, card not played yet
				}
			}

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
					if (score < minScore) {
						minScore = score;
						minCard = count;
					}

					if (score > otherScore && score < maxUnderScore) {
						maxUnderScore = score;
						maxOver = count;
					}
					if (score > otherScore + 3 && score < maxUnderScore2) {
						maxUnderScore2 = score;
						maxOver2 = count;
					}
					if (s == "spades" && score < minHeartScore) {
						minHeart = count;
						minHeartScore = score;
					}


				}
				++count;

			}
			if (maxOver2 != -1) {
				return maxOver2;
			}
			if (maxOver != -1) {
				return maxOver;
			}
			if (otherScore == 0 && maxCard != -1) {
				return maxCard;
			}

			if (minCard != -1)
				return minCard;
			//if (((JArray)possibles["items"]).Count == 12) {
			//	return 2;
			//}
			return rand.Next (0,items.Count);
		}
	}
}

