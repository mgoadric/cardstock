using System.Collections.Generic;
namespace CardEngine{
	public class CardScore{
		List<PointAwards> awards;
		public Dictionary<string,Dictionary<string,int>> pointLookups = new Dictionary<string,Dictionary<string,int>>();
		public CardScore(List<PointAwards> input){
			awards = input;
			foreach (var award in awards){
				if (pointLookups.ContainsKey(award.identifier)){
					if (pointLookups[award.identifier].ContainsKey(award.value)){
						pointLookups[award.identifier][award.value] += award.pointsToAward;
					}
					else{
						pointLookups[award.identifier].Add(award.value,award.pointsToAward);
					}
				}
				else{
					pointLookups[award.identifier] = new Dictionary<string,int>{
						{award.value, award.pointsToAward}
					};
				}
			}
		}
		public int GetScore(Card c){
			int total = 0;
			foreach (var key in pointLookups.Keys){
				var arrAtts = key.Split(',');
				var attStr = "";
				foreach (var att in arrAtts){
                    System.Diagnostics.Debug.WriteLine("Card: " + c);
					var val = c.ReadAttribute(att);
					attStr += val + ",";
				}
				attStr = attStr.Substring(0,attStr.Length - 1);
				if (pointLookups[key].ContainsKey(attStr)){
					total += pointLookups[key][attStr];
				}
			}
			return total;
		}
	}
	public class PointAwards{
		public string identifier;
		public string value;
		public int pointsToAward;
		public PointAwards(string identifier, string value, int p){
			this.identifier = identifier;
			this.value = value;
			pointsToAward = p;
		}
		
		public int ScoreCard(){
			return pointsToAward;
			
		}
	}
}