using System.Collections.Generic;
using CardEngine;
using Players;
using System.IO;
using System.Threading;

namespace CardGames
{
    public class Program

    // todo: Hearts - check if any statement fixed issue
    //        SaneEights - run 100 times, look at fancycardmoveaction print stamenets
    //          to see where it's trying to move from empty location
    //       lostCities - check if removing duplicate declare statements fixed it
    //       DuckSoup - ? i think is also trying to move from empty location?
    {
        public static void Main(string[] args)
        {
            var p = new Program();
            p.SingleGame("Pairs");
            //p.AllGames();
        }

        void SingleGame(string game) {
			var exp = new Experiment();
			exp.fileName = game;
            // System.Console.WriteLine(g.Substring(6, g.Length - 4));
            exp.numGames = 1;
			exp.numEpochs = 1;

            exp.logging = false;
            // TODO make for as many players as in game 
            // one AI vs everyone else is helpful
            exp.ai1 = true;
            exp.ai2 = false;

			var codeGen = new ParseEngine(exp);
		}

        void AllGames() {
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
                SingleGame(g.Substring(6, g.Length - 10));
            }
   		}
    }
}
