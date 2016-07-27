using System;
using System.Diagnostics;

namespace CardEngine{
	public class FancyCardLocation{
		public CardCollection cardList;
		public string locIdentifier;
		public bool physicalLocation = false;
		
		public CardFilter filter;
		public void Add(Card c){
			if (locIdentifier == "top"){
				cardList.Add(c);
			}
			else if (locIdentifier == "bottom"){
				cardList.AddBottom(c);
			}
            else{
                cardList.Add(c, Int32.Parse(locIdentifier));
            }
		}
		public int FilteredCount(){
			if (filter != null){
				var temp = filter.FilterList(cardList);
				return temp.Count;
			}
			return cardList.Count;
		}
		public Card Get(){
            var temp = cardList;
            if (filter != null) {
                temp = filter.FilterList(cardList);
            }			
			if (locIdentifier == "top"){
				return temp.Peek();
			}
			else if (locIdentifier == "bottom"){
				return temp.AllCards().GetEnumerator().Current;
			}
            else{
                return temp.Get(Int32.Parse(locIdentifier));
            }
		}
		public CardCollection FilteredList(){
			if (filter != null){
				var temp = filter.FilterList(cardList);
				return temp;
			}
			return cardList;
		}
		public Card Remove(){
			if (physicalLocation){
				var card = cardList.Peek();
				var trueLocation = card.owner;
				trueLocation.Remove(card);
				return card;
			}
			if (filter != null){
				var temp = filter.FilterList(cardList);
				Debug.WriteLine("Removed from Filter...");
				if (locIdentifier == "top"){
					return temp.Remove();
				}
				else if (locIdentifier == "bottom"){
					return temp.AllCards().GetEnumerator().Current;
				}
                else{
                    return temp.RemoveAt(Int32.Parse(locIdentifier));
                }
			}
			if (cardList.Count != 0){
				Debug.WriteLine("Pulling from Standard...");
				if (locIdentifier == "top"){
					return cardList.Remove();
				}
				else if (locIdentifier == "bottom"){
					return cardList.Remove();
				}
			}
			return null;
		}
	}	
}