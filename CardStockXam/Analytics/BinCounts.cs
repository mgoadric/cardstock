using System.Collections.Generic;
using CardEngine;
namespace Analytics{
	public class BinCounts{
		private static BinCounts instance;
		public static BinCounts Instance
   		{
	  		get 
	  		{
		         if (instance == null)
		         {
		            instance = new BinCounts();
		         }
		         return instance;
		     }
			set{
				instance = value;
			}
		}
		public BinCounts(){
			
		}
		public Dictionary<string,List<string>> DictRep(){
			var game = CardGame.Instance;
			var ret = new Dictionary<string,List<string>>();
			var curr = "game";
			ret[curr] = new List<string>();
			foreach (var key in game.gameStorage.binDict.Keys){
				ret[curr].Add(key);
			}
			curr = "player";
			for (int i = 0; i < game.players.Count; ++i){
				var player = game.players[i];
				var keyCombo = curr + i;
				ret[keyCombo] = new List<string>();
				foreach (var key in player.storage.binDict.Keys){
					ret[keyCombo].Add(key);
				}
			}
			curr = "team";
			for (int i = 0; i < game.teams.Count; ++i){
				var team = game.teams[i];
				var keyCombo = curr + i;
				ret[keyCombo] = new List<string>();
				foreach (var key in team.teamStorage.binDict.Keys){
					ret[keyCombo].Add(key);
				}
			}
			return ret;
		}
		public override string ToString(){
			string ret = "";
			
			return ret;
		}
	}
	
}