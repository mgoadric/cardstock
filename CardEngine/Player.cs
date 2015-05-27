using System.Collections.Generic;
using System;
namespace CardEngine
{
	public class Player{
		public RawStorage storage;
		public CardStorage cardBins;
		public Team team;
		
		public Player(){
			storage = new RawStorage();
			cardBins = new CardStorage();
		}
		
		public void IncrValue(int bin, int value){
			storage.storage[bin] += value;
		}
		public void AddCard(Card c,int idx){
			cardBins.storage[idx].Add(c);
		}
		public Card RemoveCard(int idx){
			return cardBins.storage[idx].Remove();
		}
		public int MakeAction(List<GameAction> possibles,Random rand){
			
			return rand.Next(0,possibles.Count);
		}
		public override string ToString(){
			string ret = "Player:\n";
			foreach (var card in cardBins.storage[0].AllCards()){
				ret += "Card:" + card.ToString() + "\n";
			}
			return ret;
		}
	}
}