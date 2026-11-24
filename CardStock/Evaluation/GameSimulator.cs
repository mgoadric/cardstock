using Antlr4.Runtime;
using System.Text.RegularExpressions;
using System.Diagnostics;
using CardStock.CardEngine;
using CardStock.Players;
using CardStock.FreezeFrame;

namespace CardStock.Evaluation
{
    public partial class GameSimulator()
    {

        public static Experiment? exp;
        private RecycleParser.GameContext tree;
        public const int MAXPLAYERS = 9; // This makes some things easier to store as arrays.
        public const int CHOICELIMIT = 500; // The upper bound on the number of moves in a game before it is called.
        public const int LOOPLIMIT = 200; // The upper bound on the number of actions without a choice interrupting

        public const ImperfectLevel imperfectLevel = ImperfectLevel.TAKEN;

        public void LoadGame()
        {
            

            return true;
        }

        [GeneratedRegex("(;;)(.*?)(\n)")]
        private static partial Regex MyRegex();
    }
}
