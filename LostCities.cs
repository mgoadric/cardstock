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
			player.cardBins["TRICK"] = new CardStackCollection();
		}
		
		// Establish PRECEDENCE for the cards.
		//
		// TODO : Push this into game, have this description be flexible to again read from string
		List<CardFilter> precGen = new List<CardFilter>();
		
		var suits = new List<string>{"TRUMP","LEAD"};
		var rankIter = new List<string>{"A","K","Q","J","10","9","8","7","6","5","4","3","2"};
		
		foreach (var suit in suits){
			foreach (var rank in rankIter){
				precGen.Add(new CardFilter(new List<TreeExpression>{
					new TreeExpression("suit",suit,true),
					new TreeExpression("rank",rank,true)
				}));
			}
		}
		

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
			if (game.teams.Exists(team => team.teamStorage["SCORE"] >= 500)){
				gameNotOver = false;
			}
			else{
			}
		}
		time.Stop();
		Console.WriteLine("Elapsed:" + time.Elapsed);
	}
	
}