using System;
using System.Collections.Generic;
using CardEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using FreezeFrame;
using ParseTreeIterator;
namespace Players
{
	public class LessThanPerfectPlayer : GeneralPlayer
	{
		public LessThanPerfectPlayer ()
		{
		}
		public override int MakeAction(List<GameActionCollection> possibles,Random rand){

			return rand.Next(0,possibles.Count);
		}
		public override int MakeAction(JObject possibles, Random rand){
			var items = (JArray)possibles ["items"];
			if (items.Count == 1) {
				return 0;
			}
			CardEngine.CardGame.preserved = CardEngine.CardGame.Instance;


			var results = new int[items.Count];
			Debug.WriteLine ("Start Monte");
			for (int item = 0; item < items.Count; ++item){
				results [item] = 0;
				for (int i = 0; i < 20; ++i) {
					Debug.WriteLine ("****Made Switch****");

					CardEngine.CardGame.Instance = CardEngine.CardGame.preserved.CloneSecret (0);

					var flag = true;
					foreach (var player in CardEngine.CardGame.Instance.players) {
						if (flag) {
							flag = false;
							player.decision = new PredictablePlayer ();
							((PredictablePlayer)player.decision).toChoose = item;

						} else {
							player.decision = new Players.GeneralPlayer ();
						}
					}
					var preservedIterator = ParseEngine.currentIterator;
					var cloneContext = ParseEngine.currentIterator.Clone ();
					ParseEngine.currentIterator = cloneContext;
					while (!cloneContext.AdvanceToChoice ()) {
						cloneContext.ProcessChoice ();
					}
					var winners = ScoreIterator.ProcessScore (ParseEngine.currentTree.scoring ());
					for (int j = 0; j < winners.Count; ++j) {
						if (winners [j].Item2 == 0) {
							results [item] += j;
						}
					}

					ParseEngine.currentIterator = preservedIterator;
				}

			}
			Debug.WriteLine ("End Monte");
			//Debug.WriteLine ("***Switch Back***");
			CardEngine.CardGame.Instance = CardEngine.CardGame.preserved;
			var typeOfGame = ParseEngine.currentTree.scoring ().GetChild (2).GetText ();
			if (typeOfGame == "min") {
				return idxOfMinimum (results);
			} else {
				return idxOfMaximum (results);
			}
			//return rand.Next (0,items.Count);
		}
		public static int idxOfMinimum(int[] input){
			int min = int.MaxValue;
			int minIdx = -1;
			for (int i = 0; i < input.Length; ++i) {
				if (input[i] < min) {
					min = input[i];
					minIdx = i;
				}
			}
			return minIdx;
		}
		public static int idxOfMaximum(int[] input){
			int max = int.MinValue;
			int maxIdx = -1;
			for (int i = 0; i < input.Length; ++i) {
				if (input[i] > max) {
					max = input[i];
					maxIdx = i;
				}
			}
			return maxIdx;
		}
	}
}

