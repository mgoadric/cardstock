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
		
		public static void ProcessTeamCreate(RecycleParser.TeamcreateContext teamCreate) {
			
				var numTeams = teamCreate.attribute().Count();
				for (int i = 0; i < numTeams; ++i){
					var newTeam = new Team();
					foreach (var p in teamCreate.attribute(i).trueany()) {
						var j = Int32.Parse(p.GetText());
						newTeam.teamPlayers.Add(CardGame.Instance.players[j]);
						CardGame.Instance.players[j].team = newTeam;
					}
					CardGame.Instance.teams.Add(newTeam);
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
			if (setupNode.teamcreate() != null){
				var teamCreate = setupNode.teamcreate() as RecycleParser.TeamcreateContext;
				ProcessTeamCreate(teamCreate);
			}
			if (setupNode.deckcreate() != null){
				var decks = setupNode.deckcreate();
				foreach (var deckinit in decks) {				
					var locstorage = CardIterator.ProcessSubLocation(deckinit.locstorage().locpre(), deckinit.locstorage().locpost());
					var deckTree = DeckIterator.ProcessDeck(deckinit.deck());
					ret.Add(new InitializeAction(locstorage[0].cardList,deckTree));
				}
			}
			
			// IF ANY MISSING, THROW EXCEPTION
			
			
			
			return ret;
		}		
	}
}