using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;
using Antlr4.Runtime;
using System.Text.RegularExpressions;

namespace CardStockXam.Scoring
{
    class Generator
    {
        public string transcript = "";

        private int numMutations;
        private GeneticFiler filer;
        private bool printing;

        private Random rnd = new Random();
        private Regex regex = new Regex("(;;)(.*?)(\n)");
        private Type[] crossovers = new Type[] { typeof(RecycleParser.StageContext), typeof(RecycleParser.MultiactionContext), typeof(RecycleParser.Multiaction2Context),
            typeof(RecycleParser.DeckContext), typeof(RecycleParser.SetupContext) };
        private Type[] mutations = new Type[]  { typeof(RecycleParser.MoveactionContext), typeof(RecycleParser.ShuffleactionContext), typeof(RecycleParser.RepeatContext),
                                                 typeof(RecycleParser.MultiactionContext), typeof(RecycleParser.Multiaction2Context), typeof(RecycleParser.EndconditionContext),
                                                 typeof(RecycleParser.CondactContext) };

        public Generator(GeneticFiler f, int numMutations, bool printing) {
            filer = f;
            this.numMutations = numMutations;
            this.printing = printing;
        }

        public void Crossover(string parent1, string parent2)
        {
            var folder = filer.Intermediate() + "/";
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
            string changedText = "";
            while (unchanged){
                tree = crossovers[rnd.Next(crossovers.Count())];
                var subtree1 = FindSubTree(game1, tree);
                var subtree2 = FindSubTree(game2, tree);
                if (subtree1 != null && subtree2 != null)
                {
                    var cleaned = CleanRefs(game1, game2, subtree1, subtree2);
                    child1 = gametext1.Replace(cleaned.Item1, cleaned.Item2);
                    child2 = gametext2.Replace(cleaned.Item2, cleaned.Item1);
                    // check that subtrees return non-empty before changing unchanged
                    changedText = "    " + cleaned.Item1 + "\n    " + cleaned.Item2;
                    unchanged = false;
                }
            }
            string child1Name = filer.GetName(parent1, parent2);
            string child2Name = filer.GetName(parent2, parent1);

            transcript += "Swapped in files " + child1Name + " and " + child2Name + "\n" + changedText + "\n";

            filer.MakeFile(child1, folder + child1Name);
            filer.MakeFile(child2, folder + child2Name);
        }

        public void Mutate(string parent)
        {
            var folder = filer.Intermediate() + "/";
            string childName = filer.MutName(parent); 
            var parser = OpenParser(parent);
            var game = parser.game();
            string child = game.GetText();
            var info = FindGameInfo(game);
            for (int i = 0; i < numMutations; i++)
            {
                var tree = mutations[rnd.Next(mutations.Count())];
                var subtree = FindSubTree(game, tree); // check subtree
                var newMutation = GetMutation(subtree, info.Item1, info.Item2);
                printMut(subtree.GetText(), newMutation);
                transcript += "Changed " + childName + "\n    " + subtree.GetText() + "\nto:\n    " + newMutation + "\n";
                if (!newMutation.Any()) { i--; }
                else { child = child.Replace(subtree.GetText(), newMutation); }
            }
            filer.MakeFile(child, folder + childName);
        }

