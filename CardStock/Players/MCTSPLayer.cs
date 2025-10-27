using CardStock.CardEngine;
using CardStock.FreezeFrame;
using CardStock.Evaluation;
using CardStock.FreezeFrame.Actions;

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
        private readonly Dictionary<Tuple<CardGame, int>, NodeStats>[] stats = new Dictionary<Tuple<CardGame, int>, NodeStats>[GameSimulator.NUMSAMPLES];
        private readonly Dictionary<Tuple<CardGame, int>, NodeStats[]>[] movestatetree = new Dictionary<Tuple<CardGame, int>, NodeStats[]>[GameSimulator.NUMSAMPLES];
        private readonly Tuple<CardGame, GameIterator>[] determinizations = new Tuple<CardGame, GameIterator>[GameSimulator.NUMSAMPLES];
        private readonly NodeStats[][] choiceStats = new NodeStats[GameSimulator.NUMSAMPLES][];

        public override void Explore()
        {
            // MAKE THIS MANY DETERMINIZATIONS
            for (int det = 0; det < GameSimulator.NUMSAMPLES; det++)
            {
                determinizations[det] = perspective.GetPrivateGame();
                stats[det] = [];
                movestatetree[det] = [];
                choiceStats[det] = new NodeStats[numChoices];
            }

            // GAME SIMULATIONS
            Parallel.For(0, GameSimulator.NUMSAMPLES, det =>
            {
                for (int i = 0; i < GameSimulator.NUMTESTS / GameSimulator.NUMSAMPLES * numChoices; i++)
                {
                    RunSimulation(det, i);
                }
            });
        }

        public override int ChooseOption()
        {

            double[] movescores = new double[numChoices];
            int[] choiceplays = new int[numChoices];

            for (int m = 0; m < numChoices; m++)
            {
                for (int det = 0; det < GameSimulator.NUMSAMPLES; det++)
                {
                    // check for small sample numbers, some moves might be 0
                    if (choiceStats[det][m] is not null)
                    {
                        movescores[m] += choiceStats[det][m].wins / choiceStats[det][m].plays;
                        choiceplays[m] += choiceStats[det][m].plays;
                    }
                }
                movescores[m] /= GameSimulator.NUMSAMPLES;
            }

            var (min, max) = MinMaxIdx(movescores);

            // TODO THIS IS MISSING LEAD HISTORY RECORDING!!
            // Record info for heuristic evaluation
            //RecordHeuristics(rankSum);
            Console.WriteLine(perspective.GetIdx() + " choosing move " + max);
            Console.WriteLine("{0}", string.Join(", ", movescores));
            Console.WriteLine("{0}", string.Join(", ", choiceplays));

            return max;
        }

        public void RunSimulation(int det, int sim)
        {
            HashSet<Tuple<CardGame, int>> visitedstates = [];

            CardGame cg = determinizations[det].Item1.Clone();
            GameIterator gameIterator = determinizations[det].Item2.Clone(cg);
            for (int j = 0; j < numPlayers; j++)
            {
                cg.players[j].decision = null;
            }

            bool expand = true;
            bool first = true;
            int previdx = -1;
            Tuple<CardGame, int> parent = Tuple.Create(cg.Clone(), previdx);

            int depth = 0;

            // "Playing a simulated game"
            while (!gameIterator.AdvanceToChoice())
            {
                // Should be loop that stops when you hit GameSimulator.CHOICELIMIT
                if (depth > GameSimulator.CHOICELIMIT)
                {
                    break;
                }
                
                if (expand)
                {
                    // Each turn, need to check to see if we have enough information to make a move using UCB
                    // If we do (movelist.count() == choicenum), and we check the stats of each move
                    List<GameActionCollection> allOptions = gameIterator.BuildOptions();
                    int choicenum = allOptions.Count;

                    NodeStats[]? movelist = null;
                    if (!movestatetree[det].TryGetValue(parent, out NodeStats[]? value))
                    {
                        value = new NodeStats[choicenum];
                        movestatetree[det][parent] = value;
                    }
                    movelist = value;

                    int idx = cg.currentPlayer.Peek().idx;

                    int choice = 0;
                    if (movelist.Count(s => s is not null) == choicenum)
                    {
                        // USE UCB
                        double bestscore = int.MinValue;
                        double totalplays = depth == 0 ? sim + 1 : stats[det][parent].plays;

                        totalplays = Math.Log(totalplays);
                        for (int i = 0; i < movelist.Length; i++)
                        {
                            NodeStats child = movelist[i];
                            int n = child.plays;

                            // c parameter is the sqrt(2) part
                            double temp = (child.wins / n) + Math.Sqrt(2 * totalplays / n);

                            // does this still work if recording score, not 1--0 win record?
                            if (temp > bestscore)
                            {
                                bestscore = temp;
                                choice = i;
                            }
                        }
                        allOptions[choice].ExecuteAll();
                        gameIterator.PopCurrentNode();
                    }
                    else
                    {
                        choice = gameIterator.ProcessChoice();
                    }

                    // Chosen is Tuple with state after move, and the idx of the player who made the move
                    CardGame savestate = gameIterator.game.Clone();
                    Tuple<CardGame, int> chosen = Tuple.Create(savestate, idx);
                    previdx = idx;
                    parent = chosen;
                    depth++;

                    visitedstates.Add(chosen);

                    // IF THIS IS THE FIRST SIMULATION WHICH HAS ARRIVED AT THIS STATE
                    if (!stats[det].ContainsKey(chosen))
                    {
                        expand = false;
                        NodeStats cstats = new();
                        stats[det][chosen] = cstats;
                        movelist[choice] = cstats;
                    }

                    // IF AT THE ROOT
                    if (first)
                    {
                        choiceStats[det][choice] = stats[det][chosen];
                        first = false;
                    }
                }
                else { gameIterator.ProcessChoice(); }
            }

            // ProcessScore returns the score for each player and a mult for min/max games
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
                        node.wins += results[j] * mult;//inverseRankSum[stateandplayer.Item2];
                    }
                }
            }
        }
    }
}