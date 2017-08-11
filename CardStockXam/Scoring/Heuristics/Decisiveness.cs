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

        public override double Get(World w){
            if (w.numAIvsAI == 0) {
                return 0;
            }
            double threshold = 0.8;
            double total = 0;
            int numEvaluated = 0;
            // lead is never added to - needs to say:
            // after it is clear this person will win, 
            // they should just win 


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
                    total += (mgd - current.Count) / current.Count;
                    numEvaluated++;
                }
            }
            return 1 - (total / numEvaluated);
        }
    }
}
