using CardGames;
using CardStockXam.Scoring;
using System.Diagnostics;
using CardStockXam.Scoring.Heuristics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CardStockXam
{
    class Scorer{
        private List<Experiment> exps = new List<Experiment>();
        private ParseEngine engine;
        public string name = "temp";
        // Static here TODO 
        public static World gameWorld;
        public string text;

        private int numRndvRnd = 10;
        private int numAIvRnd  = 10;
        private int numAIvAI   = 5;


        // TODO run everything with one game and make a big chart with all 5 working heuristics 
        public static void Main(string[] args) {
			List<string> gameFiles = new List<string>();
			string[] allFiles = System.IO.Directory.GetFiles("games/");
            List<Tuple<string, List<double>>> scores = new List<Tuple<string, List<double>>>();
			foreach (string s in allFiles)
			{
				if (s.EndsWith(".gdl"))
				{
					gameFiles.Add(s);
				}
			}
            foreach (string name in gameFiles.GetRange(0, gameFiles.Count))
            {

                Debug.WriteLine(name);
                var p = new Scorer(name);
                var score = p.Score();
                var tupl = Tuple.Create(name.Substring(6, name.Length - 10), score);
                scores.Add(tupl);
            }
            foreach (Tuple<string, List<double>> t in scores.GetRange(0, scores.Count)) {
                Debug.WriteLine(t.Item1 + "\t");
                foreach (double d in t.Item2) {
                    Debug.Write(d + "\t");
                }
                Debug.Write("\n");
            }

        }





        // list of heuristic values
        private List<Heuristic> hs = new List<Heuristic>() {
            new MeaningfulMoves(),
            new Variance(),
            //new Depth(),
            //new ExcessRules(),
            new Fairness(),
            //new GameLength(),
            //new NoTies(),
            new Drama(),
            new Decisiveness()
        };

        public Scorer(string fileName)
        {
          
            text = "Scoring " + fileName + ":\n";



            exps.Add(new Experiment()
            {
                fileName = fileName,
                numGames = numRndvRnd,
                numEpochs = 1,
                logging = false,
                evaluating = true,

            });



            exps.Add(new Experiment()
            {
                fileName = fileName,
                numGames = numAIvRnd,
                numEpochs = 1,
                logging = false,
                evaluating = true,
                type = GameType.RndandAI
                    
            });


            exps.Add(new Experiment()
            {
                fileName = fileName,
                numGames = numAIvAI,
                numEpochs = 1,
                logging = false,
                evaluating = true,
                type = GameType.AllAI
            });

        }

     

        // define heuristics here
        public List<double> Score(){
            
            //var path = Path.Combine("Gamepool", "Scoring" + name + ".txt");
            gameWorld = new World();
            List<double> empty = new List<double>();
            empty.Add(0.0);
            for (int i = 0; i < exps.Count; i++){
                Debug.WriteLine("Experiment " + i);
                engine = new ParseEngine(exps[i]);
                engine.setWorld(gameWorld);
                var tup = engine.Loader();

           
               
                if (!tup.Item1) { Debug.WriteLine("not shuffling"); return empty; }
                if (!tup.Item2) { Debug.WriteLine("no choice"); return empty; }

                var compiling = engine.Experimenter();
                if (!compiling) {Debug.WriteLine("not compiling"); return empty; }
            }

            //gameWorld.EvalOver();
            Debug.WriteLine("passed reasonable");
            List<double> total = new List<double>();
            var cleanoutput = "";
            foreach (Heuristic h in hs){
                var score = h.Eval(gameWorld);
                var output = h.ToString().Substring(32) + "\t" + (score / h.Weight()) +
                        "\t" + h.Weight() + "\t" + score;
                var split = h.ToString().Split('.');
                var heuristic = split[split.Length - 1];
                cleanoutput += heuristic + ": " + score + "\n";
                text += "    " + output;
               
				
                Console.WriteLine(output);
                total.Add(score);
            }
            /*
			if (!File.Exists(path))
			{
				File.WriteAllText(path, cleanoutput + "\n\n----\n\n\t");
			}
			else
			{
				using (StreamWriter file = new StreamWriter(path, true))
				{
					file.WriteLine(cleanoutput + "\n\n----\n\n");
				}
			}*/
			
            return total;
        }
        public bool parseBool(string line)
        {
            return line.Split(':')[1] == "T";
        }
    }
}
