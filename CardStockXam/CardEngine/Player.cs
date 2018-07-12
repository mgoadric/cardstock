using System.Collections.Generic;
using System;
using Players;
using System.Text;
namespace CardEngine
{
	public class Player{
		public RawStorage storage;
		public CardStorage cardBins; 
		public Team team; // Don't Include this in compare method
        public string name; // Don't Include this
		public GeneralPlayer decision; // Don't include this
		public Player(){
			storage = new RawStorage();
			cardBins = new CardStorage();
			cardBins.owner = this;
		}
		public Player Clone(){
            Player other = new Player();
			other.storage = storage.Clone ();
			other.cardBins = cardBins.Clone ();
            other.name = name;
			other.cardBins.owner = other;
            other.decision = decision;
            return other;
		}
		public void IncrValue(int bin, int value){ // is the bin always the same across all players?
			storage.storage[bin] += value;
		}
		public Card RemoveCard(int idx){
			return cardBins.storage[idx].Remove();
		}
		public int MakeAction(List<GameAction> possibles,Random rand){
			return rand.Next(0,possibles.Count);
		}
		public override string ToString(){
			StringBuilder ret = new StringBuilder("Player:\n");
			ret.Append (cardBins.ToString ());
			return ret.ToString();
		}
        public bool CompareTo(Player other) // Needs to be tested
        {
            for (int i = 0; i <= storage.storage.Length; i++) // Compare their "Storage Locations"
                if (storage.storage[i] != other.storage.storage[i])
                {
                    return false;
                }

            if (!CountCompare(other.cardBins.binCounter)) { return false; } // Compare Card Collection Size

            for (int i = 0; i <= cardBins.binCounter; i++) // Compare Cards // storage is probably 32 long
            {
                bool missing = true;
                for (int j = 0; j <= other.cardBins.storage.Length; j++)
                {
                    if (cardBins.storage[i].ToString() == other.cardBins.storage[j].ToString())
                        { missing = false; }
                }

                if (missing)
                { return false; }
            }
            // If we didn't return false, then the cards are all there, and same
            return true;
        }

        public bool CountCompare(int othercount) // Compares card collection size
        {
            return cardBins.binCounter == othercount;
        }

	}
}
