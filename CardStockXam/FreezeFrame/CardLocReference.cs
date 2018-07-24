using System;
using System.Diagnostics;

namespace FreezeFrame{
	public class CardLocReference{
		public CardCollection cardList;
        // Can't remember why we need the default -1 here...
		public string locIdentifier = "-1";
        public string name;
		public bool actual = false;

        public CardLocReference(){
            
        }

        public CardLocReference ShallowCopy(CardGame cg)
        {
            var loc = new CardLocReference()
            {
                cardList = cardList.ShallowCopy(),
                locIdentifier = String.Copy(locIdentifier),
                name = String.Copy(name) + " - Copy",
                actual = actual,
            };
            cg.AddToMap(loc);
            return loc;
        }

        public void Add(Card c){
            switch (locIdentifier)
            {
                case "top":
                    cardList.Add(c);
                    break;
                case "bottom":
                    cardList.AddBottom(c);
                    break;
                case "-1":
                    cardList.Add(c);
                    break;
                default:
                    cardList.Add(c, Int32.Parse(locIdentifier));
                    break;
            }
        }
		public int Count(){
			return cardList.Count;
		}
		public Card Get(){
            switch (locIdentifier)
            {
                case "top":
                    return cardList.Peek();
                case "bottom":
                    System.Collections.Generic.IEnumerator<Card> e = cardList.AllCards().GetEnumerator();
                    e.MoveNext();
                    return e.Current;
                case "-1":
                    return cardList.Peek();
                default:
                    return cardList.Get(Int32.Parse(locIdentifier));
            }
        }
		public Card Remove(){
            var card = Get();
            if (actual){
                card.owner.Remove(card);
            }
            else if (cardList.type == CCType.VIRTUAL){
                cardList.Remove(card);
                card.owner.Remove(card);
            }
            else{
                Debug.WriteLine("Pulling from Standard...");
                cardList.Remove(card);
            }
            return card;
		}

        public void SetLocId(Card c){
            for (int idx = 0; idx < cardList.Count; idx++){
                if (c.Equals(cardList.Get(idx))){
                    locIdentifier = idx.ToString();
                }
            }
        }

        public override String ToString()
        {
            return cardList + " " + locIdentifier + " " + actual;
        }

        public String ToOutputString(){
            return cardList.ToString();
        }
    }	
}