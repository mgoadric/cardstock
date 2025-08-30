using System.IO.Enumeration;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace CardStock.Evaluation
{
    public class DataCollector
    {
        private readonly Dictionary<string, StreamWriter> dataFiles = [];
        private readonly Experiment exp;

        private readonly int[,] aggregator;
        private readonly int[,] playerRank;
        private readonly double[,] playerFirst;

        public DataCollector(Experiment exp)
        {
            this.exp = exp;

            /***********
            * Set up the data recording files
            * THIS SHOULD ALL BE TIDY DATA
            ***********/
            string path = string.Join("/", ["output", exp.Game, exp.PlayerCount, exp.type, exp.AI]) + "/";
            FileInfo file = new(path);
            file.Directory.Create(); // If the directory already exists, this method does nothing.

            List<String> fileStrings = ["lead", "choice", "results", "spread"];
            foreach (string f in fileStrings)
            {
                dataFiles[f] = new(path + f + ".csv");
            }

            dataFiles["lead"].WriteLine(exp.type);
            CSVOutput("choice", "game", "numPlayers", "type,ai", "run", "move", "player", "choices", "choice");
            CSVOutput("results", "game", "numPlayers", "type,ai", "run", "player", "score", "rank");
            dataFiles["spread"].WriteLine(exp.type);

            aggregator = new int[GameSimulator.MAXPLAYERS, exp.NumGames];
            playerRank = new int[GameSimulator.MAXPLAYERS, exp.NumGames];
            playerFirst = new double[GameSimulator.MAXPLAYERS, exp.NumGames];
        }

        private void CSVOutput(string file, params object[] values)
        {
            dataFiles[file].WriteLine(string.Join(",", values));
        }

        public void RecordGameStatistics(int run, List<Tuple<int, int>> results, int mult, List<Tuple<int, int, int>> choiceList,
                                        List<Tuple<int, double[]>> allLeadList, List<Tuple<int, double>> spreadList)
        {
            // TODO Should we move the choice, allLead, and spread lists to live here?
            // Maybe give the DataCollector to the GameIterator????
            lock (this)
            {

                int topRank = 0;
                int numWinners = 1;

                for (int j = 0; j < results.Count; ++j)
                {

                    aggregator[results[j].Item2, run] += results[j].Item1;

                    if (j != 0 && results[j].Item1 != results[j - 1].Item1)
                    {
                        playerRank[results[j].Item2, run] += j;
                        if (topRank == 0)
                        {
                            numWinners = j;
                        }
                        topRank = j;

                    }
                    else
                    {
                        playerRank[results[j].Item2, run] += topRank;
                    }

                }

                /*****
                 * Record choice
                 */
                int move = 0;
                foreach (Tuple<int, int, int> t in choiceList)
                {
                    CSVOutput("choice", exp.Game, exp.PlayerCount, exp.type, exp.AI, run, move, t.Item1, t.Item2, t.Item3);
                    move++;
                }

                /*****
                 * Record Lead
                 */
                dataFiles["lead"].WriteLine("game" + run);
                foreach (Tuple<int, double[]> allLeads in allLeadList)
                {
                    dataFiles["lead"].Write(allLeads.Item1 + ",");
                    for (int k = 0; k < exp.PlayerCount; k++)
                    {
                        dataFiles["lead"].Write(allLeads.Item2[k] + ",");
                    }
                    dataFiles["lead"].WriteLine();
                }

                /*****
                 * Record Spread
                 */
                dataFiles["spread"].WriteLine("game" + run);
                foreach (Tuple<int, double> s in spreadList)
                {
                    dataFiles["spread"].Write(s.Item2 + ",");
                }
                dataFiles["spread"].WriteLine();
                foreach (Tuple<int, double> s in spreadList)
                {
                    dataFiles["spread"].Write(s.Item1 + ",");
                }
                dataFiles["spread"].WriteLine();
            }
        }

        public void Aggregate()
        {
            for (int player = 0; player < exp.PlayerCount; player++)
            {
                for (int run = 0; run < exp.NumGames; run++)
                {
                    CSVOutput("results", exp.Game, exp.PlayerCount, exp.type, exp.AI, run, player, aggregator[player, run], playerRank[player, run]);
                }
            }
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