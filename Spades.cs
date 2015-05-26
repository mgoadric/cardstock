using System.Collections.Generic;
using System;
using CardEngine;
using System.Linq;
using System.Collections;
using System.Diagnostics;

public class Spades{
	

	public Spades(){
		
		// PREAMBLE: Define the DECK of cards based on a tree structure
		var red = new Node{
			Value = "red",
			children = new List<Node>{
				new Node{Value="hearts"},
				new Node{Value= "diamonds"}
			}
		};
		var black = new Node{	
			Value = "black",
			children = new List<Node>{
				new Node{Value="clubs"},
				new Node{Value="spades"}	
			}
		};
		var ranks = new Node{
			Value = "rank",
			children = new List<Node>{
			new Node{Value="2"},new Node{Value="3"},new Node{Value="4"},
			new Node{Value="5"},new Node{Value="6"},new Node{Value="7"},new Node{Value="8"},new Node{Value="9"},new Node{Value="10"},
			new Node{Value="J"},new Node{Value="Q"},new Node{Value="K"},new Node{Value="A"}
			}
		};
		Tree t = new Tree{
			rootNode = new Node{
				Value="Attrs",
				children = new List<Node>{
					new Node{
						Value = "colors",
						children = new List<Node>{
							red,black
						}
					},
					ranks
				}
			}
		};
		
		// Here for timing estimates right now
		Stopwatch time = new Stopwatch();
		time.Start();
		
		// READ NUMBER OF PLAYERS and CREATE THE GAME
		int numPlayers = 4;
		var game = new CardGame(numPlayers);
		game.SetDeck(t);
		
		//Instantiate Player Decks and Play Areas
		foreach (var player in game.players){
			player.cardBins.storage[0] = new CardListCollection();
			player.cardBins.storage[1] = new CardStackCollection();
		}
		
		// Establish PRECEDENCE for the cards.
		List<CardFilter> precGen = new List<CardFilter>();
		
		var suits = new List<string>{"spades","LEAD"};
		var rankIter = new List<string>{"A","K","Q","J","10","9","8","7","6","5","4","3","2"};
		
		foreach (var suit in suits){
			foreach (var rank in rankIter){
				precGen.Add(new CardFilter(new List<TreeExpression>{
					new TreeExpression(new List<int>{
						0
					},suit,true,"suit"),
					new TreeExpression(new List<int>{
						1
					},rank,true,"rank")
				}));
			}
		}
		
		var suitTraversal = new TreeTraversal(new List<int>{
			0
		});
		var rankTraversal = new TreeTraversal(new List<int>{
			1
		});
		var suitDict = new Dictionary<string,HashSet<Card>>();
		var rankDict = new Dictionary<string,HashSet<Card>>();
		var comboDict = new Dictionary<string, Card>();
		foreach (var card in game.sourceDeck){
			var suit = suitTraversal.ReadValue(card);
			
			if (suitDict.ContainsKey(suit)){
				suitDict[suit].Add(card);
			}
			else{
				suitDict.Add(suit,new HashSet<Card>{card});
			}
			
			var rank = rankTraversal.ReadValue(card);
			
			if (rankDict.ContainsKey(rank)){
				rankDict[rank].Add(card);
			}
			else{
				rankDict.Add(rank,new HashSet<Card>{card});
			}
			
			comboDict.Add(suit + rank,card);
		}
		
		// STAGE 0: SETUP
		game.DealEvery(13);
		
		Dictionary<String, int> StoreNames = new Dictionary<String, int>{
			{"SPADESBROKEN", 0},
			{"PLAYERTURN", 1},
			{"CURRENTPLAYER", 2},
			{"CURRENTHAND", 3}	
		};
		
		game.SetValue(StoreNames["SPADESBROKEN"], 0);//SPADES BROKEN = FALSE
		game.SetValue(StoreNames["PLAYERTURN"], 0);//Play Turn within hand
		game.SetValue(StoreNames["CURRENTPLAYER"], 0);//Current Players Turn
		game.SetValue(StoreNames["CURRENTHAND"], 0);//Current Hand
		
		var noSpades = new CardFilter(new List<TreeExpression>{
			new TreeExpression(new List<int>{
				0
			},"spades",false,"suit")
		});
				
		// STAGE 1: PLAY ROUNDS UNTIL ALL CARDS USED
		bool stage1Complete = false;
		while (!stage1Complete){
			
			// STAGE 1 END CONDITION
			if (game.GetValue(StoreNames["CURRENTHAND"]) == 13) {
				stage1Complete = true;
			} else {
				
				// STAGE 1.1: EACH PLAYER PLAYS ONE CARD
				if (game.GetValue(StoreNames["PLAYERTURN"]) == 0){
					var played = game.PlayerRevealCard(game.GetValue(StoreNames["CURRENTPLAYER"]),noSpades);
					if (!played){
						game.PlayerRevealCard(game.GetValue(StoreNames["CURRENTPLAYER"]),new CardFilter(new List<TreeExpression>()));
					}			
				}
				else{
					var followSuit = new CardFilter(new List<TreeExpression>{
					new TreeExpression(new List<int>{
					0
					},game.players[(game.GetValue(StoreNames["CURRENTPLAYER"]) - game.GetValue(StoreNames["PLAYERTURN"]) + 4) % 4].visibleCards[game.GetValue(StoreNames["CURRENTHAND"])].attributes.children[0].Value,true,"suit")
			});
					var played = game.PlayerRevealCard(game.GetValue(StoreNames["CURRENTPLAYER"]),followSuit);
					if (!played){
						game.PlayerRevealCard(game.GetValue(StoreNames["CURRENTPLAYER"]),new CardFilter(new List<TreeExpression>()));
					}
				}
				game.IncrValue(StoreNames["PLAYERTURN"], 1);
				game.SetValue(StoreNames["CURRENTPLAYER"],(game.GetValue(StoreNames["CURRENTPLAYER"]) + 1) % 4);
				if (game.GetValue(1) == 4){
					var precendence = new List<CardFilter>();
					foreach (var filter in precGen){
						precendence.Add(filter.Copy());
					}
					foreach (var filter in precendence){
						foreach (var treeDirection in filter.filters){
							if (treeDirection.expectedValue == "LEAD"){
								treeDirection.expectedValue = game.players[(game.GetValue(StoreNames["CURRENTPLAYER"]) - game.GetValue(StoreNames["PLAYERTURN"]) + 4) % 4].visibleCards[game.GetValue(StoreNames["CURRENTHAND"])].attributes.children[0].Value;
								//Console.WriteLine("treeValue:" + treeDirection.expectedValue);
							}
						}
					}
					
					var orderedCards = new List<Card>();
					foreach (var filter in precendence){
						//Approaches N time
						var suit = filter.filters.Where(obj => obj.indexLabel == "suit").FirstOrDefault().expectedValue;
						var rank = filter.filters.Where(obj => obj.indexLabel == "rank").FirstOrDefault().expectedValue;
						
						//direct method
						var card = comboDict[suit + rank];
						orderedCards.Add(card);
						
						//Intersect method
						
						/*
						var suitSet = suitDict[suit];
						var rankSet = rankDict[rank];
						
						var inter = suitSet.Intersect(rankSet);
						
						orderedCards.Add(inter.First());
						*/
						
						/*foreach (var card in game.sourceDeck){//N^2 Algorithm
							if (filter.CardConforms(card)){
								orderedCards.Add(card);
							}
						}*/
					}
					
					foreach (var card in orderedCards){
						//Console.WriteLine("Card:" + card.ToString());
					}
					
					// Determine who won the trick
					
					var winningPlayer = 0;
					var winningIdx = int.MaxValue;
					for (int i = 0; i < numPlayers; ++i){
						//Console.WriteLine("PrecIdx:" + );
						var player = game.players[i];
						var precedenceIdx = orderedCards.IndexOf(player.visibleCards[player.visibleCards.Count - 1]);
						if (precedenceIdx >= 0 && precedenceIdx < winningIdx){
							winningPlayer = i;
							winningIdx = precedenceIdx;
						}
					}
					Console.WriteLine("Winner: Player " + (winningPlayer + 1));
					foreach (var p in game.players){
						Console.Write("Player:" + p.visibleCards[p.visibleCards.Count - 1].ToString() + "\n");
					}
					game.SetValue(StoreNames["PLAYERTURN"], 0);//Runs 0->3 everytime
					game.SetValue(StoreNames["CURRENTPLAYER"], winningPlayer);//Should be winner
					game.IncrValue(StoreNames["CURRENTHAND"], 1);//Current Hand
				}
			}
			
		}
		time.Stop();
		Console.WriteLine("Elapsed:" + time.Elapsed);
	}
	
}