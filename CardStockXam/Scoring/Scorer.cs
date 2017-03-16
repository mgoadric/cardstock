using CardGames;
using CardStockXam.Scoring;
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

        public static World gameWorld;

        private int numRndvRnd = 1;
        private int numAIvRnd  = 3;
        private int numAIvAI   = 3;

        private bool testing = false;

        // list of heuristic values
        private List<Heuristic> hs = new List<Heuristic>() {
            new MeaningfulMoves(),
            new Variance()
        };

        /*
        private List<Heuristic> hs = new List<Heuristic>() {
            new MeaningfulMoves(),
            new Variance(),
            new Depth(),
            new ExcessRules(),
            new Fairness(),
            new GameLength(),
            new NoTies()
        };*/

        public Scorer(string fileName)
        {
            bool first = true;
            for (int i = 0; i < numRndvRnd; i++){
                exps.Add(new Experiment()
                {
                    fileName = fileName,
                    numGames = 1,
                    numEpochs = 1,
                    logging = false,
                    evaluating = true,
                    first = first
                });
                first = false;
            }
            for (int i = 0; i < numAIvRnd; i++){
                exps.Add(new Experiment()
                {
                    fileName = fileName,
                    numGames = 1,
                    numEpochs = 1,
                    logging = false,
                    evaluating = true,
                    ai1 = true
                });
            }
            for (int i = 0; i < numAIvAI; i++){
                exps.Add(new Experiment(){
                    fileName = fileName,
                    numGames = 1,
                    numEpochs = 1,
                    logging = false,
                    evaluating = true,
                    ai1 = true,
                    ai2 = true
                });
            }
        }

        public Scorer(string fileName, bool testing){
            testing = true;
            exps.Add(new Experiment(){
                fileName = fileName,
                numGames = 1,
                numEpochs = 1,
                logging = testing,
                evaluating = true,
                ai1 = true,
                first = true
            });
        }

        // define heuristics here
        public double Score(){
            gameWorld = new World();
            for (int i = 0; i < exps.Count; i++){
                engine = new ParseEngine(exps[i]);
                if (new Reasonable().Eval(gameWorld) < 1.0) { if (testing) { Console.WriteLine("failed reasonable"); } return 0.0; }
            }
            double total = 0;
            foreach (Heuristic h in hs){
                var score = h.Eval(gameWorld);
                if (testing){
                    Console.WriteLine("Heuristic: " + h.ToString() + " returned " + score);
                }
                total += score;
            }
            return total;
        }

        //deprecated
        private World ProcessFile(){
            World w = new World();

            var fs = new FileStream(exps[0].fileName + "_results.txt", FileMode.Open);
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);

            while (fs.Read(b, 0, b.Length) > 0){
                string line = temp.GetString(b);
                if (line.Equals("failure")) { return null; }
                // TODO analyze each line here, add to w
            }
            fs.Close();
            return w;
        }
        public bool parseBool(string line)
        {
            return line.Split(':')[1] == "T";
        }
    }
}
