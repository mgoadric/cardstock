using System;
using CardEngine;
using Players;

namespace CardGames
{
    public class Program
    {
        public static void Main(string[] args)
        {

			var exp = new Experiment();

			exp.fileName = "Pairs2";
			exp.numGames = 1000;
			exp.numEpochs = 10;
			exp.logging = false;
			exp.ai = true;

            var codegen = new ParseEngine(exp);
        }
    }
}
