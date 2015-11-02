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
			if (actionNode.teamcreate() != null){
				var teamCreate = actionNode.teamcreate() as RecycleParser.TeamcreateContext;
				SetupIterator.ProcessTeamCreate(teamCreate);
			}
			else if (actionNode.initpoints() != null){
				var points = actionNode.initpoints();
				var name = points.name().GetText();
				if (!CardGame.Instance.points.binDict.ContainsKey(name)){
					CardGame.Instance.points.AddKey(name);
				}
				List<PointAwards> temp = new List<PointAwards>();
				var awards = points.awards();
				foreach (RecycleParser.AwardsContext award in awards){
					string key = "";
					string value = "";
					int reward = IntIterator.ProcessListInt(award.@int())[0];
					var iter = award.subaward();
					foreach (RecycleParser.SubawardContext i in iter){
						key += i.name().GetText() + ",";
						if (i.trueany() != null){
							value += i.trueany().GetText() + ",";
						}
						else{
							value += CardIterator.ProcessCardatt(i.cardatt()) + ",";
						}
					}
					key = key.Substring(0,key.Length - 1);
					value = value.Substring(0,value.Length - 1);
					temp.Add(new PointAwards(key,value,reward));
				}
				CardGame.Instance.points[name] = new CardScore(temp);
			}
			else if (actionNode.copyaction() != null){
				Debug.WriteLine("REMEMBER: '" + actionNode.GetText() + "'");
				var copy = actionNode.copyaction();
				ret.AddRange(CardActionIterator.ProcessCopy(copy));
			}
			else if (actionNode.removeaction() != null){
				Debug.WriteLine("FORGET: '" + actionNode.GetText() + "'");
				var removeAction = actionNode.removeaction();
				ret.AddRange(CardActionIterator.ProcessRemove(removeAction));
			}
			else if (actionNode.moveaction() != null){
				Debug.WriteLine("MOVE: '" + actionNode.GetText() + "'");
				var move = actionNode.moveaction();
				ret.AddRange(CardActionIterator.ProcessMove(move));
			}
			else if (actionNode.shuffleaction() != null){
				var locations = CardIterator.ProcessLocation(actionNode.shuffleaction().cstorage());
				foreach (var loc in locations){
					loc.cardList.Shuffle();
				}
			}
			else if (actionNode.setaction() != null){
				var setAction = actionNode.setaction();
				ret.AddRange(IntIterator.SetAction(setAction));
			}
			else if (actionNode.incaction() != null){
				var incAction = actionNode.incaction();
				ret.AddRange(IntIterator.IncAction(incAction));
			}
			else if (actionNode.decaction() != null){
				var decAction = actionNode.decaction();
				ret.AddRange(IntIterator.DecAction(decAction));
			} 
			else if (actionNode.cycleaction() != null) {
				
				if (actionNode.cycleaction().GetChild(1).GetText() == "next"){
					//Set next player
					if (actionNode.cycleaction().@int() != null) {
						var idx = IntIterator.ProcessListInt(actionNode.cycleaction().@int())[0];
						CardGame.Instance.CurrentPlayer().SetNext(idx);
						Debug.WriteLine("Next Player:" + idx);
					} else if (actionNode.cycleaction().GetChild(2).GetText() == "next") {
						CardGame.Instance.CurrentPlayer().SetNext(CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().PeekNext()));			
					} else if (actionNode.cycleaction().GetChild(2).GetText() == "current") {
						CardGame.Instance.CurrentPlayer().SetNext(CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().Current()));			
					} else if (actionNode.cycleaction().GetChild(2).GetText() == "previous") {
						CardGame.Instance.CurrentPlayer().SetNext(CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().PeekPrevious()));			
					}
				}
				else if (actionNode.cycleaction().GetChild(1).GetText() == "current"){
					//Set next player
					if (actionNode.cycleaction().@int() != null) {
						var idx = IntIterator.ProcessListInt(actionNode.cycleaction().@int())[0];
						CardGame.Instance.CurrentPlayer().SetPlayer(idx);
						Debug.WriteLine("Next Player:" + idx);
					} else if (actionNode.cycleaction().GetChild(2).GetText() == "next") {
						CardGame.Instance.CurrentPlayer().SetPlayer(CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().PeekNext()));			
					} else if (actionNode.cycleaction().GetChild(2).GetText() == "current") {
						CardGame.Instance.CurrentPlayer().SetPlayer(CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().Current()));			
					} else if (actionNode.cycleaction().GetChild(2).GetText() == "previous") {
						CardGame.Instance.CurrentPlayer().SetPlayer(CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().PeekPrevious()));			
					}
				}
			}
			else{
				Console.WriteLine("Not Processed: '" + actionNode.GetText() + "'");
			}
			return ret;
		}
		
	}
}