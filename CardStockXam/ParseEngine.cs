using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using Antlr4.Runtime.Tree;
using CardGames;
using ParseTreeIterator;
using CardStockXam;
using Players;

// add basic stats (% wins)
public class ParseEngine
{
    public static FreezeFrame.GameIterator currentIterator;
    public static RecycleParser.GameContext currentTree;
    StringBuilder builder = new StringBuilder();

    public static int reportedBF = 0;

    public static Experiment expstat;

    public ParseEngine(Experiment exp)
    {
        expstat = exp;

        Debug.AutoFlush = true;
        var regex = new Regex("(;;)(.*?)(\n)");

        if (exp.logging) {
            File.WriteAllText(exp.fileName + ".txt", string.Empty);
        }
        // Load up the game from the .gdl RECYCLE description
        string fileName = exp.fileName;
        if (!exp.evaluating)
        {
            fileName = "games/" + fileName + ".gdl";
        }
        else
        {
            string[] split = new string[] { "Release\\" };
            var path = fileName.Split(split, StringSplitOptions.RemoveEmptyEntries);
            if (path.Count() == 1){
                split = new string[] { "Debug\\" };
                path = fileName.Split(split, StringSplitOptions.RemoveEmptyEntries);
            }
            fileName = path[1] + ".gdl";
        }
        Console.WriteLine("name: " + fileName);
        var file = File.ReadAllText(fileName);
        file = regex.Replace(file, "\n");

        // Parse the game with the Antlr grammar description
        AntlrInputStream stream = new AntlrInputStream(file);
        ITokenSource lexer = new RecycleLexer(stream);
        ITokenStream tokens = new CommonTokenStream(lexer);
        var parser = new RecycleParser(tokens);

        parser.BuildParseTree = true;
        var tree = parser.game();
        currentTree = tree;

        // Make the parse tree visualizations
        builder.Append("graph tree{");
        builder.AppendLine("NODE0 [label=\"Stage\" style=filled fillcolor=\"red\"]");
        DOTMaker(tree, "NODE0");
        builder.Append("}");
        if (!exp.evaluating) { 
            try{
                var fs = File.Create("games/" + exp.fileName + ".gv");
                var bytes = Encoding.UTF8.GetBytes(builder.ToString());
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
                Debug.WriteLine("wrote " + exp.fileName + ".gv");
            }
            catch (Exception ex){
                Debug.WriteLine(ex.ToString());
            }
        }
        if (exp.first){
            var tup = HasShuffleAndChoice(tree);
            if (exp.evaluating){
                Scorer.gameWorld.hasShuffle = tup.Item1;
                Scorer.gameWorld.hasChoice = tup.Item2;
            }
        }
        int choiceCount = 0;
        var aggregator = new int[5, exp.numEpochs];
        var winaggregator = new int[exp.numEpochs];

        int[,] playerRank = new int[5, exp.numEpochs];
        int[,] playerFirst = new int[5, exp.numEpochs];
       
        Stopwatch time = new Stopwatch();
        time.Start();
        int numPlayers = 0;

        for (int i = 0; i < exp.numGames; ++i)
        {
            try
            {


                System.GC.Collect();

                Dictionary<String, int> seenStates = new Dictionary<String, int>();

                CardEngine.CardGame.Instance = new CardEngine.CardGame();
                var manageContext = new FreezeFrame.GameIterator(tree);

                currentIterator = manageContext;
                // TODO add so can have 4 AI players
                if (exp.ai1)
                {
                    CardEngine.CardGame.Instance.players[0].decision = new LessThanPerfectPlayer();
                    //CardEngine.CardGame.Instance.players[0].decision = new PerfectPlayer();
                }
                if (exp.ai2)
                {
                    CardEngine.CardGame.Instance.players[1].decision = new LessThanPerfectPlayer();
                    //CardEngine.CardGame.Instance.players[1].decision = new PerfectPlayer();
                }
                while (!manageContext.AdvanceToChoice())
                {
                    choiceCount++;

                    manageContext.ProcessChoice();


                }

                if (!exp.evaluating) { Console.WriteLine("Results: Game " + (i + 1)); }
                var results = ScoreIterator.ProcessScore(tree.scoring());
                numPlayers = results.Count;
                for (int j = 0; j < results.Count; ++j)
                {
                    aggregator[results[j].Item2, i / (exp.numGames / exp.numEpochs)] += results[j].Item1;
                    if (!exp.evaluating) { Console.WriteLine("Player " + results[j].Item2 + ":" + results[j].Item1); }

                    playerRank[results[j].Item2, i / (exp.numGames / exp.numEpochs)] += j;
                    // if player was ranked first (could be win or loss)
                    if (j == 0)
                    {
                        playerFirst[results[j].Item2, i / (exp.numGames / exp.numEpochs)]++;
                    }
					if (results[j].Item2 == 0 && j != results.Count - 1)
                    {
                        winaggregator[i / (exp.numGames / exp.numEpochs)]++;
                        if (Scorer.gameWorld != null) { Scorer.gameWorld.GameOver(j); }
                    }
                }

                WriteToFile("|");
                Debug.WriteLine("Finished game " + (i + 1) + " of " + exp.numGames);
            }
            catch (Exception e)
            {
                if (exp.evaluating) { Scorer.gameWorld.compiling = false; }
                Console.WriteLine(fileName + " failed from exception: " + e + "\n\n\n");
            }
        }
        time.Stop();
        if (!exp.evaluating)
        {
            Console.Out.WriteLine(time.Elapsed);
            Console.Out.WriteLine("Turns per game: " + choiceCount / (double)(exp.numGames));
            Console.Out.WriteLine("Score: ");
            for (int i = 0; i < numPlayers; ++i)
            {
                Console.Out.Write("Player" + i  + ":\t");

                for (int j = 0; j < exp.numEpochs; j++)
                {
                    Console.Out.Write(aggregator[i, j] / (double)(exp.numGames / exp.numEpochs) + "\t");

                }
                Console.Out.WriteLine();
            }
			Console.Out.WriteLine("Rank: ");

			for (int i = 0; i < numPlayers; ++i)
			{
				Console.Out.Write("Player" + i + ":\t");

				for (int j = 0; j < exp.numEpochs; j++)
				{
					Console.Out.Write(playerRank[i, j] / (double)(exp.numGames / exp.numEpochs) + "\t");
				}
				Console.Out.WriteLine();
			}
			Console.Out.WriteLine("First: ");

			for (int i = 0; i < numPlayers; ++i)
			{
				Console.Out.Write("Player" + i + ":\t");

				for (int j = 0; j < exp.numEpochs; j++)
				{
					Console.Out.Write(playerFirst[i, j] / (double)(exp.numGames / exp.numEpochs) + "\t");
				}
				Console.Out.WriteLine();
			}


            //for (int j = 0; j < exp.numEpochs; j++)
            //{
                
            //    if (exp.evaluating) { Scorer.gameWorld.wins += 1; }
            //}

            Console.Out.WriteLine();


           // Console.Read();
        }
        else
        {
            Scorer.gameWorld.numFirstWins += winaggregator[0];
            Scorer.gameWorld.numGames += winaggregator.Sum();
            if (exp.ai1 && !exp.ai2)
            {
                Scorer.gameWorld.numAIWins += winaggregator[0]; //TODO does this do what i think it does?
                if (winaggregator.Length > 1) { Scorer.gameWorld.numRndWins += winaggregator[1]; }
            }
            else if (!exp.ai1 && exp.ai2)
            {
                Scorer.gameWorld.numRndWins += winaggregator[0];
                if (winaggregator.Length > 1) { Scorer.gameWorld.numAIWins += winaggregator[1]; }
            }
        }
    }

