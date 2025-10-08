using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
    public class ShuffleAction : GameAction
    {
        private readonly CardLocReference locations;
        private readonly CardCollection unshuffled;

        public ShuffleAction(CardLocReference locations, Logger script) : base('O', script)
        {
            this.locations = locations;
            unshuffled = new CardCollection(CCType.VIRTUAL);
        }

        public override void Execute()
        {
            foreach (Card c in locations.cardList.AllCards())
            {
                unshuffled.Add(c);
            }
            locations.cardList.Shuffle();
            script?.WriteToFile(prefix + ":" + locations.name);
        }
        public override void Undo()
        {
            locations.cardList.Clear();
            foreach (Card c in unshuffled.AllCards())
            {
                locations.Add(c);
            }
        }
        public override string ToString()
        {
            return "ShuffleAction. Location: " + locations.name;
        }
    }
}