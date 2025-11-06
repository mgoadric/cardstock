using System.Diagnostics;
using System.Security.Cryptography;
using CardStock.CardEngine;
using CardStock.Evaluation;

namespace CardStock.FreezeFrame.Actions
{

    public class CardMoveAction : GameAction
    {
        public CardLocReference startLocation;
        public CardLocReference endLocation;
        public CardCollection oldOwner;
        public CardCollection owner;
        public Card cardToMove;
        public bool actualloc;
        public int ownerIndex;
        public CardMoveAction(CardLocReference start, CardLocReference end, Logger script) : base('M', script)
        {
            if (start.cardList.type == CCType.MEMORY)
            {
                Debug.WriteLine("start is a mem loc " + start.name + ", " + end.name);
                throw new NotSupportedException();
            }
            if (start.cardList.type == CCType.VIRTUAL)
            {
                Debug.WriteLine("start is a virtual loc " + start.name + ", " + end.name);
                actualloc = true;
            }
            if (end.cardList.type == CCType.VIRTUAL || end.cardList.type == CCType.MEMORY)
            {
                Debug.WriteLine("end is not physical");
                throw new NotSupportedException();
            }
            startLocation = start;
            endLocation = end;
        }

        public override void Execute()
        {
            try
            {
                if (startLocation.Count() != 0)
                {
                    cardToMove = startLocation.Remove();

                    endLocation.Add(cardToMove);
                    owner = cardToMove.Owner;
                    cardToMove.Owner = endLocation.cardList;

                    var arrow = " -> ";
                    if (inChoice) { arrow = " ?-> "; }

                    script?.WriteToFile(prefix + ":" + cardToMove.ToString() + " " + owner.TranscriptName() + arrow + endLocation.cardList.TranscriptName());

                    Debug.WriteLine("Moved Card '" + cardToMove + " to " + endLocation);

                    if (!inChoice) {
                        script?.AddToMovementFile(owner, endLocation.cardList);
                        if (GameSimulator.imperfectLevel >= ImperfectLevel.TAKEN)
                        {
                            if (owner.type == CCType.VISIBLE && (endLocation.cardList.type == CCType.INVISIBLE || endLocation.cardList.type == CCType.HIDDEN))
                            {
                                //Console.WriteLine("Hiding a card that is known!!! " + startLocation.cardList.name + " -> " + endLocation.cardList.name);
                                endLocation.cardList.AddKnown(cardToMove);
                            }
                            if (owner.type == CCType.INVISIBLE || startLocation.cardList.type == CCType.HIDDEN)
                            {
                                //Console.WriteLine("Clearing out " + startLocation.cardList.name);
                                if (endLocation.cardList.type == CCType.VISIBLE)
                                {
                                    owner.RemoveKnown(cardToMove);
                                }
                                else
                                {
                                    owner.ClearKnown();
                                }
                            }
                        }
                    }
                    // Track here to see if it moved from a visible to invisible location TODO
                    // Then record the invisible as the last known location.
                }
                    else
                    {
                        Console.WriteLine("error: attempting to move from empty location " + startLocation.ToString()); //TODO debug here
                        Console.WriteLine("moving to " + endLocation.ToString());
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
                Debug.WriteLine("Undoing FancyCardMoveAction. Putting back in: " + startLocation.name);
                var cardFound = endLocation.Remove();
                if (cardFound != cardToMove)
                {
                    Console.WriteLine("Cards are not equal!!!");
                    Console.WriteLine("Undoing move Card '" + cardToMove + " to " + endLocation + " but found " + cardFound);
                    throw new Exception();
                }
                startLocation.Add(cardToMove);

                // Is this going back in the right index location? I DON'T THINK SO
                // I think it is always at the end of the list??
                // Does it matter? I THINK SO
                // WHAT? Testing and they are equal before and after??? Weird.
                // Then what is causing the problems??
                if (actualloc)
                {
                    owner.Add(cardToMove);
                }
                cardToMove.Owner = owner;
            }
            else
            {
                Debug.WriteLine("move has not been executed yet");
                throw new NotSupportedException();
            }
        }
        public override string ToString()
        {
            return "CardMoveAction: StartLocation: " + startLocation.name + "; EndLocation: " + endLocation.name;
        }
    }

}