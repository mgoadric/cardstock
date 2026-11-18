using CardStock.CardEngine;
using CardStock.FreezeFrame;
using CardStock.Evaluation;
using CardStock.FreezeFrame.Actions;

namespace CardStock.Players
{
    //https://jeffbradberry.com/posts/2015/09/intro-to-monte-carlo-tree-search/
    public class ISMCTSPlayer(Perspective perspective, DataCollector dc) : AIPlayer(perspective, dc)
    {
        private readonly Dictionary<Tuple<CardGame, int, int>, NodeStats> stats = new(new InfoSetComparison(perspective.GetIdx()));
        private readonly Dictionary<Tuple<CardGame, int, int>, Dictionary<string, NodeStats>> movestatetree = new(new InfoSetComparison(perspective.GetIdx()));
        private Dictionary<string, NodeStats> choiceStats;
        private List<string> allData;

        private double scoreMin = double.MaxValue;
        private double scoreMax = double.MinValue;

        public override void Explore(List<string> allData)
        {
            this.allData = allData;
            choiceStats = [];

            // GAME SIMULATIONS
            for (int i = 0; i < dc.exp.numTests; i++)
            {
                RunSimulation(i);
            }
        }

        public override int ChooseOption()
        {
            double[][] moveScores = new double[numPlayers][];
            double[][] moveRanks = new double[numPlayers][];
            double[][] moveWins = new double[numPlayers][];
            for (int i = 0; i < perspective.NumberOfPlayers(); i++)
            {
                moveScores[i] = new double[numChoices];
                moveRanks[i] = new double[numChoices];
                moveWins[i] = new double[numChoices];
            }        
            // FOR DEBUGGING    
            //int[] choiceplays = new int[numChoices];
            /*Console.WriteLine("Choices explored...");
            foreach (string s in choiceStats.Keys)
            {
                Console.WriteLine(s);
            }
            */

            for (int m = 0; m < numChoices; m++)
            {
                for (int i = 0; i < numPlayers; i++)
                {
                    // check for small sample numbers, some moves might be 0
                    if (choiceStats.TryGetValue(allData[m], out NodeStats? value))
                    {
                        moveScores[i][m] += value.scores[i] / value.plays;
                        moveRanks[i][m] += value.ranks[i] / value.plays;
                        moveWins[i][m] += value.wins[i] / value.plays;
                        //choiceplays[m] += choiceStats[m].plays;
                    }

                    //if (i == perspective.GetIdx())
                    //{
                    //    Console.WriteLine(det + "\t" + m + "\t" + choiceStats[det][m].plays + "\t" + choiceStats[det][m].scores[i] / choiceStats[det][m].plays);
                    //}
                }
            }

            var (_, max) = MinMaxIdx(moveWins[perspective.GetIdx()]);

            // FOR DEBUGGING
            //Console.WriteLine(perspective.GetIdx() + " choosing move " + max);
            //Console.WriteLine("{0}", string.Join(", ", moveScores[perspective.GetIdx()]));
            //Console.WriteLine("{0}", string.Join(", ", choiceplays));

            // Record info for heuristic evaluation
            dc.RecordHeuristics(moveScores, moveRanks, perspective.GetIdx());

            return max;
        }

