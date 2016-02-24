using System.Collections.Generic;
using System;
using Players;
namespace CardEngine
{
	public class Player{
		public RawStorage storage;
		public CardStorage cardBins;
		public Team team;
		public GeneralPlayer decision;
		public Player(){
			storage = new RawStorage();
			cardBins = new CardStorage();
			cardBins.owner = this;
		}
		public void CopyStructure(Player other){
			other.storage = storage.Clone ();
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
			string ret = "Player:\n";
			foreach (var card in cardBins.storage[0].AllCards()){
				ret += "Card:" + card.ToString() + "\n";
			}
			return ret;
		}
	}
}
