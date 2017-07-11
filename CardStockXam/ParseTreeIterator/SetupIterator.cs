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

        public static void ProcessTeamCreate(RecycleParser.TeamcreateContext teamCreate){
            var numTeams = teamCreate.teams().Count();
            for (int i = 0; i < numTeams; ++i){
                var newTeam = new Team(i);
                var teamStr = "T:";
                foreach (var p in teamCreate.teams(i).INTNUM()){
                    var j = Int32.Parse(p.GetText());
                    newTeam.teamPlayers.Add(CardGame.Instance.players[j]);
                    CardGame.Instance.players[j].team = newTeam;
                    teamStr += j + " ";
                }
                CardGame.Instance.teams.Add(newTeam);
                CardGame.Instance.WriteToFile(teamStr);
            }

            CardGame.Instance.currentTeam.Push(new StageCycle<Team>(CardGame.Instance.teams));
            Debug.WriteLine("NUMTEAMS:" + CardGame.Instance.teams.Count);

        }
		public static GameActionCollection ProcessSetup(RecycleParser.SetupContext setupNode){
			var ret = new GameActionCollection();
			if (setupNode.playercreate() != null){
                Debug.WriteLine("Creating players.");
				var playerCreate = setupNode.playercreate() as RecycleParser.PlayercreateContext;
                var numPlayers = 2;
                if (playerCreate.@int() != null){
                    numPlayers = IntIterator.ProcessInt(playerCreate.@int());
                }
                else{
                    numPlayers = VarIterator.ProcessIntVar(playerCreate.var());
                }
                CardGame.Instance.WriteToFile("nump:" + numPlayers);
				CardGame.Instance.AddPlayers(numPlayers);
			}
			if (setupNode.teamcreate() != null){
                Debug.WriteLine("Creating teams.");
				var teamCreate = setupNode.teamcreate() as RecycleParser.TeamcreateContext;
				ProcessTeamCreate(teamCreate);
			}
			if (setupNode.deckcreate() != null){
                Debug.WriteLine("Creating decks.");
				var decks = setupNode.deckcreate();
				foreach (var deckinit in decks) {
                    ret.Add(ProcessDeck(deckinit));
				}
			}
            if (setupNode.repeat() != null){
                foreach (var rep in setupNode.repeat()){
                    if (CheckDeckRepeat(rep)){
                        ret.AddRange(ActionIterator.ProcessRepeat(rep));
                    }
                    else
                    {
                        throw new InvalidDataException();
                    }
                }
            }
			return ret;
		}

        public static bool CheckDeckRepeat(RecycleParser.RepeatContext reps){
            if (reps.action().deckcreate() != null){
                return true;
            }
            else if (reps.action().repeat() != null){
                return CheckDeckRepeat(reps.action().repeat());
            }
            return false;
        }
        public static GameAction ProcessDeck(RecycleParser.DeckcreateContext deckinit)
        {
            var locstorage = CardIterator.ProcessLocation(deckinit.cstorage());
            var deckTree = DeckIterator.ProcessDeck(deckinit.deck());
            return new InitializeAction(locstorage.cardList, deckTree);
        }
    }
}