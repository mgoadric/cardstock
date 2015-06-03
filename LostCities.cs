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
			Console.WriteLine(card);
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
				
				if (player.storage["CURRENTSTATE"] == 0){//Play a card
					Console.WriteLine("Player TURN");
					foreach (var gameLocation in game.tableCards.Keys()){
						var colorFilter = new CardFilter(new List<TreeExpression>{
							new TreeExpression("color",gameLocation,true)
						});
						var cardMatches = game.FilterCardsFromLocation(colorFilter,"P",game.gameStorage["CURRENTPLAYER"],"HAND");
						foreach (var card in cardMatches){
							choices.Add(new CardMoveAction(card,game.players[game.gameStorage["CURRENTPLAYER"]].cardBins["HAND"],
							game.tableCards[gameLocation]));
						}
					}
					foreach (var gameLocation in game.players[game.gameStorage["CURRENTPLAYER"]].cardBins.Keys()){
						var colorFilter = new CardFilter(new List<TreeExpression>{
							new TreeExpression("color",gameLocation,true)
						});
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
					foreach (var location in game.tableCards.Keys()){
						Console.WriteLine("Location:" + location);
						foreach (var card in game.tableCards[location].AllCards()){
							Console.WriteLine(card);
						}
					}
					Console.ReadKey();
					
				}
				else if (player.storage["CURRENTSTATE"] == 1){//Pick up a card
					
				}
				
				
					
				
			}
		}
		time.Stop();
		Console.WriteLine("Elapsed:" + time.Elapsed);
	}
	
}