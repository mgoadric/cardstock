using System.Collections.Generic;
using CardEngine;
using Players;
using System.IO;
using System.Threading;
using CardStockXam.Scoring;
using System.Text;
namespace CardGames
{
    public class Program

   
    {
        public static void Main(string[] args)
        {
            

            //CardStockXam.Scorer.Main(args);


            //PythonController python = new PythonController();
            //python.run_cmd();
            var p = new Program();
			/*if (args.Length > 0)
			{
                p.SingleGame(args[0]);
			}
            else {
			    p.SingleGame("/Users/anna/Desktop/cardstock/CardStockXam/games/Hearts.gdl");

			}*/

            p.AllGames();
			//System.IO.DirectoryInfo di = new DirectoryInfo("/Users/anna/Desktop/cardstock/CardStockXam/games/generated/");

			//foreach (FileInfo file in di.GetFiles())
			//{
			//	file.Delete();
			//}


        }



        void SingleGame(string game) {
			var exp = new Experiment();
			exp.fileName = game;
            // System.Console.WriteLine(g.Substring(6, g.Length - 4));
            exp.numGames = 1;
			exp.numEpochs = 1;

            exp.logging = false;
            exp.type = GameType.AllRnd;

			var codeGen = new ParseEngine(exp);
            codeGen.exp.builder.Append("strict digraph{");

			codeGen.setWorld(new World());
            codeGen.Loader();
            codeGen.Experimenter();

			codeGen.exp.builder.Append("}");
			
			
            /*var fs = File.Create(exp.fileName.Substring(0, exp.fileName.Length - 4) + "Connections.gv");
			var bytes = Encoding.UTF8.GetBytes(exp.builder.ToString());
			fs.Write(bytes, 0, bytes.Length);
			fs.Close();
			System.Debug.WriteLine("wrote " + exp.fileName + ".gv");
            System.Console.WriteLine(exp.fileName.Substring(0, exp.fileName.Length - 4) + "Connections.gv");*/

		
		


		}

        void AllGames() {
			List<string> gameFiles = new List<string>();

			string[] allFiles = System.IO.Directory.GetFiles("/Users/anna/Desktop/cardstock/CardStockXam/games/");
            System.Console.Write("hi");
			foreach (string s in allFiles)
			{
                System.Console.WriteLine(s);

                if (s.EndsWith(".gdl")) // && string.Compare(s[6].ToString(), "L") > 0)
				{
					gameFiles.Add(s);
				}
			}
            foreach (string g in gameFiles.GetRange(0, gameFiles.Count)) {
                //SingleGame(g.Substring(16, g.Length - 20));
                SingleGame(g);
            }

   		}

    }
}
