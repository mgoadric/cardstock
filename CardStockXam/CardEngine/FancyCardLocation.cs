using System;
using System.Diagnostics;

namespace CardEngine{
	public class FancyCardLocation{
		public CardCollection cardList;
		public string locIdentifier;
        public string name;
		public bool physicalLocation = false;
        
		
		public CardFilter filter;
		public void Add(Card c){
			if (locIdentifier == "top"){
				cardList.Add(c);
			}
			else if (locIdentifier == "bottom"){
				cardList.AddBottom(c);
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
			if (filter != null){
				var temp = filter.FilterList(cardList);
				if (locIdentifier == "top"){
					return temp.Peek();
				}
				else if (locIdentifier == "bottom"){
					return temp.AllCards().GetEnumerator().Current;
				}
			}
			if (locIdentifier == "top"){
				return cardList.Peek();
			}
			else if (locIdentifier == "bottom"){
				return cardList.AllCards().GetEnumerator().Current;
			}
			return null;
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
                    var current = temp.Peek();
                    current.owner.Remove(current);
                    return current;
					//return temp.Remove();
				}
				else if (locIdentifier == "bottom"){
                    var current = temp.AllCards().GetEnumerator().Current;
                    current.owner.Remove(current);
                    return current;
				}
			}
			if (cardList.Count != 0){
				Debug.WriteLine("Pulling from Standard...");
                if (locIdentifier == "top"){
					return cardList.Remove();
				}
				else if (locIdentifier == "bottom"){
					return cardList.RemoveAt(0);
				}
			}
			return null;
		}

        public bool Contains(Card c)
        {
            return cardList.Contains(c);
        }

        public override String ToString() {
            return cardList.ToString() + " " + locIdentifier + " " + physicalLocation;
        }
	}	
}