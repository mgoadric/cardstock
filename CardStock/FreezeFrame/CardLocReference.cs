using CardStock.CardEngine;
using System.Diagnostics;

namespace CardStock.FreezeFrame{
	public class CardLocReference{
		public required CardCollection cardList;
        // Can't remember why we need the default -1 here...
		public string locIdentifier = "-1";
        public required string name;
		public bool actual = false;

        public CardLocReference ShallowCopy()
        {
            var loc = new CardLocReference()
            {
                cardList = cardList.ShallowCopy(),
                locIdentifier = locIdentifier,
                name = name + " - Copy",
                actual = actual,
            };
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
                    // SHOULD THIS THROW EXCEPTION INSTEAD?
                    Console.WriteLine("Adding to a -1 loc ref");
                    throw new Exception();
                    cardList.Add(c);
                    break;
                default:
                    cardList.Add(c, int.Parse(locIdentifier));
                    break;
            }
        }
		public int Count(){
			return cardList.Count;
		}
		public Card Get(){
            //Console.WriteLine("locid:" + locIdentifier);
            switch (locIdentifier)
            {
                case "top":
                    return cardList.Peek();
                case "bottom":
                    System.Collections.Generic.IEnumerator<Card> e = cardList.AllCards().GetEnumerator();
                    e.MoveNext();
                    return e.Current;
                case "-1":
                    Console.WriteLine("Getting from a -1 loc ref");
                    // SHOULD THIS THROW EXCEPTION INSTEAD?
                    return cardList.Peek();
                default:
                    return cardList.Get(int.Parse(locIdentifier));
            }
        }

        // TODO Can we speed up removal for the cardList if we know locIdentifier
        public Card Remove()
        {
            var card = Get();
            if (cardList.type == CCType.VIRTUAL)
            {
                Debug.WriteLine("Removing from Virtual...");
                cardList.Remove(card);
                card.owner.Remove(card); // where was it removed from? How do we save this for undo?
            }
            else
            {
                Debug.WriteLine("Pulling from Standard...");
                cardList.Remove(card);
            }
            return card;
            //return new Tuple<Card, int>(card, -1);
        }

        public void SetLocId(Card c){
            for (int idx = 0; idx < cardList.Count; idx++){
                if (c.Equals(cardList.Get(idx))){
                    locIdentifier = idx.ToString();
                }
            }
        }

        public override string ToString()
        {
            return cardList + " " + locIdentifier + " " + actual;
        }

        public string ToOutputString(){
            return cardList.ToString();
        }
    }	
}