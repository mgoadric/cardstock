using System.IO.Enumeration;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using CardStock.Players;

namespace CardStock.Evaluation
{
    public class DataCollector
    {
        private readonly Dictionary<string, StreamWriter> dataFiles = [];
        private readonly Experiment exp;
        private readonly string ai;

        public List<Tuple<int, int, int>> choiceList = [];
        public List<Tuple<int, double[]>> allLeadList = [];
        public List<Tuple<int, double[]>> allScoresList = [];
        public List<Tuple<int, double>> spreadList = [];

        public DataCollector(Experiment exp)
        {
            this.exp = exp;
            ai = exp.PlayerAbv();

            /***********
            * Set up the data recording files
            * THIS SHOULD ALL BE TIDY DATA
            ***********/
            string path = string.Join("/", ["output", exp.Game, exp.PlayerCount, ai]) + "/";
            FileInfo file = new(path);
            file.Directory.Create(); // If the directory already exists, this method does nothing.

            List<String> fileStrings = ["lead", "choice", "results", "spread"];
            foreach (string f in fileStrings)
            {
                dataFiles[f] = new(path + f + ".csv");
            }

            CSVOutput("lead", "game", "numPlayers", "ai", "run", "move", "recorder", "player", "score", "rankestimate");
            CSVOutput("choice", "game", "numPlayers", "ai", "run", "move", "player", "choices", "choice");
            CSVOutput("results", "game", "numPlayers", "ai", "run", "player", "score", "rank");
            CSVOutput("spread", "game", "numPlayers", "ai", "run", "pmove", "player", "spread");
        }

        private void CSVOutput(string file, params object[] values)
        {
            dataFiles[file].WriteLine(string.Join(",", values));
        }

        public void RecordGameStatistics(int run, int[] results, int mult)
        {
            lock (this)
            {

                /*******
                 * Record rank and results
                 ******/
                int[] ranks = FindRanks(results, mult);
                for (int j = 0; j < results.Length; ++j)
                {
                    CSVOutput("results", exp.Game, exp.PlayerCount, ai, run, j, results[j], ranks[j]);
                }

                /******
                 * Record choice
                 */
                int move = 0;
                foreach (Tuple<int, int, int> t in choiceList)
                {
                    CSVOutput("choice", exp.Game, exp.PlayerCount, ai, run, move, t.Item1, t.Item2, t.Item3);
                    move++;
                }

                /******
                 * Record Lead
                 */
                for (move = 0; move < allLeadList.Count; move++)
                {
                    Tuple<int, double[]> allLeads = allLeadList[move];
                    Tuple<int, double[]> allScores = allScoresList[move];
                    for (int k = 0; k < exp.PlayerCount; k++)
                    {
                        CSVOutput("lead", exp.Game, exp.PlayerCount, ai, run, move, allLeads.Item1, k, allScores.Item2[k], allLeads.Item2[k]);
                    }
                }

                /******
                 * Record Spread
                 */
                move = 0;
                foreach (Tuple<int, double> s in spreadList)
                {
                    CSVOutput("spread", exp.Game, exp.PlayerCount,ai, run, move, s.Item1, s.Item2);
                    move++;
                }

                choiceList = [];
                allLeadList = [];
                allScoresList = [];
                spreadList = [];
            }
        }


        public static int[] FindRanks(int[] results, int mult)
        {
            var resultsList = new List<Tuple<int, int>>();
            for (int i = 0; i < results.Length; i++)
            {
                resultsList.Add(new Tuple<int, int>(results[i], i));
            }
            resultsList.Sort();
            if (mult == 1)
            {
                resultsList.Reverse();
            }

            int topRank = 0;
            int[] ranks = new int[results.Length];
            for (int j = 0; j < results.Length; j++)
            {
                if (j != 0 && resultsList[j].Item1 != resultsList[j - 1].Item1)
                {
                    topRank = j;
                }
                ranks[resultsList[j].Item2] = topRank;
            }
            return ranks;
        }

        public void RecordHeuristics(double[][] scoreSums, double[][] rankSums, int playerIdx)
        {
            double[] scoreSum = scoreSums[playerIdx];
            double[] myLeadView = new double[rankSums.Length];
            double[] myScoreView = new double[scoreSums.Length];

            (var minidx, var maxidx) = AIPlayer.MinMaxIdx(scoreSum);
            var best = scoreSum[maxidx];
            var worst = scoreSum[minidx];

            var variance = Math.Abs(best - worst);

            for (int i = 0; i < myLeadView.Length; i++)
            {
                myLeadView[i] = (exp.PlayerCount - 1 - rankSums[i][maxidx]) /
                    (exp.PlayerCount - 1);
                myScoreView[i] = scoreSums[i][maxidx];
            }
            
            allLeadList.Add(new Tuple<int, double[]>(playerIdx, myLeadView));
            allScoresList.Add(new Tuple<int, double[]>(playerIdx, myScoreView));
            spreadList.Add(new Tuple<int, double>(playerIdx, variance));
        }

        public void AddChoiceList(Tuple<int, int, int> choices)
        {
            choiceList.Add(choices);
        }
        public void Close()
        {
            foreach (StreamWriter file in dataFiles.Values)
            {
                file.Close();
            }
        }
    }
}