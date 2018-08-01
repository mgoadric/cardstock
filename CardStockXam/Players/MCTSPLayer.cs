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
    //https://jeffbradberry.com/posts/2015/09/intro-to-monte-carlo-tree-search/
    public class MCTSPLayer : AIPlayer
    {
        public Dictionary<Tuple<CardGame, int>, int> plays = new Dictionary<Tuple<CardGame, int>, int>();
        public Dictionary<Tuple<CardGame, int>, double> wins = new Dictionary<Tuple<CardGame, int>, double>();
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
            for (int i = 0; i < 100; i++)
            {
                RunSimulation();
            }
            //Console.WriteLine("Game after: " + cardGamesx[0]);

            int j = 0;
            foreach(var k in plays.Keys)
            {
                Console.WriteLine(j + " --> " + plays[k] + " --> " + wins[k]);
                j++;
            }

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
                {
                    expand = false;
                    plays[stateandplayer] = 0;
                    wins[stateandplayer] = 0;
                }
               
                visitedstates.Add(stateandplayer);
                idx = cg.currentPlayer.Peek().idx;
            }

            // ProcessScore returns a sorted list 
            // where the winner is rank 0 for either min/max games.
            var winners = gameIterator.ProcessScore(gameIterator.rules.scoring());
            double[] inverseRankSum = new double[numPlayers];

            int p = 0;
            foreach (Tuple<int, int> scoreandidx in winners)
            {
                inverseRankSum[scoreandidx.Item2] = ((double)1) / (p + 1);
                p++;   
            }
            // GO THROUGH VISITED STATES
            foreach (Tuple<CardGame, int> stateandplayer in visitedstates)
            {
                if (plays.Keys.Contains(stateandplayer))
                {
                    plays[stateandplayer] += 1;
                    wins[stateandplayer] += inverseRankSum[stateandplayer.Item2];
                }
            }
        }

        public Node SelectNodeUsingUCT(List<Node> moves)
        {


            return null;
        }



    }
}
