using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;

namespace CardStockXam.CardEngine
{
    class IteratingTree{
        public Stack<IParseTree> trees;
        public List<String> vars;
        public List<object> objects;

        public IteratingTree(){
            trees = new Stack<IParseTree>();
        }
        public IteratingTree (Stack<IParseTree> trees){
            this.trees = trees;
        }

        public void AddVar(String k, Object v){
            vars.Add(k);
            objects.Add(v);
        }

        public IteratingTree Copy(){
            Console.WriteLine(ToString());
            return new IteratingTree(trees){
                vars = vars,
                objects = objects
            };
        }

        public void Push(IParseTree tree){
            trees.Push(tree);
        }

        public IParseTree Pop(){
            return trees.Pop();
        }
        public IParseTree Peek(){
            return trees.Peek();
        }

        public int Count(){
            return trees.Count;
        }

        public override string ToString(){
            var ret = "";
            foreach (var obj in trees)
            {
                ret += obj.GetText();
            }
            return ret;
        }
    }
}
