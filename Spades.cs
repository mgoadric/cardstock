using System.Collections.Generic;
using System;
using CardEngine;
public class Spades{
	public Spades(){
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
		
		var game = new CardGame(4);
		game.SetDeck(t);
		game.DealEvery(13);
		game.SetValue(0,0);//SPADES BROKEN = FALSE
		game.SetValue(1,0);//Play Turn within hand
		game.SetValue(2,0);//Current Players Turn
		game.SetValue(3,0);//Current Hand
		
		var noSpades = new CardFilter(new List<TreeDirections>{
			new TreeDirections(new List<int>{
				0
			},"spades",false)
		});
		
		
		
		while (game.GetValue(3) != 13){
			if (game.GetValue(1) == 0){
				var played = game.PlayerRevealCard(game.GetValue(2),noSpades);
				if (!played){
					game.PlayerRevealCard(game.GetValue(2),new CardFilter(new List<TreeDirections>()));
				}			
			}
			else{
				var followSuit = new CardFilter(new List<TreeDirections>{
				new TreeDirections(new List<int>{
				0
				},game.players[(game.GetValue(2) - game.GetValue(1) + 4) % 4].visibleCards[game.GetValue(3)].attributes.children[0].Value,true)
		});
				var played = game.PlayerRevealCard(game.GetValue(2),followSuit);
				if (!played){
					game.PlayerRevealCard(game.GetValue(2),new CardFilter(new List<TreeDirections>()));
				}
			}
			game.SetValue(1,game.GetValue(1) + 1);
			game.SetValue(2,(game.GetValue(2) + 1) % 4);
			if (game.GetValue(1) == 4){
				game.SetValue(1,0);//Runs 0->3 everytime
				game.SetValue(2,2);//Should be winner
				game.SetValue(3,game.GetValue(3) + 1);//Current Hand
			}
		}
		for (int i = 0; i < 13; ++i){
		foreach (var p in game.players){
			
			Console.Write("Player:" + p.visibleCards[i].ToString() + "\n");
		}
		}
		//Console.Write(t.rootNode.ToString());
	}
	
}