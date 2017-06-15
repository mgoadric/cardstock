using System.Collections.Generic;
using CardEngine;
using Players;
using System.IO;

namespace CardGames
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AllGames();

        }

        static void SingleGame(string game){
			var exp = new Experiment();
			exp.fileName = game;
			// System.Console.WriteLine(g.Substring(6, g.Length - 4));
			exp.numGames = 1;
			exp.numEpochs = 1;

			exp.logging = true;
			exp.ai1 = false;
			exp.ai2 = false;

			var codeGen = new ParseEngine(exp);
		}

        static void AllGames(){
			List<string> gameFiles = new List<string>();
			string[] allFiles = System.IO.Directory.GetFiles("games/");
			foreach (string s in allFiles)
			{
				if (s.EndsWith(".gdl"))
				{
					gameFiles.Add(s);
				}
			}
			foreach (string g in gameFiles)
			{

				var exp = new Experiment();

				string sub = g.Substring(6, g.Length - 10);
				exp.fileName = sub;

				exp.numGames = 1;
				exp.numEpochs = 1;

				exp.logging = true;
				exp.ai1 = false;
				exp.ai2 = false;

				var codeGen = new ParseEngine(exp);
				System.Console.WriteLine(g);
			}
		}
    }
}
