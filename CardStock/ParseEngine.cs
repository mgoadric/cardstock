using Antlr4.Runtime;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Antlr4.Runtime.Tree;
using CardStock.CardEngine;
using CardStock.Players;
using CardStock.Scoring;

namespace CardStock {
public class ParseEngine
{

    public Experiment exp;
    public RecycleParser.GameContext tree;
    public World gameWorld;
    public string fileName;
    public static int CHOICELIMIT = 200;

        public ParseEngine(Experiment exp, World gameWorld)
        {
            this.exp = exp;
            this.gameWorld = gameWorld;
        }

    public Tuple<bool, bool> Loader() {

        Debug.AutoFlush = true;

        if (exp.Logging)
        {
            File.WriteAllText("output/" + exp.Game + "/" + exp.PlayerCount + "/logging.txt", string.Empty);
        }

        /************
         * Load up the game from the .gdl RECYCLE description
         ************/
        fileName = "games/" + exp.Game + exp.PlayerCount + ".gdl";

        Console.WriteLine("name: " + fileName);

        var file = File.ReadAllText(fileName);
        var regex = new Regex("(;;)(.*?)(\n)");
        file = regex.Replace(file, "\n");

        /***********
         * Parse the game with the Antlr grammar description
         ***********/
        AntlrInputStream stream = new(file);
        ITokenSource lexer = new RecycleLexer(stream);
        ITokenStream tokens = new CommonTokenStream(lexer);
        var parser = new RecycleParser(tokens);

        parser.BuildParseTree = true;
        this.tree = parser.game();

        /***********
         * Make the parse tree visualization
         ***********/
        if (!exp.Evaluating)
        {
            DotVisualization.DOTMakerTop(tree, fileName);
        }

        return HasShuffleAndChoice(tree);

    }

