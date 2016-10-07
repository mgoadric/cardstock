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
        private static int repetitions = 2;
        private static int numKept = 2;//10;
        private static double crossoverRate = .4;
        private static double mutationRate = .4;
        private static int numMutations = 2;
        private static int minimumChildren = 2;//(int) Math.Floor(numKept * 1.5);
        private static Random rnd = new Random();


        public static void Main(string[] args){
            string newPool = "Gamepool/Pool0";
            var pool = newPool;
            string intermediate = "Gamepool/Intermediate0";
            deleteAllOldFiles();
            moveAllFiles("Gamepool/Initial", newPool, true);
            
            for (int rep = 0; rep < repetitions; rep++){
                pool = newPool;
                newPool = "Gamepool/Pool" + (rep + 1);
                intermediate = "Gamepool/Intermediate" + rep;
                Directory.CreateDirectory(pool);
                Directory.CreateDirectory(intermediate);
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
                                Crossover(parent1, parent2, intermediate);
                            }
                        }
                    }
                    if (rnd.NextDouble() > mutationRate) { 
                        Mutate(parent1, intermediate);
                    }
                }
                string[] newFiles = Directory.GetFiles(intermediate);
                Console.WriteLine("Created files in " + intermediate + ":");
                foreach (string filename in newFiles){
                    Console.WriteLine(filename);
                }
                int numFiles = newFiles.Count();
                while (numFiles < minimumChildren){ // if not enough files created, create more
                    var parent1 = files[rnd.Next(files.Count())];
                    if (rnd.Next(2) == 0){
                        var parent2 = files[rnd.Next(files.Count())];
                        while (parent2 == parent1){
                            parent2 = files[rnd.Next(files.Count())];
                        }
                        Crossover(parent1, parent2, intermediate);
                    }
                    else{
                        Mutate(parent1, intermediate);
                    }
                    numFiles++;
                }
                foreach (FileStream file in files){
                    file.Close();
                }
                newFiles = Directory.GetFiles(intermediate);
                /* scoring
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
                }*/
                if (rep + 1 == repetitions) {
                    moveAllFiles(intermediate, "GamePool/Final", true);
                }
                else{
                    moveAllFiles(intermediate, newPool, true, newFiles);
                }   
            }
        }

        private static void Crossover(FileStream parent1, FileStream parent2, string folder)
        {
            folder += "/";
            // perform crossover
            // parse both files
            // take corresponding elements and switch them
            // ex switch moves or scoring or end conditions
            // save to file in intermediate

            //string child1Name = GetName(parent1, parent2);
            //string child2Name = GetName(parent2, parent1);
            var child1 = parent1.ToString();// TODO
            var child2 = parent2.ToString();
            string child1Name = GetName(parent1, parent2);
            string child2Name = GetName(parent2, parent1);

            MakeFile(child1, folder + child1Name);
            MakeFile(child2, folder + child2Name);
        }

        private static void Mutate(FileStream parent, string folder)
        {
            folder += "/";
            Console.WriteLine("folder: " + folder);
            // perform mutation
                // choose numMutations random mutations
                // to mutate:
                    // randomly choose an atom
                    // perform a random change on that atom
            // save to file in intermediate
            string childName = Trim(parent.Name) + "M.gdl";
            string child = parent.ToString();
            MakeFile(child, folder + childName);
            File.WriteAllText(folder + childName, child);
        }

        private static void MakeFile(string file, string name){
            if (File.Exists(name))
            {
                name.Insert(name.Length - 4, "1");
            }
            File.WriteAllText(name, file);
        }

        private static string GetName(FileStream parent1, FileStream parent2){
            Console.WriteLine("getname: ");
            var name1 = Trim(parent1.Name);
            var name2 = Trim(parent2.Name);
            Console.WriteLine(name1);
            Console.WriteLine(name2);
            name1 = name1.Substring(0, name1.Length / 2);
            name2 = name2.Substring(name2.Length / 2, name2.Length / 2);
            Console.WriteLine(name1);
            Console.WriteLine(name2);
            return name1 + name2 + ".gdl";
        }

        private static string Trim(string s){
            var paths = s.Split('\\');
            s = paths[paths.Count() - 1];
            s = s.Split('.')[0];
            return s;
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
            if (!Directory.Exists(end)) { Directory.CreateDirectory(end); }
            if (files == null) { files = Directory.GetFiles(start); }

            foreach (string s in files){
                var fileName = Path.GetFileName(s);
                var destFile = Path.Combine(end, fileName);
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

        private static void deleteAllOldFiles(){
            var folders = Directory.GetDirectories("Gamepool");
            foreach (var folder in folders){
                Console.WriteLine(folder);
                if (folder.Contains("Pool") || folder.Contains("Intermediate")){
                    Console.WriteLine("^deleting");
                    DeleteDirectory(folder);
                }
            }
        }

        public static void DeleteDirectory(string targetDir)
        {
            deleteFiles(targetDir);
            Directory.Delete(targetDir, false);
        }
    }
}
