using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;
using CardGames;
using CardStockXam;
using Players;

// add basic stats (% wins)
public class ParseEngine
{

    public Experiment exp;
    public RecycleParser.GameContext tree;
    public string fileName;

    public ParseEngine(Experiment exp)
    {
        this.exp = exp;
    }


    public Tuple<bool, bool> Loader() {

        Debug.AutoFlush = true;
        var regex = new Regex("(;;)(.*?)(\n)");

        if (exp.logging)
        {
            File.WriteAllText(exp.fileName + ".txt", string.Empty);
        }


        /************
         * Load up the game from the .gdl RECYCLE description
         ************/
        fileName = exp.fileName;
        if (!exp.evaluating)
        {
            fileName = "games/" + fileName + ".gdl";
        }
        else
        {
            string[] split = new string[] { "Release\\" };
            var path = fileName.Split(split, StringSplitOptions.RemoveEmptyEntries);
            if (path.Count() == 1)
            {
                split = new string[] { "Debug\\" };
                path = fileName.Split(split, StringSplitOptions.RemoveEmptyEntries);
            }
            fileName = path[1] + ".gdl";
        }
        Console.WriteLine("name: " + fileName);
        var file = File.ReadAllText(fileName);
        file = regex.Replace(file, "\n");

        /***********
         * Parse the game with the Antlr grammar description
         ***********/
        AntlrInputStream stream = new AntlrInputStream(file);
        ITokenSource lexer = new RecycleLexer(stream);
        ITokenStream tokens = new CommonTokenStream(lexer);
        var parser = new RecycleParser(tokens);

        parser.BuildParseTree = true;
        this.tree = parser.game();


        /***********
         * Make the parse tree visualization
         ***********/
        if (!exp.evaluating)
        {
            DOTMakerTop(tree, exp.fileName);
        }

        return HasShuffleAndChoice(tree);

    }

    public bool Experimenter() {
        int choiceCount = 0;
		int numPlayers = 0;
		var aggregator = new int[5, exp.numEpochs];
        var winaggregator = new int[exp.numEpochs];
        bool compiling = true;
        int[,] playerRank = new int[5, exp.numEpochs];
        int[,] playerFirst = new int[5, exp.numEpochs];
       
        Stopwatch time = new Stopwatch();
        time.Start();
       


        /***********
         * Run the experiments
         ***********/

        //for (int i = 0; i < exp.numGames; i++)
        Parallel.For(0, exp.numGames, i =>
        {
            try
            {
                
                System.GC.Collect();

                CardEngine.CardGame instance = new CardEngine.CardGame(true, exp.fileName + i);
                var manageContext = new FreezeFrame.GameIterator(tree, instance);

                // TODO add so can have 4 AI players
                if (exp.ai1)
                {
                    instance.players[0].decision = new LessThanPerfectPlayer(manageContext);
                }
                if (exp.ai2)
                {
                    instance.players[1].decision = new LessThanPerfectPlayer(manageContext);
                }

                // PLAY THE GAME
                while (!manageContext.AdvanceToChoice())
                {
                    choiceCount++;
                    manageContext.ProcessChoice();
                }

                // SORT OUT RESULTS
                if (!exp.evaluating) { Console.WriteLine("Results: Game " + (i + 1)); }
                var results = manageContext.parseoop.ProcessScore(tree.scoring());
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

                Debug.WriteLine("Finished game " + (i + 1) + " of " + exp.numGames);
            }
            catch (Exception e)
            {
                Console.WriteLine(fileName + " failed from exception: " + e + "\n\n\n");
                compiling = false;
            }
        }
        );
        // should fail as soon as a game stops compiling, not after all threads are finished TODO 
        if (!compiling)
        {
            return false;
        }
        time.Stop();


        if (!exp.evaluating)
        {
            // SHOW RESULTS TO CONSOLE
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
            Console.Out.WriteLine();
            // Console.Read();
        }
        else
        {
            // USE RESULTS IN GENETIC ALGORITHM
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
        return true;
    }

	/*********
     * Output the parsed game for graphviz dot
     *********/
	public void DOTMakerTop(IParseTree node, string fileName) {
		StringBuilder builder = new StringBuilder();
		builder.Append("graph tree{");
		builder.AppendLine("NODE0 [label=\"Stage\" style=filled fillcolor=\"red\"]");
		DOTMaker(node, "NODE0", builder);
		builder.Append("}");
		try
		{
			var fs = File.Create("games/" + fileName + ".gv");
			var bytes = Encoding.UTF8.GetBytes(builder.ToString());
			fs.Write(bytes, 0, bytes.Length);
			fs.Close();
			Debug.WriteLine("wrote " + fileName + ".gv");
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.ToString());
		}
	}

    /*********
     * Output the parsed game for graphviz dot
     *********/
    public void DOTMaker(IParseTree node, string nodeName, StringBuilder builder)
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
                    DOTMaker(node.GetChild(i), newNodeName, builder);
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
                DOTMaker(node.GetChild(i), newNodeName, builder);
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
}