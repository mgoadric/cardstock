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
	public class ActionIterator{
		public static GameActionCollection ProcessAction(RecycleParser.ActionContext actionNode){
			var ret = new GameActionCollection();
			if (actionNode.teamcreate() != null) {
				var teamCreate = actionNode.teamcreate() as RecycleParser.TeamcreateContext;
				SetupIterator.ProcessTeamCreate(teamCreate);
			}
			else if (actionNode.initpoints() != null){
				var points = actionNode.initpoints();
				var name = points.var().GetText();
				if (!CardGame.Instance.points.binDict.ContainsKey(name)){
					CardGame.Instance.points.AddKey(name);
				}
				List<PointAwards> temp = new List<PointAwards>();
				var awards = points.awards();
				foreach (RecycleParser.AwardsContext award in awards){
					string key = "";
					string value = "";
					int reward = IntIterator.ProcessInt(award.@int());
					var iter = award.subaward();
					foreach (RecycleParser.SubawardContext i in iter){
						key += i.namegr().GetText() + ",";
						if (i.trueany() != null){
							value += i.trueany().GetText() + ",";
                        }
						else{
							value += CardIterator.ProcessCardatt(i.cardatt()) + ",";
                        }
					}
					key = key.Substring(0,key.Length - 1);
					value = value.Substring(0,value.Length - 1);
                    CardGame.Instance.WriteToFile("A:" + value + " " + reward);
                    temp.Add(new PointAwards(key,value,reward));
				}
				CardGame.Instance.points[name] = new CardScore(temp);
			}
			else if (actionNode.copyaction() != null){
				Debug.WriteLine("REMEMBER: '" + actionNode.GetText() + "'");
				var copy = actionNode.copyaction();
				ret.Add(CardActionIterator.ProcessCopy(copy));
			}
			else if (actionNode.removeaction() != null){
				Debug.WriteLine("FORGET: '" + actionNode.GetText() + "'");
				var removeAction = actionNode.removeaction();
				ret.Add(CardActionIterator.ProcessRemove(removeAction));
			}
			else if (actionNode.moveaction() != null){
				Debug.WriteLine("MOVE: '" + actionNode.GetText() + "'");
				var move = actionNode.moveaction();
				ret.Add(CardActionIterator.ProcessMove(move));
			}
			else if (actionNode.shuffleaction() != null){
				var locations = CardIterator.ProcessLocation(actionNode.shuffleaction().cstorage());
                locations.cardList.Shuffle();
			}
			else if (actionNode.setaction() != null){
				var setAction = actionNode.setaction();
				ret.Add(IntIterator.SetAction(setAction));
			}
			else if (actionNode.incaction() != null){
				var incAction = actionNode.incaction();
				ret.Add(IntIterator.IncAction(incAction));
			}
			else if (actionNode.decaction() != null){
				var decAction = actionNode.decaction();
				ret.Add(IntIterator.DecAction(decAction));
			} 
			else if (actionNode.cycleaction() != null) {

                if (actionNode.cycleaction().GetChild(1).GetText() == "next")
                {
                    //Set next player
                    if (actionNode.cycleaction().owner() != null)
                    {
                        var idx = ProcessOwner(actionNode.cycleaction().owner());
                        CardGame.Instance.CurrentPlayer().SetNext(idx);
                        Debug.WriteLine("Next Player:" + idx);
                    }
                    else if (actionNode.cycleaction().GetChild(2).GetText() == "next")
                    {
                        CardGame.Instance.CurrentPlayer().SetNext(CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().PeekNext()));
                    }
                    else if (actionNode.cycleaction().GetChild(2).GetText() == "current")
                    {
                        CardGame.Instance.CurrentPlayer().SetNext(CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().Current()));
                    }
                    else if (actionNode.cycleaction().GetChild(2).GetText() == "previous")
                    {
                        CardGame.Instance.CurrentPlayer().SetNext(CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().PeekPrevious()));
                    }
                }
                else if (actionNode.cycleaction().GetChild(1).GetText() == "current")
                {
                    //Set next player
                    if (actionNode.cycleaction().owner() != null)
                    {
                        var idx = ProcessOwner(actionNode.cycleaction().owner());
                        CardGame.Instance.CurrentPlayer().SetPlayer(idx);
                        Debug.WriteLine("Next Player:" + idx);
                    }
                    else if (actionNode.cycleaction().GetChild(2).GetText() == "next")
                    {
                        CardGame.Instance.CurrentPlayer().SetPlayer(CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().PeekNext()));
                    }
                    else if (actionNode.cycleaction().GetChild(2).GetText() == "current")
                    {
                        CardGame.Instance.CurrentPlayer().SetPlayer(CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().Current()));
                    }
                    else if (actionNode.cycleaction().GetChild(2).GetText() == "previous")
                    {
                        CardGame.Instance.CurrentPlayer().SetPlayer(CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().PeekPrevious()));
                    }
                }
                else if (actionNode.deckcreate() != null){
                    ret.AddRange(SetupIterator.ProcessDeck(actionNode.deckcreate()));
                }
                else if (actionNode.turnaction() != null){
                    CardGame.Instance.CurrentPlayer().Next();
                }
                else if (actionNode.repeat() != null){
                    ret.AddRange(ProcessRepeat(actionNode.repeat()));
                }
			}
			else{
				Console.WriteLine("Not Processed: '" + actionNode.GetText() + "'");
			}
			return ret;
		}

        public static void ProcessLet(RecycleParser.LetContext letContext){ //TODO
            throw new NotImplementedException();
        }

        public static void ProcessAgg(RecycleParser.AggContext aggContext){ //TODO
            throw new NotImplementedException();
        }

        public static GameActionCollection ProcessDo(RecycleParser.CondactContext[] condact){ //TODO
            GameActionCollection ret = new GameActionCollection();
            foreach (RecycleParser.CondactContext cond in condact){
                if (cond.boolean() != null){
                    if (BooleanIterator.ProcessBoolean(cond.boolean())){
                        ret.AddRange(DoAction(cond));
                    }
                }
                else{
                    ret.AddRange(DoAction(cond));
                }
            }
            return ret;
        }

        public static GameActionCollection DoAction(RecycleParser.CondactContext cond){
            if (cond.multiaction() != null){
                return StageIterator.ProcessSubStage(cond.multiaction());//TODO
            }
            else{
                return ProcessAction(cond.action());
            }
        }

        public static GameActionCollection ProcessRepeat(RecycleParser.RepeatContext rep){
            var ret = new GameActionCollection();
            int idx = 1;
            if (rep.@int() != null){
                idx = IntIterator.ProcessInt(rep.@int());
            }
            else { //TODO if valid action for all
                //idx = size of from location 
            }
            for (int i = 0; i < idx; i++){
                ret.AddRange(ProcessAction(rep.action()));
            }
            return ret;
        }

        private static int ProcessOwner(RecycleParser.OwnerContext owner) {
            Debug.WriteLine("Got to OWNER");
            var resultingCard = CardIterator.ProcessCard(owner.card()).Get();
            Debug.WriteLine("Result :" + resultingCard);
            return CardGame.Instance.CurrentPlayer().playerList.IndexOf(resultingCard.owner.container.owner);
        }

   
	}
}