        public string GetMutation(IParseTree tree, List<RecycleParser.CstorageContext> locs, List<RecycleParser.VarContext> vars)
        { //TODO add var to random var of same type
            string ret = "";
            if (tree is RecycleParser.MoveactionContext){
                var t = tree as RecycleParser.MoveactionContext;
                while (ret.Length == 0){
                    var r = rnd.Next(0, 5);
                    if (r == 0)
                    { // swap beginning and end
                        var cards = t.card();
                        var text1 = cards[0].GetText();
                        var text2 = cards[1].GetText();
                        ret = "move " + text2 + " " + text1;
                    }
                    else if (r == 1)
                    { // change beginning to random loc
                        var loc = locs[rnd.Next(0, locs.Count)];
                        ret = ConstructMoveString("(top" + loc.GetText() + ")", t.card()[1].GetText());
                    }
                    else if (r == 2)
                    { // change ending to random loc
                        var loc = locs[rnd.Next(0, locs.Count)];
                        ret = ConstructMoveString(t.card()[0].GetText(), "(top" + loc.GetText() + ")");
                    }
                    else if (r == 3)
                    { // 1 case with bottom
                        var loc = locs[rnd.Next(0, locs.Count)];
                        ret = ConstructMoveString("(bottom" + loc.GetText() + ")", t.card()[1].GetText());
                    }
                    else if (r == 4)
                    { // 2 case with bottom
                        var loc = locs[rnd.Next(0, locs.Count)];
                        ret = ConstructMoveString(t.card()[0].GetText(), "(bottom" + loc.GetText() + ")");
                    }
                }
            }
            else if (tree is RecycleParser.ShuffleactionContext)
            {
                var t = tree as RecycleParser.ShuffleactionContext;
                for (int i = 0; i < locs.Count; i++){ // swap shuffle location with other location
                    var loc = locs[rnd.Next(0, locs.Count)];
                    var loctext = loc.GetText();
                    if (loctext.Contains("iloc") && !t.GetChild(1).GetText().Contains(loctext)){
                        ret = ConstructShuffleString(t.cstorage().GetText(), loc.GetText());
                        break;
                    }
                }
            }
            else if (tree is RecycleParser.RepeatContext)
            {
                var t = tree as RecycleParser.RepeatContext;
                if (t.@int() != null)
                {
                    var r = rnd.Next(1, 10);
                    ret = "repeat " + r + " " + t.GetChild(2).GetText();
                }
                else
                {
                    ret = "repeat all (" + GetMutation(t.GetChild(3), locs, vars) + ")";
                }
            }
            else if (tree is RecycleParser.MultiactionContext){
                var t = tree as RecycleParser.MultiactionContext;
                if (t.agg() != null){
                    var a = t.agg();
                    var r = rnd.Next(0, 2);
                    if (r == 0)
                    {// swap any and all
                        var mod = "any";
                        if (a.GetChild(1).Equals("any"))
                        {
                            mod = "all";
                        }
                        ret = "(" + mod + " " +
                            a.GetChild(2).GetText() + " " +
                            a.GetChild(3).GetText() + " " +
                            a.GetChild(4).GetText() + ")";
                    }
                    else if (r == 1)
                    {
                        var loc = locs[rnd.Next(0, locs.Count)];
                        ret = "(" + a.GetChild(1).GetText() + " " +
                            loc.GetText() + " " +
                            a.GetChild(3).GetText() + " " +
                            a.GetChild(4).GetText() + ")";
                    }
                }
                else if (t.let() != null){
                    if (t.let().multiaction() != null)
                    {
                        var let = t.let();
                        ret = "(let " +
                            let.GetChild(2).GetText() + " " +
                            let.GetChild(3).GetText() + " " +
                            GetMutation(let.multiaction(), locs, vars) + ")";
                    }
                }
                else{ // choice or do
                    var r = rnd.Next(0, 3);
                    if (r == 0)
                    { // swap choice/do
                        var snd = "choice";
                        if (t.GetChild(1).GetText().Contains("c"))
                        {
                            snd = "do";
                        }
                        ret = "(" + snd + " (";
                        for (int i = 3; i < t.ChildCount - 2; i++)
                        {
                            ret += t.GetChild(i).GetText() + " ";
                        }
                        ret += "))";
                    }
                    else if (r == 1)
                    { // change condact
                        var ind = rnd.Next(0, t.condact().Count());
                        ret = "(" + t.GetChild(1).GetText() + " (";
                        for (int i = 3; i < t.ChildCount - 2; i++)
                        {
                            if (i - 3 == ind) { ret += GetMutation(t.GetChild(i), locs, vars); }
                            else { ret += t.GetChild(i).GetText() + " "; }
                        }
                        ret += "))";
                    }
                    else
                    { // add new modified condact
                        var ind = rnd.Next(0, t.condact().Count());
                        ret = "(" + t.GetChild(1).GetText() + " (";
                        for (int i = 3; i < t.ChildCount - 2; i++)
                        {
                            if (i - 3 == ind) { ret += GetMutation(t.GetChild(i), locs, vars); }
                            ret += t.GetChild(i).GetText() + " ";
                        }
                        ret += "))";
                    }
                }
            }
            else if (tree is RecycleParser.Multiaction2Context){
                var t = tree as RecycleParser.Multiaction2Context;
                if (t.agg() != null){
                    var a = t.agg();
                    var r = rnd.Next(0, 2);
                    if (r == 0)
                    {// swap any and all
                        var mod = "any";
                        if (a.GetChild(1).Equals("any"))
                        {
                            mod = "all";
                        }
                        ret = "(" + mod + " " +
                            a.GetChild(2).GetText() + " " +
                            a.GetChild(3).GetText() + " " +
                            a.GetChild(4).GetText() + ")";
                    }
                    else if (r == 1)
                    {
                        var loc = locs[rnd.Next(0, locs.Count)];
                        ret = "(" + a.GetChild(1).GetText() + " " +
                            loc.GetText() + " " +
                            a.GetChild(3).GetText() + " " +
                            a.GetChild(4).GetText() + ")";
                    }
                }
                else if (t.let() != null)
                {
                    if (t.let().multiaction() != null)
                    {
                        var let = t.let();
                        ret = "(let " +
                            let.GetChild(2).GetText() + " " +
                            let.GetChild(3).GetText() + " " +
                            GetMutation(let.multiaction(), locs, vars) + ")";
                    }
                }
                else
                { // do
                    var r = rnd.Next(0, 2);
                    if (r == 0)
                    { // change condact
                        var ind = rnd.Next(0, t.condact().Count());
                        ret = "(do (";
                        for (int i = 3; i < t.ChildCount - 2; i++)
                        {
                            if (i - 3 == ind) { ret += GetMutation(t.GetChild(i), locs, vars); }
                            else { ret += t.GetChild(i).GetText() + " "; }
                        }
                        ret += "))";
                    }
                    else
                    { // add new modified condact
                        var ind = rnd.Next(0, t.condact().Count());
                        ret = "(do (";
                        for (int i = 3; i < t.ChildCount - 2; i++)
                        {
                            if (i - 3 == ind) { ret += GetMutation(t.GetChild(i), locs, vars); }
                            ret += t.GetChild(i).GetText() + " ";
                        }
                        ret += "))";
                    }
                }
            }
            else if (tree is RecycleParser.EndconditionContext)
            {
                var t = tree as RecycleParser.EndconditionContext;
                ret = "(end (not " + t.GetChild(2).GetText() + "))";
            }
            else if (tree is RecycleParser.ScoringContext)
            {
                var t = tree as RecycleParser.ScoringContext;
                var r = rnd.Next(0, 2);
                if (r == 0){ //swap min and max
                    var mod = "min";
                    if (t.GetChild(2).GetText().Equals(mod)) { mod = "max"; }
                    ret = "(scoring " + mod + t.GetChild(3).GetText();
                }
                else{
                    ret = "(scoring " + t.GetChild(2).GetText() + " (not " + t.GetChild(3).GetText() + ")";
                }
            }
            else if (tree is RecycleParser.CondactContext)
            {
                var t = tree as RecycleParser.CondactContext;
                if (t.boolean() != null)
                {// not bool
                    ret = "((not " + t.boolean().GetText() + ") " + t.GetChild(2).GetText() + ")";
                }
                else if (t.multiaction2() != null){
                    ret = GetMutation(t.multiaction2(), locs, vars);
                }
            }
            //Console.WriteLine("changed " + tree.GetText() + " to " + ret);
            return ret;
        }

