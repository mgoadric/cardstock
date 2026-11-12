using System.Text.Json;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
    public class ShuffleAction : GameAction
    {
        private readonly CardLocReference location;
        private readonly CardCollection unshuffled = new(CCType.VIRTUAL);

        public ShuffleAction(CardLocReference location, Logger script) : base("shuffle", script)
        {
            this.location = location;
        }

        public override Dictionary<string, object> Execute(bool inChoice = false)
        {
            foreach (Card c in location.cardList.AllCards())
            {
                unshuffled.Add(c);
            }
            location.cardList.Shuffle();

            return Data();
        }

        public override Dictionary<string, object> Data(bool inChoice = false)
        {
            Dictionary<string, object> data = [];
            data["action"] = prefix;
            data["location"] = location.cardList.ToJSON();
            return data;
        }

        public override void Undo()
        {
            location.cardList.Clear();
            foreach (Card c in unshuffled.AllCards())
            {
                location.Add(c);
            }
        }
    }
}