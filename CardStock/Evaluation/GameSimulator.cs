using Antlr4.Runtime;
using System.Text.RegularExpressions;
using System.Diagnostics;
using CardStock.CardEngine;
using CardStock.Players;

namespace CardStock.Evaluation {
    public partial class GameSimulator(Experiment exp)
    {

        private readonly Experiment exp = exp;
        private RecycleParser.GameContext tree;
        public const int MAXPLAYERS = 9; // This makes some things easier to store as arrays.
        public const int CHOICELIMIT = 500; // The upper bound on the number of moves in a game before it is called.
        public const int NUMTESTS = 100; //make 1000 for comparison.  This is PER MOVE
        public const int NUMSAMPLES = 10; // how many determinizations the AIs should create

        public void LoadGame() {

            Debug.AutoFlush = true;

            /************
            * Load up the game from the .rcy RECYCLE description
            ************/
            string fileName = "games/" + exp.Game + exp.PlayerCount + ".rcy";

            Console.WriteLine("name: " + fileName);

            var file = File.ReadAllText(fileName);
            var regex = MyRegex();
            file = regex.Replace(file, "\n");

            /***********
            * Parse the game with the Antlr grammar description
            ***********/
            AntlrInputStream stream = new(file);
            ITokenSource lexer = new RecycleLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            var parser = new RecycleParser(tokens)
            {
                BuildParseTree = true
            };
            this.tree = parser.game();

            /***********
            * Make the parse tree visualization
            ***********/
            DotVisualization.DOTMakerTop(tree, "output/" + exp.Game + "/" + exp.PlayerCount + "/parsetree");
        }

        public bool RunExperiment() {

            Stopwatch time = new();
            time.Start();

            /***********
            * Set up the data recording files
            ***********/

            DataCollector dc = new(exp);

            int numFinished = 0;

            /***********
            * Run the experiments
            ***********/
            //Parallel.For(0, exp.NumGames, i =>
            for (int i = 0; i < exp.NumGames; i++)
            {
                try
                {
                    GC.Collect();

                    string path = "output/" + exp.Game + "/" + exp.PlayerCount + "/" + exp.PlayerAbv() + "/simulation/";
                    FileInfo file = new(path);
                    file.Directory.Create();

                    CardGame game = new();
                    var gamePlay = new FreezeFrame.GameIterator(tree, game, path + (i + 1));
                    if (game.players.Length > MAXPLAYERS)
                    {
                        Console.WriteLine("Too many players, max is " + MAXPLAYERS);
                        throw new Exception();
                    }

                    // Fill in the players. If not specificed, make a Random player.
                    for (int j = 0; j < game.players.Length; j++)
                    {
                        Perspective perspective = new(j, gamePlay);

                        if (j < exp.Players.Count)
                        {
                            game.players[j].decision = exp.Players[j].AI(perspective);
                        }
                        else
                        {
                            game.players[j].decision = PlayerType.RANDOM.AI(perspective);
                        }
                        game.players[j].decision.dc = dc;
                    }

                    /*********
                         * PLAY THE GAME
                         ***********/
                        while (!gamePlay.AdvanceToChoice())
                        {
                            gamePlay.ProcessChoice();

                            if (gamePlay.totalChoices > CHOICELIMIT)
                            {
                                Console.WriteLine("Game " + (i + 1) + " Choices not processed (probably infinite loop)");
                                //compiling = false;
                                break;
                            }
                        }

                    var (results, mult) = gamePlay.ProcessScore();

                    /************
                     * WRITE OUT STATS
                     *************/
                    dc.RecordGameStatistics(i, results, mult);

                    numFinished++;
                    Console.WriteLine("Finished game " + numFinished + " of " + exp.NumGames);

                }
                catch (Exception e)
                {
                    Console.WriteLine(exp.Game + " failed from exception: " + e + "\n\n\n");
                    return false;
                }
            }
        //);
        
            time.Stop();

            dc.Close();

            return true;
        }

        [GeneratedRegex("(;;)(.*?)(\n)")]
        private static partial Regex MyRegex();
    }
}
