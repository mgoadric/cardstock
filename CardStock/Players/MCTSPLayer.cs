using CardStock.CardEngine;
using CardStock.FreezeFrame;
using CardStock.Evaluation;

namespace CardStock.Players
{
    public record NodeStats
    {
        public int plays;
        public double wins;
    }

    //https://jeffbradberry.com/posts/2015/09/intro-to-monte-carlo-tree-search/
    public class MCTSPLayer(Perspective perspective) : AIPlayer(perspective)
    {
        public Dictionary<Tuple<CardGame, int>, NodeStats>[] stats = new Dictionary<Tuple<CardGame, int>, NodeStats>[GameSimulator.NUMSAMPLES];
        public Dictionary<Tuple<CardGame, int>, Tuple<CardGame, int>[]>[] movestatetree = new Dictionary<Tuple<CardGame, int>, Tuple<CardGame, int>[]>[GameSimulator.NUMSAMPLES];

        private readonly Tuple<CardGame, GameIterator>[] determinizations = new Tuple<CardGame, GameIterator>[GameSimulator.NUMSAMPLES];


        public double[] choiceplays;
        public double[] movescores;

        public override void Explore()
        {
            choiceplays = new double[numChoices];
            movescores = new double[numChoices];

            // MAKE THIS MANY DETERMINIZATIONS
            for (int det = 0; det < GameSimulator.NUMSAMPLES; det++)
            {
                determinizations[det] = perspective.GetPrivateGame();
                stats[det] = [];
                movestatetree[det] = [];
            }

            // GAME SIMULATIONS
            // TODO can we do these in parallel?? Need to store the privategame, privateiterators like in PIPMC
            Parallel.For(0, GameSimulator.NUMSAMPLES, det =>
            {
                for (int i = 0; i < GameSimulator.NUMTESTS / GameSimulator.NUMSAMPLES * numChoices; i++)
                {
                    RunSimulation(det);
                }
            });
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
            //Console.WriteLine(perspective.GetIdx() + " choosing move " + max);
            //Console.WriteLine("{0}", string.Join(", ", movescores));
            //Console.WriteLine("{0}", string.Join(", ", choiceplays));

            return max;
        }

        public void RunSimulation(int det)
        {
            // Each turn, need to check to see if we have enough information to make move using UCB
            // If we do (movelist.count() == choicenum), and we check the stats of each move
            // A predictable player is set for the currentplayers idx which wil chose the move determined by 
            // Movelist should be tuple array with each entry a state and a who played it
            // Its key should be a state and the idx of the player in charge

            HashSet<Tuple<CardGame, int>> visitedstates = [];

            CardGame cg = determinizations[det].Item1.Clone();
            GameIterator gameIterator = determinizations[det].Item2.Clone(cg);
            for (int j = 0; j < numPlayers; j++)
            {
                cg.players[j].decision = null;
            }

            bool expand = true;
            bool first = true;
            Tuple<CardGame, int> og = null;
            int om = -1;
            int previdx = -1;
            Tuple<CardGame, int> parent = Tuple.Create(cg.Clone(), previdx);
            NodeStats nodeState = new NodeStats();
            if (!stats[det].ContainsKey(parent))
            {
                stats[det][parent] = new NodeStats();
            }
            visitedstates.Add(parent);
            int depth = 0;

            // "Playing a simulated game"
            // Should be loop that stops when you hit GameSimulator.CHOICELIMIT
            while (!gameIterator.AdvanceToChoice())
            {
                if (expand)
                {
                    List<GameActionCollection> allOptions = gameIterator.BuildOptions();
                    Tuple<CardGame, int>[] movelist = null;
                    int c = 0;

                    int choicenum = allOptions.Count;

                    if (!movestatetree[det].ContainsKey(parent))
                    {
                        movestatetree[det][parent] = new Tuple<CardGame, int>[choicenum];
                    }
                    movelist = movestatetree[det][parent];

                    int idx = cg.currentPlayer.Peek().idx;

                    if (movelist.Count(s => s != null) == choicenum)
                    {
                        // USE UCB
                        double bestscore = 0;
                        c = 0;
                        double totalplays = 0;
                        // CAN WE USE DELIBERATOR HERE AND AVOID THE FOR LOOP??? TODO
                        foreach (Tuple<CardGame, int> child in movelist)
                        {
                            totalplays += stats[det][child].plays;
                        }
                        Console.WriteLine(depth + ":" + totalplays + "," + stats[det][parent].plays);
                        totalplays = Math.Log(totalplays);
                        for (int i = 0; i < movelist.Length; i++)
                        {
                            Tuple<CardGame, int> child = movelist[i];
                            NodeStats node = stats[det][child];
                            int n = node.plays;
                            double temp = node.wins / n;
                            // should there be a c parameter?
                            // does this still work if recording score, not 1--0 win record?
                            temp += Math.Sqrt(2 * totalplays / n);
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

                    // Stateandplayer is Tuple with state after move, and the idx of the player who made the move
                    CardGame savestate = gameIterator.game.Clone();
                    Tuple<CardGame, int> chosen = Tuple.Create(savestate, idx);
                    previdx = idx;
                    parent = chosen;
                    depth++;

                    visitedstates.Add(chosen);

                    // IF THIS IS THE FIRST SIMULATION WHICH HAS ARRIVED AT THIS STATE::
                    if (!stats[det].ContainsKey(chosen))
                    {
                        expand = false;
                        stats[det][chosen] = new NodeStats();
                        movelist[c] = chosen;
                    }
                    if (first)
                    {
                        choiceplays[c]++;
                        om = c;
                        og = chosen;
                        first = false;
                    }
                }
                else { gameIterator.ProcessChoice(); }
            }

            // ProcessScore returns a sorted list 
            // where the winner is rank 0 for either min/max games.
            var (results, mult) = gameIterator.ProcessScore();

            // GO THROUGH VISITED STATES
            foreach (Tuple<CardGame, int> stateandplayer in visitedstates)
            {
                NodeStats node = stats[det][stateandplayer];
                node.plays += 1;
                for (int j = 0; j < numPlayers; j++)
                {
                    if (j == stateandplayer.Item2)
                    {
                        node.wins += (double)results[j] * mult;//inverseRankSum[stateandplayer.Item2];
                        if (stateandplayer.Equals(og))
                        {
                            lock (this)
                            {
                                //Console.WriteLine("counting up");
                                //Console.WriteLine(node.plays + ", " + node.wins);

                                movescores[om] += results[j] * mult;
                            }
                            //Console.WriteLine(movescores[om]);
                        }
                    }
                }
            }
        }
    }
}