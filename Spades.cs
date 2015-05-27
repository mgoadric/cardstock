using System.Collections.Generic;
using System;
using CardEngine;
using System.Linq;
using System.Collections;
using System.Diagnostics;

public class Spades{
	

	public Spades(){
		
		// PREAMBLE: Define the DECK of cards based on a tree structure
		//
		// TODO: Push this code inside the CardGame class, to read a string like below
		// 
		// (tree (rank (2 3 4 5 6 7 8 9 10 J Q K)
		// 		 (color (red (hearts diamonds)
		//		  		(black (clubs spades))))
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
		
		// Set PLAYER card and int storage locations
		foreach (var player in game.players){
			player.storage.AddKey("BID");
			player.storage.AddKey("CURRENTSTATE");
			player.storage.AddKey("TRICKSWON");
			
			player.cardBins.AddKey("HAND");
			player.cardBins.AddKey("TRICK");
		}
		
		// Set TEAMS and Link to PLAYERS
		
		for (int i = 0; i < 2; ++i){
			var team = new Team();
			team.teamStorage.AddKey("SCORE");
			team.teamStorage.AddKey("BAGS");
			team.teamPlayers.Add(game.players[i]);
			team.teamPlayers.Add(game.players[i + 2]);
			game.players[i].team = team;
			game.players[i + 2].team = team;
			game.teams.Add(team);
		}
		
		game.SetDeck(t);
		
		//Instantiate Player Decks and Play Areas
		foreach (var player in game.players){
			player.cardBins["HAND"] = new CardListCollection();
			player.cardBins["TRICK"] = new CardStackCollection();
		}
		
		// Establish PRECEDENCE for the cards.
		//
		// TODO : Push this into game, have this description be flexible to again read from string
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
		
		// STAGE 0: SETUP STORAGE and DEAL
		game.DealEvery(13);
		
		Dictionary<String, int> StoreNames = new Dictionary<String, int>{
			{"SPADESBROKEN", 0},
			{"PLAYERTURN", 1},
			{"CURRENTPLAYER", 2},
			{"CURRENTHAND", 3}	
		};
		foreach (var key in StoreNames.Keys){
			game.gameStorage.AddKey(key);
		}
		game.gameStorage["SPADESBROKEN"] = 0;//SPADES BROKEN = FALSE
		game.gameStorage["PLAYERTURN"] = 0;//Play Turn within hand
		game.gameStorage["CURRENTPLAYER"] = 0;//Current Players Turn
		game.gameStorage["CURRENTHAND"] = 0;//Current Hand
		
		var noSpades = new CardFilter(new List<TreeExpression>{
			new TreeExpression(new List<int>{
				0
			},"spades",false,"suit")
		});
				
		// STAGE 1: BIDDING
		foreach (var player in game.players){
			game.PromptPlayer(player,"BID",0,14);
		}
		foreach (var player in game.players){
			Console.WriteLine("Bid: " + player.storage["BID"]);
		}
		// STAGE 2: PLAY ROUNDS UNTIL ALL CARDS USED
		bool stage2Complete = false;
		while (!stage2Complete){
			
			// STAGE 2 END CONDITION
			if (game.gameStorage["CURRENTHAND"] == 13) {
				stage2Complete = true;
			} else {

				// STAGE 2 SETUP
				game.gameStorage["PLAYERTURN"] = 0;//Runs 0->3 everytime
				
				// STAGE 2_1: EACH PLAYER PLAYS ONE CARD
				bool stage2_1Complete = false;
				while (!stage2_1Complete) {
					
					if (game.gameStorage["PLAYERTURN"] == 4) {
						stage2_1Complete = true;
					} else {
						
						if (game.gameStorage["PLAYERTURN"] == 0){
							var played = game.PlayerRevealCard(game.gameStorage["CURRENTPLAYER"],noSpades,"HAND","TRICK");
							if (!played){
								game.PlayerRevealCard(game.gameStorage["CURRENTPLAYER"],new CardFilter(new List<TreeExpression>()),"HAND","TRICK");
							}			
						}
						else{
							var followSuit = new CardFilter(new List<TreeExpression>{
							new TreeExpression(new List<int>{
							0
							},game.players[(game.gameStorage["CURRENTPLAYER"] - game.gameStorage["PLAYERTURN"] + 4) % 4].cardBins["TRICK"].AllCards().First().attributes.children[0].Value,true,"suit")
					});
							var played = game.PlayerRevealCard(game.gameStorage["CURRENTPLAYER"],followSuit,"HAND","TRICK");
							if (!played){
								game.PlayerRevealCard(game.gameStorage["CURRENTPLAYER"],new CardFilter(new List<TreeExpression>()),"HAND","TRICK");
							}
						}
						
						// STAGE 2_1 WRAPUP
						game.gameStorage["PLAYERTURN"] += 1;
						game.gameStorage["CURRENTPLAYER"] = (game.gameStorage["CURRENTPLAYER"] + 1) % 4;
					}
				}					

				// STAGE 2_2: Determine who WON the trick
				bool stage2_2Complete = false;
				while (!stage2_2Complete) {
					
					// Solidify precedence rules based on LEAD
					var precendence = new List<CardFilter>();
					foreach (var filter in precGen){
						precendence.Add(filter.Copy());
					}
					foreach (var filter in precendence){
						foreach (var treeDirection in filter.filters){
							if (treeDirection.expectedValue == "LEAD"){
								treeDirection.expectedValue = game.players[(game.gameStorage["CURRENTPLAYER"] - game.gameStorage["PLAYERTURN"] + 4) % 4].cardBins["TRICK"].AllCards().First().attributes.children[0].Value;
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
					}
						
						
					// Now, determine who won the trick									
					var winningPlayer = 0;
					var winningIdx = int.MaxValue;
					for (int i = 0; i < numPlayers; ++i){
						//Console.WriteLine("PrecIdx:" + );
						var player = game.players[i];
						var precedenceIdx = orderedCards.IndexOf(player.cardBins["TRICK"].AllCards().First());
						if (precedenceIdx >= 0 && precedenceIdx < winningIdx){
							winningPlayer = i;
							winningIdx = precedenceIdx;
						}
					}
					
					// DEBUG for us to validate game works
					Console.WriteLine("Winner: Player " + (winningPlayer + 1));
					foreach (var p in game.players){
						Console.Write("Player:" + p.cardBins["TRICK"].AllCards().First().ToString() + "\n");
					}
					
					// Reward winning player with 1 TRICK
					game.players[winningPlayer].storage["TRICKSWON"] += 1;
					
					game.gameStorage["CURRENTPLAYER"] =  winningPlayer;//Should be winner
					
					stage2_2Complete = true;
				}

				// STAGE 2 WRAPUP
				game.gameStorage["CURRENTHAND"] += 1;//Current Hand

			}
			
		}
		
		// STAGE 3: DETERMINE SCORE FOR TEAMS OF PLAYERS
		
		
		// DEBUG tricks taken by each
		foreach (var player in game.players){
			Console.WriteLine("Tricks:" + player.storage["TRICKSWON"]);
		}
		
		// DEBUG teams score
		for (int i = 0; i < game.teams.Count; ++i){
			Console.Write("Team " + (i + 1) + " Score: ");
			var total = 0;
			var totalBid = 0;
			foreach (var player in game.teams[i].teamPlayers){
				total += player.storage["TRICKSWON"];
				totalBid += player.storage["BID"];
			} 
			var team = game.teams[i];
			if (total > totalBid){
				team.teamStorage["SCORE"] += totalBid * 10;
				team.teamStorage["BAGS"] += total - totalBid;
			}
			else{
				team.teamStorage["SCORE"] -= totalBid * 10;
			}
			Console.WriteLine(total);
			Console.WriteLine(team.teamStorage["SCORE"] + " : " + team.teamStorage["BAGS"]);
		}
		
		time.Stop();
		Console.WriteLine("Elapsed:" + time.Elapsed);
	}
	
}