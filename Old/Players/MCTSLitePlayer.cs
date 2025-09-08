using CardEngine;
using FreezeFrame;
using Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStockXam.Players
{
    //https://jeffbradberry.com/posts/2015/09/intro-to-monte-carlo-tree-search/
    public class MCTSLitePLayer : AIPlayer
    {
        public Dictionary<Tuple<CardGame, int>, int> plays = new Dictionary<Tuple<CardGame, int>, int>();
        public Dictionary<Tuple<CardGame, int>, double> wins = new Dictionary<Tuple<CardGame, int>, double>();
        public Dictionary<int, CardGame> movestates = new Dictionary<int, CardGame>();
        public Dictionary<Tuple<CardGame, int>, Tuple<CardGame, int>[]> movestatetree = new Dictionary<Tuple<CardGame, int>, Tuple<CardGame, int>[]>();
        private CardGame privategame;
        private GameIterator privateiterator;
        public MCTSLitePLayer(Perspective perspective) : base(perspective) { }


        public override int MakeAction(int optioncount) //
        {
            // GAME SIMULATIONS TEST
            (CardGame privategame, GameIterator privateiterator) = perspective.GetPrivateGame();
            int myidx = perspective.GetIdx();
            movestates = new Dictionary<int, CardGame>();

            for (int i = 0; i < 10 * optioncount; i++)
            {
                RunSimulation();
            }
            //Console.WriteLine("Game after: " + cardGamesx[0]);

            int j = 0;
            foreach (var k in plays.Keys)
            {
                //Console.WriteLine(j + " --> " + plays[k] + " --> " + wins[k]);
                j++;
            }

            double[] moverankingarray = new double[optioncount];
            for (int x = 0; x < optioncount; x++)
            {
                if (movestates.Keys.Contains(x))
                {
                    Tuple<CardGame, int> stateandplayer = new Tuple<CardGame, int>(movestates[x], myidx);
                    moverankingarray[x] = wins[stateandplayer] / plays[stateandplayer];
                }
            }
            Tuple<int, int> worstandbest = MinMaxIdx(moverankingarray);

            return worstandbest.Item2;
        }

        public void RunSimulation()
        {
            // Each turn, need to check to see if we have enough information to make move using UCB
            // If we do (movelist.count() == choicenum), and we check the stats of each move
            // A predictable player is set for the currentplayers idx which wil chose the move determined by 
            // Movelist should be tuple array with each entry a state and a who played it
            // Its key should be a state and the idx of the player in charge

            HashSet<Tuple<CardGame, int>> visitedstates = new HashSet<Tuple<CardGame, int>>();
            CardGame cg = privategame.Clone();
            GameIterator gameIterator = privateiterator.Clone(cg);
            for (int j = 0; j < numPlayers; j++)
            {
                cg.players[j].decision = new RandomPlayer(perspective);
            }
            int idxme = cg.currentPlayer.Peek().idx;

            bool expand = true;
            bool first = true;

            // "Playing a simulated game"
            while (!gameIterator.AdvanceToChoice())
            {
                int idx = cg.currentPlayer.Peek().idx;
                if (idxme == idx)
                {
                    List<GameActionCollection> allOptions = gameIterator.BuildOptions();

                    Tuple<CardGame, int>[] movelist = null;
                    int c = 0;
                    if (expand)
                    {
                        int choicenum = allOptions.Count;
                        Tuple<CardGame, int> deliberator = Tuple.Create<CardGame, int>(cg.Clone(), idx);

                        if (!movestatetree.Keys.Contains(deliberator))
                        {
                            movestatetree[deliberator] = new Tuple<CardGame, int>[choicenum];
                        }
                        movelist = movestatetree[deliberator];

                        //Console.WriteLine("Choice num: " + choicenum + " Movelist Count: " + movelist.Count(s => s != null));
                        if (movelist.Count(s => s != null) == choicenum)
                        {
                            // USE UCB
                            double bestscore = 0;
                            c = 0;
                            double totalplays = 0;
                            foreach (Tuple<CardGame, int> stateandplay in (movelist))
                            {
                                totalplays += plays[stateandplay];
                            }
                            totalplays = Math.Log(totalplays);
                            for (int i = 0; i < movelist.Length; i++)
                            {
                                Tuple<CardGame, int> stateandplay = movelist[i];
                                double temp = wins[stateandplay] / plays[stateandplay];
                                temp += Math.Sqrt(2 * totalplays / plays[stateandplay]);
                                if (temp > bestscore)
                                {
                                    bestscore = temp;
                                    c = i;
                                }
                            }
                            allOptions[c].ExecuteAll();
                            gameIterator.PopCurrentNode();
                        }
                        else
                        {
                            c = gameIterator.ProcessChoice();
                        }
                    }
                    else { c = gameIterator.ProcessChoice(); }

                    CardGame savestate = gameIterator.game.Clone();
                    // THIS HELPS FIND ORIGINAL MOVE CHOICES
                    if (first)
                    {
                        if (!movestates.Keys.Contains(c))
                        { movestates[c] = savestate; }
                        first = false;
                    }
                    
                    // Stateandplayer is Tuple with state after move, and the idx of the player who made the move
                    Tuple<CardGame, int> stateandplayer = Tuple.Create<CardGame, int>(savestate, idx);

                    // IF THIS IS THE FIRST SIMULATION WHICH HAS ARRIVED AT THIS STATE::
                    if (expand && (!plays.Keys.Contains(stateandplayer)))
                    {
                        expand = false;
                        plays[stateandplayer] = 0;
                        wins[stateandplayer] = 0;
                        movelist[c] = stateandplayer;
                    }
                    visitedstates.Add(stateandplayer);
                }
                else { gameIterator.ProcessChoice(); } // IF IT ISNT MY MOVE, DONT KEEP ANY DATA
            }

            // ProcessScore returns a sorted list 
            // where the winner is rank 0 for either min/max games.
            var winners = gameIterator.ProcessScore();
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
    }
}
    



