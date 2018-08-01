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
        public Dictionary<Tuple<CardGame, int>, int> plays = new Dictionary<Tuple<CardGame, int>, int>();
        private CardGame privategame;
        private GameIterator privateiterator;
        public MCTSPLayer(Perspective perspective) : base(perspective) { }


        public override int MakeAction(List<GameActionCollection> possibles, Random rand)
        {
            return Choice(possibles.Count, rand);
        }

        public int Choice(int optioncount, Random random) //
        {

            /*
            Tuple<CardGame, GameIterator> temp =  perspective.GetPrivateGame();
            privategame = temp.Item1;
            privateiterator = temp.Item2;
            
            // TEST CLONE 
            if (perspective.TestingClone())
            { Console.WriteLine("Clone Equals"); }
            else { Console.WriteLine(("Doesn't Equal")); }

            // TEST CLONESECRET
            perspective.TestingCloneSecret();

            // TEST CLONESECRETCLONE
            perspective.TestCloneSecretClone();
            
            //HASHCODE TESTING
            CardGame simgame = privateiterator.game.Clone();
            CardGame test = simgame.Clone();
            if (simgame.Equals(test)) { Console.WriteLine("equality check"); }
            Console.WriteLine("simgame hash: " + simgame.GetHashCode() + " vs. test hash: " + test.GetHashCode());
            */

            // GAME SIMULATIONS TEST
           
            Tuple<CardGame, GameIterator> game = perspective.GetPrivateGame();
            privategame = game.Item1;
            privateiterator = game.Item2;
            for (int i = 0; i < 10; i++)
            {
                RunSimulation();
            }
            //Console.WriteLine("Game after: " + cardGamesx[0]);

            Console.WriteLine("Simulated Game is Over");
            Console.WriteLine(plays.Count);
            Console.ReadLine();
            Environment.Exit(0);
            return 0;
        }

        public void RunSimulation()
        {
            HashSet<Tuple<CardGame, int>> visitedstates = new HashSet<Tuple<CardGame, int>>();
            CardGame cg = privategame.Clone();
            GameIterator gameIterator = privateiterator.Clone(cg);
            for (int j = 0; j < numPlayers; j++)
            {
                cg.players[j].decision = new RandomPlayer(perspective);
            }
            int idx = cg.currentPlayer.Peek().idx;

            bool expand = true;
            // "Playing a simulated game"
            while (!gameIterator.AdvanceToChoice())
            {
                gameIterator.ProcessChoice();
                CardGame savestate = gameIterator.game.Clone();
                Tuple<CardGame, int> stateandplayer = Tuple.Create<CardGame, int>(savestate, idx);


                if (expand && (!plays.Keys.Contains(stateandplayer)))
                { expand = false; plays[stateandplayer] = 0; }
               
                visitedstates.Add(stateandplayer);
                idx = cg.currentPlayer.Peek().idx;
            }
            // Find winner TODO
        }

        public Node SelectNodeUsingUCT(List<Node> moves)
        {


            return null;
        }



    }
}