        private void printMut(string orig, string n){
            if (printing){
                Debug.WriteLine("Changed:\n    " + orig + "\nto:\n    " + n);
            }
        }

        private string ConstructMoveString(string c1, string c2)
        {
            if (c1 == c2) { return ""; }
            return "move " + c1 + " " + c2;
        }

        private string ConstructShuffleString(string c1, string c2)
        {
            if (c1 == c2) { return ""; }
            return "shuffle " + c2;
        }

        private RecycleParser OpenParser(string fileName)
        {
            var file = File.ReadAllText(fileName);
            file = regex.Replace(file, "\n");
            AntlrInputStream stream = new AntlrInputStream(file);
            ITokenSource lexer = new RecycleLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            return new RecycleParser(tokens);
        }

        private IParseTree FindSubTree(IParseTree game, Type treeType)
        {
            List<IParseTree> nodes = new List<IParseTree>();
            nodes.Add(game);
            List<IParseTree> all = new List<IParseTree>();
            List<RecycleParser.CstorageContext> cstorages = new List<RecycleParser.CstorageContext>();
            while (nodes.Count > 0)
            {
                IParseTree current = nodes[0];
                nodes.RemoveAt(0);
                for (int i = 0; i < current.ChildCount; i++)
                {
                    var child = current.GetChild(i);
                    if (!((child is TerminalNodeImpl) || (child is RecycleParser.NamegrContext)))
                    {
                        if (child.GetType() == treeType)
                        {
                            all.Add(child);
                        }
                        else if (child is RecycleParser.CstorageContext)
                        {
                            cstorages.Add(child as RecycleParser.CstorageContext);
                        }
                        nodes.Add(child);
                    }
                }
            }
            if (all.Count == 0)
            {
                return null;
            }
            int index = rnd.Next(all.Count);
            return all[index];
        }


        private Tuple<List<RecycleParser.CstorageContext>, List<RecycleParser.VarContext>> FindGameInfo(IParseTree game)
        {
            List<IParseTree> nodes = new List<IParseTree>();
            nodes.Add(game);
            List<RecycleParser.CstorageContext> cstorages = new List<RecycleParser.CstorageContext>();
            List<RecycleParser.VarContext> vars = new List<RecycleParser.VarContext>();
            while (nodes.Count > 0)
            {
                IParseTree current = nodes[0];
                nodes.RemoveAt(0);
                for (int i = 0; i < current.ChildCount; i++)
                {
                    var child = current.GetChild(i);
                    if (!((child is TerminalNodeImpl) || (child is RecycleParser.NamegrContext)))
                    {
                        if (child is RecycleParser.CstorageContext)
                        {
                            cstorages.Add(child as RecycleParser.CstorageContext);
                        }
                        nodes.Add(child);
                    }
                }
            }
            return new Tuple<List<RecycleParser.CstorageContext>, List<RecycleParser.VarContext>>(cstorages, vars);
        }

        private Tuple<String, String> CleanRefs(RecycleParser.GameContext g1, RecycleParser.GameContext g2, IParseTree t1, IParseTree t2)
        {
            //TODO
            // check for vars and locs
              // if vars or locs don't exist in rest of context, then switch to something of same type that does exist
                // if that fails, create a definition based on usage in other game
            return new Tuple<String, String>(t1.ToString(), t2.ToString());
        }
    }
}
