using System.Diagnostics;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{

    public class CardMoveAction : GameAction
    {
        public CardLocReference startLocation;
        public CardLocReference endLocation;
        public CardCollection owner;
        public Card cardToMove;
        public bool actualloc;
        public int ownerIndex;
        public CardMoveAction(CardLocReference start, CardLocReference end, Transcript script) : base('M', script)
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

            if (start.cardList.type == CCType.VISIBLE && end.cardList.type != CCType.VISIBLE)
            {
                //Console.WriteLine("Hiding a card that is known!!! " + start.cardList.name + " -> " + end.car);
            }
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

                    Debug.WriteLine("Moved Card '" + cardToMove + " to " + endLocation.locIdentifier);

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
                    throw new Exception();
                }
                startLocation.Add(cardToMove);

                // Is this going back in the right index location? I DON'T THINK SO
                // I think it is always at the end of the list??
                // Does it matter? I THINK SO
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