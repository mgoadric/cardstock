using CardEngine;
using CardStockXam;
using FreezeFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    public class MCTSPLayer : GeneralPlayer
    {
        private int idx;

        public MCTSPLayer(GameIterator m, int idx) : base(m) // ??
		{
            this.idx = idx;
        }

        public override int MakeAction(List<GameActionCollection> possibles, Random rand)
        {
            return Choice(possibles.Count, rand);
        }

        public int Choice(int optioncount, Random random) //
        {
            CardGame cg = gameContext.game.CloneSecret(idx);
            var cloneContext = gameContext.Clone(cg);

            if (cg.Equals(gameContext.game))
            {
                Console.WriteLine("CardGame equals Clone");
            }

            Dictionary<CardGame, Int32> plays = new Dictionary<CardGame, Int32>();

            Console.WriteLine("Playing a simulated game");

            while (!cloneContext.AdvanceToChoice())
            {
                CardGame simgame = cloneContext.game.Clone();
                plays.Add(simgame, 1);
                cloneContext.ProcessChoice();
            }

            Console.WriteLine("Simulated Game is Over");
            Console.WriteLine(plays.Count);

            Console.ReadLine();
            Environment.Exit(0);
            return 0;
        }




        public Node SelectNodeUsingUCT(List<Node> moves)
        {


            return null;
        }



    }
}
