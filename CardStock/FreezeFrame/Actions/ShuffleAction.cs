using System.Text.Json;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
    public class ShuffleAction(CardLocReference location, Logger script) : GameAction("shuffle", script)
    {
        private readonly CardLocReference location = location;
        private readonly CardCollection unshuffled = new(CCType.VIRTUAL);

        public override Dictionary<string, object> Execute(bool inChoice = false)
        {
            foreach (Card c in location.cardList.AllCards())
            {
                unshuffled.Add(c);
            }
            location.cardList.Shuffle();

            var data = new Dictionary<string, object>
            {
                ["action"] = prefix,
                ["location"] = location.cardList.ToJSON(),
            };
            script?.WriteToJSON(data);
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
        public override string ToString()
        {
            return "ShuffleAction. Location: " + location.name;
        }
    }
}