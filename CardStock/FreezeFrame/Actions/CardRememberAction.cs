using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
    
    public class CardRememberAction : GameAction
    {
        readonly CardLocReference startLocation;
        readonly CardLocReference endLocation;
        public CardRememberAction(CardLocReference start, CardLocReference end, Logger script) : base("remember", script)
        {
            startLocation = start;
            endLocation = end;
            if (endLocation.cardList.type != CCType.MEMORY)
            {
                throw new InvalidOperationException();
            }
        }
        public override void Execute()
        {
            var cardToCopy = startLocation.Get();
            var owner = cardToCopy.Owner;
            endLocation.Add(cardToCopy);
            script?.WriteToFile(prefix + ":" + cardToCopy.ToString() + " " + owner.TranscriptName() + "->" + endLocation.cardList.TranscriptName());
            if (!inChoice) {
                script?.AddToMovementFile(cardToCopy.Owner, endLocation.cardList);
            }
        }
        public override void Undo()
        {
            endLocation.Remove();
        }
        public override string ToString()
        {
            return "CardRememberAction: Starting loaction: " + startLocation.name + "; Ending location: " + endLocation.name;
        }
    }


}