using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using Antlr4.Runtime.Tree;
using ParseTreeIterator;
public class ParseEngine{
	public static FreezeFrame.GameIterator currentIterator;
	public static RecycleParser.GameContext currentTree;
        StringBuilder builder = new StringBuilder();
	public ParseEngine(){

		Debug.AutoFlush = true;
		var breakOnCycle = false;
		var regex = new Regex ("(;;)(.*?)(\n)");


		const string fileName = "Pairs2";

		var f = File.ReadAllText ("games/" + fileName + ".gdl");
		var file = f;
		//Console.WriteLine(file);
		file = regex.Replace (file, "\n");
		//Console.WriteLine(file);
		AntlrInputStream stream = new AntlrInputStream (file);
		ITokenSource lexer = new RecycleLexer (stream);
		ITokenStream tokens = new CommonTokenStream (lexer);
		var parser = new RecycleParser (tokens);
        
		parser.BuildParseTree = true;
		var tree = parser.game ();
		currentTree = tree;
		//Recurse(tree);
                
		//Console.Write(tree.ToStringTree());
		builder.Append ("graph tree{");
		builder.AppendLine ("NODE0 [label=\"Stage\" style=filled fillcolor=\"red\"]");
		NEWMaker (tree, "NODE0");
		builder.Append ("}");
		try {
			var fs = File.Create ("games/" + fileName + ".gv");
			var bytes = Encoding.UTF8.GetBytes (builder.ToString ());
			fs.Write (bytes, 0, bytes.Length);
			fs.Close ();
			Console.WriteLine("wrote games.gv");
		} catch (Exception ex) {
			Console.WriteLine (ex);
		}
	
		//Console.WriteLine(tree);
		TimeSpan minTime = TimeSpan.MaxValue;
		TimeSpan maxTime = TimeSpan.MinValue;
		TimeSpan totalTime = new TimeSpan(0);
		int[] teamWins = new int[4];
		int[] teamTies = new int[4];
		double[] teamScores = new double[5];

		int[] aggregator = new int[4];
		int cycleCount = 0;
		int numGames = 10;
		for (int i = 0; i < numGames; ++i){
			Analytics.BranchingFactor.Instance = new Analytics.BranchingFactor ();
			Analytics.BinCounts.Instance = new Analytics.BinCounts ();
			Analytics.StageCount.Instance = new Analytics.StageCount ();
			Analytics.StorageValues.Instance = new Analytics.StorageValues ();
			Analytics.TimeStep.Instance = new Analytics.TimeStep ();

			System.GC.Collect ();
			bool gameBroke = false;
			HashSet<String> seenStates = new HashSet<String> ();
			CardEngine.CardGame.Instance = new CardEngine.CardGame ();
			var manageContext = new FreezeFrame.GameIterator (tree);
			//manageContext.AdvanceToChoice ();
			currentIterator = manageContext;

			//CardEngine.CardGame.Instance.players [0].decision = new Players.LessThanPerfectPlayer ();
			//CardEngine.CardGame.Instance.players [0].decision = new Players.PerfectPlayer ();
			//manageContext.AdvanceToChoice ();
			while (!manageContext.AdvanceToChoice ()) {
				if (breakOnCycle) {
					var curr = CardEngine.CardGame.Instance.ToString ();
					if (seenStates.Contains (curr)) {
						cycleCount++;
						gameBroke = true;
						break;
					} else {
						seenStates.Add (curr);
					}
				}
				manageContext.ProcessChoice ();
			}

			if (!gameBroke) {
				Console.Out.WriteLine ("Results: " + i);
				var results = ScoreIterator.ProcessScore (tree.scoring ());
				for (int j = 0; j < results.Count; ++j) {
					aggregator [results [j].Item2] += results [j].Item1;
					Console.Out.WriteLine ("Player " + results [j].Item2 + ":" + results [j].Item1);
				}
			} else {
				Console.Out.WriteLine ("Results:\nCycle Occurred\n");
			}
		}
		for (int i = 0; i < 4; ++i) {
			Console.Out.WriteLine("Player" + (i + 1) + ": " + aggregator[i]/(double)(numGames)); 
		}
		if (breakOnCycle) {
			Console.WriteLine ("Cycles:" + cycleCount);
		}
		/*
		for (int i = 0; i < 1000; ++i) {
			CardEngine.CardGame.Instance = new CardEngine.CardGame ();

			// Here for timing estimates right now
			Stopwatch time = new Stopwatch ();
			time.Start ();

			StageIterator.ProcessGame (tree);
//			if (CardEngine.CardGame.Instance.teams [0].teamStorage ["SCORE"] > CardEngine.CardGame.Instance.teams [1].teamStorage ["SCORE"]) {
//				teamWins [0]++;
//			}
//			if (CardEngine.CardGame.Instance.teams [1].teamStorage ["SCORE"] > CardEngine.CardGame.Instance.teams [0].teamStorage ["SCORE"]) {
//				teamWins [1]++;
//			}
//			if (CardEngine.CardGame.Instance.teams [1].teamStorage ["SCORE"] == CardEngine.CardGame.Instance.teams [0].teamStorage ["SCORE"]) {
//				teamWins [2]++;
//			}


			int minIdx = 0;
			bool tie = false;
			int minScore = CardEngine.CardGame.Instance.players [0].storage ["SCORE"];
			teamScores [0] += minScore;
			for (int j = 1; j < 4; ++j){
				int score = CardEngine.CardGame.Instance.players [j].storage ["SCORE"];
				teamScores [j] += score;
				if (score < minScore) {
					minIdx = j;
					minScore = score;
					tie = false;
				} else if (score <= minScore) {
					tie = true;
					minIdx = j;
					minScore = score;
				}
			}
			for (int j = 0; j < 4; ++j) {
				if (minScore == CardEngine.CardGame.Instance.players [j].storage ["SCORE"]) {
					if (tie)
						teamTies [j]++;
					else
						teamWins [j]++;
				}
			}

			foreach (var player in CardEngine.CardGame.Instance.players) {
				Debug.WriteLine ("Green bin:");
				foreach (var green in player.cardBins["GREEN"].AllCards()) {
					Debug.WriteLine (green);
				}
			}
			//Console.Write(Analytics.StageCount.Instance);
			//Console.Write(Analytics.BranchingFactor.Instance);
			//Console.Write(Analytics.StorageValues.Instance);
			var binCounts = Analytics.BinCounts.Instance.DictRep ();
			foreach (var key in binCounts.Keys) {
				Debug.WriteLine (key);
				foreach (var str in binCounts[key]) {
					Debug.Write (str + ", ");
				}
						
				Debug.Write ("\n");
			}
			time.Stop ();
			//Analytics.AnalyticsNetworking.PostResults();
			if (time.Elapsed < minTime) {
				minTime = time.Elapsed;
			}
			if (time.Elapsed > maxTime) {
				maxTime = time.Elapsed;
			}
			totalTime += time.Elapsed;
			//Console.WriteLine ("Elapsed:" + time.Elapsed);
		}
		Console.WriteLine ("Min:" + minTime);
		Console.WriteLine ("Max:" + maxTime);
		Console.WriteLine ("Avg:" + totalTime.TotalSeconds / 1000.0);
		//Console.WriteLine ("Team 1: " + teamWins [0] + " Team 2: " + teamWins [1] + " Ties: " + teamWins[2]);
		for (int i = 0; i < 4; ++i){
			teamScores [i] /= 1000.0;
			Console.Write("Score: " + (teamWins[i] + teamTies[i]) + " (" + teamWins[i] + ", " + teamTies[i] + ") " + teamScores[i]); 
		}
		*/
	}
	public void NEWMaker(IParseTree node, string nodeName){
		for (int i = 0; i < node.ChildCount; ++i) {
			var dontCreate = false;
			var newNodeName = nodeName + "_" + i;
			var contextName = node.GetChild (i).GetType ().ToString ().Replace ("RecycleParser+", "").Replace ("Context", "");
			if (node.GetChild (i).ChildCount > 0 && contextName == "Int") { 
				continue;
				var text = node.GetChild (i).GetText ();
				int myi = 0;
				while (myi < text.Length && Char.IsDigit (text [myi])) {
					myi++;
				} 
				if (myi != text.Length) {
					builder.AppendLine (newNodeName + " [label=\"" + node.GetChild (i).GetType ().ToString ().Replace ("RecycleParser+", "").Replace ("Context", "") + "\" ]");
					DOTMaker (node.GetChild (i), newNodeName);                             
				} else {
					builder.AppendLine (newNodeName + " [label=\"" + node.GetChild (i).GetText () + "\" style=filled fillcolor=\"lightblue\"]");  
				}                         
			} else if (node.GetChild (i).ChildCount > 0 && contextName != "Namegr" && contextName != "Name" && contextName != "Trueany") {
				continue;
				var extra = "";
				if (contextName == "Stage") {
					extra = " style=filled fillcolor=\"red\"";
				} else if (contextName == "Computermoves") {
					extra = " style=filled shape=box fillcolor=\"yellow\"";
				} else if (contextName == "Playermoves") {
					extra = " style=filled shape=diamond fillcolor=\"orange\"";
				}
				builder.AppendLine (newNodeName + " [label=\"" + node.GetChild (i).GetType ().ToString ().Replace ("RecycleParser+", "").Replace ("Context", "") + "\" " + extra + "]");
				DOTMaker (node.GetChild (i), newNodeName);                             
			} else if (node.GetChild (i).ChildCount > 0) {
				builder.AppendLine (newNodeName + " [fillcolor=\"green\" style=filled label=\"" + node.GetChild (i).GetText () + "\"]");
			} else if (node.GetChild (i).GetText () == "(" || node.GetChild (i).GetText () == ")" || node.GetChild (i).GetText () == "," ||
				node.GetChild (i).GetText () == "end" || node.GetChild (i).GetText () == "stage" || node.GetChild (i).GetText () == "comp" ||
				node.GetChild (i).GetText () == "create" || node.GetChild (i).GetText () == "sto" || node.GetChild (i).GetText () == "loc" ||
				node.GetChild (i).GetText () == "initialize" || node.GetChild (i).GetText () == "move" || node.GetChild (i).GetText () == "copy" ||
				node.GetChild (i).GetText () == "inc" || node.GetChild (i).GetText () == "dec" || node.GetChild (i).GetText () == "shuffle" ||
				node.GetChild (i).GetText () == "remove" ||
				node.GetChild (i).GetText () == "choice") {
				dontCreate = true;
			} else {
				builder.AppendLine (newNodeName + " [label=\"" + node.GetChild (i).GetText () + "\"]");
				//DOTMaker(node.GetChild(i),newNodeName);
			}
			if (!dontCreate) {
				builder.AppendLine (nodeName + " -- " + newNodeName);
			}
		}
	}
    public void DOTMaker(IParseTree node, string nodeName){
                
		for (int i = 0; i < node.ChildCount; ++i) {
			var dontCreate = false;
			var newNodeName = nodeName + "_" + i;
			var contextName = node.GetChild (i).GetType ().ToString ().Replace ("RecycleParser+", "").Replace ("Context", "");
			if (node.GetChild (i).ChildCount > 0 && contextName == "Int") {
				var text = node.GetChild (i).GetText ();
				int myi = 0;
				while (myi < text.Length && Char.IsDigit (text [myi])) {
					myi++;
				} 
				if (myi != text.Length) {
					builder.AppendLine (newNodeName + " [label=\"" + node.GetChild (i).GetType ().ToString ().Replace ("RecycleParser+", "").Replace ("Context", "") + "\" ]");
					DOTMaker (node.GetChild (i), newNodeName);                             
				} else {
					builder.AppendLine (newNodeName + " [label=\"" + node.GetChild (i).GetText () + "\" style=filled fillcolor=\"lightblue\"]");  
				}                         
			} else if (node.GetChild (i).ChildCount > 0 && contextName != "Namegr" && contextName != "Name" && contextName != "Trueany") {
				var extra = "";
				if (contextName == "Stage") {
					extra = " style=filled fillcolor=\"red\"";
				} else if (contextName == "Computermoves") {
					extra = " style=filled shape=box fillcolor=\"yellow\"";
				} else if (contextName == "Playermoves") {
					extra = " style=filled shape=diamond fillcolor=\"orange\"";
				}
				builder.AppendLine (newNodeName + " [label=\"" + node.GetChild (i).GetType ().ToString ().Replace ("RecycleParser+", "").Replace ("Context", "") + "\" " + extra + "]");
				DOTMaker (node.GetChild (i), newNodeName);                             
			} else if (node.GetChild (i).ChildCount > 0) {
				builder.AppendLine (newNodeName + " [fillcolor=\"green\" style=filled label=\"" + node.GetChild (i).GetText () + "\"]");
			} else if (node.GetChild (i).GetText () == "(" || node.GetChild (i).GetText () == ")" || node.GetChild (i).GetText () == "," ||
			                              node.GetChild (i).GetText () == "end" || node.GetChild (i).GetText () == "stage" || node.GetChild (i).GetText () == "comp" ||
			                              node.GetChild (i).GetText () == "create" || node.GetChild (i).GetText () == "sto" || node.GetChild (i).GetText () == "loc" ||
			                              node.GetChild (i).GetText () == "initialize" || node.GetChild (i).GetText () == "move" || node.GetChild (i).GetText () == "copy" ||
			                              node.GetChild (i).GetText () == "inc" || node.GetChild (i).GetText () == "dec" || node.GetChild (i).GetText () == "shuffle" ||
			                              node.GetChild (i).GetText () == "remove" ||
			                              node.GetChild (i).GetText () == "choice") {
				dontCreate = true;
			} else {
				builder.AppendLine (newNodeName + " [label=\"" + node.GetChild (i).GetText () + "\"]");
				//DOTMaker(node.GetChild(i),newNodeName);
			}
			if (!dontCreate) {
				builder.AppendLine (nodeName + " -- " + newNodeName);
			}
		}
	}
/*        public void Recurse(RecycleParser.BodyContext con){
                Recurse(con.childNode());
        }
        public void Recurse(RecycleParser.ChildNodeContext con){
                Console.Write("{ ");
                if (con.ChildCount == 4){
                        Recurse((RecycleParser.ChildNodeContext)con.children[1]);
                        Recurse((RecycleParser.ChildNodeContext)con.children[3]);
                }
                else if (con.ChildCount == 3){
                        Recurse((RecycleParser.ChildNodeContext)con.children[1]);
                }
                else{
                        Console.Write(con.GetText());
                }
                Console.Write(" }");
        }
        */
}