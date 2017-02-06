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

        private int numRndvRnd = 1;
        private int numAIvRnd  = 3;
        private int numAIvAI   = 3;

        // list of heuristic values
        private List<Heuristic> hs = new List<Heuristic>() { new MeaningfulMoves(), new Variance() };

        public Scorer(string fileName)
        {
            for (int i = 0; i < numRndvRnd; i++){
                exps.Add(new Experiment()
                {
                    fileName = fileName,
                    numGames = 1,
                    numEpochs = 1,
                    logging = false,
                    evaluating = true
                });
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
            exps.Add(new Experiment(){
                fileName = fileName,
                numGames = 1,
                numEpochs = 1,
                logging = true,
                evaluating = true,
                ai1 = true
            });
        }

        // define heuristics here
        public double Score(){
            for (int i = 0; i < exps.Count; i++){
                engine = new ParseEngine(exps[i]);
                if (!Compiling()) { return 0.0; }
            }
            World w = ProcessFile();
            double total = 0;
            foreach (var h in hs){
                total += h.Eval(w);
            }
            return total;
        }

        private bool Compiling(){
            var fs = new FileStream(exps[0].fileName + "_results.txt", FileMode.Open);
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);
            while (fs.Read(b, 0, b.Length) > 0){
                string line = temp.GetString(b);
                if (line[0] == 'C'){
                    if (!parseBool(line)) {
                        fs.Close();
                        return false;
                    }
                }
            }
            fs.Close();
            return true;
        }

        private World ProcessFile(){
            World w = new World();

            var fs = new FileStream(exps[0].fileName + "_results.txt", FileMode.Open);
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);

            while (fs.Read(b, 0, b.Length) > 0){
                string line = temp.GetString(b);

                // TODO analyze each line here, add to w
            }
            fs.Close();
            return w;
        }
        public bool parseBool(string line)
        {
            return line[2] == 'T';
        }
    }
}
