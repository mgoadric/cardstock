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
            p.SingleGame("games/NinetyEight.gdl");
            // p.AllGames();


        }



        void SingleGame(string game) {
			var exp = new Experiment();
			exp.fileName = game;
            // System.Console.WriteLine(g.Substring(6, g.Length - 4));
            exp.numGames = 100;
			exp.numEpochs = 1;

            exp.logging = true;
            exp.evaluating = false;
            exp.type = GameType.AllRnd;

			var codeGen = new ParseEngine(exp);
            codeGen.setWorld(new World());
            codeGen.Loader();
            codeGen.Experimenter();
            System.Console.ReadLine();
		}

        void AllGames() {
			List<string> gameFiles = new List<string>();
			string[] allFiles = System.IO.Directory.GetFiles("games/");

			foreach (string s in allFiles)
			{
                if (s.EndsWith(".gdl") && string.Compare(s[6].ToString(), "L") > 0)
				{
					gameFiles.Add(s);
				}
			}
            foreach (string g in gameFiles.GetRange(0, gameFiles.Count)) {
                SingleGame(g.Substring(6, g.Length - 10));
            }
   		}
    }
}
