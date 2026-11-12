using System.Diagnostics;
using System.Runtime.ExceptionServices;
using CardStock.CardEngine;
using CardStock.Evaluation;
using CardStock.Players;

namespace CardStock.FreezeFrame.Actions
{
    
    public class CardSwapAction : GameAction
    {
        public CardLocReference startLocation;
        public CardLocReference endLocation;
        public CardCollection startOwner;
        public CardCollection endOwner;
        public Card startCard;
        public Card endCard;
        public int startIdx;
        public int endIdx;
        public bool actuallocStart;
        public bool actuallocEnd;
        public CardSwapAction(CardLocReference start, CardLocReference end, Logger script) : base("swap", script)
        {
            if (start.cardList.type == CCType.MEMORY)
            {
                Console.WriteLine("start is a mem loc " + start.name + ", " + end.name);
                throw new NotSupportedException();
            }
            if (end.cardList.type == CCType.MEMORY)
            {
                Console.WriteLine("end is a mem loc");
                throw new NotSupportedException();
            }

            if (start.cardList.type == CCType.VIRTUAL)
            {
                Debug.WriteLine("start is a virtual loc " + start.name + ", " + end.name);
                actuallocStart = true;
            }
            if (end.cardList.type == CCType.VIRTUAL)
            {
                actuallocEnd = true;
            }

            startLocation = start;
            endLocation = end;

            if (startLocation.Count() == 0 || endLocation.Count() == 0) {

                Console.WriteLine("error: attempting to move from empty location " + startLocation.ToString()); //TODO debug here
                Console.WriteLine("swapping to " + endLocation.ToString());
                throw new Exception();
            }
        }

        public override Dictionary<string, object> Execute(bool inChoice = false)
        {
            var data = new Dictionary<string, object>();
            if (script is not null)
            {
                data["action"] = prefix;
                startCard = startLocation.Get();
                startOwner = startCard.Owner;
                startIdx = startOwner.IndexOf(startCard);
                var first = new Dictionary<string, object>();
                if (!inChoice) {
                    first["card"] = startCard.ToJSON();
                }
                first["location"] = startOwner.ToJSON();
                first["index"] = startIdx;
                data["first"] = first;
                endCard = startLocation.Get();
                endOwner = endCard.Owner;
                endIdx = endOwner.IndexOf(endCard);

                var second = new Dictionary<string, object>();
                if (!inChoice) {
                    second["card"] = endCard.ToJSON();
                }
                second["location"] = endOwner.ToJSON();
                second["index"] = endIdx;
                data["second"] = second;
            }

            startCard = startLocation.Remove();
            endCard = endLocation.Remove();
            startLocation.Add(endCard);
            endLocation.Add(startCard);
            startOwner = startCard.Owner;
            endOwner = endCard.Owner;
            startCard.Owner = endOwner;
            endCard.Owner = startOwner;
            if (actuallocStart)
            {
                startOwner.Add(endCard);
            }
            if (actuallocEnd)
            {
                endOwner.Add(startCard);
            }

            if (!inChoice) {
                script?.AddToMovementFile(startOwner, endOwner);
                script?.AddToMovementFile(endOwner, startOwner);

                // Track here to see if either moved from a visible to invisible location TODO
                // Then record the invisible as the last known location.
                // SHOULD THIS BE HERE, OR ANOTHER FUNCTION??
                if (GameSimulator.exp!.imperfectLevel >= ImperfectLevel.TAKEN)
                {
                    // FIND BETTER WAY THAN COPY/PASTA

                    if (startOwner.type == CCType.INVISIBLE || startOwner.type == CCType.HIDDEN)
                    {
                        if (endLocation.cardList.type == CCType.VISIBLE)
                        {
                            startOwner.RemoveKnown(startCard);
                        }
                        else 
                        {         
                            //Console.WriteLine("Clearing out " + startLocation.cardList.name);
                            startOwner.ClearKnown();
                        }
                    }
                    if (endOwner.type == CCType.INVISIBLE || endOwner.type == CCType.HIDDEN)
                    {
                        if (startLocation.cardList.type == CCType.VISIBLE)
                        {
                            endOwner.RemoveKnown(startCard);
                        }
                        else 
                        {         
                            //Console.WriteLine("Clearing out " + startLocation.cardList.name);
                            endOwner.ClearKnown();
                        }
                    }
                    if (startOwner.type == CCType.VISIBLE && (endLocation.cardList.type == CCType.INVISIBLE || endLocation.cardList.type == CCType.HIDDEN))
                    {
                        //Console.WriteLine("Hiding a card that is known!!! " + startLocation.cardList.name + " -> " + endLocation.cardList.name);
                        endLocation.cardList.AddKnown(startCard);
                    }
                    if (endOwner.type == CCType.VISIBLE && (startLocation.cardList.type == CCType.INVISIBLE || startLocation.cardList.type == CCType.HIDDEN))
                    {
                        //Console.WriteLine("Hiding a card that is known!!! " + startLocation.cardList.name + " -> " + endLocation.cardList.name);
                        startLocation.cardList.AddKnown(startCard);
                    }
                    
                }

            }
            Debug.WriteLine("Swapped Cards '" + startCard + " to " + endLocation.locIdentifier);

            complete = true;
            return data;
        }

        public override void Undo()
        {
            if (complete)
            {
                Debug.WriteLine("Undoing FancyCardSwapAction. Putting them back.");
                startLocation.Remove();
                endLocation.Remove();
                startLocation.Add(startCard);
                endLocation.Add(endCard);
                startCard.Owner = startOwner;
                endCard.Owner = endOwner;
                if (actuallocStart)
                {
                    startOwner.Add(startCard, startIdx);
                }
                if (actuallocEnd)
                {
                    endOwner.Add(endCard, endIdx);
                }
            }
            else
            {
                Debug.WriteLine("swap has not been executed yet");
                throw new NotSupportedException();
            }
        }
        public override string ToString()
        {
            return "CardSwapAction: StartLocation: " + startLocation.name + "; EndLocation: " + endLocation.name;
        }
    }

}