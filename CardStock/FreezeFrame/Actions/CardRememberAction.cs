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
        public override Dictionary<string, object> Execute(bool inChoice = false)
        {
            var cardToCopy = startLocation.Get();
            var owner = cardToCopy.Owner;

            var data = new Dictionary<string, object>();
            if (script is not null)
            {
                data["action"] = prefix;
                data["origin"] = new Dictionary<string, object> {
                    ["location"] = owner.ToJSON(),
                    ["index"] = owner.IndexOf(cardToCopy)
                };
                data["destination"] = new Dictionary<string, object> {
                    ["location"] = endLocation.cardList.ToJSON(),
                    ["index"] = endLocation.locIdentifier == CardLocTypes.NUMBER ? endLocation.locid : 
                                    endLocation.locIdentifier == CardLocTypes.BOTTOM ? 0 :
                                    endLocation.cardList.Count 
                };
            }

            endLocation.Add(cardToCopy);
            if (!inChoice) {
                script?.AddToMovementFile(cardToCopy.Owner, endLocation.cardList);
            }
            return data;
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