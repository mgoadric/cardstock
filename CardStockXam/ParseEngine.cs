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
using CardEngine;
using Players;
using CardStockXam.Scoring;
using CardStockXam.Players;
using CardStockXam;

public class ParseEngine
{

    public Experiment exp;
    public RecycleParser.GameContext tree;
    public World gameWorld;
    public string fileName;

    public ParseEngine(Experiment exp)
    {
        this.exp = exp;
    }

    public Tuple<bool, bool> Loader() {

        Debug.AutoFlush = true;

        if (exp.logging)
        {
            File.WriteAllText(exp.fileName + ".txt", string.Empty);
        }

        /************
         * Load up the game from the .gdl RECYCLE description
         ************/
        fileName = exp.fileName;

        Console.WriteLine("name: " + fileName);

        var file = File.ReadAllText(fileName);
        var regex = new Regex("(;;)(.*?)(\n)");
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
            DotVisualization.DOTMakerTop(tree, exp.fileName);
        }

        return HasShuffleAndChoice(tree);

    }
    public void setWorld(World gameWorld) {
        this.gameWorld = gameWorld;
    }

    public bool Experimenter() {

        int numPlayers = 0;

		var aggregator = new int[5, exp.numEpochs];
        bool compiling = true;
        int choiceAgg = 0;
        int[,] playerRank = new int[5, exp.numEpochs];
        double[,] playerFirst = new double[5, exp.numEpochs];

        if (exp.type == CardGames.GameType.AllAI)
        {
            gameWorld.numAIvsAI = exp.numGames;
        }

        Stopwatch time = new Stopwatch();
        time.Start();

        /***********
         * Run the experiments
         ***********/
        List<List<double>>[] lead = new List<List<double>>[exp.numGames];
        StreamWriter expfile = new StreamWriter(exp.fileName + "-stats.txt", true);
        expfile.WriteLine(exp.type);
        int[] winners = new int[exp.numGames];
        int numFinished = 0;

        Parallel.For(0, exp.numGames, i =>
        {
            try
            {
                System.GC.Collect();

                // TODO Can the creation of the game go inside the GameIterator???
                CardGame game = new CardGame();
                var gamePlay = new FreezeFrame.GameIterator(tree, game, gameWorld, exp.fileName + i);

                if (exp.type == GameType.AllAI)
                {
                    for (int j = 0; j < game.players.Length; j++)
                    {
                        Console.WriteLine("Making players");
                        Perspective perspective = new Perspective(j, gamePlay);
                        game.players[j].decision = new PIPMCPlayer(perspective);
                        // if (j == 1) { game.players[j].decision = new ISMCTSPlayer(perspective); }
                        // if (j == 2) { game.players[j].decision = new MCTSPLayer(perspective);  }
                        // if (j == 3) { game.players[j].decision = new MCTSLitePLayer(perspective); }
                    }
                }
                else if (exp.type == GameType.RndandAI)
                {
                    Perspective perspective = new Perspective(0, gamePlay);
                    game.players[0].decision = new PIPMCPlayer(perspective);
                }

                /*********
	             * PLAY THE GAME
                 ***********/
                while (!gamePlay.AdvanceToChoice())
                {
                    lock (this)
                    {
                        choiceAgg++;
                    }
                    gamePlay.ProcessChoice();

                    if (gamePlay.totalChoices > 500)
                    {
                        Console.WriteLine("Game " + (i + 1) + "Choices not processed (probably infinite loop)");
                        compiling = false;
                        break;
                    }
                }

                /************
				 * SORT OUT RESULTS
				 *************/
                //if (!exp.evaluating) { Console.WriteLine("Results: Game " + (i + 1)); }
                lock (this)
                {

                    var results = gamePlay.ProcessScore();
                    numPlayers = results.Count();

                    int topRank = 0;
                    int numWinners = 1;

                    for (int j = 0; j < results.Count; ++j)
                    {

                        aggregator[results[j].Item2, i / (exp.numGames / exp.numEpochs)] += results[j].Item1;
                        //if (!exp.evaluating) { Console.WriteLine("Player " + results[j].Item2 + ":" + results[j].Item1); }

                        if (j != 0 && results[j].Item1 != results[j - 1].Item1)
                        {
                            playerRank[results[j].Item2, i / (exp.numGames / exp.numEpochs)] += j;
                            if (topRank == 0)
                            {
                                numWinners = j;
                            }
                            topRank = j;

                        }
                        else
                        {
                            playerRank[results[j].Item2, i / (exp.numGames / exp.numEpochs)] += topRank;
                        }

                    }

                    for (int j = 0; j < results.Count; ++j)
                    {
                        if (j == 0 || results[j].Item1 == results[j - 1].Item1)
                        {
                            playerFirst[results[j].Item2, i / (exp.numGames / exp.numEpochs)] += 1.0 / numWinners;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (gameWorld != null)
                    {
                        // also go get PIPMCPlayer and get the chunk of data here about winners/choices
                        // also lock this in the gameover method so that it's safe for multiple games to access 
                        if (exp.type == GameType.AllAI)
                        {
                            lead[i] = new List<List<double>>();
                            for (int j = 0; j < game.players.Length; j++)
                            {
                                Console.WriteLine("Adding leads for P" + j + ", count of " + game.players[j].decision.GetLead().Count);
                                lead[i].Add(game.players[j].decision.GetLead());
                            }

                        }
                        else if (exp.type == GameType.RndandAI)
                        {
                            lead[i] = new List<List<double>>();
                            lead[i].Add(game.players[0].decision.GetLead());
                        }
                        winners[i] = results[0].Item2;
                        //gameWorld.GameOver(results[0].Item2);
                        //gameWorld.IncNumTurns(choiceCount);
                        expfile.WriteLine("game" + (numFinished + 1));
                        foreach (Tuple<int, int> t in gamePlay.choiceList)
                        {
                            expfile.Write(t.Item2 + ",");
                        }
                        expfile.WriteLine();
                        foreach (Tuple<int, int> t in gamePlay.choiceList)
                        {
                            expfile.Write(t.Item1 + ",");
                        }
                        expfile.WriteLine();

                        foreach (Tuple<int, double[]> allLeads in gamePlay.allLeadList)
                        {
                            expfile.Write(allLeads.Item1 + ",");
                            for (int k = 0; k < numPlayers; k++)
                            {
                                expfile.Write(allLeads.Item2[k] + ",");
                            }
                            expfile.WriteLine();
                        }
                    }

                    numFinished++;
                    Console.WriteLine("Finished game " + numFinished + " of " + exp.numGames);
                }


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
            Console.WriteLine(time.Elapsed);
            Console.WriteLine("Turns per game: " + choiceAgg / (double)(exp.numGames));
            Console.WriteLine("Score: ");
            for (int i = 0; i < numPlayers; ++i)
            {
                Console.Out.Write("Player" + i  + ":\t");

                for (int j = 0; j < exp.numEpochs; j++)
                {
                    Console.Out.Write(aggregator[i, j] / (double)(exp.numGames / exp.numEpochs) + "\t");

                }
                Console.WriteLine();
            }
			Console.WriteLine("Rank: ");

			for (int i = 0; i < numPlayers; ++i)
			{
				Console.Out.Write("Player" + i + ":\t");

				for (int j = 0; j < exp.numEpochs; j++)
				{
					Console.Out.Write(playerRank[i, j] / (double)(exp.numGames / exp.numEpochs) + "\t");
				}
				Console.WriteLine();
			}
			Console.WriteLine("First: ");

			for (int i = 0; i < numPlayers; ++i)
			{
				Console.Out.Write("Player" + i + ":\t");

				for (int j = 0; j < exp.numEpochs; j++)
				{
					Console.Out.Write(playerFirst[i, j] / (double)(exp.numGames / exp.numEpochs) + "\t");
				}
				Console.WriteLine();
			}
            Console.WriteLine();
            // Console.Read();
        }
        else
        {

            expfile.WriteLine(time.Elapsed);
            expfile.WriteLine("Turns per game," + choiceAgg / (double)(exp.numGames));
            expfile.WriteLine("Score: ");
            for (int i = 0; i < numPlayers; ++i)
            {
                for (int j = 0; j < exp.numEpochs; j++)
                {
                    expfile.Write(aggregator[i, j] / (double)(exp.numGames / exp.numEpochs) + ",");

                }
                expfile.WriteLine();
            }
            expfile.WriteLine("Rank: ");

            for (int i = 0; i < numPlayers; ++i)
            {
                for (int j = 0; j < exp.numEpochs; j++)
                {
                    expfile.Write(playerRank[i, j] / (double)(exp.numGames / exp.numEpochs) + ",");
                }
                expfile.WriteLine();
            }

            gameWorld.SetWinners(winners);
            gameWorld.AddNumTurns(choiceAgg);

            // USE RESULTS IN GENETIC ALGORITHM
            var sum = 0.0;
			for (int i = 0; i < exp.numEpochs; i++)
			{
				sum += playerFirst[0, i];
			}

            if (exp.type == GameType.AllRnd)
            {          
                gameWorld.numFirstWins += sum;
				gameWorld.numGames += exp.numGames;
            }
            else if (exp.type == GameType.RndandAI)
            {
                gameWorld.numAIvsRnd += exp.numGames;
                gameWorld.numAIWins += sum;
                gameWorld.SetRndVsAI(lead);
            }
            else {
                gameWorld.SetAIVsAI(lead);
            }
        }
        expfile.Close();
        return true;
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
