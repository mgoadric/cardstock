using System.IO.Enumeration;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace CardStock.Evaluation
{
    public class DataCollector
    {
        private readonly Dictionary<string, StreamWriter> dataFiles = [];
        private readonly Experiment exp;

        public List<Tuple<int, int, int>> choiceList = [];
        public List<Tuple<int, double[]>> allLeadList = [];
        public List<Tuple<int, double>> spreadList = [];

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
                    CSVOutput("results", exp.Game, exp.PlayerCount, exp.type, exp.AI, run, j, results[j], ranks[j]);
                }

                /******
                 * Record choice
                 */
                int move = 0;
                foreach (Tuple<int, int, int> t in choiceList)
                {
                    CSVOutput("choice", exp.Game, exp.PlayerCount, exp.type, exp.AI, run, move, t.Item1, t.Item2, t.Item3);
                    move++;
                }

                /******
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

                /******
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

        public void AddLeadsList(Tuple<int, double[]> leads)
        {
            allLeadList.Add(leads);
        }

        public void AddSpreadList(Tuple<int, double> spreads)
        {
            spreadList.Add(spreads);
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