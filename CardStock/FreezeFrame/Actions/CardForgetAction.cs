using System.Diagnostics;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
        public class CardForgetAction : GameAction
    {
        private readonly CardLocReference location;
        private readonly CardCollection notforgotten;

        public CardForgetAction(CardLocReference loc, Logger script) : base("forget", script)
        {
            if (loc.cardList.type == CCType.MEMORY)
            {
                location = loc;
                notforgotten = new CardCollection(CCType.VIRTUAL);
            }
            else
            {
                Debug.WriteLine(loc.name);
                throw new InvalidOperationException();
            }
        }
        public override Dictionary<string, object> Execute(bool inChoice = false)
        {
            notforgotten.Add(location.Remove());
            var data = new Dictionary<string, object>
            {
                ["action"] = prefix,
                ["location"] = location.cardList.ToJSON(),
            };
            //script?.WriteToJSON(data);
            return data;
        }
        public override void Undo()
        {
            location.Add(notforgotten.Remove());
        }
        public override string ToString()
        {
            return "CardForgetAction: To be removed: " + location.name;
        }
    }

}