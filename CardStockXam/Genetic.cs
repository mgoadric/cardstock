using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStockXam
{
    class Genetic
    {
        private static int repetitions = 10;
        private static double crossoverRate = .4;
        private static double mutationRate = .4;
        private static Random rnd = new Random();


        public static void Main(string[] args){
            var pool = "Gamepool/Pool";
            var intermediate = "Gamepool/Intermediate";

            moveAllFiles("Initial", "Pool");

            for (int rep = 0; rep < repetitions; rep++)
            {
                string[] fileNames = Directory.GetFiles(pool);
                FileStream[] files = new FileStream[fileNames.Length];
                var idx = 0;
                foreach (var fileName in fileNames)
                {
                    files[idx] = new FileStream(fileName, FileMode.Open);
                    idx++;
                }

                foreach (var parent1 in files){
                    foreach (var parent2 in files){
                        if (rnd.NextDouble() > crossoverRate){
                            Crossover(parent1, parent2);
                            // perform crossover
                            // save to file in intermediate
                        }
                    }
                }
                foreach (string toMutate in files){
                    if (rnd.NextDouble() > mutationRate){
                        // perform mutation
                        // save to file in "Intermediate"
                    }
                }
                string[] tempFiles = Directory.GetFiles(intermediate);
            }
            moveAllFiles("Pool", "Final");
        }

        public static void moveAllFiles(string start, string end)
        {
            var startFolder = "Gamepool/" + start;
            var endFolder   = "Gamepool/" + end;
            string[] files = Directory.GetFiles(startFolder);
            string[] toRemove = Directory.GetFiles(endFolder);

            foreach (string s in toRemove){
                File.Delete(s);
            }

            foreach (string s in files){
                var fileName = Path.GetFileName(s);
                var destFile = Path.Combine(endFolder, fileName);
                File.Copy(s, destFile, true);
            }
        }

        private static void Crossover(FileStream file, FileStream parent2)
        {
            
        }
    }
}
