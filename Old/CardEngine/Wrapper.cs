using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStockXam.CardEngine
{
    class Wrapper : ICloneable
    {
        public object o;
        public Wrapper() { }
        public Wrapper(object o) { this.o = o; }
        public object Clone()
        {
            return new Wrapper() { o = this.o };
        }
    }
}
