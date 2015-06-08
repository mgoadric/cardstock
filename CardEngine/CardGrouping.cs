using System;
using System.Collections.Generic;
using System.Linq;
namespace CardEngine{
	public static class ListExtension{
		public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
		{
		  return k == 0 ? new[] { new T[0] } :
		    elements.SelectMany((e, i) =>
		      elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] {e}).Concat(c)));
		}
	}
	public class CardGrouping{
		CardCollection[] array;
		CardScore score;
		public CardGrouping(int numBins, CardScore scoring){
			array = new CardCollection[numBins];
			for (int i = 0; i < numBins; ++i){
				array[i] = new CardListCollection();
			}
			score = scoring;
		}
		private void SortCards(CardCollection source){
			foreach (var card in source.AllCards()){
				var curScore = score.GetScore(card);
				array[curScore].Add(card);
			}
		}
		
		public List<CardCollection> TuplesOfSize(CardCollection source, int setSize){
			var ret = new List<CardCollection>();
			SortCards(source);
			for (int i = 0; i < 13; ++i){
				var combos = ListExtension.Combinations<Card>(array[i].AllCards(),setSize);
				foreach (var combo in combos){
					var newAdd = new CardListCollection();
					
					
					Console.WriteLine("Combo:");
					foreach (var card in combo){
						newAdd.Add(card);
						Console.Write(" " + card + " ");
					}		
					ret.Add(newAdd);
					Console.WriteLine();			
				}
				
			}
			return ret;
		}
	}
}