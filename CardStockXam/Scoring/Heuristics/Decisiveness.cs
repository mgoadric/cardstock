using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace CardStockXam.Scoring.Heuristics
{
    class Decisiveness : Heuristic
    {

        public override double Weight()
        {
            return 0.4;
        }
        // TODO hey this assumes that turns are taken one after another
        // whereas in games like blackjack several turns can be taken at once 

        public override double Get(World w)
        {
            if (w.numAIvsAI == 0)
            {
                return 0;
            }
            double threshold = 0.8;
            double total = 0;
            int numEvaluated = 0;


            Debug.WriteLine("size: " + w.numAIvsAI);
            for (int i = 0; i < w.winners.Length; i++)
            {
                for (int j = 0; j < w.AIvAI[i].Count; j++) {
                    Debug.Write("Player: " + j + "\t");
                    for (int x = 0; x < w.AIvAI[i][j].Count; x++)
                    {
                        Debug.Write(w.AIvAI[i][j][x] + "\t");
                    }
                    Debug.Write("\n");

                           
                }
                Debug.WriteLine("Winner: " + w.winners[i] + "\n");
                List<double> current = w.AIvAI[i][w.winners[i]];
                int mgd = current.Count - 1;
                /*for (int j = 0; j < current.Count; j++)
                {
                    
                    //Console.WriteLine(current[j]);
                }*/
                for (int j = 0; j < current.Count; j++)
                {

                    if (current[j] > threshold)
                    {
                        mgd = j;
                        break;
                    }
                }
                if (current.Count != 0)
                {
                    total += (double)(current.Count - mgd) / current.Count;
                    numEvaluated++;
                }


            }
            return 1 - ((double)total / numEvaluated);
        }
    }
}
