using System.Collections.Generic;
using System;
using CardEngine;
using System.Linq;
using System.Collections;
using System.Diagnostics;

public class Hearts{
	

	public Hearts(){
		
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
		
		List<string> locationsToCreate = new List<string>{
			"STOCK",
			"TRUMP",
			"VERYBAD",
			"LEAD"//TODO TRUMP and LEAD are imaginary locations, should not be used for play
		};
		foreach (var key in locationsToCreate){
			game.tableCards.AddKey(key);
			game.tableCards[key] = new CardStackCollection();
		}
		
		// Set PLAYER card and int storage locations
		foreach (var player in game.players){
			player.storage.AddKey("CURRENTSTATE");
			
			player.cardBins.AddKey("HAND");
			player.cardBins.AddKey("TRICK");
			player.cardBins.AddKey("TRICKSWON");
			player.cardBins["HAND"] = new CardListCollection();
			player.cardBins["TRICK"] = new CardListCollection();
			player.cardBins["TRICKSWON"] = new CardListCollection();
		}
		
		// Set TEAMS and Link to PLAYERS
		
		for (int i = 0; i < 4; ++i){
			var team = new Team();
			team.teamStorage.AddKey("SCORE");
			team.teamPlayers.Add(game.players[i]);
			game.players[i].team = team;
			game.teams.Add(team);
		}
		
		game.SetDeck(t);
		
		game.tableCards["TRUMP"].Add(game.sourceDeck.First());
		Console.WriteLine(game.tableCards["TRUMP"].Peek());
		
		game.tableCards["VERYBAD"].Add(game.sourceDeck[49]);
		Console.WriteLine(game.tableCards["VERYBAD"].Peek());
		// Establish PRECEDENCE for the cards.
		//
		// TODO : Push this into game, have this description be flexible to again read from string
		List<CardFilter> precGen = new List<CardFilter>();
		
		var suits = new List<string>{"LEAD"};
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
		Dictionary<String, int> StoreNames = new Dictionary<String, int>{
			{"HEARTSBROKEN", 0},
			{"PLAYERTURN", 1},
			{"CURRENTPLAYER", 2},
			{"CURRENTHAND", 3}	
		};
		foreach (var key in StoreNames.Keys){
			game.gameStorage.AddKey(key);
		}
		bool gameNotOver = true;
		while (gameNotOver){
			if (game.teams.Exists(team => team.teamStorage["SCORE"] >= 100)){
				gameNotOver = false;
			}
			else{
				game.PopulateLocation("STOCK");
				game.tableCards["STOCK"].Shuffle();
				// STAGE 0: SETUP STORAGE and DEAL
				game.DealEvery(13,"STOCK","HAND");
				
				foreach (var player in game.players){
					player.cardBins["TRICKSWON"].Clear();
				}
				
				game.gameStorage["HEARTSBROKEN"] = 0;//HEARTS BROKEN = FALSE
				game.gameStorage["PLAYERTURN"] = 0;//Play Turn within hand
				game.gameStorage["CURRENTPLAYER"] = 0;//Current Players Turn
				game.gameStorage["CURRENTHAND"] = 0;//Current Hand
				
				var noHearts = new CardFilter(new List<TreeExpression>{
					new TreeExpression(new List<int>{
						0
					},suitTraversal.ReadValue(game.tableCards["TRUMP"].Peek()),false,"suit")
				});
				
				// STAGE 1.5: Give leading player right values
				var leader = game.players[0];
				leader.storage["CURRENTSTATE"] = 2;
				
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
								var player = game.players[game.gameStorage["CURRENTPLAYER"]];
								
								var choices = new List<Card>();
								
								if (player.storage["CURRENTSTATE"] == 0){//Normal Play, follow suit
									var followSuit = new CardFilter(new List<TreeExpression>{
									new TreeExpression(new List<int>{
											0
										},suitTraversal.ReadValue(game.tableCards["LEAD"].Peek()),true,"suit")
									});
									choices = game.FilterCardsFromLocation(followSuit,"P",game.gameStorage["CURRENTPLAYER"],"HAND");
									
								}
								else if (player.storage["CURRENTSTATE"] == 1){//Play anything, spades broken or unable to follow
									choices = game.FilterCardsFromLocation(new CardFilter(new List<TreeExpression>()),"P",game.gameStorage["CURRENTPLAYER"],"HAND");
								}
								else if (player.storage["CURRENTSTATE"] == 2){//Spades not broken, leading with non spade
									choices = game.FilterCardsFromLocation(noHearts,"P",game.gameStorage["CURRENTPLAYER"],"HAND");
								}
								if (choices.Count == 0){//No moves in current state
									var changeStateAction = game.ChangePlayerState(game.gameStorage["CURRENTPLAYER"],"CURRENTSTATE",1);
									game.PlayerMakeChoice(new List<GameActionCollection>{
										new GameActionCollection{
											changeStateAction
										}
									},game.gameStorage["CURRENTPLAYER"]);
								}
								else{
									var ultimateChoices = new List<GameActionCollection>();
									var changeTurnAction = game.ChangeGameState("PLAYERTURN", game.gameStorage["PLAYERTURN"] + 1);
									var moduloChangeAction = game.ChangeGameState("CURRENTPLAYER",(game.gameStorage["CURRENTPLAYER"] + 1) % 4);
									var resetStateAction = game.ChangePlayerState(game.gameStorage["CURRENTPLAYER"],"CURRENTSTATE",0);
									foreach (var choice in choices){
										var cardPlayAction = new CardMoveAction(choice,game.players[game.gameStorage["CURRENTPLAYER"]].cardBins["HAND"],game.players[game.gameStorage["CURRENTPLAYER"]].cardBins["TRICK"]);
										ultimateChoices.Add(new GameActionCollection{
											cardPlayAction,changeTurnAction,moduloChangeAction,resetStateAction
										});	
										if (game.gameStorage["PLAYERTURN"] == 0){
											ultimateChoices.Last().Add(new CardCopyAction(choice,game.tableCards["LEAD"]));
										}
										
											
									}
									
									game.PlayerMakeChoice(ultimateChoices,game.gameStorage["CURRENTPLAYER"]);
									
								}

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
										treeDirection.expectedValue = suitTraversal.ReadValue(game.tableCards["LEAD"].Peek());
										//Console.WriteLine("treeValue:" + treeDirection.expectedValue);
									}
								}
							}
							