    public bool Experimenter() {

        int numPlayers = 0;

		var aggregator = new int[10, exp.NumEpochs];
        bool compiling = true;
        int choiceAgg = 0;
        int[,] playerRank = new int[10, exp.NumEpochs];
        double[,] playerFirst = new double[10, exp.NumEpochs];

        if (exp.type == GameType.AllAI)
        {
            gameWorld.numAIvsAI = exp.NumGames;
        }

        Stopwatch time = new();
        time.Start();

        /***********
         * Run the experiments
         ***********/
        List<List<double>>[] lead = new List<List<double>>[exp.NumGames];

        string filePath = "output/" + exp.Game + "/" + exp.PlayerCount + "/" + exp.type + "-leadstats.txt";
        System.IO.FileInfo file = new(filePath);
        file.Directory.Create(); // If the directory already exists, this method does nothing.
        StreamWriter expleadfile = new(filePath);
        expleadfile.WriteLine(exp.type);
        StreamWriter expchoicefile = new("output/" + exp.Game + "/" + exp.PlayerCount + "/" + exp.type + "-choicestats.txt");
        expchoicefile.WriteLine(exp.type);
        StreamWriter expresultsfile = new("output/" + exp.Game + "/" + exp.PlayerCount + "/" + exp.type + "-resultsstats.txt");
        expresultsfile.WriteLine(exp.type);
        StreamWriter expspreadfile = new("output/" + exp.Game + "/" + exp.PlayerCount + "/" + exp.type + "-spreadstats.txt");
        expspreadfile.WriteLine(exp.type);
        int[] winners = new int[exp.NumGames];
        int numFinished = 0;

            //Parallel.For(0, exp.NumGames, i =>
        for (int i = 0; i < exp.NumGames; i++)
        {
            try
            {
                System.GC.Collect();

                // TODO Can the creation of the game go inside the GameIterator???
                CardGame game = new();

                var gamePlay = new FreezeFrame.GameIterator(tree, game, gameWorld, "output/" + exp.Game + "/" + exp.PlayerCount + "/simulation" + i + exp.type + ".txt");

                if (exp.type == GameType.AllAI)
                {
                    Console.WriteLine("Making players");
                    for (int j = 0; j < game.players.Length; j++)
                    {
                        Perspective perspective = new(j, gamePlay);
                        game.players[j].decision = exp.ai.AI(perspective);
                    }
                }
                else if (exp.type == GameType.RndandAI)
                {
                    Perspective perspective = new(0, gamePlay);
                    game.players[0].decision =  exp.ai.AI(perspective);
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

                    if (gamePlay.totalChoices > CHOICELIMIT)
                    {
                        Console.WriteLine("Game " + (i + 1) + " Choices not processed (probably infinite loop)");
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

                    var (results, mult) = gamePlay.ProcessScore();
                    numPlayers = results.Count;

                    int topRank = 0;
                    int numWinners = 1;

                    for (int j = 0; j < results.Count; ++j)
                    {

                        aggregator[results[j].Item2, i / (exp.NumGames / exp.NumEpochs)] += results[j].Item1;
                        //if (!exp.evaluating) { Console.WriteLine("Player " + results[j].Item2 + ":" + results[j].Item1); }

                        if (j != 0 && results[j].Item1 != results[j - 1].Item1)
                        {
                            playerRank[results[j].Item2, i / (exp.NumGames / exp.NumEpochs)] += j;
                            if (topRank == 0)
                            {
                                numWinners = j;
                            }
                            topRank = j;

                        }
                        else
                        {
                            playerRank[results[j].Item2, i / (exp.NumGames / exp.NumEpochs)] += topRank;
                        }

                    }

                    for (int j = 0; j < results.Count; ++j)
                    {
                        if (j == 0 || results[j].Item1 == results[j - 1].Item1)
                        {
                            playerFirst[results[j].Item2, i / (exp.NumGames / exp.NumEpochs)] += 1.0 / numWinners;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (gameWorld != null)
                    {
                        // also go get AIPlayer and get the chunk of data here about winners/choices
                        // also lock this in the gameover method so that it's safe for multiple games to access 
                        if (exp.type == GameType.AllAI)
                        {
                            lead[i] = [];
                            for (int j = 0; j < game.players.Length; j++)
                            {
                                Console.WriteLine("Adding leads for P" + j + ", count of " + game.players[j].decision.GetLead().Count);
                                lead[i].Add(game.players[j].decision.GetLead());
                            }

                        }
                        else if (exp.type == GameType.RndandAI)
                        {
                            lead[i] = [game.players[0].decision.GetLead()];
                        }
                        winners[i] = results[0].Item2;

                        expchoicefile.WriteLine("game" + i);
                        foreach (Tuple<int, int> t in gamePlay.choiceList)
                        {
                            expchoicefile.Write(t.Item2 + ",");
                        }
                        expchoicefile.WriteLine();
                        foreach (Tuple<int, int> t in gamePlay.choiceList)
                        {
                            expchoicefile.Write(t.Item1 + ",");
                        }
                        expchoicefile.WriteLine();

                        expleadfile.WriteLine("game" + i);
                        foreach (Tuple<int, double[]> allLeads in gamePlay.allLeadList)
                        {
                            expleadfile.Write(allLeads.Item1 + ",");
                            for (int k = 0; k < numPlayers; k++)
                            {
                                expleadfile.Write(allLeads.Item2[k] + ",");
                            }
                            expleadfile.WriteLine();
                        }

                        expspreadfile.WriteLine("game" + i);
                        foreach (Tuple<int, double> s in gamePlay.spreadList)
                        {
                            expspreadfile.Write(s.Item2 + ",");
                        }
                        expspreadfile.WriteLine();
                        foreach (Tuple<int, double> s in gamePlay.spreadList)
                        {
                            expspreadfile.Write(s.Item1 + ",");
                        }
                        expspreadfile.WriteLine();
                    }

                    numFinished++;
                    Console.WriteLine("Finished game " + numFinished + " of " + exp.NumGames);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(fileName + " failed from exception: " + e + "\n\n\n");
                compiling = false;
            }
        }
        //);
        

        // should fail as soon as a game stops compiling, not after all threads are finished TODO 
        if (!compiling)
        {
            return false;
        }

        time.Stop();

        if (!exp.Evaluating)
        {
            // SHOW RESULTS TO CONSOLE
            Console.WriteLine(time.Elapsed);
            Console.WriteLine("Turns per game: " + choiceAgg / (double)(exp.NumGames));
            Console.WriteLine("Score: ");
            for (int i = 0; i < numPlayers; ++i)
            {
                Console.Out.Write("Player" + i  + ":\t");

                for (int j = 0; j < exp.NumEpochs; j++)
                {
                    Console.Out.Write(aggregator[i, j] / (double)(exp.NumGames / exp.NumEpochs) + "\t");

                }
                Console.WriteLine();
            }
			Console.WriteLine("Rank: ");

			for (int i = 0; i < numPlayers; ++i)
			{
				Console.Out.Write("Player" + i + ":\t");

				for (int j = 0; j < exp.NumEpochs; j++)
				{
					Console.Out.Write(playerRank[i, j] / (double)(exp.NumGames / exp.NumEpochs) + "\t");
				}
				Console.WriteLine();
			}
			Console.WriteLine("First: ");

			for (int i = 0; i < numPlayers; ++i)
			{
				Console.Out.Write("Player" + i + ":\t");

				for (int j = 0; j < exp.NumEpochs; j++)
				{
					Console.Out.Write(playerFirst[i, j] / (double)(exp.NumGames / exp.NumEpochs) + "\t");
				}
				Console.WriteLine();
			}
            Console.WriteLine();
            // Console.Read();
        }
        else
        {

            expresultsfile.WriteLine(time.Elapsed);
            expresultsfile.WriteLine("Turns per game," + choiceAgg / (double)(exp.NumGames));
            expresultsfile.WriteLine("Score: ");
            for (int i = 0; i < numPlayers; ++i)
            {
                for (int j = 0; j < exp.NumEpochs; j++)
                {
                    expresultsfile.Write(aggregator[i, j] / (double)(exp.NumGames / exp.NumEpochs) + ",");

                }
                expresultsfile.WriteLine();
            }
            expresultsfile.WriteLine("Rank: ");

            for (int i = 0; i < numPlayers; ++i)
            {
                for (int j = 0; j < exp.NumEpochs; j++)
                {
                    expresultsfile.Write(playerRank[i, j] / (double)(exp.NumGames / exp.NumEpochs) + ",");
                }
                expresultsfile.WriteLine();
            }

            gameWorld.SetWinners(winners);
            gameWorld.AddNumTurns(choiceAgg);

            // USE RESULTS IN GENETIC ALGORITHM
            var sum = 0.0;
			for (int i = 0; i < exp.NumEpochs; i++)
			{
				sum += playerFirst[0, i];
			}

            if (exp.type == GameType.AllRnd)
            {          
                gameWorld.numFirstWins += sum;
				gameWorld.numGames += exp.NumGames;
            }
            else if (exp.type == GameType.RndandAI)
            {
                gameWorld.numAIvsRnd += exp.NumGames;
                gameWorld.numAIWins += sum;
                gameWorld.SetRndVsAI(lead);
            }
            else {
                gameWorld.SetAIVsAI(lead);
            }
        }
        expleadfile.Close();
        expchoicefile.Close();
        expresultsfile.Close();
        expspreadfile.Close();
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
}
