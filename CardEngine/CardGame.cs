using System;
using System.Collections.Generic;

namespace CardEngine
{
	public class CardGame{
		public Random rand = new Random();
		public List<Card> sourceDeck = new List<Card>();
		public CardStorage tableCards = new CardStorage();
		public List<Player> players = new List<Player>();
		public List<Team> teams = new List<Team>();
		public RawStorage gameStorage = new RawStorage();
		public CardGame(int numPlayers){
			
			for (int i = 0; i < numPlayers; ++i){
				players.Add(new Player());
			}
			
			//var first = new Card();
		}
		public void SetDeck(Tree cardAttributes){
			var combos = cardAttributes.combinations();
			foreach (var combo in combos){
				sourceDeck.Add(new Card(combo));
			}
		}
		public void PopulateLocation(string cardLocation){
			var location = tableCards[cardLocation];
			foreach (var card in sourceDeck){
				location.Add(card);
			}
		}
		public void DealEvery(int numCards,string cardLocation,string destination){
			var location = tableCards[cardLocation];
			foreach (var player in players){
				for (int i = 0; i < numCards; ++i){
					player.AddCard(location.Remove(),destination);
				}
			}
		}
		public void SetValue(int idx, int value){
			gameStorage.storage[idx] = value;
		}
		public int GetValue(int idx){
			return gameStorage.storage[idx];
		}
		public void IncrValue(int idx, int incr){
			gameStorage.storage[idx] += incr;
		}
		public void PromptPlayer(Player p, string storageName, int minValue, int maxValue){
			
			var possibles = new List<GameAction>();
			for (int i = minValue; i < maxValue; ++i){
				possibles.Add(new IntAction(p.storage,storageName,i));
			}
			var choice = p.MakeAction(possibles,rand);
			Console.WriteLine("Choice:" + choice);
			possibles[choice].Execute();
			
		}
		public bool PlayerRevealCard(int player, CardFilter filter, string startDeck, string endDeck){
			var p = players[player];
			
			var poss = filter.FilterMatchesAll(p.cardBins[startDeck]);
			if ((new List<Card>(poss.AllCards())).Count !=  0){
				var actions = new List<GameAction>();
				foreach (var c in poss.AllCards()){
					actions.Add(new CardMoveAction(c,p.cardBins[startDeck],p.cardBins[endDeck]));
				}
				var choice = p.MakeAction(actions,rand);
				actions[choice].Execute();
				return true;
			}
			return false;
		}
		public override string ToString(){
			var ret = "Table Deck:\n";
			foreach (var card in tableCards["STOCK"].AllCards()){
				ret += "Card:" + card.ToString() + "\n";
			}
			ret += "Players:\n";
			foreach (var player in players){
				ret += player.ToString() + "\n";
			}
			return ret;
		}
	}
}