using Antlr4.Runtime;
using System.Text.RegularExpressions;
using System.Diagnostics;
using CardStock.CardEngine;
using CardStock.Players;
using CardStock.FreezeFrame;
using System.Runtime;

namespace CardStock.Evaluation
{
    public partial class GameSimulator()
    {

        public static Experiment exp;
        private RecycleParser.GameContext tree;
        public const ImperfectLevel imperfectLevel = ImperfectLevel.TAKEN;

        public void LoadGame()
        {

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

        public async Task<bool> RunExperiment()
        {
            GameThreadPool pool = new(
                exp.NumGames, Environment.ProcessorCount, exp, tree
            );

            await pool.Start();

            return true;
        }

        [GeneratedRegex("(;;)(.*?)(\n)")]
        private static partial Regex MyRegex();
    }
}
