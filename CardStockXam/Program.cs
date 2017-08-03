using System.Collections.Generic;
using CardEngine;
using Players;
using System.IO;
using System.Threading;

namespace CardGames
{
    public class Program

   
    {
        public static void Main(string[] args)
        {
            var p = new Program();
            //p.SingleGame("Pairs");
            p.AllGames();
        }

        void SingleGame(string game) {
			var exp = new Experiment();
			exp.fileName = game;
            // System.Console.WriteLine(g.Substring(6, g.Length - 4));
            exp.numGames = 100;
			exp.numEpochs = 10;

            exp.logging = false;
            // TODO make for as many players as in game 
            // one AI vs everyone else is helpful
            exp.ai1 = true;
            exp.ai2 = false;

			var codeGen = new ParseEngine(exp);
            codeGen.Loader();
            codeGen.Experimenter();
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
