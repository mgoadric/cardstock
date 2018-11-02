using System.Collections.Generic;
using CardEngine;
using Players;
using System.IO;
using System.Threading;
using CardStockXam.Scoring;

namespace CardGames
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CardStockXam.Scorer.Main(args);
            var p = new Program();
            p.SingleGame("games/BottleImp.gdl");
            //p.AllGames();
        }

        void SingleGame(string game) {
			var exp = new Experiment();
			exp.fileName = game;
            // System.Console.WriteLine(g.Substring(6, g.Length - 4));
            exp.numGames = 10;
            exp.numEpochs = 1;

            exp.logging = false;
            exp.evaluating = false;
            exp.type = GameType.RndandAI;

			var codeGen = new ParseEngine(exp);
            codeGen.setWorld(new World());
            codeGen.Loader();
            codeGen.Experimenter();
            System.Console.ReadLine();
		}

        void AllGames() {
            System.Console.WriteLine("All Games!");
			List<string> gameFiles = new List<string>();
			string[] allFiles = System.IO.Directory.GetFiles("games/");

			foreach (string s in allFiles)
			{
                if (s.EndsWith(".gdl"))
				{
					gameFiles.Add(s);
				}
			}
            foreach (string g in gameFiles.GetRange(0, gameFiles.Count)) {
                SingleGame(g);
            }
   		}
    }
}
