using System.Diagnostics;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
        public class CardSwapAllAction : GameAction
    {
        public CardLocReference startLocation;
        public CardLocReference endLocation;

        public CardSwapAllAction(CardLocReference start, CardLocReference end, Logger script) : base("swapall", script)
        {
            if (start.cardList.type == CCType.MEMORY)
            {
                Console.WriteLine("start is a mem loc " + start.name + ", " + end.name);
                throw new NotSupportedException();
            }
            if (start.cardList.type == CCType.VIRTUAL)
            {
                Debug.WriteLine("start is a virtual loc " + start.name + ", " + end.name);
                throw new NotSupportedException();
            }
            if (end.cardList.type == CCType.VIRTUAL)
            {
                Debug.WriteLine("end is a virtual loc " + start.name + ", " + end.name);
                throw new NotSupportedException();
            }
            if (end.cardList.type == CCType.MEMORY)
            {
                Console.WriteLine("end is a mem loc");
                throw new NotSupportedException();
            }
            startLocation = start;
            endLocation = end;

            if (start.cardList.type == CCType.VISIBLE && end.cardList.type != CCType.VISIBLE)
            {
                //Console.WriteLine("Hiding a card that is known!!! " + start.cardList.name + " -> " + end.car);
            }
        }

        public override void Execute(bool inChoice = false)
        {
            try
            {
                if (startLocation.Count() != 0 && endLocation.Count() != 0)
                {
                    Queue<Card> temp = new();  
                    foreach (var card in startLocation.cardList.AllCards())
                    {
                        temp.Enqueue(card);
                    }
                    startLocation.cardList.Clear();
                    foreach (var card in endLocation.cardList.AllCards())
                    {
                        startLocation.cardList.Add(card);
                        card.Owner = startLocation.cardList;
                        if (!inChoice) {
                            script?.AddToMovementFile(endLocation.cardList, startLocation.cardList);
                        }
                    }
                    endLocation.cardList.Clear();
                    foreach (var card in temp)
                    {
                        endLocation.cardList.Add(card);
                        card.Owner = endLocation.cardList;
                        if (!inChoice) {
                            script?.AddToMovementFile(startLocation.cardList, endLocation.cardList);
                        }
                    }

                    Debug.WriteLine("loc Counts " + startLocation.Count() + ", " + endLocation.Count());

                    var arrow = " <-> ";
                    if (inChoice) { arrow = " ?<-> "; }

                    script?.WriteToFile(prefix + ":" + startLocation + arrow + endLocation);
                    if (!inChoice) {
                        script?.AddToMovementFile(startLocation.cardList, endLocation.cardList);
                    }
                    Debug.WriteLine("Swapped Cards from'" + startLocation + " to " + endLocation);

                    // Track here to see if it moved from a visible to invisible location TODO
                    // Then record the invisible as the last known location.
                }
                else
                {
                    Console.WriteLine("error: attempting to swap from empty location " + startLocation.ToString()); //TODO debug here
                    Console.WriteLine("swapping to " + endLocation.ToString());
                    throw new Exception();
                }
            }
            catch
            {
                Debug.WriteLine(startLocation.name);
                foreach (var card in startLocation.cardList.AllCards())
                {
                    Debug.WriteLine(card);
                }
                throw;
            }
            complete = true;
        }

        public override void Undo()
        {
            if (complete)
            {
                Queue<Card> temp = new();  
                foreach (var card in startLocation.cardList.AllCards())
                {
                    temp.Enqueue(card);
                }
                startLocation.cardList.Clear();
                foreach (var card in endLocation.cardList.AllCards())
                {
                    startLocation.cardList.Add(card);
                    card.Owner = startLocation.cardList;
                }
                endLocation.cardList.Clear();
                foreach (var card in temp)
                {
                    endLocation.cardList.Add(card);
                    card.Owner = endLocation.cardList;
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
            return "CardSwapAllAction: StartLocation: " + startLocation.name + "; EndLocation: " + endLocation.name;
        }
    }
}