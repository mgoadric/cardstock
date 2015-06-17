using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Antlr4.Runtime.Tree;
using CardEngine;

namespace ParseTreeIterator
{
	public class ActionIterator{
		public static void ProcessAction(CardLanguageParser.ActionContext actionNode){
			if (actionNode.loccreate() != null){
				var locAction = actionNode.loccreate() as CardLanguageParser.LoccreateContext;
				CardStorage[] dest = new CardStorage[1];
				if (locAction.obj().GetText() == "game"){
					dest = new CardStorage[]{CardGame.Instance.tableCards};
				}
				else if (locAction.obj().GetText() == "player"){
					var players = CardGame.Instance.players;
					dest = new CardStorage[players.Count];
					for (int i = 0; i < players.Count; ++i){
						dest[i] = players[i].cardBins;
					}
				}
				else if (locAction.obj().GetText() == "team"){
					//unsuported (for now?);
				}
				

				foreach (var location in dest){
					for (int i = 3; i < locAction.ChildCount; ++i){
						var locDef = locAction.GetChild(i) as CardLanguageParser.LocationdefContext;
						var binName = locDef.name().GetText();
						location.AddKey(binName);
						if (locDef.GetChild(2).GetText() == "Stack"){
							location[binName] = new CardStackCollection();
						}
						else if (locDef.GetChild(2).GetText() == "List"){
							location[binName] = new CardListCollection();
						}
						else if (locDef.GetChild(2).GetText() == "Queue"){
							location[binName] = new CardQueueCollection();
						}
						else{
							throw new System.ArgumentException("Unsuported Card bin type");
						}
						
					}
				}
			}
			else if (actionNode.storagecreate() != null){
				var stoAction = actionNode.storagecreate();
				
				RawStorage[] dest = new RawStorage[1];
				
				if (stoAction.obj().GetText() == "game"){
					dest[0] = CardGame.Instance.gameStorage;
				}
				else if (stoAction.obj().GetText() == "player"){
					var players = CardGame.Instance.players;
					dest = new RawStorage[players.Count];
					for (int i = 0; i < players.Count; ++i){
						dest[i] = players[i].storage;
					}
				}
				else if (stoAction.obj().GetText() == "team"){
					var teams = CardGame.Instance.teams;
					dest = new RawStorage[teams.Count];
					for (int i = 0; i < teams.Count; ++i){
						dest[i] = teams[i].teamStorage;
					}
				}
				
				int namegrCnt = (stoAction.ChildCount - 5)/2 + 1;
				foreach (var storage in dest){
					for (int i = 0; i < namegrCnt; ++i){
						var namegr = stoAction.namegr(i);
						var name = namegr.GetText();
						storage.AddKey(name);
						
					}
				}
				
			}
			else if (actionNode.playercreate() != null){
				var playerCreate = actionNode.playercreate() as CardLanguageParser.PlayercreateContext;
				var numPlayers = IntIterator.ProcessInt(playerCreate.@int());
				CardGame.Instance.AddPlayers(numPlayers);
			}
			else if (actionNode.teamcreate() != null){
				var teamCreate = actionNode.teamcreate() as CardLanguageParser.TeamcreateContext;
				var numTeams = IntIterator.ProcessInt(teamCreate.@int());
				if (teamCreate.ChildCount == 4){//alternate
					for (int i = 0; i < numTeams; ++i){
						var newTeam = new Team();
						var j = i;
						var playerCount = CardGame.Instance.players.Count;
						var skip =  playerCount / numTeams;
						while (j < playerCount){
							newTeam.teamPlayers.Add(CardGame.Instance.players[j]);
							CardGame.Instance.players[j].team = newTeam;
							
							j += skip;
						}
						CardGame.Instance.teams.Add(newTeam);
					}
				}
				else{//Sequential
					for (int i = 0; i < numTeams; ++i){
						var newTeam = new Team();
						var playerCount = CardGame.Instance.players.Count;
						var skip =  playerCount / numTeams;
						for (var j = 0; j < skip; ++j){
							newTeam.teamPlayers.Add(CardGame.Instance.players[i * skip + j]);
							CardGame.Instance.players[i * skip + j].team = newTeam;
						}
						CardGame.Instance.teams.Add(newTeam);
					}
				}
				Console.WriteLine("NUMTEAMS:" + CardGame.Instance.teams.Count);
			}
			else if (actionNode.init() != null){
				var initialize = actionNode.init();
				if (initialize.deckinit() != null){
					var deckinit = initialize.deckinit();
					var locstorage = BucketIterator.ProcessLocation(deckinit.locstorage());
					var deckTree = DeckIterator.ProcessDeck(deckinit.deck());
					CardGame.Instance.SetDeck(deckTree);
					CardGame.Instance.PopulateLocation(locstorage);
					foreach (var card in locstorage.AllCards()){
						Console.WriteLine(card);
					}
				}
			}
		}
		
	}
}