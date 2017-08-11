using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStockXam.Scoring.Heuristics
{
    class Decisiveness : Heuristic{

        public override double Weight()
        {
            return 0.4;
        }
        // TODO hey this assumes that turns are taken one after another
        // whereas in games like blackjack several turns can be taken at once 

        public override double Get(World w){
            if (w.numAIvsAI == 0) {
                Console.WriteLine("num: " + w.numAIvsAI);
                return 0;
            }
            double threshold = 0.8;
            double total = 0;
            int numEvaluated = 0;
          


            for (int i = 0; i < w.lead.Count(); i++){
                List<double> current = w.lead[w.winners[i]][i];
                int mgd = current.Count - 1;
                for (int j = 0; j < current.Count; j++) {
                    if (current[j] > threshold){
                        mgd = j;
                        break;
                    }
                }
                if (current.Count != 0){
                    total += (current.Count - mgd) / current.Count;
                    numEvaluated++;
                }
            }
            return 1 - (total / numEvaluated);
        }
    }
}
