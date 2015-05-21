using System.Collections.Generic;
namespace CardEngine
{
	public class Player{
		public List<Card> hand = new List<Card>();
		public List<Card> visibleCards = new List<Card>();
		public Player(){
			
		}
		public void DealCard(Card c){
			hand.Add(c);
		}
		public Card CardForFilter(CardFilter description){
			foreach (var c in hand){
				if (description.CardConforms(c)){
					return c;
				}
			}
			return null;
		}
		public override string ToString(){
			string ret = "Player:\n";
			foreach (var card in hand){
				ret += "Card:" + card.ToString() + "\n";
			}
			return ret;
		}
	}
}