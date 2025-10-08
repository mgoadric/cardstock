using System.Diagnostics;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
        public class CardForgetAction : GameAction
    {
        private readonly CardLocReference endLocation;
        private readonly CardCollection notforgotten;

        public CardForgetAction(CardLocReference end, Logger script) : base('F', script)
        {
            if (end.cardList.type == CCType.MEMORY)
            {
                endLocation = end;
                notforgotten = new CardCollection(CCType.VIRTUAL);
            }
            else
            {
                Debug.WriteLine(end.name);
                throw new InvalidOperationException();
            }
        }
        public override void Execute()
        {
            notforgotten.Add(endLocation.Remove());
            script?.WriteToFile(prefix + ":" + endLocation.cardList.TranscriptName());
        }
        public override void Undo()
        {
            endLocation.Add(notforgotten.Remove());
        }
        public override string ToString()
        {
            return "CardForgetAction: To be removed: " + endLocation.name;
        }
    }

}