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
        private Experiment exp;
        private ParseEngine engine;
        private int numGames;

        // list of heuristic values
        private bool compiles;

        public Scorer(string fileName)
        {
            exp = new Experiment()
            {
                fileName = fileName,
                numGames = 1,
                numEpochs = 1, //?
                logging = false,
                evaluating = true,
                ai = false
            };
            engine = new ParseEngine(exp);
        }

        // define heuristics here
        public double Score(){
            ProcessFile();
            if (!compiles) { return 0.0; }
            
            // for all heuristics, multiply heuristic by weight
            return 1.0;
        }

        public void ProcessFile(){
            var fs = new FileStream(exp.fileName + "_results.txt", FileMode.Open);
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);

            while (fs.Read(b, 0, b.Length) > 0){
                string line = temp.GetString(b);
                if (line[0] == 'C'){ //compiles
                    compiles = parseBool(line);
                }
            }
        }
        public bool parseBool(string line)
        {
            return line[2] == 'T';
        }
    }
}
