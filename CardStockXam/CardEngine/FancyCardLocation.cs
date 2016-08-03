using System;
using System.Diagnostics;

namespace CardEngine{
	public class FancyCardLocation{
		public CardCollection cardList;
		public string locIdentifier = "-1";
        public string name;
		public bool actual = false;
        public bool nonPhysical = false;

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
		public int Count(){
			return cardList.Count;
		}
		public Card Get(){
            var temp = cardList;		
			if (locIdentifier == "top"){
				return temp.Peek();
			}
			else if (locIdentifier == "bottom"){
				return temp.AllCards().GetEnumerator().Current;
			}
            else if (locIdentifier == "-1"){
                throw new NotSupportedException();
            }
            else{
                return temp.Get(Int32.Parse(locIdentifier));
            }
		}
		public Card Remove(){
            var card = Get();
            if (actual){
                card.owner.Remove(card);
            }
            else if (nonPhysical){
                cardList.Remove(card);
                card.owner.Remove(card);
            }
            else{
                Debug.WriteLine("Pulling from Standard...");
                cardList.Remove(card);
            }
            return card;
		}
	}	
}