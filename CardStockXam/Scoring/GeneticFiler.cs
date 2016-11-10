using System;
using System.IO;
using System.Linq;



namespace CardStockXam.Scoring
{
    class GeneticFiler
    {
        private int rep;
        private int repetitions;
        public GeneticFiler() { }

        public void Start(int r)
        {
            repetitions = r;
            rep = -1;
            deleteAllOldFiles();
            moveAllFiles("Gamepool\\Initial", NextPool(), true);
        }

        public void newIter()
        {
            rep++;
            Directory.CreateDirectory(Intermediate());
        }

        public string[] GetFiles(string folder) { return Directory.GetFiles(folder); }
        public string[] GetFullPathFiles(string folder){
            string[] files = GetFiles(folder);
            for (int i = 0; i < files.Count(); i++){
                files[i] = Path.GetFullPath(files[i]);
            }
            return files;
        }

        public string Initial() { return "Gamepool\\Initial"; }
        public string Pool() { return Pool(rep); }
        public string NextPool() { return Pool(rep + 1); }
        public string Pool(int i) { return "Gamepool\\Pool" + i; }
        public string Intermediate() { return "Gamepool\\Intermediate" + rep; }

        public void moveAllFiles(string start, string end, bool copy = false, string[] files = null)
        {
            if (!Directory.Exists(end)) { Directory.CreateDirectory(end); }
            if (files == null) { files = Directory.GetFiles(start); }

            foreach (string s in files)
            {
                var fileName = Path.GetFileName(s);
                var destFile = Path.Combine(end, fileName);
                if (copy)
                {
                    File.Copy(s, destFile, true);
                }
                else
                {
                    File.Move(s, destFile);
                }
            }
        }

        public void MakeFile(string file, string name)
        {
            if (File.Exists(name))
            {
                name.Insert(name.Length - 4, "1");
            }
            File.WriteAllText(name, file);
            //Console.WriteLine("Wrote file " + name);
        }

        public string GetName(string parent1, string parent2)
        {
            var name1 = Trim(parent1);
            var name2 = Trim(parent2);
            name1 = name1.Substring(0, name1.Length / 2);
            name2 = name2.Substring(name2.Length / 2, name2.Length / 2);
            return name1 + name2 + ".gdl";
        }

        public string MutName(string parent)
        {
            return Trim(parent) + "M.gdl";
        }

        public void FixInit(){
            var files = Directory.GetFiles(Initial());
            foreach (var file in files){
                if (!file.Contains(".gdl")){
                    File.Delete(file);
                }
            }
        }

        public void DeleteDirectory(string targetDir){
            deleteFiles(targetDir);
            Directory.Delete(targetDir, false);
        }

        private void deleteFiles(string folder)
        {
            string[] toRemove = Directory.GetFiles(folder);
            foreach (string s in toRemove)
            {
                File.Delete(s);
            }
        }

        private void deleteAllOldFiles()
        {
            var folders = Directory.GetDirectories("Gamepool");
            foreach (var folder in folders)
            {
                if (folder.Contains("Pool") || folder.Contains("Intermediate"))
                {
                    //Console.WriteLine("Deleting folder " + folder);
                    DeleteDirectory(folder);
                }
            }
        }

        private string Trim(string s)
        {
            var paths = s.Split('\\');
            s = paths[paths.Count() - 1];
            s = s.Split('.')[0];
            return s;
        }
    }
}