using CardEngine;
using FreezeFrame;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Players
{
    //https://jeffbradberry.com/posts/2015/09/intro-to-monte-carlo-tree-search/ // ADD OTHER PAPER
    public class ISMCTSPlayer : AIPlayer
    {
        public Dictionary<Tuple<CardGame, int>, int> plays;
        public Dictionary<Tuple<CardGame, int>, double> wins;
        public Dictionary<Tuple<CardGame, int>, Tuple<CardGame, int>[]> movestatetree;
        private CardGame privategame;
        private GameIterator privateiterator;
        private int playeridx;
        private static int NUMTESTS = 5; //previously 20

        public ISMCTSPlayer(Perspective perspective) : base(perspective)
        {
            playeridx = perspective.GetIdx();
            plays = new Dictionary<Tuple<CardGame, int>, int>(new InfoSetComparison(playeridx));
            wins = new Dictionary<Tuple<CardGame, int>, double>(new InfoSetComparison(playeridx));
            movestatetree = new Dictionary<Tuple<CardGame, int>, Tuple<CardGame, int>[]>(new InfoSetComparison(playeridx));
        }


        public override int MakeAction(int numChoices)
        {
            // GAME SIMULATIONS TEST

            int myidx = perspective.GetIdx();
            int deals = 3;
            // TEST ()
            /*(privategame, privateiterator) = perspective.GetPrivateGame();
            plays.Add(new Tuple<CardGame, int>(privategame, myidx), 1);
            CardGame infotest = privategame.CloneSecret(myidx);
            
            if (infotest.Equals(privategame))
            { Console.WriteLine("?"); }
            if (plays.ContainsKey(new Tuple<CardGame, int>(infotest, myidx)))
            {
                plays[new Tuple<CardGame, int>(infotest, myidx)] += 1;
                Console.WriteLine(infotest.ToString());
                Console.WriteLine(privategame.ToString());
            }
            else
            {
                foreach (Tuple<CardGame, int> k in plays.Keys)
                {
                    Console.WriteLine(k.Item2);
                    Console.WriteLine(k.Item2.ToString());
                }
            }
            Console.ReadLine();
            Environment.Exit(0);*/

            for (int d = 1; d <= deals; d++)
            {
                (privategame, privateiterator) = perspective.GetPrivateGame();
                //Console.WriteLine("Deal: " + d + " Play Count: " + plays.Count + "\r\n");
                for (int i = 0; i < NUMTESTS * numChoices; i++)
                {
                    RunSimulation();
                }
                Console.WriteLine("Deal: " + d + " Play Count: " + plays.Count + "\r\n");
            }
            //Console.WriteLine("Game after: " + cardGamesx[0]);

            //int j = 0;
            //foreach(var k in plays.Keys)
            //{
            //Console.WriteLine(j + " --> " + plays[k] + " --> " + wins[k]);
            //     j++;
            // }

            double[] moverankingarray = new double[numChoices];
            Tuple<CardGame, int>[] movestates = movestatetree[new Tuple<CardGame, int>(privategame, myidx)];
            for (int x = 0; x < numChoices; x++)
            {

                if (movestates[x] != null)
                {
                    Tuple<CardGame, int> stateandplayer = movestates[x];
                    Console.WriteLine("Choice " + x + ":\t" + "Plays: " + plays[stateandplayer] + " Wins: " + wins[stateandplayer]);
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

            // Which equality should this use?
            HashSet<Tuple<CardGame, int>> visitedstates = new HashSet<Tuple<CardGame, int>>(new InfoSetComparison(playeridx));
            CardGame cg = privategame.Clone();
            GameIterator gameIterator = privateiterator.Clone(cg);
            for (int j = 0; j < numPlayers; j++)
            {
                cg.players[j].decision = new RandomPlayer(perspective);
            }


            bool expand = true;

            // "Playing a simulated game"
            while (!gameIterator.AdvanceToChoice())
            {

                int idx = cg.currentPlayer.Peek().idx;

                Tuple<CardGame, int>[] movelist = null;
                int c = 0;

                if (expand && idx == playeridx)
                {
                    List<GameActionCollection> allOptions = gameIterator.BuildOptions();
                    int choicenum = allOptions.Count;
                  
                    Tuple<CardGame, int> deliberator = Tuple.Create<CardGame, int>(cg.Clone(), idx);

                    if (!movestatetree.ContainsKey(deliberator))
                    {
                        movestatetree[deliberator] = new Tuple<CardGame, int>[choicenum];
                    }
                    else if (movestatetree[deliberator].Length != choicenum)
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

                // Stateandplayer is Tuple with state after move, and the idx of the player who made the move
                Tuple<CardGame, int> stateandplayer = Tuple.Create<CardGame, int>(savestate, idx);

                // IF THIS IS THE FIRST SIMULATION WHICH HAS ARRIVED AT THIS STATE::
                if (expand && (!plays.Keys.Contains(stateandplayer)) && playeridx == idx)
                {
                    expand = false;
                    plays[stateandplayer] = 0;
                    wins[stateandplayer] = 0;
                    movelist[c] = stateandplayer;
                }
                visitedstates.Add(stateandplayer);
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


            //SOMETHING FAILING HERE

            foreach (Tuple<CardGame, int> stateandplayer in visitedstates)
            {
                if (plays.Keys.Contains(stateandplayer))
                {
                    plays[stateandplayer] += 1;
                    //Console.WriteLine(inverseRankSum.Length);
                    //Console.WriteLine(stateandplayer.Item2);
                    wins[stateandplayer] += inverseRankSum[stateandplayer.Item2];
                }

            }
        } 
    }
}


