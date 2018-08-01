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
            /*Tuple<CardGame, GameIterator> temp =  perspective.GetPrivateGame();
            privategame = temp.Item1;
            privateiterator = temp.Item2;*/

            /*/ TEST CLONE 
            if (perspective.TestingClone())
            { Console.WriteLine("Clone Equals"); }
            else { Console.WriteLine(("Doesn't Equal")); }


            // TEST CLONESECRET
            perspective.TestingCloneSecret();

            // TEST CLONESECRETCLONE
            perspective.TestCloneSecretClone();
            */



            //
            Tuple<CardGame, GameIterator> game = perspective.GetPrivateGame();
            privategame = game.Item1;
            privateiterator = game.Item2;
            for (int j = 0; j < numPlayers; j++)
            {
                privategame.players[j].decision = new RandomPlayer(perspective);
            }

            /* HASHCODE TESTING
            CardGame simgame = privateiterator.game.Clone();
            CardGame test = simgame.Clone();
            if (simgame.Equals(test)) { Console.WriteLine("equality check"); }
            Console.WriteLine("simgame hash: " + simgame.GetHashCode() + " vs. test hash: " + test.GetHashCode());
            */

            // PLAY GAME SIMULATION TEST
            Dictionary<CardGame, Int32> plays = new Dictionary<CardGame, Int32>();
           
            //TEST FOR KEY CHECKING
            //List<CardGame> cardGamesx = new List<CardGame>();

            Console.WriteLine("Playing a simulated game");
            while (!privateiterator.AdvanceToChoice())
            {
                CardGame savestate = privateiterator.game.Clone();
                // cardGamesx.Add(savestate);
                if (plays.Keys.Contains(savestate))
                { Console.WriteLine("Game in play dictionary already."); plays[savestate] += 1; }
                else
                { plays.Add(savestate, 1); }
                //if (cardGamesx.Count == 1) { Console.WriteLine("Game added: " + cardGamesx[0]); }
                privateiterator.ProcessChoice();
            }

            //Console.WriteLine("Game after: " + cardGamesx[0]);

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
