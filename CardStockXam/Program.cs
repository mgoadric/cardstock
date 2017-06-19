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
            p.SingleGame("Blackjack");
        }

        void SingleGame(string game){
			var exp = new Experiment();
			exp.fileName = game;
            // System.Console.WriteLine(g.Substring(6, g.Length - 4));
            exp.numGames = 10;
			exp.numEpochs = 1;

			exp.logging = true;
            // TODO make for as many players as in game 
            // one AI vs everyone else is helpful
            exp.ai1 = true;
            exp.ai2 = false;

			var codeGen = new ParseEngine(exp);
		}

        void AllGames(){
			List<string> gameFiles = new List<string>();
			string[] allFiles = System.IO.Directory.GetFiles("games/");

			foreach (string s in allFiles)
			{
				if (s.EndsWith(".gdl"))
				{
					gameFiles.Add(s);
                    
				}
			}
            // TODO CardGame.Instance is a singleton ;/
            //gameFiles.Add("Blackjack");
            //gameFiles.Add("SaneEights");
            //System.Threading.Tasks.Parallel.ForEach(gameFiles, SingleGame); 
               //print stuff
               //System.Console.WriteLine("this is a disaster" + g);




                // TODO write each game to file instead of console to avoid
                // multithreading problems 


                //string copy = g.Substring(6, g.Length - 10);
               // Thread myThread = new Thread(() => this.SingleGame(copy));
                //myThread.Start();
              
		}
    }
}
