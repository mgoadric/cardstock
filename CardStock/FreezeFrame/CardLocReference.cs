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
                case CardLocTypes.NUMBER:
                    return cardList.Get(locid);
                default:
                    Console.WriteLine("Getting from a -1 loc ref");
                    // SHOULD THIS THROW EXCEPTION INSTEAD?
                    throw new Exception();
                    //return cardList.Peek();
            }
        }

        public Card SimpleRemove()
        {
            switch (locIdentifier)
            {
                case CardLocTypes.TOP:
                    Card c = cardList.Remove();
                    return c;
                case CardLocTypes.BOTTOM:
                    Card d = cardList.RemoveAt(0);
                    return d;
                case CardLocTypes.NUMBER:
                    return cardList.RemoveAt(locid);
                default:
                    Console.WriteLine("Getting from a -1 loc ref");
                    // SHOULD THIS THROW EXCEPTION INSTEAD?
                    throw new Exception();
            }
        }

        public void VirtualRemove(Card card)
        {
            if (cardList.type == CCType.VIRTUAL)
            {
                Debug.WriteLine("Removing from Virtual...");
                card.Owner.Remove(card); // where was it removed from? How do we save this for undo?
            }
        }

        // TODO Can we speed up removal for the cardList if we know locIdentifier
        public Card Remove()
        {
            Card card = SimpleRemove();
            VirtualRemove(card);
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
                    break;
                }
            }
        }

        public override string ToString()
        {
            return cardList + " " + locIdentifier + ":" + locid;
        }

        public string ToOutputString()
        {
            return cardList.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is CardLocReference other)
            {
                return Get().Equals(other.Get());
            }
            return false;
        }
    }	
}