							//Precedence is known, pop the leading card from imaginary location
							game.tableCards["LEAD"].Remove();
							
							
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
							var transportAction = new GameActionCollection();
							foreach (var p in game.players){
								//Uncommenting will throw an exception, stack has been popped
								Console.Write("Player:" + p.cardBins["TRICK"].AllCards().First().ToString() + "\n");
								var queueCard = p.cardBins["TRICK"].Peek();
								if (suitTraversal.ReadValue(queueCard) == suitTraversal.ReadValue(game.tableCards["TRUMP"].Peek())){
									Console.WriteLine("***HEARTSBROKEN***");
									game.gameStorage["HEARTSBROKEN"] = 1;
								}
								transportAction.Add(new CardMoveAction(queueCard,p.cardBins["TRICK"],game.players[winningPlayer].cardBins["TRICKSWON"]));
							}
							transportAction.ExecuteAll();
							// Reward winning player with 1 TRICK
							
							
							game.gameStorage["CURRENTPLAYER"] =  winningPlayer;//Should be winner
							
							
							var winner = game.players[winningPlayer];
							if (game.gameStorage["HEARTSBROKEN"] == 1){
								winner.storage["CURRENTSTATE"] = 1;
							}
							else{
								winner.storage["CURRENTSTATE"] = 2;
							}
							
							
							stage2_2Complete = true;
						}
		
						// STAGE 2 WRAPUP
						game.gameStorage["CURRENTHAND"] += 1;//Current Hand
		
					}
					
				}
				
				// STAGE 3: DETERMINE SCORE FOR TEAMS OF PLAYERS
				
				
				// DEBUG tricks taken by each
				foreach (var player in game.players){
					var findHearts = new CardFilter(new List<TreeExpression>{
						new TreeExpression(new List<int>{
							0
						},suitTraversal.ReadValue(game.tableCards["TRUMP"].Peek()),true,"suit")
					});
					var filteredList = findHearts.FilterMatchesAll(player.cardBins["TRICKSWON"]);
					Console.WriteLine("Number Hearts Accrued:" + filteredList.Count);
					
				}
				
				// DEBUG teams score
				for (int i = 0; i < game.teams.Count; ++i){
					Console.Write("Team " + (i + 1) + " Score: ");
					var heartsFound = 0;
					var team = game.teams[i];
					foreach (var player in team.teamPlayers){
						var findHearts = new CardFilter(new List<TreeExpression>{
						new TreeExpression(new List<int>{
								0
							},suitTraversal.ReadValue(game.tableCards["TRUMP"].Peek()),true,"suit")
						});
						
						var findQueen = new CardFilter(new List<TreeExpression>{
							new TreeExpression(new List<int>{
								0
							},suitTraversal.ReadValue(game.tableCards["VERYBAD"].Peek()),true,"suit"),
							new TreeExpression(new List<int>{
								1
							}, rankTraversal.ReadValue(game.tableCards["VERYBAD"].Peek()),true,"rank")
						});
						var queenList = findQueen.FilterMatchesAll(player.cardBins["TRICKSWON"]);
						var filteredList = findHearts.FilterMatchesAll(player.cardBins["TRICKSWON"]);
						heartsFound += filteredList.Count + (13 * queenList.Count);
					} 
					
					if (heartsFound < 26){
						team.teamStorage["SCORE"] += heartsFound;
					}
					else{
						team.teamStorage["SCORE"] -= heartsFound;
					}
					
					
					Console.WriteLine(team.teamStorage["SCORE"]);
				}
			}
		}
		time.Stop();
		Console.WriteLine("Elapsed:" + time.Elapsed);
	}
	
}