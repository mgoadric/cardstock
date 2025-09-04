using System.Diagnostics;
using CardStock.CardEngine;
using CardStock.FreezeFrame;
using CardStock.Evaluation;

namespace CardStock.Players
{
    //https://jeffbradberry.com/posts/2015/09/intro-to-monte-carlo-tree-search/
    public class MCTSPLayer(Perspective perspective) : AIPlayer(perspective)
    {
        public Dictionary<Tuple<CardGame, int>, int> plays = []; 
        public Dictionary<Tuple<CardGame, int>, double> wins = [];
        public Dictionary<Tuple<CardGame, int>, Tuple<CardGame, int>[]> movestatetree = [];
        private CardGame privategame;
        private GameIterator privateiterator;

        public double[] choiceplays;
        public double[] movescores;

        public override void Explore()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            choiceplays = new double[numChoices];
            movescores = new double[numChoices];

            // GAME SIMULATIONS
            for (int det = 0; det < GameSimulator.NUMSAMPLES; det++)
            {
                (privategame, privateiterator) = perspective.GetPrivateGame();
                for (int i = 0; i < GameSimulator.NUMTESTS / GameSimulator.NUMSAMPLES * numChoices; i++)
                {
                    RunSimulation();
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds);
        }

        public override int ChooseOption()
        {

            for (int m = 0; m < numChoices; m++)
            {
                movescores[m] /= choiceplays[m];
            }

            var (min, max) = MinMaxIdx(movescores);

            // TODO THIS IS MISSING LEAD HISTORY RECORDING!!
            // Record info for heuristic evaluation
            //RecordHeuristics(rankSum);
            Console.WriteLine(perspective.GetIdx() + " choosing move " + max);
            Console.WriteLine("{0}", string.Join(", ", movescores));

            return max;
        }

        public void RunSimulation()
        {
            // Each turn, need to check to see if we have enough information to make move using UCB
            // If we do (movelist.count() == choicenum), and we check the stats of each move
            // A predictable player is set for the currentplayers idx which wil chose the move determined by 
            // Movelist should be tuple array with each entry a state and a who played it
            // Its key should be a state and the idx of the player in charge

            HashSet<Tuple<CardGame, int>> visitedstates = [];

            CardGame cg = privategame.Clone();
            GameIterator gameIterator = privateiterator.Clone(cg);
            for (int j = 0; j < numPlayers; j++)
            {
                cg.players[j].decision = new RandomPlayer(perspective);
            }


            bool expand = true;
            bool first = true;
            Tuple<CardGame, int> og = null;
            int om = -1;
            
            // "Playing a simulated game"
            // Should be loop that stops when you hit GameSimulator.CHOICELIMIT
            while (!gameIterator.AdvanceToChoice())
            {
                if (expand)
                {
                    List<GameActionCollection> allOptions = gameIterator.BuildOptions();
                    int idx = cg.currentPlayer.Peek().idx;
                    Tuple<CardGame, int>[] movelist = null;
                    int c = 0;

                    int choicenum = allOptions.Count;
                    Tuple<CardGame, int> deliberator = Tuple.Create(cg.Clone(), idx);

                    if (!movestatetree.ContainsKey(deliberator))
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
                        foreach (Tuple<CardGame, int> stateandplay in movelist)
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

                    CardGame savestate = gameIterator.game.Clone();

                    // Stateandplayer is Tuple with state after move, and the idx of the player who made the move
                    Tuple<CardGame, int> stateandplayer = Tuple.Create<CardGame, int>(savestate, idx);

                    visitedstates.Add(stateandplayer);

                    // IF THIS IS THE FIRST SIMULATION WHICH HAS ARRIVED AT THIS STATE::
                    if (!plays.ContainsKey(stateandplayer))
                    {
                        expand = false;
                        plays[stateandplayer] = 0;
                        wins[stateandplayer] = 0;
                        movelist[c] = stateandplayer;
                    }
                    if (first)
                    {
                        choiceplays[c]++;
                        om = c;
                        og = stateandplayer;
                        first = false;
                    }
                }
                else { gameIterator.ProcessChoice(); }
            }

            // ProcessScore returns a sorted list 
            // where the winner is rank 0 for either min/max games.
            var (winners, mult) = gameIterator.ProcessScore();

            // GO THROUGH VISITED STATES
            foreach (Tuple<CardGame, int> stateandplayer in visitedstates)
            {
                plays[stateandplayer] += 1;
                for (int j = 0; j < numPlayers; j++)
                {
                    if (winners[j].Item2 == stateandplayer.Item2)
                    {
                        wins[stateandplayer] += (double)winners[j].Item1 * mult;//inverseRankSum[stateandplayer.Item2];
                        if (stateandplayer.Equals(og))
                        {
                            movescores[om] += winners[j].Item1 * mult;
                            //Console.WriteLine(movescores[om]);
                        }                    }
                }
            }
        }
    }
}