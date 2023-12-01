using System.Collections.Generic;
using CardEngine;
using Players;
using System.IO;
using System.Threading;
using CardStockXam.Scoring;
using CardStockXam;
using System;
using System.Diagnostics;

namespace CardGames
{
    public class Program
    {

        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine(args[0]);
            }
            int numRndvRnd = 100;
            int numAIvRnd = 100;
            int numAIvAI = 100;
            string name = "games/Pairs4.gdl";

            var p = new Scorer(name, numRndvRnd, numAIvRnd, numAIvAI);
            var score = p.Score();

            Debug.WriteLine(name + "\t" + score);

            Console.ReadLine();
        }

        void SingleGame(string game) {
			var exp = new Experiment();
			exp.fileName = game;
            // System.Console.WriteLine(g.Substring(6, g.Length - 4));
            exp.numGames = 100;
            exp.numEpochs = 10;

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