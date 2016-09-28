using CardGames;
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
        private static int repetitions = 1;
        private static int numKept = 2;//10;
        private static double crossoverRate = .4;
        private static double mutationRate = .4;
        private static int minimumChildren = (int) Math.Floor(numKept * 1.5);
        private static Random rnd = new Random();


        public static void Main(string[] args){
            string pool = "Gamepool/Pool";
            string intermediate = "Gamepool/Intermediate";
            deleteFiles(intermediate);
            moveAllFiles("Initial", "Pool", true);
            
            for (int rep = 0; rep < repetitions; rep++)
            {
                string[] fileNames = Directory.GetFiles(pool);
                Console.WriteLine(fileNames[0]);
                FileStream[] files = new FileStream[fileNames.Length];
                var idx = 0;
                foreach (var fileName in fileNames)
                {
                    files[idx] = new FileStream(fileName, FileMode.Open);
                    files[idx].Close();
                    idx++;
                }

                foreach (var parent1 in files){
                    foreach (var parent2 in files){
                        if (parent1 != parent2){
                            if (rnd.NextDouble() > crossoverRate){
                                Crossover(parent1, parent2);
                            }
                        }
                    }
                    if (rnd.NextDouble() > mutationRate) { 
                        Mutate(parent1);
                    }
                }

                string[] newFiles = Directory.GetFiles(intermediate);
                while (newFiles.Count() < minimumChildren){ // if not enough files created, create more
                    var parent1 = files[rnd.Next(files.Count())];
                    if (rnd.Next(2) == 0){
                        var parent2 = files[rnd.Next(files.Count())];
                        while (parent2 == parent1){
                            parent2 = files[rnd.Next(files.Count())];
                        }
                        Crossover(parent1, parent2);
                    }
                    else{
                        Mutate(parent1);
                    }
                }
                foreach (FileStream file in files){
                    file.Close();
                }
                /*
                newFiles = Directory.GetFiles(intermediate);
                double[] scores = new double[newFiles.Count()];
                for (int i = 0; i < newFiles.Count(); i++) { // get scores
                    Scorer s = new Scorer(newFiles[i]);
                    scores[i] = s.Score();
                    i++;
                }
                int[] indexes = TopScoreIndexes(scores, numKept);
                string[] keep = new string[indexes.Count()];
                for (int k = 0; k < indexes.Count(); k++){
                    keep[k] = newFiles[indexes[k]];
                }
                moveAllFiles(intermediate, pool, false, keep);
                */
            }
            moveAllFiles("Pool", "Final");
        }

        private static void Crossover(FileStream parent1, FileStream parent2)
        {
            // perform crossover
            // save to file in intermediate
        }

        private static void Mutate(FileStream file)
        {
            // perform mutation
            // save to file in intermediate
        }

        private static int[] TopScoreIndexes(double[] ar, int num)
        {
            int[] ret = new int[num];
            double lower = GetNthBiggest(ar, num);
            int idx = 0;
            for (int i = 0; i < ar.Count(); i++){ 
                if (ar[i] >= lower)
                {
                    ret[idx] = i;
                    idx++;
                }
            }
            return ret;
        }

        private static double GetNthBiggest(double[] array, int n)
        {
            var comparer = Comparer<int>.Create((x, y) => array[x].CompareTo(array[y])); 
            var highestIndices = new SortedSet<int>(comparer);
            for (var i = 0; i < array.Length; i++)
            {
                var entry = array[i];
                if (highestIndices.Count < n) highestIndices.Add(i);
                else if (array[highestIndices.Min] < entry)
                {
                    highestIndices.Remove(highestIndices.Min);
                    highestIndices.Add(i);
                }
            }

            return highestIndices.Min;
        }


        public static void moveAllFiles(string start, string end, bool copy = false, string[] files = null)
        {
            var startFolder = "Gamepool/" + start;
            var endFolder   = "Gamepool/" + end;
            if (files == null) { files = Directory.GetFiles(startFolder); }

            deleteFiles(endFolder);

            foreach (string s in files){
                var fileName = Path.GetFileName(s);
                var destFile = Path.Combine(endFolder, fileName);
                if (copy){
                    File.Copy(s, destFile, true);
                }
                else {
                    File.Move(s, destFile);
                }
            }
        }

        private static void deleteFiles(string folder){
            string[] toRemove = Directory.GetFiles(folder);

            foreach (string s in toRemove)
            {
                File.Delete(s);
            }
        }
    }
}