    public void DOTMaker(IParseTree node, string nodeName)
    {

        for (int i = 0; i < node.ChildCount; ++i)
        {
            var dontCreate = false;
            var newNodeName = nodeName + "_" + i;
            var contextName = node.GetChild(i).GetType().ToString().Replace("RecycleParser+", "").Replace("Context", "");
            if (node.GetChild(i).ChildCount > 0 && contextName == "Int")
            {
                var text = node.GetChild(i).GetText();
                int myi = 0;
                while (myi < text.Length && Char.IsDigit(text[myi]))
                {
                    myi++;
                }
                if (myi != text.Length)
                {
                    builder.AppendLine(newNodeName + " [label=\"" + node.GetChild(i).GetType().ToString().Replace("RecycleParser+", "").Replace("Context", "") + "\" ]");
                    DOTMaker(node.GetChild(i), newNodeName);
                }
                else
                {
                    builder.AppendLine(newNodeName + " [label=\"" + node.GetChild(i).GetText() + "\" style=filled fillcolor=\"lightblue\"]");
                }
            }
            else if (node.GetChild(i).ChildCount > 0 && contextName != "Namegr" && contextName != "Name" && contextName != "Trueany")
            {
                var extra = "";
                if (contextName == "Stage")
                {
                    extra = " style=filled fillcolor=\"red\"";
                }
                else if (contextName == "Computermoves")
                {
                    extra = " style=filled shape=box fillcolor=\"yellow\"";
                }
                else if (contextName == "Playermoves")
                {
                    extra = " style=filled shape=diamond fillcolor=\"orange\"";
                }
                builder.AppendLine(newNodeName + " [label=\"" + node.GetChild(i).GetType().ToString().Replace("RecycleParser+", "").Replace("Context", "") + "\" " + extra + "]");
                DOTMaker(node.GetChild(i), newNodeName);
            }
            else if (node.GetChild(i).ChildCount > 0)
            {
                builder.AppendLine(newNodeName + " [fillcolor=\"green\" style=filled label=\"" + node.GetChild(i).GetText() + "\"]");
            }
            else if (node.GetChild(i).GetText() == "(" || node.GetChild(i).GetText() == ")" || node.GetChild(i).GetText() == "," ||
                                        node.GetChild(i).GetText() == "end" || node.GetChild(i).GetText() == "stage" || node.GetChild(i).GetText() == "comp" ||
                                        node.GetChild(i).GetText() == "create" || node.GetChild(i).GetText() == "sto" || node.GetChild(i).GetText() == "loc" ||
                                        node.GetChild(i).GetText() == "initialize" || node.GetChild(i).GetText() == "move" || node.GetChild(i).GetText() == "copy" ||
                                        node.GetChild(i).GetText() == "inc" || node.GetChild(i).GetText() == "dec" || node.GetChild(i).GetText() == "shuffle" ||
                                        node.GetChild(i).GetText() == "remove" ||
                                        node.GetChild(i).GetText() == "choice")
            {
                dontCreate = true;
            }
            else
            {
                builder.AppendLine(newNodeName + " [label=\"" + node.GetChild(i).GetText() + "\"]");
                //DOTMaker(node.GetChild(i),newNodeName);
            }
            if (!dontCreate)
            {
                builder.AppendLine(nodeName + " -- " + newNodeName);
            }
        }
    }

    Tuple<bool, bool> HasShuffleAndChoice(IParseTree tree)
    {
        bool shuffle = false;
        bool choice = false;
        if (tree is RecycleParser.ShuffleactionContext)
        {
            shuffle = true;
        }
        else if (tree is RecycleParser.MultiactionContext)
        {
            if (tree.GetChild(1).GetText().Equals("choice"))
            {
                choice = true;
            }
        }
        if (shuffle && choice) { return new Tuple<bool, bool>(shuffle, choice); }
        for (int i = 0; i < tree.ChildCount; i++)
        {
            var res = HasShuffleAndChoice(tree.GetChild(i));
            shuffle |= res.Item1;
            choice |= res.Item2;
        }
        return new Tuple<bool, bool>(shuffle, choice);
    }


    /*******
	 * Logging for the visualization of games in play
	 */
    public static void WriteToFile(String text)
    {
        if (expstat.logging)
        {
            using (StreamWriter file = new StreamWriter(expstat.fileName + ".txt", true))
            {
                file.WriteLine(text);
            }
        }
    }
}