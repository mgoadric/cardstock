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
			for (int i = 0; i < array.Count(); ++i){
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
		public List<CardCollection> RunsOfSize(CardCollection source, int runLength){
			var ret = new List<CardCollection>();
			SortCards(source);
			for (int i = 0; i < array.Count(); ++i){
				var found = RightLook(i,runLength);
				ret.AddRange(found);
				foreach (var lst in found){
					Console.WriteLine("RUN***");
					foreach (var card in lst.AllCards()){
						Console.WriteLine(card);
					}
				}
			}
			return ret;
		}
		private List<CardCollection> RightLook(int idx, int remainingLength){
			if (idx < array.Count() && array[idx].Count > 0){
				List<CardCollection> recurs;
				if (remainingLength != 1){
					recurs = RightLook(idx + 1, remainingLength - 1);
					var ret = new List<CardCollection>();
					foreach (var card in array[idx].AllCards()){
						foreach (var downLine in recurs){
							var tempList = new CardListCollection();
							tempList.Add(card);
							foreach (var innerCard in downLine.AllCards()){
								tempList.Add(innerCard);
							}
							ret.Add(tempList);
							
						}
					}
					return ret;
				}
				else{
					var ret = new List<CardCollection>();
					foreach (var card in array[idx].AllCards()){
						var tempList = new CardListCollection();
						tempList.Add(card);
						ret.Add(tempList);
						
					}
					return ret;
				}
				
				
			}
			else{
				return new List<CardCollection>();
			}
		}
	}
}