using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using Antlr4.Runtime.Tree;
using CardEngine;

namespace ParseTreeIterator
{
	public class SetupIterator{
		
		public static void ProcessTeamCreate(RecycleParser.TeamcreateContext teamCreate) {
                var numTeams = teamCreate.teams().Count();
				for (int i = 0; i < numTeams; ++i){
					var newTeam = new Team();
                    var teamStr = "T:";
					foreach (var p in teamCreate.teams(i).INTNUM()) {
						var j = Int32.Parse(p.GetText());
						newTeam.teamPlayers.Add(CardGame.Instance.players[j]);
						CardGame.Instance.players[j].team = newTeam;
                        teamStr += j + " ";
					}
					CardGame.Instance.teams.Add(newTeam);
                    CardGame.Instance.WriteToFile(teamStr);
				}
				
				CardGame.Instance.currentTeam.Push(new TeamCycle(CardGame.Instance.teams));
				Debug.WriteLine("NUMTEAMS:" + CardGame.Instance.teams.Count);
			
		}
		public static GameActionCollection ProcessSetup(RecycleParser.SetupContext setupNode){
			var ret = new GameActionCollection();
			if (setupNode.playercreate() != null){
				var playerCreate = setupNode.playercreate() as RecycleParser.PlayercreateContext;
				var numPlayers = IntIterator.ProcessInt(playerCreate.@int());
                CardGame.Instance.WriteToFile("nump:" + numPlayers);
				CardGame.Instance.AddPlayers(numPlayers);
			}
			if (setupNode.teamcreate() != null){
				var teamCreate = setupNode.teamcreate() as RecycleParser.TeamcreateContext;
				ProcessTeamCreate(teamCreate);
			}
			if (setupNode.deckcreate() != null){
				var decks = setupNode.deckcreate();
				foreach (var deckinit in decks) {
                    ret.Concat(ProcessDeck(deckinit));
				}
			}
			return ret;
		}
        public static GameActionCollection ProcessDeck(RecycleParser.DeckcreateContext deckinit)
        {
            var ret = new GameActionCollection();
            if (deckinit.repeat() != null) {
                return ActionIterator.ProcessRepeat(deckinit.repeat()));
            }
            else {
                var locstorage = CardIterator.ProcessSubLocation(deckinit.cstorage().locpre(), deckinit.cstorage().locdesc(), deckinit.cstorage().GetChild(2).GetText() == "iloc", deckinit.cstorage().GetChild(2).GetText() == "mem");
                var deckTree = DeckIterator.ProcessDeck(deckinit.deck());
                return ret;
            }
        }
    }
}