        public void RunSimulation(int sim)
        {
            //Console.WriteLine("******Sim:" + sim);
            HashSet<Tuple<CardGame, int, int>> visitedstates = [];

            (CardGame cg, GameIterator gameIterator) = perspective.GetPrivateGame();
            cg.WipePlayers();

            bool expand = true;
            bool first = true;
            int previdx = -1;
            int depth = 0;
            Tuple<CardGame, int, int> parent = Tuple.Create(cg.Clone(), previdx, depth);

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
                    //Console.WriteLine("Expanding");
                    // Each turn, need to check to see if we have enough information to make a move using UCB
                    // If we do (movelist.count() == choicenum), and we check the stats of each move
                    (List<GameActionCollection> allOptions, List<string> gameActions) = gameIterator.BuildOptions();
                    int choicenum = allOptions.Count;
                    int actnum = gameActions.Count;
                    //Console.WriteLine("Number of GameActions is " + choicenum);
                    //Console.WriteLine("Number of GameActionStrings is " + actnum);
                    //foreach (string s in gameActions)
                    //{
                    //    Console.WriteLine(s);
                    //}

                    Dictionary<string, NodeStats>? moveDict; 
                    if (!movestatetree.TryGetValue(parent, out Dictionary<string, NodeStats>? value))
                    {
                        value = [];
                        movestatetree[parent] = value;
                    }
                    moveDict = value;

                    int idx = cg.currentPlayer.Peek().idx;

                    int choice = 0;
                    bool boop = true;
                    var children = movestatetree[parent];
                    if (gameActions.Count(children.ContainsKey) == choicenum)
                    {
                        // USE UCB
                        //Console.WriteLine("In UCB");
                        //double bestscore = int.MinValue;
                        double bestscore = 0;
                        double totalplays = depth == 0 ? sim + 1 : stats[parent].available;

                        totalplays = Math.Log(totalplays);
                        for (int i = 0; i < gameActions.Count; i++)
                        {
                            NodeStats child = children[gameActions[i]];  // How could this be null????
                            int n = child.plays;

                            // c parameter is the sqrt(2) 
                            // c changed to 1.0, easier math, James is happier
                            //double normscore = (child.scores[idx] / n - scoreMin) / (scoreMax - scoreMin);
                            double normscore = child.wins[idx] / n;
                            //Console.WriteLine(normscore);
                            double temp = normscore + Math.Sqrt(totalplays / n); // Used to be 2 * for the sqrt(2) part
                            // old method with raw scores -> no exploration!!
                            //double temp = child.scores[idx] / n + Math.Sqrt(2 * totalplays / n);

                            // does this still work if recording score, not 1--0 win record?
                            if (temp > bestscore)
                            {
                                bestscore = temp;
                                choice = i;
                            }
                            child.available++;
                        }
                        allOptions[choice].ExecuteAll();
                        gameIterator.PopCurrentNode();
                    }
                    else
                    {
                        //Console.WriteLine("Making a random choice!");
                        choice = gameIterator.ProcessChoice();
                        boop = false;
                    }

                    // Chosen is Tuple with state after move, and the idx of the player who made the move
                    CardGame savestate = gameIterator.game.Clone();
                    depth++;
                    Tuple<CardGame, int, int> chosen = Tuple.Create(savestate, idx, depth);
                    previdx = idx;
                    var oldparent = parent;
                    parent = chosen;

                    visitedstates.Add(chosen);

                    // IF THIS IS THE FIRST SIMULATION WHICH HAS ARRIVED AT THIS STATE
                    if (!stats.ContainsKey(chosen))
                    {
                        if (choice >= gameActions.Count)
                        {
                            Console.WriteLine("AUGH! Random is " + boop + ", Choice is " + choice + ", numMoves is " + gameActions.Count);
                        }
                        expand = false;
                        NodeStats cstats = new(numPlayers);
                        stats[chosen] = cstats;
                        moveDict[gameActions[choice]] = cstats;
                    }

                    // IF AT THE ROOT
                    if (first)
                    {
                        choiceStats[gameActions[choice]] = stats[chosen];
                        //Console.WriteLine("chosing " + choice + ", explored=" + choiceStats.Count);
                        first = false;
                    }
                }
                else { gameIterator.ProcessChoice(); }
            }

            // ProcessScore returns the score for each player and a mult for min/max games
            var results = gameIterator.ProcessScore();
            var mult = gameIterator.ProcessDirection();
            int[,] ranks = DataCollector.FindRanks(results, mult);

            // GO THROUGH VISITED STATES
            foreach (Tuple<CardGame, int, int> stateandplayer in visitedstates)
            {
                NodeStats node = stats[stateandplayer];
                node.plays += 1;
                for (int j = 0; j < numPlayers; j++)
                {
                    node.ranks[j] += ranks[j, 0];
                    node.scores[j] += results[j] * mult;
                    node.wins[j] += ranks[j, 0] == 0 ? 1 : 0;
                }
            }

            for (int j = 0; j < numPlayers; j++)
            {
                scoreMin = double.Min(scoreMin, results[j] * mult);
                scoreMax = double.Max(scoreMax, results[j] * mult);
            }
            //Console.WriteLine(scoreMin + " -- " + scoreMax);
        }
    }
}