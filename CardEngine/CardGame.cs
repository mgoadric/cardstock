using System;
using System.Collections.Generic;
namespace CardEngine
{
	public class CardGame{
		public CardGame(){
			var suits = new Dictionary<string,List<string>>{
				{"red",new List<string>{
					"hearts",
					"diamonds"
				}},
				{"black",new List<string>{
					"clubs",
					"spades"	
				}}
			};
			var ranks = new List<string>{
				"2","3","4","5","6","7","8","9","10","J","Q","K","A"
			};
			
			var cards = new List<Card>();
			foreach (var color in suits.Keys){
				foreach (var suit in suits[color]){
					foreach (var rank in ranks){
						var cardAtts = new Dictionary<string,string>{
							{"a0",color},
							{"a1",suit},
							{"a2",rank}
						};
						cards.Add(new Card(cardAtts));
					}
				}
			}
			foreach (var card in cards){
				Console.Write(card);
			}
			
			//var first = new Card();
		}
	}
}