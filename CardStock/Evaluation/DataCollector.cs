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
        public List<long> timeList = [];

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
            DirectoryInfo? directoryInfo = file.Directory;
            directoryInfo?.Create(); // If the directory already exists, this method does nothing.

            List<String> fileStrings = ["lead", "choice", "results", "spread"];
            foreach (string f in fileStrings)
            {
                dataFiles[f] = new(path + f + ".csv");
            }

            CSVOutput("lead", "game", "numPlayers", "ai", "run", "move", "recorder", "player", "score", "rank", "rankestimate");
            CSVOutput("choice", "game", "numPlayers", "ai", "run", "move", "player", "choices", "choice", "time");
            CSVOutput("results", "game", "numPlayers", "ai", "run", "player", "score", "rank", "time");
            CSVOutput("spread", "game", "numPlayers", "ai", "run", "pmove", "player", "spread");
        }

        private void CSVOutput(string file, params object[] values)
        {
            dataFiles[file].WriteLine(string.Join(",", values));
        }

        public void RecordGameStatistics(int run, int[] results, int mult, double time)
        {
            lock (this)
            {

                /*******
                 * Record rank and results
                 ******/
                int[,] ranks = FindRanks(results, mult);
                for (int j = 0; j < results.Length; ++j)
                {
                    CSVOutput("results", exp.Game, exp.PlayerCount, ai, run + 1, j + 1, results[j], ranks[j, 0] + 1, time);
                }

                /******
                 * Record choice
                 */
                int move = 0;
                foreach (Tuple<int, int, int> t in choiceList)
                {
                    CSVOutput("choice", exp.Game, exp.PlayerCount, ai, run + 1, move + 1, t.Item1 + 1, t.Item2, t.Item3 + 1, timeList[move]);
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
                        CSVOutput("lead", exp.Game, exp.PlayerCount, ai, run + 1, move + 1, allLeads.Item1 + 1, k + 1, allScores.Item2[k], ranks[k, 1], allLeads.Item2[k]);
                    }
                }
                
                // tack on the final results at the end of the lead list
                for (int k = 0; k < exp.PlayerCount; k++)
                {
                    double r = (exp.PlayerCount - 1 - ranks[k, 0]) /
                        (double)(exp.PlayerCount - 1);
                    CSVOutput("lead", exp.Game, exp.PlayerCount, ai, run + 1, move + 1, k + 1, k + 1, results[k], ranks[k, 1], r);
                }

                /******
                 * Record Spread
                 */
                move = 0;
                foreach (Tuple<int, double> s in spreadList)
                {
                    CSVOutput("spread", exp.Game, exp.PlayerCount,ai, run + 1, move + 1, s.Item1, s.Item2);
                    move++;
                }

                choiceList = [];
                allLeadList = [];
                allScoresList = [];
                spreadList = [];
            }
        }


        public static int[,] FindRanks(int[] results, int mult)
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
            int tie = 0;
            int[,] ranks = new int[results.Length,2];
            for (int j = 0; j < results.Length; j++)
            {
                if (j != 0 && resultsList[j].Item1 != resultsList[j - 1].Item1)
                {
                    topRank = j;
                    tie = 0;
                }
                else if (j != 0)
                {
                    tie++;
                }
                ranks[resultsList[j].Item2,0] = topRank;
                ranks[resultsList[j].Item2,1] = topRank + tie;
            }
            return ranks;
        }

        public void RecordHeuristics(double[][] scoreSums, double[][] rankSums, int playerIdx)
        {
            lock (this)
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
        }

        public void AddChoices(Tuple<int, int, int> choices)
        {
            choiceList.Add(choices);
        }

        public void AddTime(long time)
        {
            timeList.Add(time);
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