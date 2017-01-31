using System;
using System.Collections.Generic;
using Antlr4.Runtime.Tree;

namespace CardStockXam.CardEngine
{
    class IterItem{
        public IParseTree tree;
        public string varContext;
        public ICloneable item;

        public IterItem(IParseTree tree){
            this.tree = tree;
        }
        public IterItem(string k)
        {
            varContext = k;
        }
        public IterItem(string k, object v){
            varContext = k;
            item = v;
        }
    }
}
