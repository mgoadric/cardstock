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
        // Static here TODO 
        public static World gameWorld;
        public string text;

        private int numRndvRnd = 10;
        private int numAIvRnd  = 2;
        private int numAIvAI   = 2;

        private bool testing = false;

       

        // list of heuristic values
        private List<Heuristic> hs = new List<Heuristic>() {
            new MeaningfulMoves(),
            new Variance(),
            //new Depth(),
            new ExcessRules(),
            new Fairness(),
            new GameLength(),
            new NoTies(),
            new Drama()
        };

        public Scorer(string fileName)
        {
            bool first = true;
            text = "Scoring " + fileName + ":\n";
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

        public Scorer(string fileName, bool b){
            testing = b;
            text = "Scoring " + fileName + ":\n";
            exps.Add(new Experiment(){
                fileName = fileName,
                numGames = 2,
                numEpochs = 1,
                logging = b,
                evaluating = true,
                ai1 = true,
                first = true
            });
            exps.Add(new Experiment(){
                fileName = fileName,
                numGames = 2,
                numEpochs = 1,
                logging = b,
                evaluating = true,
                ai1 = true,
                ai2 = true,
                first = true
            });
        }

        // define heuristics here
        public double Score(){
            // static world here 
            gameWorld = new World();
            gameWorld.testing = testing;
            for (int i = 0; i < exps.Count; i++){
                Debug.WriteLine("Experiment " + i);
                engine = new ParseEngine(exps[i]);
                var tup = engine.Loader();

           
               
                if (!tup.Item1) { Debug.WriteLine("not shuffling"); return 0.0; }
                if (!tup.Item2) { Debug.WriteLine("no choice"); return 0.0; }

                var compiling = engine.Experimenter();
                if (!compiling) {Debug.WriteLine("not compiling"); return 0.0; }
            }

            gameWorld.EvalOver();
            Debug.WriteLine("passed reasonable");
            double total = 0;
            foreach (Heuristic h in hs){
                var score = h.Eval(gameWorld);
                var output = "Heuristic " + h.ToString() + " returned " + (score / h.Weight()) +
                        " with weight " + h.Weight() + " for total score: " + score;
                text += "    " + output;
                if (testing){
                    Console.WriteLine(output);
                }
                total += score;
            }
            return total;
        }
        public bool parseBool(string line)
        {
            return line.Split(':')[1] == "T";
        }
    }
}
