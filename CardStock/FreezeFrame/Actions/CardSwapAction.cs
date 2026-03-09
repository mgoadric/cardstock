using System.Diagnostics;
using CardStock.CardEngine;
using CardStock.Evaluation;

namespace CardStock.FreezeFrame.Actions
{
    
    public class CardSwapAction : GameAction
    {
        public CardLocReference startLocation;
        public CardLocReference endLocation;
        public CardCollection owner1;
        public CardCollection owner2;
        public Card card1;
        public Card card2;
        public bool actualloc1;
        public bool actualloc2;
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
                actualloc1 = true;
            }
            if (end.cardList.type == CCType.VIRTUAL)
            {
                actualloc2 = true;
            }

            startLocation = start;
            endLocation = end;
        }

        public override Dictionary<string, object> Execute(bool inChoice = false)
        {
            try
            {
                if (startLocation.Count() != 0 && endLocation.Count() != 0)
                {
                    var data = new Dictionary<string, object>();
                    if (script is not null)
                    {
                        data["action"] = prefix;
                        card1 = startLocation.Get();
                        owner1 = card1.Owner;
                        data["first"] = new Dictionary<string, object> {
                            ["card"] = card1.ToJSON(),
                            ["location"] = owner1.ToJSON(),
                            ["index"] = owner1.IndexOf(card1)
                        };
                        card2 = startLocation.Get();
                        owner2 = card2.Owner;
                        data["second"] = new Dictionary<string, object> {
                            ["card"] = card2.ToJSON(),
                            ["location"] = owner2.ToJSON(),
                            ["index"] = owner2.IndexOf(card2)
                        };
                    }

                    card1 = startLocation.Remove();
                    card2 = endLocation.Remove();
                    startLocation.Add(card2);
                    endLocation.Add(card1);
                    owner1 = card1.Owner;
                    owner2 = card2.Owner;
                    card1.Owner = owner2;
                    card2.Owner = owner1;
                    if (actualloc1)
                    {
                        owner1.Add(card2);
                    }
                    if (actualloc2)
                    {
                        owner2.Add(card1);
                    }

                    if (!inChoice) {
                        script?.AddToMovementFile(owner1, owner2);
                        script?.AddToMovementFile(owner2, owner1);

                        // Track here to see if either moved from a visible to invisible location TODO
                        // Then record the invisible as the last known location.
                        // SHOULD THIS BE HERE, OR ANOTHER FUNCTION??
                        if (GameSimulator.exp!.imperfectLevel >= ImperfectLevel.TAKEN)
                        {
                            // FIND BETTER WAY THAN COPY/PASTA

                            if (owner1.type == CCType.INVISIBLE || owner1.type == CCType.HIDDEN)
                            {
                                if (endLocation.cardList.type == CCType.VISIBLE)
                                {
                                    owner1.RemoveKnown(card1);
                                }
                                else 
                                {         
                                    //Console.WriteLine("Clearing out " + startLocation.cardList.name);
                                    owner1.ClearKnown();
                                }
                            }
                            if (owner2.type == CCType.INVISIBLE || owner2.type == CCType.HIDDEN)
                            {
                                if (startLocation.cardList.type == CCType.VISIBLE)
                                {
                                    owner2.RemoveKnown(card1);
                                }
                                else 
                                {         
                                    //Console.WriteLine("Clearing out " + startLocation.cardList.name);
                                    owner2.ClearKnown();
                                }
                            }
                            if (owner1.type == CCType.VISIBLE && (endLocation.cardList.type == CCType.INVISIBLE || endLocation.cardList.type == CCType.HIDDEN))
                            {
                                //Console.WriteLine("Hiding a card that is known!!! " + startLocation.cardList.name + " -> " + endLocation.cardList.name);
                                endLocation.cardList.AddKnown(card1);
                            }
                            if (owner2.type == CCType.VISIBLE && (startLocation.cardList.type == CCType.INVISIBLE || startLocation.cardList.type == CCType.HIDDEN))
                            {
                                //Console.WriteLine("Hiding a card that is known!!! " + startLocation.cardList.name + " -> " + endLocation.cardList.name);
                                startLocation.cardList.AddKnown(card1);
                            }
                            
                        }

                    }
                    Debug.WriteLine("Swapped Cards '" + card1 + " to " + endLocation.locIdentifier);

                    complete = true;
                    return data;
                }
                else
                {
                    Console.WriteLine("error: attempting to move from empty location " + startLocation.ToString()); //TODO debug here
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
        }

        public override void Undo()
        {
            if (complete)
            {
                Debug.WriteLine("Undoing FancyCardSwapAction. Putting them back.");
                card1 = startLocation.Remove();
                card2 = endLocation.Remove();
                startLocation.Add(card2);
                endLocation.Add(card1);
                owner1 = card1.Owner;
                owner2 = card2.Owner;
                card1.Owner = owner2;
                card2.Owner = owner1;
                if (actualloc1)
                {
                    owner1.Add(card2);
                }
                if (actualloc2)
                {
                    owner2.Add(card1);
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