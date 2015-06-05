using System;
using System.Collections.Generic;
using CardEngine;
using System.Diagnostics;
using System.Linq;
public class Cribbage{
	public Cribbage(){
		var red = new Node{
			Value = "red",
			Key="color",
			children = new List<Node>{
				new Node{
					Value="hearts",
					Key="suit",
				},
				new Node{
					Value="diamonds",
					Key="suit"
				}
				
					
			}
		};
		var black = new Node{	
			Value = "black",
			Key = "color",
			children = new List<Node>{
				new Node{
					Value="clubs",
					Key="suit",
				},
				new Node{
					Value="spades",
					Key="suit"
				}
					
			}
		};
		var ranks = new Node{
			Value = "combo2",
			children = new List<Node>{
			new Node{Value="2",Key="rank"},new Node{Value="3",Key="rank"},new Node{Value="4",Key="rank"},
			new Node{Value="5",Key="rank"},new Node{Value="6",Key="rank"},new Node{Value="7",Key="rank"},new Node{Value="8",Key="rank"},new Node{Value="9",Key="rank"},new Node{Value="10",Key="rank"},
			new Node{Value="J",Key="rank"},new Node{Value="Q",Key="rank"},new Node{Value="K",Key="rank"},new Node{Value="A",Key="rank"}
			}
		};
		Tree t = new Tree{
			rootNode = new Node{
				Value="Attrs",
				children = new List<Node>{
					new Node{
						Value = "combo1",
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
		int numPlayers = 2;
		var game = new CardGame(numPlayers);
		
		List<string> locationsToCreate = new List<string>{
			"STOCK",
			"PLAYHISTORY",
			"STARTER",
			"CRIB"//TODO TRUMP and LEAD are imaginary locations, should not be used for play
		};
		foreach (var key in locationsToCreate){
			game.tableCards.AddKey(key);
			game.tableCards[key] = new CardStackCollection();
		}
		
		// Set PLAYER card and int storage locations
		foreach (var player in game.players){
			player.storage.AddKey("BID");
			player.storage.AddKey("CURRENTSTATE");
			player.storage.AddKey("TRICKSWON");
			player.storage.AddKey("GONE");
			player.cardBins.AddKey("HAND");
			player.cardBins.AddKey("TRICK");
		}
		
		// Set TEAMS and Link to PLAYERS
		
		for (int i = 0; i < 2; ++i){
			var team = new Team();
			team.teamStorage.AddKey("SCORE");
			team.teamPlayers.Add(game.players[i]);
			game.players[i].team = team;
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
		Console.WriteLine("here");
		

		var suitDict = new Dictionary<string,HashSet<Card>>();
		var rankDict = new Dictionary<string,HashSet<Card>>();
		var comboDict = new Dictionary<string, Card>();
		foreach (var card in game.sourceDeck){
			var suit = card.ReadAttribute("suit");
			
			if (suitDict.ContainsKey(suit)){
				suitDict[suit].Add(card);
			}
			else{
				suitDict.Add(suit,new HashSet<Card>{card});
			}
			
			var rank = card.ReadAttribute("rank");
			
			if (rankDict.ContainsKey(rank)){
				rankDict[rank].Add(card);
			}
			else{
				rankDict.Add(rank,new HashSet<Card>{card});
			}
			
			comboDict.Add(suit + rank,card);
		}
		Dictionary<String, int> StoreNames = new Dictionary<String, int>{
			{"SPADESBROKEN", 0},
			{"PLAYERTURN", 1},
			{"CURRENTPLAYER", 2},
			{"CURRENTHAND", 3}	
		};
		foreach (var key in StoreNames.Keys){
			game.gameStorage.AddKey(key);
		}
		bool gameNotOver = true;
		while (gameNotOver){
			if (game.teams.Exists(team => team.teamStorage["SCORE"] >= 121)){
				gameNotOver = false;
			}
			else{
				game.PopulateLocation("STOCK");
				game.tableCards["STOCK"].Shuffle();
				// STAGE 0: SETUP STORAGE and DEAL
				game.DealEvery(6,"STOCK","HAND");
				Console.WriteLine("here");
				//Populate the crib
				for (int i = 0; i < 2; ++i){
					var player = game.players[i];
					var ultimateChoices = new List<GameActionCollection>();
					foreach (var card in player.cardBins["HAND"].AllCards()){
						ultimateChoices.Add(new GameActionCollection{
							new CardMoveAction(card,player.cardBins["HAND"],game.tableCards["CRIB"])
						});
					}
					game.PlayerMakeChoices(ultimateChoices,i,2);
				}
				Console.WriteLine("here");
				//Normal Game phase
				var rankStrings = new List<string>{
					"A","2","3","4","5","6","7","8","9","10","J","Q","K"
				};
				var rankInts = new List<int>{
					1,2,3,4,5,6,7,8,9,10,10,10,10	
				};
				var scoreList = new List<PointAwards>();
				for (int i = 0; i < rankStrings.Count; ++i){
					scoreList.Add(new PointAwards("rank",rankStrings[i],rankInts[i]));
				}
				var stackScore = new CardScore(scoreList);
				Console.WriteLine("here");
				while (!game.players.Exists(player => player.cardBins["HAND"].Count == 0)){
					game.tableCards["PLAYHISTORY"].Clear();
					foreach (var player in game.players){
						player.cardBins["TRICK"].Clear();
						player.storage["GONE"] = 0;
					}
					while (game.tableCards["PLAYHISTORY"].AllCards().Sum(card => stackScore.GetScore(card)) < 31 && game.players.Exists(player => player.storage["GONE"] == 0)){
						//Players each play a remaining card
						var remainingScore = 31 - game.tableCards["PLAYHISTORY"].AllCards().Sum(card => stackScore.GetScore(card));
						
						var playableFilter = new CardFilter(new List<CardExpression>{
							new ScoreExpression(stackScore,"<=",remainingScore)
						});
						
						var actions = new List<GameActionCollection>();
						
						foreach (var card in playableFilter.FilterMatchesAll(game.players[game.gameStorage["CURRENTPLAYER"]].cardBins["HAND"]).AllCards()){
							actions.Add(new GameActionCollection{
								new CardMoveAction(card,game.players[game.gameStorage["CURRENTPLAYER"]].cardBins["HAND"],game.players[game.gameStorage["CURRENTPLAYER"]].cardBins["TRICK"]),
								new CardCopyAction(card,game.tableCards["PLAYHISTORY"])
							});
						}
						if (actions.Count > 0){
							game.PlayerMakeChoice(actions,game.gameStorage["CURRENTPLAYER"]);
							game.gameStorage["CURRENTPLAYER"] = (game.gameStorage["CURRENTPLAYER"] + 1) % 2;
							
							Console.WriteLine("STATE");
							foreach (var card in game.tableCards["PLAYHISTORY"].AllCards()){
								Console.WriteLine(card);
							}
						}
						else{
							game.players[game.gameStorage["CURRENTPLAYER"]].storage["GONE"] = 1;
							game.gameStorage["CURRENTPLAYER"] = (game.gameStorage["CURRENTPLAYER"] + 1) % 2;
						}
					}
				}
			}
			break;
		}
		time.Stop();
		Console.WriteLine("Elapsed:" + time.Elapsed);
	}
}