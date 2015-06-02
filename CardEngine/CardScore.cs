using System.Collections.Generic;
namespace CardEngine{
	public class CardScore{
		List<PointAwards> awards;
		public CardScore(List<PointAwards> input){
			awards = input;
		}
		public int GetScore(Card c){
			int total = 0;
			foreach (var award in awards){
				total += award.ScoreCard(c);
			}
			return total;
		}
	}
	public class PointAwards{
		CardFilter matching;
		int pointsToAward;
		public PointAwards(CardFilter m, int p){
			matching = m;
			pointsToAward = p;
		}
		
		public int ScoreCard(Card card){
			if (matching.CardConforms(card)){
				return pointsToAward;
			}
			else{
				return 0;
			}
		}
	}
}