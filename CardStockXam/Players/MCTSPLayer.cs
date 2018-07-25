using CardEngine;
using CardStockXam;
using CardStockXam.Scoring;
using FreezeFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    public class MCTSPLayer : AIPlayer
    {
        private CardGame privategame;
        private GameIterator privateiterator;
        public MCTSPLayer(Perspective perspective) : base(perspective) { }


        public override int MakeAction(List<GameActionCollection> possibles, Random rand)
        {
            return Choice(possibles.Count, rand);
        }

        public int Choice(int optioncount, Random random) //
        {
            Tuple<CardGame, GameIterator> game = perspective.GetPrivateGame();
            privategame = game.Item1;
            privateiterator = game.Item2;
            if (privategame.Equals(privateiterator.game))
            {
                Console.WriteLine("CardGame equals Clone");
            }

            Dictionary<CardGame, Int32> plays = new Dictionary<CardGame, Int32>();

            Console.WriteLine("Playing a simulated game");

            while (!privateiterator.AdvanceToChoice())
            {
                CardGame simgame = privateiterator.game.Clone();
                plays.Add(simgame, 1);
                privateiterator.ProcessChoice();
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
