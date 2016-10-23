using CardGames;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime;
using System.Text.RegularExpressions;

namespace CardStockXam
{
    class Genetic
    {
        private static int repetitions = 3;
        private static int numKept = 2;//10;
        private static double crossoverRate = .4;
        private static double mutationRate = .4;
        private static int numMutations = 2;
        private static int minimumChildren = 2;//(int) Math.Floor(numKept * 1.5);
        private static Random rnd = new Random();
        private static Regex regex = new Regex("(;;)(.*?)(\n)");
        private static Type[] crossovers = new Type[] { typeof(RecycleParser.StageContext), typeof(RecycleParser.MultiactionContext), typeof(RecycleParser.Multiaction2Context), typeof(RecycleParser.DeckContext), typeof(RecycleParser.SetupContext) };
        private static Type[] mutations = new Type[] { typeof(RecycleParser.MoveactionContext) }; //, typeof(RecycleParser.ShuffleactionContext), typeof(RecycleParser.RepeatContext), typeof(RecycleParser.MultiactionContext), typeof(RecycleParser.Multiaction2Context), typeof(RecycleParser.EndconditionContext) };


        public static void Main(string[] args){
            string newPool = "Gamepool\\Pool0";
            var pool = newPool;
            string intermediate = "Gamepool\\Intermediate0";
            deleteAllOldFiles();
            moveAllFiles("Gamepool\\Initial", newPool, true);
            
            for (int rep = 0; rep < repetitions; rep++){
                pool = newPool;
                newPool = "Gamepool\\Pool" + (rep + 1);
                intermediate = "Gamepool\\Intermediate" + rep;
                Directory.CreateDirectory(pool);
                Directory.CreateDirectory(intermediate);
                string[] fileNames = Directory.GetFiles(pool);

                foreach (var parent1 in fileNames){
                    foreach (var parent2 in fileNames){
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
                    var parent1 = fileNames[rnd.Next(fileNames.Count())];
                    if (rnd.Next(2) == 0){
                        var parent2 = fileNames[rnd.Next(fileNames.Count())];
                        while (parent2 == parent1){
                            parent2 = fileNames[rnd.Next(fileNames.Count())];
                        }
                        Crossover(parent1, parent2, intermediate);
                    }
                    else{
                        Mutate(parent1, intermediate);
                    }
                    numFiles++;
                }
                newFiles = Directory.GetFiles(intermediate);
                
                // Scoring
                double[] scores = new double[newFiles.Count()];
                for (int i = 0; i < newFiles.Count(); i++) { // get scores
                    newFiles[i] = Path.GetFullPath(newFiles[i]);
                    Scorer s = new Scorer(newFiles[i].Substring(0, newFiles[i].Length - 4));
                    scores[i] = s.Score();
                    i++;
                }
                string[] keep = Tournament(scores, newFiles);

                // Save toKeep
                if (rep + 1 == repetitions) {
                    moveAllFiles(intermediate, "Gamepool/Final", true);
                }
                else{
                    moveAllFiles(intermediate, newPool, true, newFiles);// keep);
                }   
            }
        }

        private static void Crossover(string parent1, string parent2, string folder)
        {
            folder += "/";
            var parser1 = OpenParser(parent1);
            var parser2 = OpenParser(parent2);
            var game1 = parser1.game();
            var game2 = parser2.game();
            string gametext1 = game1.GetText();
            string gametext2 = game2.GetText();
            bool unchanged = true;
            Type tree = null;
            string child1 = "";
            string child2 = "";
            while (unchanged){
                tree = crossovers[rnd.Next(crossovers.Count())];
                var subtree1 = FindSubTree(game1, tree);
                var subtree2 = FindSubTree(game2, tree);
                child1 = gametext1.Replace(subtree1.GetText(), subtree2.GetText());
                child2 = gametext2.Replace(subtree2.GetText(), subtree1.GetText());
                // check that subtrees return non-empty before changing unchanged
                unchanged = false;
            }
            string child1Name = GetName(parent1, parent2);
            string child2Name = GetName(parent2, parent1);

            MakeFile(child1, folder + child1Name);
            MakeFile(child2, folder + child2Name);
        }

        private static void Mutate(string parent, string folder) {
            folder += "/";
            string childName = Trim(parent) + "M.gdl";
            var parser = OpenParser(parent);
            var game = parser.game();
            string child = game.GetText();
            var locs = FindCStorages(game);
            for (int i = 0; i < numMutations; i++){
                var tree = mutations[rnd.Next(mutations.Count())];
                var subtree = FindSubTree(game, tree); // check subtree
                var newMutation = GetMutation(subtree, locs);
                if (newMutation.Count() == 0) { i--; }
                else { child = child.Replace(subtree.GetText(), newMutation); }
            }
            MakeFile(child, folder + childName);
        }

        private static string ConstructMoveString(string c1, string c2){
            if (c1 == c2) { return ""; }
            return "move " + c1 + " " + c2;
        }

        private static string GetMutation(IParseTree tree, List<RecycleParser.CstorageContext> locs){
            var ret = "";
            if (tree is RecycleParser.MoveactionContext){
                var t = tree as RecycleParser.MoveactionContext;
                var r = rnd.Next(0, 5);
                if (r == 0){ // swap beginning and end
                    var cards = t.card();
                    var text1 = cards[0].GetText();
                    var text2 = cards[1].GetText();
                    ret = "move " + text2 + " " + text1;
                    Console.WriteLine("reverse of " + t.GetText() + " is ");
                    Console.WriteLine(ret);
                    return ret;
                }
                else if (r == 1){ // change beginning to random loc
                    while (ret.Length == 0){
                        var loc = locs[rnd.Next(0, locs.Count)];
                        ret = ConstructMoveString("(top" + loc.GetText() + ")", t.card()[1].GetText());
                    }
                    Console.WriteLine("beginning of " + t.GetText() + " switched is ");
                    Console.WriteLine(ret);
                    return ret;
                }
                else if (r == 2){ // change ending to random loc
                    while (ret.Length == 0){
                        var loc = locs[rnd.Next(0, locs.Count)];
                        ret = ConstructMoveString(t.card()[0].GetText(), "(top" + loc.GetText() + ")");
                    }
                    Console.WriteLine("end of " + t.GetText() + " switched is ");
                    Console.WriteLine(ret);
                    return ret;
                }
                else if (r == 3){ // 1 case with bottom
                    while (ret.Length == 0){
                        var loc = locs[rnd.Next(0, locs.Count)];
                        ret = ConstructMoveString("(bottom" + loc.GetText() + ")", t.card()[1].GetText());
                    }
                    Console.WriteLine("beginning of " + t.GetText() + " switched is ");
                    Console.WriteLine(ret);
                    return ret;
                }
                else if (r == 4){ // 2 case with bottom
                    while (ret.Length == 0){
                        var loc = locs[rnd.Next(0, locs.Count)];
                        ret = ConstructMoveString(t.card()[0].GetText(), "(bottom" + loc.GetText() + ")");
                    }
                    Console.WriteLine("end of " + t.GetText() + " switched is ");
                    Console.WriteLine(ret);
                    return ret;
                }
            }
            else if (tree is RecycleParser.ShuffleactionContext){
                var t = tree as RecycleParser.ShuffleactionContext;
                var r = rnd.Next(0, 4);
                if (r == 0)
                { // 

                }
                else if (r == 1)
                { // 

                }
                else if (r == 2)
                { // 

                }
                else if (r == 3)
                { // 

                }
            }
            else if (tree is RecycleParser.RepeatContext){
                var t = tree as RecycleParser.MoveactionContext;
                var r = rnd.Next(0, 4);
                if (r == 0)
                { // 

                }
                else if (r == 1)
                { // 

                }
                else if (r == 2)
                { // 

                }
                else if (r == 3)
                { // 

                }
            }
            else if (tree is RecycleParser.MultiactionContext){
                var t = tree as RecycleParser.MoveactionContext;
                var r = rnd.Next(0, 4);
                if (r == 0)
                { // 

                }
                else if (r == 1)
                { // 

                }
                else if (r == 2)
                { // 

                }
                else if (r == 3)
                { // 

                }
            }
            else if (tree is RecycleParser.Multiaction2Context){
                var t = tree as RecycleParser.MoveactionContext;
                var r = rnd.Next(0, 4);
                if (r == 0)
                { // 

                }
                else if (r == 1)
                { // 

                }
                else if (r == 2)
                { // 

                }
                else if (r == 3)
                { // 

                }
            }
            else if (tree is RecycleParser.EndconditionContext){
                var t = tree as RecycleParser.MoveactionContext;
                var r = rnd.Next(0, 4);
                if (r == 0)
                { // 

                }
                else if (r == 1)
                { // 

                }
                else if (r == 2)
                { // 

                }
                else if (r == 3)
                { // 

                }
            }

            return ret;
        }
    
        private static IParseTree FindSubTree(IParseTree game, Type treeType){
            List<IParseTree> nodes = new List<IParseTree>();
            nodes.Add(game);
            List<IParseTree> all = new List<IParseTree>();
            List<RecycleParser.CstorageContext> cstorages = new List<RecycleParser.CstorageContext>();
            while (nodes.Count > 0) {
                IParseTree current = nodes[0];
                nodes.RemoveAt(0);
                for (int i = 0; i < current.ChildCount; i++) {
                    var child = current.GetChild(i);
                    if (!((child is TerminalNodeImpl) || (child is RecycleParser.NamegrContext))){
                        if (child.GetType() == treeType){
                            all.Add(child);
                        }
                        else if (child is RecycleParser.CstorageContext){
                            cstorages.Add(child as RecycleParser.CstorageContext);
                        }
                        nodes.Add(child);
                    }
                }
            }
            if (all.Count == 0){
                return null;
            }
            int index = rnd.Next(all.Count);
            return all[index];
        }


        private static List<RecycleParser.CstorageContext> FindCStorages(IParseTree game)
        {
            List<IParseTree> nodes = new List<IParseTree>();
            nodes.Add(game);
            List<RecycleParser.CstorageContext> cstorages = new List<RecycleParser.CstorageContext>();
            while (nodes.Count > 0)
            {
                IParseTree current = nodes[0];
                nodes.RemoveAt(0);
                for (int i = 0; i < current.ChildCount; i++)
                {
                    var child = current.GetChild(i);
                    if (!((child is TerminalNodeImpl) || (child is RecycleParser.NamegrContext))) {
                        if (child is RecycleParser.CstorageContext) {
                            cstorages.Add(child as RecycleParser.CstorageContext);
                        }
                        nodes.Add(child);
                    }
                }
            }
            return cstorages;
       }

        private static string[] Tournament(double[] scores, string[] files)
        {
            string[] ret = new string[numKept];
            var count = scores.Count();

            if (count < numKept) { throw new ArgumentOutOfRangeException(); }

            for (int i = 0; i < numKept; i++)
            {
                var ind1 = rnd.Next(count);
                var ind2 = rnd.Next(count);
                string add = null;
                if (scores[ind1] > scores[ind2]) { add = files[ind1]; }
                else { add = files[ind2]; }
                if (ret.Contains(add))
                {
                    i--;
                }
                else
                {
                    ret[i] = add;
                }
            }
            return ret;
        }

        private static void MakeFile(string file, string name){
            if (File.Exists(name))
            {
                name.Insert(name.Length - 4, "1");
            }
            File.WriteAllText(name, file);
            Console.WriteLine("Wrote file " + name);
        }

        private static string[] GetTop(double[] scores, string[] files)
        {
            int[] indexes = TopScoreIndexes(scores, numKept);
            string[] keep = new string[indexes.Count()];
            for (int k = 0; k < indexes.Count(); k++)
            {
                keep[k] = files[indexes[k]];
            }
            return keep;
        }

        private static RecycleParser OpenParser(string fileName){
            var file = File.ReadAllText(fileName);
            file = regex.Replace(file, "\n");
            AntlrInputStream stream = new AntlrInputStream(file);
            ITokenSource lexer = new RecycleLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            return new RecycleParser(tokens);
        }

        private static string GetName(string parent1, string parent2){
            var name1 = Trim(parent1);
            var name2 = Trim(parent2);
            name1 = name1.Substring(0, name1.Length / 2);
            name2 = name2.Substring(name2.Length / 2, name2.Length / 2);
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
                if (folder.Contains("Pool") || folder.Contains("Intermediate")){
                    Console.WriteLine("Deleting folder " + folder);
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
