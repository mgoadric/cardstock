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
            /*List<string> gameFiles = new List<string>();
            string[] allFiles = System.IO.Directory.GetFiles("games/");
            foreach (string s in allFiles)
            {
                if (s.EndsWith(".gdl")) {
                    gameFiles.Add(s);
                }
            }*/
            //foreach (string g in gameFiles)
            //{
            //for (int i = 0; i < 20; i++)
            //{
                var exp = new Experiment();
                //    System.Console.WriteLine(g);
                //string sub = g.Substring(6, g.Length - 10);
                //exp.fileName = sub;

                exp.fileName = "LostCities";
                //System.Console.WriteLine(g.Substring(6, g.Length - 4));
                exp.numGames = 1;
                exp.numEpochs = 1;

                exp.logging = true;
                exp.ai1 = false;
                exp.ai2 = false;

                var codeGen = new ParseEngine(exp);
                // }
            //}
        }
    }
}
