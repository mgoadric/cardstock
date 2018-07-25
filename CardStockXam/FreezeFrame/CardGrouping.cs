using System;
using System.Collections.Generic;
using System.Linq;
using CardEngine;
namespace FreezeFrame{
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
		PointMap score;
		public CardGrouping(int numBins, PointMap scoring){
            Reset();
			score = scoring;
		}
		private void Reset(){
			array = new CardCollection[array.Count()];
			for (int i = 0; i < array.Count(); ++i){
				array[i] = new CardListCollection(CCType.VIRTUAL);
			}
		}
		private void SortCards(CardCollection source){
			Reset();
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
					var newAdd = new CardListCollection(CCType.VIRTUAL);
					foreach (var card in combo){
						newAdd.Add(card);
					}		
					ret.Add(newAdd);
							
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
				
			}
			return ret;
		}
		private CardCollection Clone(CardCollection source){
            var recurseList = new CardListCollection(CCType.VIRTUAL);
			foreach (var card in source.AllCards()){
				recurseList.Add(card);
			}
			return recurseList;
		}
		public List<CardCollection> AllCombos(CardCollection source){
			var ret = new List<CardCollection>();
            var option = new CardListCollection(CCType.VIRTUAL);
			option.Add(source.Peek());
			ret.Add(option);
			if (source.Count > 1){
				var recurseList = Clone(source);
				recurseList.Remove();
				var lower = AllCombos(recurseList);
				foreach (var combo in lower){
					var lowerClone = Clone(combo);
					lowerClone.Add(source.Peek());
					ret.Add(lowerClone);
					ret.Add(combo);
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
                            var tempList = new CardListCollection(CCType.VIRTUAL);
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
                        var tempList = new CardListCollection(CCType.VIRTUAL);
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