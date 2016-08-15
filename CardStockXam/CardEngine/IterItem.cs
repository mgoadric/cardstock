using System;
using System.Collections.Generic;
using Antlr4.Runtime.Tree;

namespace CardStockXam.CardEngine
{
    class IterItem{
        public IParseTree tree;
        public bool start;
        public string varContext;
        public object item;

        public IterItem(IParseTree tree){
            this.tree = tree;
        }

        public IterItem(string k, object v, bool b){
            varContext = k;
            item = v;
            start = b;
        }
    }
}
