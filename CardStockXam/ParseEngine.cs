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
        var breakOnCycle = false;
        var regex = new Regex("(;;)(.*?)(\n)");

        System.IO.File.WriteAllText(exp.fileName + ".txt", string.Empty);

        // Load up the game from the .gdl RECYCLE description
        var f = File.ReadAllText("games/" + exp.fileName + ".gdl");
        var file = f;
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
        try
        {
            var fs = File.Create("games/" + exp.fileName + ".gv");
            var bytes = Encoding.UTF8.GetBytes(builder.ToString());
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
            Console.WriteLine("wrote " + exp.fileName + ".gv");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        int choiceCount = 0;
        var aggregator = new int[5, exp.numEpochs];
        var winaggregator = new int[exp.numEpochs];
        var branching = new int[6, 4];
        int curTBranch = 0;
        int curPBranch = 0;
        int cycleCount = 0;

        Stopwatch time = new Stopwatch();
        time.Start();

        for (int i = 0; i < exp.numGames; ++i)
        {
            Analytics.BranchingFactor.Instance = new Analytics.BranchingFactor();
            Analytics.BinCounts.Instance = new Analytics.BinCounts();
            Analytics.StageCount.Instance = new Analytics.StageCount();
            Analytics.StorageValues.Instance = new Analytics.StorageValues();
            Analytics.TimeStep.Instance = new Analytics.TimeStep();

            System.GC.Collect();
            bool gameBroke = false;
            Dictionary<String, int> seenStates = new Dictionary<String, int>();
            CardEngine.CardGame.Instance = new CardEngine.CardGame();
            var manageContext = new FreezeFrame.GameIterator(tree);
            //manageContext.AdvanceToChoice ();
            currentIterator = manageContext;

            if (exp.ai)
            {
                CardEngine.CardGame.Instance.players[0].decision = new Players.LessThanPerfectPlayer();
            }

            while (!manageContext.AdvanceToChoice())//TODO
            {
                choiceCount++;
                if (breakOnCycle)
                {
                    var curr = CardEngine.CardGame.Instance.ToString();
                    if (seenStates.ContainsKey(curr))
                    {
                        if (seenStates[curr] < 3)
                        {
                            seenStates[curr] += 1;
                        }
                        else
                        {
                            cycleCount++;
                            gameBroke = true;
                            break;
                        }
                    }
                    else
                    {
                        seenStates.Add(curr, 1);
                    }
                }
                manageContext.ProcessChoice();
                branching[curPBranch, curTBranch] += reportedBF;
                curTBranch++;
                if (curTBranch == 4)
                {
                    curTBranch = 0;
                    curPBranch++;
                    if (curPBranch == 6)
                    {
                        curPBranch = 0;
                    }
                }


            }
            if (!gameBroke)
            {
                Console.Out.WriteLine("Results: " + i);
                var results = ScoreIterator.ProcessScore(tree.scoring());
                for (int j = 0; j < results.Count; ++j)
                {
                    aggregator[results[j].Item2, i / (exp.numGames / exp.numEpochs)] += results[j].Item1;
                    Console.Out.WriteLine("Player " + results[j].Item2 + ":" + results[j].Item1);
                    if (results[j].Item2 == 0 && j != results.Count - 1)
                    {
                        winaggregator[i / (exp.numGames / exp.numEpochs)]++;
                    }
                }
            }
            else
            {
                Console.Out.WriteLine("Results:\nCycle Occurred\n");
            }
            Console.WriteLine("here");
            WriteToFile("|");
        }
        time.Stop();
        Console.Out.WriteLine(time.Elapsed);
        Console.Out.WriteLine(choiceCount / (double)(exp.numGames));
        for (int i = 0; i < 5; ++i)
        {
            Console.Out.Write("Player" + (i + 1) + ":\t");
            for (int j = 0; j < exp.numEpochs; j++)
            {
                Console.Out.Write(aggregator[i, j] / (double)(exp.numGames / exp.numEpochs) + "\t");
            }
            Console.Out.WriteLine();
        }
        Console.Out.Write("Wins :\t");
        for (int j = 0; j < exp.numEpochs; j++)
        {
            Console.Out.Write(winaggregator[j] / (double)(exp.numGames / exp.numEpochs) + "\t");
        }
        Console.Out.WriteLine();
        if (breakOnCycle)
        {
            Console.WriteLine("Cycles:" + cycleCount);
        }

        Console.Read();
    }

    /*****
	 * Output suitable for use with GraphViz Dot to
	 * see the parse tree for the game
    public void NEWMaker(IParseTree node, string nodeName)
    {
        for (int i = 0; i < node.ChildCount; ++i)
        {
            var dontCreate = false;
            var newNodeName = nodeName + "_" + i;
            var contextName = node.GetChild(i).GetType().ToString().Replace("RecycleParser+", "").Replace("Context", "");
            if (node.GetChild(i).ChildCount > 0 && contextName == "Int")
            {
                continue;
            }
            else if (node.GetChild(i).ChildCount > 0 && contextName != "Namegr" && contextName != "Name" && contextName != "Trueany")
            {
                continue;
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
            }
            if (!dontCreate)
            {
                builder.AppendLine(nodeName + " -- " + newNodeName);
            }
        }
    }*/

    public void DOTMaker(IParseTree node, string nodeName){

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


    /*******
	 * Logging for the visualization of games in play
	 */
    public static void WriteToFile(String text)
    {
        if (expstat.logging)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(expstat.fileName + ".txt", true))
            {
                file.WriteLine(text);
            }
        }
    }
}