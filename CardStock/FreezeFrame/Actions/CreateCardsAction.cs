using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
    
    public class CreateCardsAction : GameAction {
        readonly CardCollection location;
        readonly CardCollection before = new(CCType.VIRTUAL);
        readonly CardTree deck;
        readonly string name;
        public CreateCardsAction(CardCollection loc, CardTree d, string n, CardGame cg, Logger script) : base('D', script)
        {
            location = loc;
            deck = d;
            name = n;
            this.cg = cg;
        }
        public override void Execute() {
            foreach (Card c in location.AllCards())
            {
                before.Add(c);
            }
            cg.SetDeck(deck, location, name, script);
        }
        public override void Undo()
        {
            location.Clear();
            foreach (Card c in before.AllCards())
            {
                location.Add(c);
            }
        }
		public override string ToString()
		{
            return "CreateCardsAction: " + "Location: " + location.name + "; Cards: " + location.AllCards();
		}
    }
}