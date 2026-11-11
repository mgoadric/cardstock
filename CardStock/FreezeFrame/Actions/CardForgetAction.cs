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

            data["action"] = prefix;
            data["location"] = location.cardList.ToJSON();
        }
        public override Dictionary<string, object> Execute(bool inChoice = false)
        {
            notforgotten.Add(location.Remove());
            return data;
        }
        public override void Undo()
        {
            location.Add(notforgotten.Remove());
        }
    }
}