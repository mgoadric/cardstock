using System.Collections.Generic;
using System;
using Players;
using System.Text;
namespace CardEngine
{
	public class Player{
		public RawStorage storage;
		public CardStorage cardBins;
		public Team team;
        public string name;
		public GeneralPlayer decision;
        public Player() {
            storage = new RawStorage() { owner = this };
			cardBins = new CardStorage();
			cardBins.owner = this;
		}
		public void CopyStructure(Player other){
			other.storage = storage.Clone ();
            other.name = name;
			other.cardBins = cardBins.Clone ();
			other.cardBins.owner = other;
		}
		public void IncrValue(int bin, int value){
			storage.storage[bin] += value;
		}
		public void AddCard(Card c,string cardLocation){
			cardBins[cardLocation].Add(c);
		}
		public Card RemoveCard(int idx){
			return cardBins.storage[idx].Remove();
		}
		public int MakeAction(List<GameAction> possibles,Random rand){
			
			return rand.Next(0,possibles.Count);
		}
//		public int MakeAction(List<GameActionCollection> possibles,Random rand){
//			
//			return rand.Next(0,possibles.Count);
//		}
		public override string ToString(){
			StringBuilder ret = new StringBuilder("Player:\n");
			ret.Append (cardBins.ToString ());
			return ret.ToString();
		}

        public string ToOutputString(int idx){
            StringBuilder ret = new StringBuilder("P" + idx);
            ret.Append(cardBins.ToOutputString());
            return ret.ToString();
        }
	}
}
