using CardStock.CardEngine;
using System.Diagnostics;

namespace CardStock.FreezeFrame{

    public enum CardLocTypes
    {
        TOP, BOTTOM, UNDEFINED, NUMBER
    }

	public class CardLocReference
    {
        public required CardCollection cardList;
        // Can't remember why we need the default -1 here...
        public CardLocTypes locIdentifier = CardLocTypes.UNDEFINED;
        public int locid;
        public required string name;

        public CardLocReference ShallowCopy()
        {
            var loc = new CardLocReference()
            {
                cardList = cardList.ShallowCopy(),
                locIdentifier = locIdentifier,
                locid = locid,
                name = name + " - Copy",
            };
            return loc;
        }

        public void Add(Card c)
        {
            switch (locIdentifier)
            {
                case CardLocTypes.TOP:
                    cardList.Add(c);
                    break;
                case CardLocTypes.BOTTOM:
                    cardList.AddBottom(c);
                    break;
                case CardLocTypes.UNDEFINED:
                    // SHOULD THIS THROW EXCEPTION INSTEAD?
                    Console.WriteLine("Adding to a -1 loc ref");
                    throw new Exception();
                default:
                    cardList.Add(c, locid);
                    break;
            }
        }
        public int Count()
        {
            return cardList.Count;
        }
        public Card Get()
        {
            //Console.WriteLine("locid:" + locIdentifier);
            switch (locIdentifier)
            {
                case CardLocTypes.TOP:
                    if (cardList.Count == 0)
                    {
                        Console.Write(name + " is empty??");
                    }
                    return cardList.Peek();
                case CardLocTypes.BOTTOM:
                    System.Collections.Generic.IEnumerator<Card> e = cardList.AllCards().GetEnumerator();
                    e.MoveNext();
                    return e.Current;
                case CardLocTypes.UNDEFINED:
                    Console.WriteLine("Getting from a -1 loc ref");
                    // SHOULD THIS THROW EXCEPTION INSTEAD?
                    throw new Exception();
                //return cardList.Peek();
                default:
                    return cardList.Get(locid);
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
                card.Owner.Remove(card); // where was it removed from? How do we save this for undo?
            }
            else
            {
                Debug.WriteLine("Pulling from Standard...");
                cardList.Remove(card);
            }
            return card;
            //return new Tuple<Card, int>(card, -1);
        }

        public void SetLocId(Card c)
        {
            for (int idx = 0; idx < cardList.Count; idx++)
            {
                if (c.Equals(cardList.Get(idx)))
                {
                    locIdentifier = CardLocTypes.NUMBER;
                    locid = idx;
                }
            }
        }

        public override string ToString()
        {
            return cardList + " " + locIdentifier;
        }

        public string ToOutputString()
        {
            return cardList.ToString();
        }
    }	
}