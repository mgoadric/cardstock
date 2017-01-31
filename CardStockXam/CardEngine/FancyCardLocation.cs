using System;
using System.Diagnostics;

namespace CardEngine{
	public class FancyCardLocation : ICloneable{
		public CardCollection cardList;
		public string locIdentifier = "-1";
        public string name;
		public bool actual = false;
        public bool nonPhysical = false;


        public FancyCardLocation Clone()
        {
            return new FancyCardLocation()
            {
                cardList = cardList.Clone(),
                locIdentifier = (string) locIdentifier.Clone(),
                name = (string) name.Clone(),
                actual = actual,
                nonPhysical = nonPhysical
            };
        }

        public void Add(Card c){
			if (locIdentifier == "top"){
				cardList.Add(c);
			}
			else if (locIdentifier == "bottom"){
				cardList.AddBottom(c);
			}
            else if (locIdentifier == "-1"){
                cardList.Add(c);
            }
            else{
                cardList.Add(c, Int32.Parse(locIdentifier));
            }
		}
		public int Count(){
			return cardList.Count;
		}
		public Card Get(){	
			if (locIdentifier == "top"){
				return cardList.Peek();
			}
			else if (locIdentifier == "bottom"){
				return cardList.AllCards().GetEnumerator().Current;
			}
            else if (locIdentifier == "-1"){
                return cardList.Peek();
            }
            else{
                return cardList.Get(Int32.Parse(locIdentifier));
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

        public void setLocId(Card c){
            for (int idx = 0; idx < cardList.Count; idx++){
                if (c.Equals(cardList.Get(idx))){
                    locIdentifier = idx.ToString();
                }
            }
        }

        public override String ToString()
        {
            return cardList.ToString() + " " + locIdentifier + " " + actual + " " + nonPhysical;
        }

        public String ToOutputString(){
            return cardList.ToString();
        }

        object ICloneable.Clone()
        {
            throw new NotImplementedException();
            //TODOClone
        }
    }	
}