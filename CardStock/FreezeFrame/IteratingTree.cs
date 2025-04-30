﻿using System;
using System.Collections.Generic;
using Antlr4.Runtime.Tree;

namespace CardStock.FreezeFrame
{
    class IteratingTree{
        public Stack<IterItem> trees;
        public int level;

        public IteratingTree(){
            trees = new Stack<IterItem>();
            level = 0;
        }

        public IteratingTree Copy(){
            return new IteratingTree
            {
                trees = new Stack<IterItem>(trees),
                level = this.level + 1
            };
        }

        public void Push(IParseTree tree){
            trees.Push(new IterItem(tree));
        }

        public void Push(string k){
            trees.Push(new IterItem(k));
        }

        public void Push(string k, object v){
            trees.Push(new  IterItem(k, v));
        }

        public IterItem Pop(){
            return trees.Pop();
        }
        public IterItem Peek(){
            return trees.Peek();
        }

        public int Count(){
            return trees.Count;
        }

        public override string ToString(){
            var ret = "";
            foreach (var obj in trees)
            {
                if (obj.tree != null){
                    ret += obj.tree.GetText();
                }
                else{
                    ret += " var context " + obj.varContext + " " + obj.item;
                }
            }
            return ret;
        }
    }
}
