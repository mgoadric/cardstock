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
	public class SetupIterator{
		
		public static GameActionCollection ProcessTeamCreate(RecycleParser.TeamcreateContext teamCreate) {
				var numTeams = IntIterator.ProcessListInt(teamCreate.@int())[0];
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
				CardGame.Instance.currentTeam.Push(new TeamCycle(CardGame.Instance.teams));
				Console.WriteLine("NUMTEAMS:" + CardGame.Instance.teams.Count);
			
		}
		public static GameActionCollection ProcessSetup(RecycleParser.SetupContext setupNode){
			var ret = new GameActionCollection();
			if (setupNode.playercreate() != null){
				var playerCreate = setupNode.playercreate() as RecycleParser.PlayercreateContext;
				var numPlayers = IntIterator.ProcessListInt(playerCreate.@int())[0];
				CardGame.Instance.AddPlayers(numPlayers);
			}
			else if (setupNode.teamcreate() != null){
				var teamCreate = setupNode.teamcreate() as RecycleParser.TeamcreateContext;
				ProcessTeamCreate(teamCreate);
			}
			else if (setupNode.deckcreate() != null){
				var deckinit = setupNode.deckcreate();
				var locstorage = BucketIterator.ProcessLocation(deckinit.locstorage());
				var deckTree = DeckIterator.ProcessDeck(deckinit.deck());
				ret.Add(new InitializeAction(locstorage,deckTree));
			}
			else{
				Console.WriteLine("Not Processed: '" + actionNode.GetText() + "'");
			}
			return ret;
		}		
	}
}