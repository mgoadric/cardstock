using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
    
    public class CreateCardsAction : GameAction {
        private readonly CardCollection location;
        private readonly CardTree deck;
        private List<Dictionary<string, object>> fullDeck;
        private readonly string name;
        public CreateCardsAction(CardCollection loc, CardTree d, string n, CardGame cg, Logger script) : base("createcards", script)
        {
            location = loc;
            deck = d;
            name = n;
            this.cg = cg;
        }
        public override Dictionary<string, object> Execute(bool inChoice = false)
        {
            fullDeck = cg.SetDeck(deck, location, name, script);

                    
            script?.AddStart(location.MovementName());
            return Data();
        }
        public override Dictionary<string, object> Data(bool inChoice = false)
        {
            if (fullDeck is null)
            {
                throw new Exception("Execute not called yet, deck not created!");
            }
            var data = new Dictionary<string, object>
            {
                ["action"] = prefix,
                ["cards"] = fullDeck,
                ["location"] = location.ToJSON()
            };
            return data;
        }
        public override void Undo()
        {
            // This should only be called in the setup
            // you don't create cards as part of a game...
            throw new NotImplementedException();
        }
    }
}