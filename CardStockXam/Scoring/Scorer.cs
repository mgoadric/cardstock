using CardGames;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStockXam
{
    class Scorer{
        private List<Experiment> exps;
        private ParseEngine engine;

        private int numRndvRnd = 1;
        private int numAIvRnd  = 3;
        private int numAIvAI   = 3;

        // list of heuristic values
        private bool compiles;

        public Scorer(string fileName)
        {
            for (int i = 0; i < numRndvRnd; i++){
                exps.Add(new Experiment()
                {
                    fileName = fileName,
                    numGames = 1,
                    numEpochs = 1, // maybe add one exp, and make numEpochs numRndvRnd??
                    logging = false,
                    evaluating = true,
                    ai1 = true
                });
            }
            /*for (int i = 0; i < numAIvRnd; i++){
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
                exps.Add(new Experiment()
                {
                    fileName = fileName,
                    numGames = 1,
                    numEpochs = 1,
                    logging = false,
                    evaluating = true,
                    ai1 = true,
                    ai2 = true
                });
            }*/
        }

        // define heuristics here
        public double Score(){
            for (int i = 0; i < exps.Count; i++){
                engine = new ParseEngine(exps[i]);
                if (!Compiling()) { return 0.0; }
            }
            ProcessFile();
            //find value of each heuristic using data from processfile
            // for all heuristics, multiply heuristic by weight
            return 1.0;
        }

        private bool Compiling(){
            var fs = new FileStream(exps[0].fileName + "_results.txt", FileMode.Open);
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);
            while (fs.Read(b, 0, b.Length) > 0){
                string line = temp.GetString(b);
                if (line[0] == 'C'){
                    if (!parseBool(line)) { return false; }
                }
            }
            return true;
        }

        private void ProcessFile(){
            var fs = new FileStream(exps[0].fileName + "_results.txt", FileMode.Open);
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);

            while (fs.Read(b, 0, b.Length) > 0){
                string line = temp.GetString(b);
                // analyze each line here
            }
        }
        public bool parseBool(string line)
        {
            return line[2] == 'T';
        }
    }
}
