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
            for (int i = 0; i < perspective.NumberOfPlayers(); i++)
            {
                moveScores[i] = new double[numChoices];
                moveRanks[i] = new double[numChoices];
            }        
            // FOR DEBUGGING    
            //int[] choiceplays = new int[numChoices];

            for (int m = 0; m < numChoices; m++)
            {
                for (int i = 0; i < numPlayers; i++)
                {
                    // check for small sample numbers, some moves might be 0
                    if (choiceStats[allData[m]] is not null)
                    {
                        moveScores[i][m] += choiceStats[allData[m]].scores[i] / choiceStats[allData[m]].plays;
                        moveRanks[i][m] += choiceStats[allData[m]].ranks[i] / choiceStats[allData[m]].plays;
                        //choiceplays[m] += choiceStats[m].plays;
                    }

                    //if (i == perspective.GetIdx())
                    //{
                    //    Console.WriteLine(det + "\t" + m + "\t" + choiceStats[det][m].plays + "\t" + choiceStats[det][m].scores[i] / choiceStats[det][m].plays);
                    //}
                }
            }

            var (_, max) = MinMaxIdx(moveScores[perspective.GetIdx()]);

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
            HashSet<Tuple<CardGame, int, int>> visitedstates = new(new InfoSetComparison(perspective.GetIdx()));
 
            bool expand = true;
            bool first = true;
            int previdx = -1;
            int depth = 0;

            // Determinization
            (CardGame cg, GameIterator gameIterator) = perspective.GetPrivateGame();
            cg.WipePlayers();           
            Tuple<CardGame, int, int> current = Tuple.Create(cg.Clone(), previdx, depth);
            int idx = cg.currentPlayer.Peek().idx;

            // Selection
            bool descend = true;
            bool terminal = false;
            while (descend)
            {
                if (!stats.ContainsKey(current))
                {
                    descend = false;
                } 
                else 
                {
                    terminal = gameIterator.AdvanceToChoice();
                    if (terminal)
                    {
                        descend = false;
                    } else
                    {
                        // Find the next by UCB...
                        (List<GameActionCollection> allOptions, List<string> localData) = gameIterator.BuildOptions();
                        
                        bool UCBtime = true;
                        var children = movestatetree[current];
                        foreach (string action in localData)
                        {
                            if (!children.ContainsKey(action))
                            {
                                UCBtime = false;
                            }
                        }

                        if (UCBtime)
                        {
                            
                        } else
                        {
                            // RANDOM CHOICE
                        }

                        Tuple<CardGame, int, int> chosen = Tuple.Create(savestate, idx, depth);
                        current = chosen;
                    }
                }
            }

            // Expansion
            if (!terminal)
            {
                (List<GameActionCollection> allOptions, List<string> localData) = gameIterator.BuildOptions();
                int choice = ThreadSafeRandom.Next(0, allOptions.Count);
                allOptions[choice].ExecuteAll();
                gameIterator.PopCurrentNode();

                CardGame savestate = gameIterator.game.Clone();
                depth++;
                Tuple<CardGame, int, int> chosen = Tuple.Create(savestate, idx, depth);

                NodeStats cstats = new(numPlayers);
                stats[chosen] = cstats;
            }

            // Simulation RUN TO THE END
            while (!terminal && !gameIterator.AdvanceToChoice())
            {
                // Stops when you hit GameSimulator.CHOICELIMIT
                if (depth > GameSimulator.CHOICELIMIT)
                {
                    break;
                }
                gameIterator.ProcessChoice(); 
            }


            // "Playing a simulated game"
            while (!gameIterator.AdvanceToChoice())
            {
                // Stops when you hit GameSimulator.CHOICELIMIT
                if (depth > GameSimulator.CHOICELIMIT)
                {
                    break;
                }
                
                if (expand)
                {
                    (List<GameActionCollection> allOptions, List<string> localData) = gameIterator.BuildOptions();

                    Dictionary<string, NodeStats>? moveDict;
                    if (!movestatetree.TryGetValue(parent, out Dictionary<string, NodeStats>? value))
                    {
                        value = [];
                        movestatetree[parent] = value;
                    }
                    moveDict = value;

                    int idx = cg.currentPlayer.Peek().idx;
                    int choice = 0;


                        // USE UCB 
                        double bestscore = int.MinValue;
                        // TODO NEED TO USE AVAILABLE INSTEAD OF PARENT PLAYS???
                        double totalplays = depth == 0 ? sim + 1 : stats[parent].available;

                        totalplays = Math.Log(totalplays);
                        for (int i = 0; i < localData.Count; i++)
                        {
                            NodeStats child = moveDict[localData[i]]; 
                            int n = child.plays;

                            // c parameter is the sqrt(2) part
                            double normscore = (child.scores[idx] / n - scoreMin) / (scoreMax - scoreMin);
                            double temp = normscore + Math.Sqrt(totalplays / n); // Used to be 2 * for the sqrt(2) part

                            // does this still work if recording score, not 1--0 win record?
                            if (temp > bestscore)
                            {
                                bestscore = temp;
                                choice = i;
                            }
                        }
                        allOptions[choice].ExecuteAll();
                        gameIterator.PopCurrentNode();
                    

                    // Chosen is Tuple with state after move, and the idx of the player who made the move
                    CardGame savestate = gameIterator.game.Clone();
                    depth++;
                    Tuple<CardGame, int, int> chosen = Tuple.Create(savestate, idx, depth);
                    parent = chosen;

                    visitedstates.Add(chosen);

                    // IF THIS IS THE FIRST SIMULATION WHICH HAS ARRIVED AT THIS STATE
                    if (!stats.ContainsKey(chosen))
                    {
                        expand = false;
                        NodeStats cstats = new(numPlayers);
                        stats[chosen] = cstats;
                        moveDict[allData[choice]] = cstats;
                    }

                    // IF AT THE ROOT
                    if (first)
                    {
                        choiceStats[allData[choice]] = stats[chosen];
                        first = false;
                    }
                }

                // Simulation
                else { gameIterator.ProcessChoice(); }
            }





            // ProcessScore returns the score for each player and a mult for min/max games
            var results = gameIterator.ProcessScore();
            var mult = gameIterator.ProcessDirection();
            int[,] ranks = DataCollector.FindRanks(results, mult);

            // Backpropagation GO THROUGH VISITED STATES
            foreach (Tuple<CardGame, int, int> stateandplayer in visitedstates)
            {
                NodeStats node = stats[stateandplayer];
                node.plays += 1;
                // TODO Record availability for siblings???
                // or do that when we are selecting??
                for (int j = 0; j < numPlayers; j++)
                {
                    node.ranks[j] += ranks[j, 0];
                    node.scores[j] += results[j] * mult;
                }
            }

            for (int j = 0; j < numPlayers; j++)
            {
                scoreMin = double.Min(scoreMin, results[j] * mult);
                scoreMax = double.Max(scoreMax, results[j] * mult);
            }
        }
    }
}