using System.Collections.Generic;
using System;
using CardEngine;
using System.Linq;
using System.Collections;
using System.Diagnostics;

public class LostCities{
	

	public LostCities(){
		
		// PREAMBLE: Define the DECK of cards based on a tree structure
		//
		// TODO: Push this code inside the CardGame class, to read a string like below
		// 
		// (tree (rank (2 3 4 5 6 7 8 9 10 J Q K)
		// 		 (color (red (hearts diamonds)
		//		  		(black (clubs spades))))
		
		var ranks = new Node{
			Value = "combo2",
			children = new List<Node>{new Node{Value="HS",Key="rank"},new Node{Value="HS",Key="rank"},new Node{Value="HS",Key="rank"},
			new Node{Value="2",Key="rank"},new Node{Value="3",Key="rank"},new Node{Value="4",Key="rank"},
			new Node{Value="5",Key="rank"},new Node{Value="6",Key="rank"},new Node{Value="7",Key="rank"},new Node{Value="8",Key="rank"},new Node{Value="9",Key="rank"},new Node{Value="10",Key="rank"}
			}
		};
		Tree t = new Tree{
			rootNode = new Node{
				Value="Attrs",
				children = new List<Node>{
					new Node{
						Value = "combo1",
						children = new List<Node>{
							new Node{Value="yellow",Key="color"},
							new Node{Value="blue",Key="color"},
							new Node{Value="black",Key="color"},
							new Node{Value="green",Key="color"},
							new Node{Value="red",Key="color"}
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
			"yellow",
			"blue",
			"black",
			"green",
			"red",
			"JUSTPLAYED"
			//TODO TRUMP and LEAD are imaginary locations, should not be used for play
		};
		foreach (var key in locationsToCreate){
			game.tableCards.AddKey(key);
			game.tableCards[key] = new CardStackCollection();
		}
		
		// Set PLAYER card and int storage locations
		foreach (var player in game.players){
			
			player.storage.AddKey("CURRENTSTATE");
			player.storage["CURRENTSTATE"] = 0;
			player.cardBins.AddKey("HAND");
			player.cardBins.AddKey("yellow");
			player.cardBins.AddKey("blue");
			player.cardBins.AddKey("black");
			player.cardBins.AddKey("green");
			player.cardBins.AddKey("red");
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
			player.cardBins["yellow"] = new CardStackCollection();
			player.cardBins["blue"] = new CardStackCollection();
			player.cardBins["black"] = new CardStackCollection();
			player.cardBins["green"] = new CardStackCollection();
			player.cardBins["red"] = new CardStackCollection();
		}
		
		
		//Deal
		game.PopulateLocation("STOCK");
		game.tableCards["STOCK"].Shuffle();
		// STAGE 0: SETUP STORAGE and DEAL
		game.DealEvery(8,"STOCK","HAND");
		
		Console.WriteLine("Dealt");
		foreach (var card in game.players[0].cardBins["HAND"].AllCards()){
			//Console.WriteLine(card);
		}
		
		Dictionary<String, int> StoreNames = new Dictionary<String, int>{
			{"SPADESBROKEN", 0},
			{"PLAYERTURN", 1},
			{"CURRENTPLAYER", 2},
			{"CURRENTHAND", 3}	
		};
		
		//Lost Cities Scoring
		var scoring = new CardScore(new List<PointAwards>{
			
		});
		var rankIter = new List<string>{
			"HS","2","3","4","5","6","7","8","9","10"
		};
		var pointIter = new List<int>{
			0,2,3,4,5,6,7,8,9,10
		};
		for (int i = 0; i < rankIter.Count; ++i){
			scoring.awards.Add(new PointAwards(new CardFilter(new List<CardExpression>{
				new TreeExpression("rank",rankIter[i],true)
			}),pointIter[i]));
		}
		
		
		foreach (var key in StoreNames.Keys){
			game.gameStorage.AddKey(key);
		}
		// STAGE 0.5 SETUP
		game.gameStorage["CURRENTPLAYER"] = 0;//Runs 0->1 everytime
		
		bool gameNotOver = true;
		while (gameNotOver){
			Console.WriteLine(game.tableCards["STOCK"].Count);
			if (game.tableCards["STOCK"].Count <= 0){
				gameNotOver = false;
			}
			else{
				// STAGE 1_1: EACH PLAYER PLAYS ONE CARD and DrawsOne
				var player = game.players[game.gameStorage["CURRENTPLAYER"]];
				
				var choices = new List<GameAction>();
				
				//Play a card
				
				foreach (var gameLocation in game.tableCards.Keys()){
					var colorFilter = new CardFilter(new List<CardExpression>{
						new TreeExpression("color",gameLocation,true)
					});
					var cardMatches = game.FilterCardsFromLocation(colorFilter,"P",game.gameStorage["CURRENTPLAYER"],"HAND");
					foreach (var card in cardMatches){
						choices.Add(new CardMoveAction(card,game.players[game.gameStorage["CURRENTPLAYER"]].cardBins["HAND"],
						game.tableCards[gameLocation]));
					}
				}
				foreach (var gameLocation in game.players[game.gameStorage["CURRENTPLAYER"]].cardBins.Keys()){
					
					var colorFilter = new CardFilter(new List<CardExpression>{
						new TreeExpression("color",gameLocation,true)
					});
					if (game.players[game.gameStorage["CURRENTPLAYER"]].cardBins[gameLocation].Count != 0){
						
						colorFilter.filters.Add(new ScoreExpression(
							scoring,
							">=",
							scoring.GetScore(game.players[game.gameStorage["CURRENTPLAYER"]].cardBins[gameLocation].Peek())
						));
					}
					var cardMatches = game.FilterCardsFromLocation(colorFilter,"P",game.gameStorage["CURRENTPLAYER"],"HAND");
					foreach (var card in cardMatches){
						choices.Add(new CardMoveAction(card,game.players[game.gameStorage["CURRENTPLAYER"]].cardBins["HAND"],
						game.players[game.gameStorage["CURRENTPLAYER"]].cardBins[gameLocation]));
					}
				}
				
				var ultimateChoices = new List<GameActionCollection>();
				foreach (var choice in choices){
					ultimateChoices.Add(new GameActionCollection{
						choice
					});
				}
				
				game.PlayerMakeChoice(ultimateChoices,0);//game.gameStorage["CURRENTPLAYER"]);
				
				//Draw a card
				List<string> locationsToIterate = new List<string>{
					"STOCK",
					"yellow",
					"blue",
					"black",
					"green",
					"red"
				};
				ultimateChoices = new List<GameActionCollection>();
				foreach (var location in locationsToIterate){
					if (game.tableCards[location].Count != 0){
						ultimateChoices.Add(new GameActionCollection{
							new CardPopMoveAction(game.tableCards[location].Peek(),game.tableCards[location],game.players[game.gameStorage["CURRENTPLAYER"]].cardBins["HAND"])
						});
					}
				}
				game.PlayerMakeChoice(ultimateChoices,game.gameStorage["CURRENTPLAYER"]);
				
				game.gameStorage["CURRENTPLAYER"] = (game.gameStorage["CURRENTPLAYER"] + 1) % 2;
			}
		}
		List<string> locationsToPrint = new List<string>{
					
					"yellow",
					"blue",
					"black",
					"green",
					"red"
				};
		Console.WriteLine("\n\n***GAME");
		foreach (var location in locationsToPrint){
			Console.WriteLine("Location:" + location);
			foreach (var card in game.tableCards[location].AllCards()){
				Console.WriteLine(card);
			}
		}
		foreach (var player in game.players){
			Console.WriteLine("\n\nPLAYERS***");
			foreach (var location in locationsToPrint){
				Console.WriteLine("Location:" + location);
				foreach (var card in player.cardBins[location].AllCards()){
					Console.WriteLine(card);
				}
			}
		}
		
		foreach (var player in game.players){
			Console.WriteLine("\n\nPLAYERS***SCORE");
			var totalScore = 0;
			foreach (var location in locationsToPrint){
				var locationScore = player.cardBins[location].Count > 0 ? -20 : 0;
				Console.WriteLine("Location:" + location);
				var hsCount = 1;
				foreach (var card in player.cardBins[location].AllCards()){
					if (card.ReadAttribute("rank") != "HS"){
						locationScore += scoring.GetScore(card);
					}
					else{
						hsCount++;
					}
					
				}
				totalScore += locationScore * hsCount;
			}
			Console.WriteLine(totalScore);
		}
		
		time.Stop();
		Console.WriteLine("Elapsed:" + time.Elapsed);
	}
	
}