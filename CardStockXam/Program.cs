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
            exp.fileName = "Golf";
            exp.numGames = 1;
            exp.numEpochs = 1;
            exp.logging = true;
            exp.ai = true;

            var codeGen = new ParseEngine(exp);
        }
    }
}
