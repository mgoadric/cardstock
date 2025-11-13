using Antlr4.Runtime.Tree;
using CardStock.CardEngine;
using CardStock.Evaluation;
using CardStock.FreezeFrame.Actions;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CardStock.FreezeFrame
{
    public class GameIterator
    {
        private readonly Stack<Queue<IParseTree>> iterStack;
        private HashSet<IParseTree> iteratingSet; // could this be a stack??
        private RecycleVariables variables;
        public readonly Logger script;

        public RecycleParser.GameContext rules;
        public CardGame game;
        public int totalChoices;
        public int run;

        public Experiment exp;

        public GameIterator(RecycleParser.GameContext context, CardGame mygame, string fileName, Experiment exp, bool fresh = true)
        {
            rules = context;
            game = mygame;
            iterStack = new Stack<Queue<IParseTree>>();
            iteratingSet = [];
            variables = new RecycleVariables();

            if (fresh)
            {
                if (exp.Logging)
                {
                    script = new Logger(fileName, exp);
                }

                Debug.WriteLine("Processing declarations.");
                foreach (RecycleParser.DeclareContext declare in rules.declare())
                {
                    ProcessDeclare(declare);
                }

                Debug.WriteLine("Setting up game.");
                ProcessSetup(rules.setup()).ExecuteAll();

                game.OptimizeCardSource();

                // Mixup the card ids ????
                game.ReindexCards();

                iterStack.Push(new Queue<IParseTree>());
                var topLevel = iterStack.Peek();
                for (int i = 3; i < rules.ChildCount - 2; ++i)
                {
                    topLevel.Enqueue(rules.GetChild(i));
                }
            }
        }

        public GameIterator Clone(CardGame newgame)
        {

            var ret = new GameIterator(rules, newgame, "clone", exp, false)
            {
                iteratingSet = [.. iteratingSet],
                variables = variables.Clone(newgame)
            };

            foreach (var queue in iterStack.Reverse())
            {
                ret.iterStack.Push(new Queue<IParseTree>(queue));
            }

            return ret;
        }

        public IParseTree CurrentNode()
        {
            var ret = iterStack.Peek().Peek();
            return ret;
        }

        public void PopCurrentNode()
        {
            iterStack.Peek().Dequeue();
            if (iterStack.Peek().Count == 0)
            {
                Debug.WriteLine("Popped current node");
                // TODO only popped here
                iterStack.Pop();
                //Console.WriteLine(iterStack.Peek());
                Debug.WriteLine(iterStack.Count);
            }
        }

        public bool AdvanceToChoice()
        {
            int count = 0;
            while (iterStack.Count != 0 && !ProcessSubStage())
            {
                count++;
                if (count > GameSimulator.LOOPLIMIT)
                {
                    Console.WriteLine("Game stuck in loop");
                    throw new Exception();
                    return true; // game stuck in loop
                }
            }
            if (iterStack.Count == 0)
            {
                return true; // game over
            }
            Debug.WriteLine(iterStack.Count);
            return false; // interupted by player decision
        }

        public int ProcessChoice()
        {
            script?.WriteToFile("???");
            var allOptions = BuildOptions();

            if (allOptions.Count == 0)
            {
                Console.WriteLine("NO Choice Available");
                throw new InvalidOperationException();
            }

            Debug.WriteLine("processed choices");
            Debug.WriteLine("Choice count for P" + game.CurrentPlayer().idx + ":" + allOptions.Count);
            int choice = game.PlayerMakeChoice(allOptions.Count, game.CurrentPlayer().idx);
            allOptions[choice].ExecuteAll();
            PopCurrentNode();
            totalChoices++;
            return choice;
        }

        public List<GameActionCollection> BuildOptions()
        {
            Debug.WriteLine("trying to process choice (in processchoice)");
            Debug.WriteLine("Player turn: " + game.CurrentPlayer().idx);
            var sub = CurrentNode();
            if (sub is RecycleParser.MultiactionContext choice)
            {
                var choices = choice.condact();
                var allOptions = new List<GameActionCollection>(16);
                for (int i = 0; i < choices.Length; i++)
                {
                    Debug.WriteLine("choice info: " + choices[i].GetType() + choices[i].GetText());
                    // PROBLEM! TODO when gets through for loop here without pushing any actions (specifically actions)
                    //  then throws off number of choices, indexing choices[1] becomes impossible. 
                    Debug.WriteLine("in for loop");
                    var gacs = RecurseDo(choices[i]);
                    if (gacs.Count > 0)
                    {
                        Debug.WriteLine("gacs.count > 0");
                        allOptions.AddRange(gacs);
                    }
                }
                return allOptions;
            }
            Console.WriteLine("Not a choice, why are we in BuildOptions???");
            throw new Exception();
        }

        public (int[] results, int mult) ProcessScore()
        {
            var results = new int[game.players.Length];
            var scoreMethod = rules.scoring();

            game.PushPlayer();
            game.CurrentPlayer().SetMember(0);
            for (int i = 0; i < results.Length; i++)
            {
                var score = ProcessInt(scoreMethod.@int());
                script?.WriteToFile("Q:" + i + " " + score);
                results[i] = score;
                game.CurrentPlayer().Next();
            }
            game.PopPlayer();

            int mult = 1;
            if (scoreMethod.GetChild(2).GetText() == "min")
            {
                mult = -1;
            }

            return (results, mult);
        }

        /************
         * GAME SETUP METHODS
         ************/
        private void ProcessDeclare(RecycleParser.DeclareContext declare)
        {
            variables.Put(declare.var().GetText(), ProcessTyped(declare.typed()));
        }

        private GameActionCollection ProcessSetup(RecycleParser.SetupContext setupNode)
        {
            var ret = new GameActionCollection();
            if (setupNode.playercreate() is not null)
            {
                Debug.WriteLine("Creating players.");
                var playerCreate = setupNode.playercreate() as RecycleParser.PlayercreateContext;
                if (playerCreate.@int() is not null)
                {
                    var numPlayers = ProcessInt(playerCreate.@int());
                    script?.WriteToFile("#:" + numPlayers);
                    game.AddPlayers(numPlayers, this);
                    script?.WriteToFile("T:" + game.currentPlayer.Peek().CurrentName());
                }
                else
                {
                    // Where is the int?
                    Console.WriteLine("Number of players not defined!!!");
                    throw new Exception();
                }
            }

            Debug.WriteLine("Creating teams.");
            var teamCreate = ProcessTeamCreate(setupNode.teamcreate(), game);
            ret.Add(new CreateTeamAction(teamCreate, game, script));

            if (setupNode.deckcreate() is not null)
            {
                Debug.WriteLine("Creating decks.");
                var decks = setupNode.deckcreate();
                foreach (var deckinit in decks)
                {
                    ret.Add(ProcessDeckCreate(deckinit));
                }
            }
            if (setupNode.repeat() is not null)
            {
                foreach (var rep in setupNode.repeat())
                {
                    if (CheckDeckRepeat(rep))
                    {
                        ret.AddRange(ProcessRepeat(rep));
                    }
                    else
                    {
                        Console.WriteLine("Invalid call to repeat for deck creation!!!");
                        throw new InvalidDataException();
                    }
                }
            }

            return ret;
        }
        private static List<List<int>> ProcessTeamCreate(RecycleParser.TeamcreateContext? teamcreate, CardGame cg)
        {
            var ret = new List<List<int>>();
            if (teamcreate is not null)
            {
                var numTeams = teamcreate.teams().Length;
                for (int i = 0; i < numTeams; i++)
                {
                    ret.Add([]);
                    foreach (var p in teamcreate.teams(i).INTNUM())
                    {
                        int t = int.Parse(p.GetText());
                        ret[i].Add(t);
                        //Console.WriteLine(t);
                    }
                }
            }
            else
            {
                var numTeams = cg.players.Length;
                for (int i = 0; i < numTeams; i++)
                {
                    ret.Add([i]);
                }
            }
            return ret;
        }

        private static bool CheckDeckRepeat(RecycleParser.RepeatContext reps)
        {
            if (reps.action().deckcreate() is not null)
            {
                return true;
            }
            else if (reps.action().repeat() is not null)
            {
                return CheckDeckRepeat(reps.action().repeat());
            }
            return false;
        }

        private CreateCardsAction ProcessDeckCreate(RecycleParser.DeckcreateContext deckinit)
        {
            var locstorage = ProcessLocation(deckinit.cstorage());
            var deckTree = ProcessDeck(deckinit.deck());
            if (deckinit.str() is null)
            {
                return new CreateCardsAction(locstorage.cardList, deckTree, "DEFAULT", game, script);
            }
            else
            {
                return new CreateCardsAction(locstorage.cardList, deckTree, ProcessString(deckinit.str()), game, script);
            }
        }

        /*********
         * STAGE AND ACTION METHODS
         **********/
        private bool ProcessSubStage()
        {
            Debug.WriteLine("Processing substage.");
            var sub = CurrentNode();
            if (sub.ChildCount > 1 && sub.GetChild(1).GetText() == "choice") { return true; }

            // Time to parse it
            else if (sub is RecycleParser.StageContext sc)
            {
                //EvalGameLead(); TODO
                var allowedToRun = ProcessStage(sc);
                if (allowedToRun)
                {
                    Debug.WriteLine("Is a stage.");
                    iteratingSet.Add(sub);
                }
            }
            else if (sub is RecycleParser.MultiactionContext mac)
            {
                PopCurrentNode();
                Debug.WriteLine("Is a multiaction.");
                ProcessMultiaction(mac);
            }
            else if (sub is RecycleParser.Multiaction2Context ma2c)
            {
                PopCurrentNode();
                Debug.WriteLine("Is a multiaction2.");
                ProcessMultiaction(ma2c);
            }
            //setup and declare already handled
            else if (sub is RecycleParser.SetupContext)
            {
                PopCurrentNode();
                //SetupIterator.ProcessSetup(sub as RecycleParser.SetupContext);
            }
            else if (sub is RecycleParser.DeclareContext)
            {
                PopCurrentNode();
            }
            else
            {
                Console.WriteLine(sub.GetType() + " is not a substage!!");
                throw new NotSupportedException();
            }
            return false;
        }

        private List<GameActionCollection> ProcessMultiaction(IParseTree sub)
        {
            var lst = new List<GameActionCollection>();

            if (sub is RecycleParser.MultiactionContext multiaction)
            {
                Debug.WriteLine(multiaction.GetType());
                if (multiaction.agg() is not null)
                {
                    Debug.WriteLine("Processing multiaction aggregation.");
                    lst.Add(ProcessAgg(multiaction.agg()));
                }
                else if (multiaction.let() is not null)
                {
                    Debug.WriteLine("Processing multiaction let statement.");
                    lst.AddRange(ProcessLet(multiaction.let()));
                }
                else if (multiaction.GetChild(1).GetText() == "choice")
                {
                    Console.WriteLine("Processing multiaction choice block in PROCESSMULTIACTION????.");
                    throw new NotImplementedException();
                    //ProcessSubChoice(multiaction.condact());
                }
                else if (multiaction.GetChild(1).GetText() == "do")
                {
                    Debug.WriteLine("Processing multiaction do statement.");
                    ProcessDo(multiaction.condact());
                }
            }
            else if (sub is RecycleParser.StageContext)
            {
                // NEVER HAPPENS, PROCESSED ELSEWHERE
                Debug.WriteLine("Processing stage.");
                //ProcessStage(sub as RecycleParser.StageContext);
            }
            else if (sub is RecycleParser.Multiaction2Context multi)
            {
                Debug.WriteLine("ur in processing multiaction2");
                if (multi.agg() is not null)
                {
                    Debug.WriteLine("Processing multiaction2 aggregation.");
                    lst.Add(ProcessAgg(multi.agg()));
                }
                else if (multi.let() is not null)
                {
                    Debug.WriteLine("Processing multiaction2 let statement.");
                    lst.AddRange(ProcessLet(multi.let()));
                }
                else
                {
                    Debug.WriteLine("Processing multiaction2 do statement.");
                    ProcessDo(multi.condact());
                }
            }
            else
            {
                Console.WriteLine("What is happening???");
            }
            Debug.WriteLine("Returning list of game actions.");
            return lst;
        }

        private List<GameActionCollection> RecurseDo(RecycleParser.CondactContext cond)
        {
            var all = new List<GameActionCollection>();
            // stack of iterating trees
            var stackTrees = new Stack<IteratingTree>(100);
            // iteratingtree = stack of iterable items (just has basic stack functionality) 
            //      -can store another iteratingtree, strings, or a key/value object
            //      -can copy
            var stackTree = new IteratingTree();
            // internal loop - where things are actually processed, not stored
            stackTree.Push(cond);
            // overarcing loop - stacktrees (another tree is created 
            //    for each ALTERNATIVE (any, etc) action
            //    so that all possible choices can be found
            stackTrees.Push(stackTree);
            var stackAct = new Stack<GameAction>(100);
            // iterate over stack of stacks
            while (stackTrees.Count != 0)
            {
                stackTree = stackTrees.Pop();
                Debug.WriteLine("Moving to next concurrent game tree");
                Debug.WriteLine("Number of concurrent game states: " + stackTrees.Count);
                // iterate over stack of iterable items
                while (stackTree.Count() != 0)
                {
                    var current = stackTree.Pop();
                    if (current.tree is not null)
                    {
                        var currentTree = current.tree;
                        if (currentTree is RecycleParser.CondactContext condact)
                        {
                            // if the boolean returns true (and exists), 
                            // push the resulting action/multiaction items
                            // on the current stack of iterable items
                            if (condact.boolean() is null || ProcessBoolean(condact.boolean()))
                            {
                                if (condact.action() is not null)
                                {
                                    stackTree.Push(condact.action());
                                }
                                if (condact.multiaction2() is not null)
                                {
                                    stackTree.Push(condact.multiaction2());
                                }
                            }
                        }

                        else if (currentTree is RecycleParser.Multiaction2Context multi2)
                        {
                            Debug.WriteLine("Finding game actions recursively in a multiaction2 statement.");

                            // is any or and
                            if (multi2.agg() is not null)
                            {
                                Debug.WriteLine("multiaction context 2 agg pushed to stack");
                                stackTree.Push(multi2.agg());
                            }
                            // is let 
                            else if (multi2.let() is not null)
                            {
                                stackTree.Push(multi2.let());
                            }
                            else
                            { // is do
                              // push all condacts onto current stack
                              // to be processed
                                var c = multi2.condact();
                                for (int i = c.Length - 1; i >= 0; i--)
                                {
                                    stackTree.Push(c[i]);
                                }
                            }
                        }
                        else if (currentTree is RecycleParser.MultiactionContext multi)
                        {
                            Debug.WriteLine("Finding game actions recursively in a multiaction.");
                            // terrible terrible ! someday TODO make this not copy paste
                            // included to allow multiactions after let statement 
                            // if rewritten (to be actually recursive etc etc)
                            // could streamline multi & multi2 to be the same thing
                            if (multi.agg() is not null)
                            {
                                stackTree.Push(multi.agg());
                            }
                            // is let 
                            else if (multi.let() is not null)
                            {
                                stackTree.Push(multi.let());
                            }
                            else
                            { // is do
                              // push all condacts onto current stack
                              // to be processed
                                var c = multi.condact();
                                for (int i = c.Length - 1; i >= 0; i--)
                                {
                                    Debug.WriteLine(c[i].GetType());
                                    stackTree.Push(c[i]);
                                }
                            }

                        }
                        else if (currentTree is RecycleParser.AggContext agg)
                        {
                            Debug.WriteLine("Finding game actions recursively in an aggregation statement.");

                            var collection = ProcessCollection(agg.collection());
                            if (agg.GetChild(1).GetText() == "any")
                            {
                                // if there is something in the collection
                                if (collection.ToList().Count > 0)
                                {
                                    bool first = true;
                                    object firstItem = collection.ToList()[0];
                                    var vartext = agg.var().GetText();
                                    // add collection of obj to current stack 
                                    stackTree.Push(currentTree.GetChild(4));

                                    foreach (object item in collection)
                                    {
                                        // for first item in collection only
                                        if (first)
                                        {
                                            firstItem = item;

                                            variables.Put(vartext, firstItem);
                                            first = false;
                                        }
                                        else
                                        {
                                            // push alternatives onto the stack
                                            // of game actions as 
                                            // an iterable item  
                                            //  (they are unexecutable as loop actions)
                                            // generate a copy of tree to use to
                                            //  process the results of choosing
                                            //  the next item in collection

                                            var newtree = stackTree.Copy();
                                            stackTrees.Push(newtree);
                                            Debug.WriteLine("pushed non-first any item: " + item);
                                            stackAct.Push(new LoopAction(vartext, item, newtree.level));
                                        }

                                    }
                                    // push first item to be processed (on current
                                    // Stack of game actions )
                                    Debug.WriteLine("pushed first any item: " + firstItem);
                                    stackTree.level++;
                                    stackAct.Push(new LoopAction(vartext, firstItem, stackTree.level));
                                }
                            }
                            else
                            { //all
                                // push
                                //      "'C" (string)
                                //      [contents of statement] (contained
                                //        in another stack tree)
                                //      "'C", iteritem (key, value)



                                foreach (object item in collection)
                                {
                                    stackTree.Push(agg.var().GetText());
                                    stackTree.Push(currentTree.GetChild(4));
                                    stackTree.Push(agg.var().GetText(), item);
                                }

                            }
                        }
                        else if (currentTree is RecycleParser.LetContext let)
                        {
                            // push name of var, statement after var, name/value pair
                            Debug.WriteLine("Finding game actions recursively in a let statement.");

                            var item = ProcessTyped(let.typed());
                            // old handling of let vars
                            /*stackTree.Push(let.var().GetText());
                            stackTree.Push(currentTree.GetChild(4));
                            stackTree.Push(let.var().GetText(), item);*/

                            Debug.WriteLine("pushed let context");
                            variables.Put(let.var().GetText(), item);
                            stackTree.Push(currentTree.GetChild(4));
                            stackTree.level++;
                            Debug.WriteLine("Pushing loop action" + item);
                            stackAct.Push(new LoopAction(let.var().GetText(), item, stackTree.level));
                        }
                        else if (currentTree is RecycleParser.ActionContext actcontext)
                        {
                            Debug.WriteLine("Finding game actions recursively in an action. ");

                            var actions = ProcessAction(actcontext);
                            foreach (GameAction action in actions)
                            {
                                // TODO where cycle actions are pushed 
                                Debug.WriteLine("pushed action" + action);
                                stackAct.Push(action);
                                action.TempExecute();
                            }
                        }
                        else
                        {
                            Console.WriteLine("failed to parse type " + current.GetType());
                            throw new Exception();
                        }
                    }
                    else
                    {//var context

                        if (current.item is not null)
                        {
                            Debug.WriteLine("Adding var in RecurseDo: " + current.varContext);

                            variables.Put(current.varContext, current.item);
                        }
                        else
                        {
                            variables.Remove(current.varContext);
                        }
                    }
                }
                // end of loop over current stack of iteritems
                var coll = new GameActionCollection();
                foreach (GameAction act in stackAct.ToArray())
                {
                    // add everythign but loop actions to coll
                    if (act is not LoopAction)
                    {
                        Debug.WriteLine(act);
                        Debug.WriteLine("Adding non-loop action to collection.");
                        coll.Add(act);
                    }
                }

                while (stackAct.Count > 0 && stackAct.Peek() is not LoopAction)
                {
                    var temp = stackAct.Pop();
                    Debug.WriteLine("Popping non-loop action off (first time)" + temp);
                    temp.Undo();
                }
                if (coll.Count > 0)
                {
                    // puts game action collection back in stack order 
                    // adds list of actions to overall choice list to be returned 
                    coll.Reverse();
                    all.Add(coll);
                    script?.WriteToFile("...");
                }

                // if there are still loopactions,
                //   remove the current one, 
                var currentLevel = 0;
                if (stackAct.Count > 0)
                {
                    if (stackAct.Pop() is LoopAction loop)
                    {
                        currentLevel = loop.level;
                        variables.Remove(loop.var);
                    }
                    else
                    {
                        // Should never happen??
                        Console.WriteLine("Expected a loop action here!!!");
                        throw new NotImplementedException();
                    }
                }
                // undo everything (until
                bool unwinding = true;
                while (unwinding)
                {
                    // "normal" - item before is loopaction & same level
                    // up one level - item before is loopaction & different level
                    // up one level - items need to be undone before finding loopaction, but is different level
                    // up n levels - 
                    while (stackAct.Count > 0 && stackAct.Peek() is not LoopAction)
                    {
                        Debug.WriteLine("popping off non-loop action (second time)" + stackAct.Peek());
                        stackAct.Pop().Undo();
                    }
                    if (stackAct.Count > 0)
                    {
                        if (stackAct.Peek() is LoopAction loop)
                        {

                            Debug.WriteLine("peek + add : " + loop.item);
                            if (loop.level == currentLevel)
                            {

                                variables.Put(loop.var, loop.item);
                                unwinding = false;
                            }
                            else
                            {
                                stackAct.Pop();
                                currentLevel = loop.level;
                            }
                        }
                        else
                        {
                            // Should never happen??
                            Console.WriteLine("Expected a loop action here!!!");
                            throw new NotImplementedException();
                        }
                    }
                    else
                    {
                        unwinding = false;
                    }
                }
            }
            return all;
        }

        //this just queues the appropriate actions if condition is met, doesn't execute
        private bool ProcessStage(RecycleParser.StageContext stage)
        {
            string text = stage.GetChild(2).GetText();
            if (stage.endcondition().boolean() is not null)
            {

                if (!iteratingSet.Contains(stage))
                {
                    switch (text)
                    {
                        case "player":
                            game.PushPlayer();
                            break;
                        case "team":
                            game.PushTeam();
                            break;
                    }
                }

                if (!ProcessBoolean(stage.endcondition().boolean()))
                {
                    Debug.WriteLine("Processing end of stage condition.");

                    //Debug.WriteLine("Hit Boolean while!");
                    iterStack.Push(new Queue<IParseTree>());
                    var topLevel = iterStack.Peek();
                    Debug.WriteLine("Current Player: " + game.CurrentPlayer().idx + ", " + game.players[game.CurrentPlayer().idx]);
                    Debug.WriteLine("Num players (gameiterator): " + game.CurrentPlayer().memberList.Count);
                    foreach (var player in game.players)
                    {
                        //Console.WriteLine ("HANDSIZE: " + player.cardBins ["{hidden}HAND"].Count);
                    }
                    for (int i = 4; i < stage.ChildCount - 1; ++i)
                    {
                        //TimeStep.Instance.treeLoc.Push(i - 4);
                        //Debug.WriteLine (TimeStep.Instance);
                        //ProcessSubStage(stage.GetChild(i));
                        topLevel.Enqueue(stage.GetChild(i));
                        Debug.WriteLine("Child enqueued: " + stage.GetChild(i).GetText());
                        //TimeStep.Instance.treeLoc.Pop();
                    }
                    if (iteratingSet.Contains(stage))
                    {
                        switch (text)
                        {
                            case "player":

                                game.CurrentPlayer().Next();
                                script?.WriteToFile("T:" + game.CurrentPlayer().CurrentName());
                                break;

                            case "team":
                                game.CurrentTeam().Next();
                                script?.WriteToFile("T:" + game.CurrentTeam().CurrentName());
                                break;
                        }
                    }
                }
                else
                {
                    PopCurrentNode();

                    if (iteratingSet.Contains(stage))
                    {
                        iteratingSet.Remove(stage);
                        switch (text)
                        {
                            case "player":
                                game.PopPlayer();
                                break;
                            case "team":
                                game.PopTeam();
                                break;
                        }
                    }
                    return false;
                }
            }
            return true;
            //instance.PopPlayer();
        }

        /*********
         * GAME ACTION PARSING
         *********/
        private GameActionCollection ProcessAction(RecycleParser.ActionContext actionNode)
        {
            Debug.WriteLine(actionNode.GetText());
            var ret = new GameActionCollection();
            if (actionNode.teamcreate() is not null)
            {
                var teamCreate = ProcessTeamCreate(actionNode.teamcreate(), game);
                ret.Add(new CreateTeamAction(teamCreate, game, script));
            }
            else if (actionNode.initpoints() is not null)
            {
                var pointAction = actionNode.initpoints();
                ret.Add(ProcessPoints(pointAction));
            }
            else if (actionNode.moveaction() is not null)
            {
                Debug.WriteLine("MOVE: '" + actionNode.GetText() + "'");
                var move = actionNode.moveaction();
                ret.Add(ProcessMove(move));
            }
            else if (actionNode.swapaction() is not null && actionNode.swapaction().card().Length > 0)
            {
                Debug.WriteLine("SWAP: '" + actionNode.GetText() + "'");
                var swap = actionNode.swapaction();
                ret.Add(ProcessSwap(swap));
            }
            else if (actionNode.swapaction() is not null && actionNode.swapaction().basecstorage().Length > 0)
            {
                Debug.WriteLine("SWAPAll: '" + actionNode.GetText() + "'");
                var swap = actionNode.swapaction();
                ret.Add(ProcessSwapAll(swap));
            }
            else if (actionNode.shuffleaction() is not null)
            {
                if (actionNode.shuffleaction().cstorage().Length == 1)
                {
                    var locations = ProcessLocation(actionNode.shuffleaction().cstorage()[0]);
                    ret.Add(ProcessShuffle(locations));
                }
                else
                {
                    Console.WriteLine("Faro shuffle not implemented");
                    throw new NotImplementedException();
                }
            }
            else if (actionNode.setaction() is not null)
            {
                var setAction = actionNode.setaction();
                ret.Add(SetAction(setAction));
            }
            else if (actionNode.setstraction() is not null)
            {
                var setstrAction = actionNode.setstraction();
                ret.Add(SetStrAction(setstrAction));
            }
            else if (actionNode.incaction() is not null)
            {
                var incAction = actionNode.incaction();
                ret.Add(IncAction(incAction));
            }
            else if (actionNode.decaction() is not null)
            {
                var decAction = actionNode.decaction();
                ret.Add(DecAction(decAction));
            }
            else if (actionNode.cycleaction() is not null)
            {
                ret.Add(CycleAction(actionNode.cycleaction()));
            }
            else if (actionNode.deckcreate() is not null)
            {
                ret.Add(ProcessDeckCreate(actionNode.deckcreate()));
            }
            else if (actionNode.turnaction() is not null)
            {
                ret.Add(new PassAction(script));
            }
            else if (actionNode.copyaction() is not null)
            {
                Debug.WriteLine("REMEMBER: '" + actionNode.GetText() + "'");
                ret.Add(ProcessCopy(actionNode.copyaction()));
            }
            else if (actionNode.removeaction() is not null)
            {
                Debug.WriteLine("FORGET: '" + actionNode.GetText() + "'");
                ret.Add(ProcessRemove(actionNode.removeaction()));
            }
            else if (actionNode.repeat() is not null)
            {
                ret.AddRange(ProcessRepeat(actionNode.repeat()));
            }
            else
            {
                Debug.WriteLine("Not Processed: '" + actionNode.GetText() + "'");
                throw new NotImplementedException();
            }
            return ret;
        }

        // TODO What about teams????
        private GameAction CycleAction(RecycleParser.CycleactionContext cycle)
        {
            var idx = -1;
            if (cycle.whop() is not null)
            {
                idx = ProcessWhop(cycle.whop()).id;
            }
            else if (cycle.varp() is not null)
            {
                idx = ProcessPlayerVar(cycle.varp()).id;
            }

            switch (cycle.GetChild(1).GetText()) {
                case "next": return new PlayerNextAction(game.CurrentPlayer(), idx, script);
                case "current": return new PlayerNowAction(idx, game, script);
            }

            Console.WriteLine("Unknown Player reference for cycle change.");
            throw new NotImplementedException();
        }

        private void ProcessDo(RecycleParser.CondactContext[] condact)
        {
            foreach (RecycleParser.CondactContext cond in condact)
            {
                ProcessSingleDo(cond);
            }
        }

        private void ProcessSingleDo(RecycleParser.CondactContext cond)
        {
            if (cond.boolean() is null || ProcessBoolean(cond.boolean())) { DoAction(cond); }
        }

        private void DoAction(RecycleParser.CondactContext cond)
        {
            if (cond.multiaction2() is not null)
            {
                Debug.WriteLine("Processing conditional multiaction.");
                // WHY ARE THESE NOT EXECUTED???
                // WHY ARE SOME OF THESE NULL??? WHAT IS THIS???
                var actions = ProcessMultiaction(cond.multiaction2());
                //Console.WriteLine(actions.Count);
                foreach (var act in actions)
                {
                    //Console.WriteLine(act);
                    act?.ExecuteAll();
                }
            }
            else
            {
                Debug.WriteLine("Processing conditional action.");
                ProcessAction(cond.action()).ExecuteAll();
            }
        }

        private GameActionCollection ProcessRepeat(RecycleParser.RepeatContext rep)
        {
            var ret = new GameActionCollection();
            int idx = 1;
            if (rep.@int() is not null)
            {
                idx = ProcessInt(rep.@int());
                for (int i = 0; i < idx; i++)
                {
                    ret.AddRange(ProcessAction(rep.action()));
                }
            }
            else if (rep.moveaction() is not null)
            { //'all'
                var card1 = ProcessCard(rep.moveaction().card()[0]);
                idx = card1.cardList.Count;
                for (int i = 0; i < idx; i++)
                {
                    ret.Add(ProcessMove(rep.moveaction()));
                }
            }
            else if (rep.removeaction() is not null)
            {
                var card1 = ProcessCard(rep.removeaction().card());
                idx = card1.cardList.Count;
                for (int i = 0; i < idx; i++)
                {
                    ret.Add(ProcessRemove(rep.removeaction()));
                }
            }
            else
            {
                Console.WriteLine("Invalid Repeat action.");
                throw new NotImplementedException();
            }
            return ret;
        }

        private bool ProcessBoolean(RecycleParser.BooleanContext boolNode)
        {
            if (boolNode.intop() is not null)
            {

                var intop = boolNode.intop();
                int trueOne = ProcessInt(boolNode.@int(0));
                int trueTwo = ProcessInt(boolNode.@int(1));
                if (intop.EQOP() is not null)
                {
                    switch (intop.EQOP().GetText())
                    {
                        case "==": return trueOne == trueTwo;
                        case "!=": return trueOne != trueTwo;
                    }
                }
                else if (intop.COMPOP() is not null)
                {
                    switch (intop.COMPOP().GetText())
                    {
                        case ">": return trueOne > trueTwo;
                        case ">=": return trueOne >= trueTwo;
                        case "<": return trueOne < trueTwo;
                        case "<=": return trueOne <= trueTwo;
                    }
                }
            }
            else if (boolNode.UNOP() is not null)
            {
                return !ProcessBoolean(boolNode.boolean(0));
            }
            else if (boolNode.BOOLOP() is not null)
            {
                string text = boolNode.BOOLOP().GetText();
                if (text == "or")
                {
                    bool flag = false;
                    var b = boolNode.boolean();
                    for (int i = 0; i < b.Length; i++)
                    {
                        flag |= ProcessBoolean(b[i]);
                        if (flag)
                        {
                            return flag;
                        }
                    }
                    return flag;
                }
                else if (text == "and")
                {
                    bool flag = true;
                    var b = boolNode.boolean();
                    for (int i = 0; i < b.Length; i++)
                    {
                        flag &= ProcessBoolean(b[i]);
                        if (!flag)
                        {
                            return flag;
                        }
                    }
                    return flag;
                }
            }
            else if (boolNode.EQOP() is not null)
            {
                bool eq = false;
                if (boolNode.EQOP().GetText() == "==")
                {
                    eq = true;
                }

                if (boolNode.str().Length > 0)
                {
                    var b = boolNode.str();
                    var t1 = ProcessString(b[0]);
                    var t2 = ProcessString(b[1]);
                    return eq == t1.Equals(t2);
                }
                else if (boolNode.card().Length > 0)
                {
                    var b = boolNode.card();
                    var card1 = ProcessCard(b[0]);
                    var card2 = ProcessCard(b[1]);
                    return eq == card1.Equals(card2);
                }
                else if (boolNode.whop().Length > 0)
                {
                    var b = boolNode.whop();
                    var p1 = ProcessWhop(b[0]);
                    var p2 = ProcessWhop(b[1]);
                    return eq == p1.Equals(p2);
                }
                else if (boolNode.whot().Length > 0)
                {
                    var b = boolNode.whot();
                    var t1 = ProcessWhot(b[0]);
                    var t2 = ProcessWhot(b[1]);
                    return eq == t1.Equals(t2);
                }
            }
            else if (boolNode.aggb() is not null)
            {
                return (bool)ProcessAggBool(boolNode.aggb());
            }
            Console.WriteLine("Invalid boolean expression");
            throw new NotSupportedException();
        }

        private CardMoveAction ProcessMove(RecycleParser.MoveactionContext move)
        {
            var c = move.card();
            var locOne = ProcessCard(c[0]);
            if (locOne.Count() == 0)
            {
                Console.WriteLine("Moving from empty, " + move.GetText());
                throw new InvalidOperationException();
            }
            var locTwo = ProcessCard(c[1]);
            return new CardMoveAction(locOne, locTwo, script);
        }

        private CardSwapAction ProcessSwap(RecycleParser.SwapactionContext swap)
        {
            var c = swap.card();
            var locOne = ProcessCard(c[0]);
            if (locOne.Count() == 0)
            {
                Console.WriteLine("Swapping from empty, " + locOne + swap.GetText());
                throw new InvalidOperationException();
            }
            var locTwo = ProcessCard(c[1]);
            if (locTwo.Count() == 0)
            {
                Console.WriteLine("Swapping to empty," + locTwo + swap.GetText());
                throw new InvalidOperationException();
            }
            return new CardSwapAction(locOne, locTwo, script);
        }

        private CardSwapAllAction ProcessSwapAll(RecycleParser.SwapactionContext swap)
        {
            var c = swap.basecstorage();
            var locOne = ProcessSubLocation(c[0]);
            if (locOne.Count() == 0)
            {
                Console.WriteLine("Swapping all from empty, " + locOne);
                throw new InvalidOperationException();
            }
            var locTwo = ProcessSubLocation(c[1]);
            if (locTwo.Count() == 0)
            {
                Console.WriteLine("Swapping all from empty," + locTwo);
                throw new InvalidOperationException();
            }
            return new CardSwapAllAction(locOne, locTwo, script);
        }
        private CardRememberAction ProcessCopy(RecycleParser.CopyactionContext copy)
        {
            var c = copy.card();
            var cardOne = ProcessCard(c[0]);
            if (cardOne.Count() == 0)
            {
                Debug.WriteLine("Copying from empty, " + copy.GetText());
                throw new InvalidOperationException();
            }
            var cardTwo = ProcessCard(c[1]);
            return new CardRememberAction(cardOne, cardTwo, script);
        }

        private CardForgetAction ProcessRemove(RecycleParser.RemoveactionContext removeAction)
        {
            return new CardForgetAction(ProcessCard(removeAction.card()), script);
        }

        private ShuffleAction ProcessShuffle(CardLocReference locations)
        {
            return new ShuffleAction(locations, script);
        }

        private CardLocReference ProcessCard(RecycleParser.CardContext card)
        {
            if (card.maxof() is not null)
            {
                var scoring = ProcessPointStorage(card.maxof().pointstorage()).Get();
                var coll = ProcessLocation(card.maxof().cstorage());
                var max = -1;

                if (!coll.cardList.AllCards().Any())
                {
                    Console.WriteLine("Can't find the max of an empty CardCollection.");
                    Console.WriteLine(coll);
                    throw new InvalidOperationException();
                }

                Card maxCard = coll.cardList.Peek();
                foreach (var c in coll.cardList.AllCards())
                {
                    int score = scoring.GetScore(c);
                    //MHG when equal, pick randomly
                    if (score > max || (score == max && ThreadSafeRandom.Next(0, 2) == 0))
                    {
                        //if (scoring.GetScore(c) > max){
                        max = scoring.GetScore(c);
                        maxCard = c;
                    }
                }
                Debug.WriteLine("MAX:" + maxCard);
                var lst = new CardCollection(CCType.VIRTUAL);
                lst.Add(maxCard);
                var fancy = new CardLocReference()
                {
                    cardList = lst,
                    locIdentifier = CardLocTypes.TOP,
                    name = coll.name + "{MAX}"
                };
                return fancy;
            }
            else if (card.minof() is not null)
            {
                var scoring = ProcessPointStorage(card.minof().pointstorage()).Get();
                var coll = ProcessLocation(card.minof().cstorage());
                var min = int.MaxValue;
                if (!coll.cardList.AllCards().Any())
                {
                    Console.WriteLine("Can't find the min of an empty CardCollection.");
                    throw new InvalidOperationException();
                }

                Card minCard = coll.cardList.Peek();
                foreach (var c in coll.cardList.AllCards())
                {
                    //MHG when equal, pick randomly
                    int score = scoring.GetScore(c);
                    if (score < min || (score == min && ThreadSafeRandom.Next(0, 2) == 0))
                    {
                        //if (scoring.GetScore(c) < min) {
                        min = score;
                        minCard = c;
                    }
                }
                Debug.WriteLine("MIN:" + minCard);
                var lst = new CardCollection(CCType.VIRTUAL);
                lst.Add(minCard);
                var fancy = new CardLocReference()
                {
                    cardList = lst,
                    locIdentifier = CardLocTypes.TOP,
                    name = coll.name + "{MIN}"
                };
                return fancy;
            }
            else if (card.varcard() is not null)
            {
                return ProcessCardVar(card.varcard());
            }
            else if (card.cstorage() is not null)
            {//cstorage
                var loc = ProcessLocation(card.cstorage());
                if (card.@int() is not null)
                {
                    //Console.WriteLine("Is this iT??");
                    var fancy = new CardLocReference()
                    {
                        cardList = loc.cardList,
                        locIdentifier = CardLocTypes.NUMBER,
                        locid = ProcessInt(card.@int()),
                        name = loc.name
                    };

                    return fancy;

                }
                else
                {
                    _ = Enum.TryParse(card.GetChild(1).GetText().ToUpper(), out CardLocTypes locType);
                    var fancy = new CardLocReference()
                    {
                        cardList = loc.cardList,
                        locIdentifier = locType, // top or bottom
                        name = loc.name
                    };

                    return fancy;
                }
            }
            Console.WriteLine("Invalid Card definition");
            throw new NotSupportedException();
        }

        private List<Owner> ProcessOther(RecycleParser.OtherContext other)
        { //return list of players
            List<Owner> lst = [];
            if (other.GetChild(2).GetText() == "player")
            {
                int me = game.currentPlayer.Peek().idx;
                for (int i = 0; i < game.players.Length; i++)
                {
                    if (i != me)
                    { lst.Add(game.players[i]); }
                }

            }
            else
            {
                // TEAMS BROKEN!!! NOT IMPLEMENTED!!!
                Console.WriteLine("Other not implemented for teams");
                throw new NotImplementedException();
                /*
                foreach (Team t in game.teams)
                {
                    lst.Add(t);
                }
                lst.Remove(game.currentTeam);
                */
            }
            return lst;
        }

        private CardLocReference[] ProcessCStorageCollection(RecycleParser.CstoragecollectionContext cstoragecoll)
        {
            if (cstoragecoll.subset() is not null)
            {
                Debug.WriteLine("Found a subset");
                var stor = ProcessLocation(cstoragecoll.subset().cstorage());
                Debug.WriteLine("There are " + stor.cardList.AllCards().Count() + " cards here");

                var subsets = new List<List<Card>>
                {
                    ([])
                };

                foreach (var card in stor.cardList.AllCards())
                {
                    var subsettemp = new List<List<Card>>();
                    foreach (var set in subsets)
                    {
                        var subset = new List<Card>(set)
                        {
                            card
                        };
                        subsettemp.Add(subset);
                    }
                    subsets.AddRange(subsettemp);
                }
                Debug.WriteLine("there are now " + subsets.Count + " subsets");
                var returnList = new CardLocReference[subsets.Count];
                for (int j = 0; j < subsets.Count; j++)
                {
                    var cardlist = subsets[j];
                    var cctemp = new CardCollection(CCType.VIRTUAL, cardlist);

                    returnList[j] = new CardLocReference()
                    {
                        cardList = cctemp,
                        name = "{subset " + j + " from " + stor.name + "}"
                    };
                }
                return returnList;
            }

            // PARTITON CODE
            else if (cstoragecoll.partition() is not null)
            {
                return ProcessPartition(cstoragecoll.partition());
            }

            else if (cstoragecoll.run() is not null)
            {
                var locs = ProcessLocation(cstoragecoll.run().cstorage());
                var points = ProcessPointStorage(cstoragecoll.run().pointstorage());
                var scoring = points.Get();
                int minsize = ProcessInt(cstoragecoll.run().@int());
                var returnList = new List<CardLocReference>();

                var sortcards = locs.cardList.AllCards().ToArray();
                Array.Sort(sortcards, new CardComparer()
                {
                    scoring = points.Get(),
                });

                var current = new List<CardCollection>
                {
                    new(CCType.VIRTUAL)
                };

                bool all = cstoragecoll.run().GetChild(2).GetText() == "all";
                bool largest = cstoragecoll.run().GetChild(2).GetText() == "largest";
                for (int j = 0; j < sortcards.Length; j++)
                {
                    Card card = sortcards[j];
                    if (j == 0)
                    {
                        // starting first spot in run
                        current[^1].Add(card);
                    }
                    else
                    {
                        if (scoring.GetScore(card) == scoring.GetScore(sortcards[j - 1]))
                        {
                            // duplicate the current runs, swap out the last card with this one
                            var toAdd = new List<CardCollection>();
                            foreach (var c in current)
                            {
                                if (c.Peek() == sortcards[j - 1])
                                {
                                    Debug.WriteLine(c);
                                    var other = c.DeepCopy();
                                    Debug.WriteLine(other);
                                    other.Remove();
                                    other.Add(card);
                                    toAdd.Add(other);
                                }
                            }
                            current.AddRange(toAdd);
                        }
                        else if (scoring.GetScore(card) == 1 + scoring.GetScore(sortcards[j - 1]))
                        {
                            // if you want all runs, then you should archive them no matter if you match or not.
                            if (all)
                            {
                                foreach (var c in current)
                                {
                                    if (c.Count >= minsize)
                                    {
                                        var cl = c.DeepCopy();//new CardCollection(CCType.VIRTUAL);
                                        returnList.Add(new CardLocReference()
                                        {
                                            cardList = cl,
                                            name = "{all runs}" + j,
                                        });
                                    }
                                }
                            }

                            // next in sequence, then add it
                            foreach (var c in current)
                            {
                                c.Add(card);
                            }
                        }
                        else
                        {
                            // finalize the runs to return when there is no match
                            foreach (var c in current)
                            {
                                if (c.Count >= minsize)
                                {
                                    returnList.Add(new CardLocReference()
                                    {
                                        cardList = c,
                                        name = "{all runs}" + j,
                                    });
                                }
                            }
                            // start new runs
                            current.Clear();
                            if (largest)
                            {
                                current.Add(new CardCollection(CCType.VIRTUAL));
                                current[^1].Add(card);
                            }
                        }

                        if (all)
                        {
                            current.Add(new CardCollection(CCType.VIRTUAL));
                            current[^1].Add(card);
                        }
                    }
                }
                // wrap up last run possibility at the end
                foreach (var c in current)
                {
                    if (c.Count >= minsize)
                    {
                        returnList.Add(new CardLocReference()
                        {
                            cardList = c,
                            name = "{all runs end}",
                        });
                    }
                }
                return [.. returnList];

            }
            else if (cstoragecoll.aggcs() is not null)
            {
                return ProcessAggCStorage(cstoragecoll.aggcs());
            }
            else if (cstoragecoll.varcsc() is not null)
            {
                return ProcessCStorageCollectionVar(cstoragecoll.varcsc());
            }
            else if (cstoragecoll.indexed() is not null)
            {
                CCType prefix = ProcessLocDesc(cstoragecoll.indexed().locdesc());
                Owner player = ProcessLocPre(cstoragecoll.indexed().locpre());
                string name = ProcessString(cstoragecoll.indexed().str());
                var bins = player.cardBins.Indexed(prefix, name + CardStorage.delimiter);
                CardLocReference[] ret = new CardLocReference[bins.Count];
                int i = 0;
                foreach (CardCollection cc in bins)
                {
                    ret[i] = new CardLocReference()
                    {
                        cardList = cc,
                        name = cc.name,
                    };
                    i++;
                }
                return ret;
            }
            Console.WriteLine("Invalid Card Collection definition.");
            throw new NotSupportedException();
        }

        private CardLocReference[] ProcessCStorageCollectionVar(RecycleParser.VarcscContext cstoragecollvar)
        {
            var temp = variables.Get(cstoragecollvar.GetText());
            if (temp is List<CardLocReference> csc)
            {
                return [.. csc];
            }
            else
            {
                Console.WriteLine("Error, "+ cstoragecollvar.GetText() + " is not a CardStorageCollection, type is: " + temp.GetType());
                throw new NotImplementedException();
            }
        }

        private CardLocReference[] CollectLocations(RecycleParser.CstorageContext[] cstorage, RecycleParser.AggcsContext aggcs)
        {
            if (cstorage.Length > 0)
            {
                var allLocs = new CardLocReference[cstorage.Length];
                int i = 0;
                foreach (var locChild in cstorage)
                {
                    allLocs[i] = ProcessLocation(locChild);
                    i++;
                }
                return allLocs;
            }
            else
            {
                return ProcessAggCStorage(aggcs);
            }
        }

        private CardLocReference ProcessLocation(RecycleParser.CstorageContext loc)
        {
            string name = "";
            if (loc.unionof() is not null)
            {
                var allLocs = CollectLocations(loc.unionof().cstorage(), loc.unionof().aggcs());

                CardCollection temp = new(CCType.VIRTUAL);
                foreach (var locs in allLocs)
                {
                    name += locs.name + " ";
                    foreach (var card in locs.cardList.AllCards())
                    {
                        temp.Add(card);  // TODO Should this check for duplicates???
                    }
                }
                name = name[..^1];

                var fancy = new CardLocReference()
                {
                    cardList = temp,
                    name = name + "{UNION}"
                };
                return fancy;
            }
            else if (loc.intersectof() is not null)
            {
                var allLocs = CollectLocations(loc.intersectof().cstorage(), loc.intersectof().aggcs());

                Dictionary<Card, int> cardCount = [];
                foreach (var locs in allLocs)
                {
                    name += locs.name + " ";
                    foreach (var card in locs.cardList.AllCards())
                    {
                        if (cardCount.ContainsKey(card))
                        {
                            cardCount[card] += 1;
                        }
                        else
                        {
                            cardCount[card] = 1;
                        }
                    }
                }

                CardCollection temp = new(CCType.VIRTUAL);
                foreach (KeyValuePair<Card, int> kvp in cardCount)
                {
                    if (kvp.Value == loc.intersectof().cstorage().Length)
                    {
                        temp.Add(kvp.Key);
                    }
                }
                name = name[..^1];

                var fancy = new CardLocReference()
                {
                    cardList = temp,
                    name = name + "{INTERSECTION}"
                };
                return fancy;
            }
            else if (loc.disjunctionof() is not null)
            {
                var allLocs = CollectLocations(loc.disjunctionof().cstorage(), loc.disjunctionof().aggcs());

                Dictionary<Card, int> cardCount = [];
                foreach (var locs in allLocs)
                {
                    name += locs.name + " ";
                    foreach (var card in locs.cardList.AllCards())
                    {
                        if (cardCount.ContainsKey(card))
                        {
                            cardCount[card] += 1;
                        }
                        else
                        {
                            cardCount[card] = 1;
                        }
                    }
                }

                CardCollection temp = new(CCType.VIRTUAL);
                foreach (KeyValuePair<Card, int> kvp in cardCount)
                {
                    if (kvp.Value == 1)
                    {
                        temp.Add(kvp.Key);
                    }
                }
                name = name[..^1];

                var fancy = new CardLocReference()
                {
                    cardList = temp,
                    name = name + "{DISJUNCTION}"
                };
                return fancy;
            }
            else if (loc.filter() is not null)
            {
                // WILL THIS FAIL LATER???
                // OH YES IT DID! IN WEIRD WAYS
                return ProcessCStorageFilter(loc.filter());
            }
            else if (loc.basecstorage() is not null)
            {
                Debug.WriteLine("Loc");
                return ProcessSubLocation(loc.basecstorage());
            }
            else if (loc.memstorage() is not null)
            {
                Debug.WriteLine("Tuple Track");
                var identifier = loc.memstorage().GetChild(1).GetText();
                var resultingSet = ProcessCStorageCollection(loc.memstorage().cstoragecollection());
                return identifier switch
                {
                    "top" => resultingSet[0],
                    "bottom" => resultingSet[^1],
                    _ => resultingSet[int.Parse(identifier)],
                };
            }
            // This should really be an ACTION, not a vitrual card loc
            else if (loc.sortof() is not null)
            {
                var locs = ProcessLocation(loc.sortof().cstorage());
                var points = ProcessPointStorage(loc.sortof().pointstorage()).Get();

                // HACK FOR NOW
                locs.cardList.Sort(points);
                /*
                // Sort the cards here, be efficient! TODO
                List<Card> cards = [];
                foreach (Card card in locs.cardList.AllCards())
                {
                    cards.Add(card);
                }

                // Sort cards.

                cards.Sort(delegate (Card a, Card b)
                {
                    if (points.GetScore(a) == points.GetScore(b)) return 0;
                    else if (points.GetScore(a) > points.GetScore(b)) return -1;
                    else return 1;
                });

                CardCollection temp = new(CCType.VIRTUAL);
                foreach (Card card in cards)
                {
                    temp.Add(card);
                }

                var fancy = new CardLocReference()
                {
                    cardList = temp,
                    name = name + "{SORTED}"
                };
                //Console.WriteLine("Sorting not implemented yet");
                //throw new NotImplementedException();
                return fancy;
                */
                return locs;
                
            }
            else if (loc.sequence() is not null)
            {
                CardCollection temp = new(CCType.VIRTUAL);
                var locs = ProcessLocation(loc.sequence().cstorage());
                var count = ProcessInt(loc.sequence().@int());
                bool top = loc.sequence().GetChild(1).GetText() == "top";

                for (int i = 0; i < count; i++)
                {
                    if (top)
                    {
                        temp.Add(locs.cardList.Get(locs.cardList.Count - i - 1));
                    }
                    else
                    {
                        temp.Add(locs.cardList.Get(i));
                    }
                }
                var fancy = new CardLocReference()
                {
                    cardList = temp,
                    name = name + "{SEQUENCE OF " + count + "}",
                };
                return fancy;
            }
            else if (loc.runsequence() is not null)
            {
                var locs = ProcessLocation(loc.runsequence().cstorage());
                var points = ProcessPointStorage(loc.runsequence().pointstorage());
                var scoring = points.Get();
                int minsize = ProcessInt(loc.runsequence().@int());
                int numcards = locs.cardList.AllCards().Count();
                var best = new CardCollection(CCType.VIRTUAL);
                var comp = new CardComparer()
                {
                    scoring = points.Get(),
                };
                bool bottom = loc.runsequence().GetChild(2).GetText() == "bottom";

                for (int i = minsize; i < numcards + 1; i++)
                {
                    var sortcards = locs.cardList.AllCards().ToArray()[(numcards - i)..];
                    if (bottom)
                    {
                        sortcards = locs.cardList.AllCards().ToArray()[..i];
                    }
                    Array.Sort(sortcards, comp);
                    var current = new CardCollection(CCType.VIRTUAL);
                    current.Add(sortcards[0]);
                    bool complete = true;
                    for (int j = 0; j < sortcards.Length; j++)
                    {
                        Card card = sortcards[j];
                        if (j != 0)
                        {
                            if (scoring.GetScore(card) == 1 + scoring.GetScore(sortcards[j - 1]))
                            {
                                // next in sequence, then add it
                                current.Add(card);
                            }
                            else
                            {
                                current.Clear();
                                complete = false;
                                break;
                            }
                        }
                    }
                    if (complete)
                    {
                        best = current;
                        Debug.WriteLine("Found a run!");
                    }
                }
                var fancy = new CardLocReference()
                {
                    cardList = best,
                    name = name + "{run sequence " + (bottom ? "bottom" : "top") + "}",
                };
                return fancy;
            }

            // CAN WE REMOVE THIS???? NO!!!
            else if (loc.varcs() is not null)
            {
                return ProcessCardStorageVar(loc.varcs());
            }

            Console.WriteLine("Card Location reference not defined.");
            throw new NotSupportedException();
        }

        private CardLocReference[] ProcessPartition(RecycleParser.PartitionContext partContext)
        {
            var allLocs = CollectLocations(partContext.cstorage(), partContext.aggcs());

            // Splitting on a card attribute?
            var partition = new Dictionary<string, CardCollection>();
            int count = 0;
            
            // Split up the cards
            foreach (var stor in allLocs)
            {
                foreach (var card in stor.cardList.AllCards())
                {
                    var attr = card.ReadAttribute(ProcessString(partContext.str()));
                    if (!partition.TryGetValue(attr, out CardCollection? value))
                    {
                        value = new CardCollection(CCType.VIRTUAL);
                        partition[attr] = value;
                        count++;
                    }

                    value.Add(card);
                }
            }

            // Make new lists
            var returnList = new CardLocReference[count];
            count = 0;
            foreach (KeyValuePair<string, CardCollection> kvp in partition)
            {
                returnList[count] = new CardLocReference()
                {
                    cardList = kvp.Value,
                    name = "{partition}" + "{part: " + kvp.Key + "}"
                };
                count++;
            }
            return returnList;
        }

        private static CCType ProcessLocDesc(RecycleParser.LocdescContext locdesc)
        {
            return locdesc.GetText() switch
            {
                "vloc" => CCType.VISIBLE,
                "iloc" => CCType.INVISIBLE,
                "hloc" => CCType.HIDDEN,
                "oloc" => CCType.OTHERS,
                "mem" => CCType.MEMORY,
                _ => CCType.VIRTUAL,
            };
        }

        private Owner ProcessLocPre(RecycleParser.LocpreContext locpre)
        {
            if (locpre.GetText() == "game")
            {
                return game.table[0];
            }
            else if (locpre.whop() is not null)
            {
                return ProcessWhop(locpre.whop());
            }
            else
            {
                return ProcessPlayerVar(locpre.varp());
            }
        }

        private CardLocReference ProcessSubLocation(RecycleParser.BasecstorageContext stor)
        {
            CCType prefix = ProcessLocDesc(stor.locdesc());
            Owner player = ProcessLocPre(stor.locpre());

            string name = ProcessString(stor.str()) + CardStorage.delimiter;
            if (stor.@int() is not null)
            {
                name += ProcessInt(stor.@int());
            }
            else
            {
                name += 0;
            }

            var fancy = new CardLocReference()
            {
                cardList = player.cardBins[prefix, name],
                locIdentifier = CardLocTypes.TOP,
                name = player.name + " " + prefix + " " + name
            };
            return fancy;
        }
        private string ProcessCardatt(RecycleParser.CardattContext cardatt)
        {
            var loc = ProcessCard(cardatt.card());
            if (loc.cardList.Count > 0)
            {
                var card = loc.Get();
                if (card is not null)
                {
                    Debug.WriteLine("Att2 is " + card.ReadAttribute(ProcessString(cardatt.str())));
                    return card.ReadAttribute(ProcessString(cardatt.str()));
                }
            }
            Debug.WriteLine("Empty Attribute, no cards found");
            //throw new NotSupportedException();
            return "";
        }

        private Owner ProcessWho(RecycleParser.WhoContext who)
        {
            if (who.whop() is not null)
            {
                return ProcessWhop(who.whop());
            }
            else if (who.whot() is not null)
            {
                return ProcessWhot(who.whot());
            }
            Console.WriteLine("Unknown Who portion.");
            throw new Exception();
        }

        private Player ProcessWhop(RecycleParser.WhopContext who)
        {
            if (who.owner() is not null)
            {
                var loc = ProcessCard(who.owner().card());
                return (Player)loc.Get().Owner.owner.owner;
            }
            else
            {
                switch (who.GetChild(1).GetText())
                {
                    case "current": return game.CurrentPlayer().Current();
                    case "next": return game.CurrentPlayer().PeekNext();
                    case "previous": return game.CurrentPlayer().PeekPrevious();
                }
                if (who.whodesc().@int() is not null)
                {
                    return game.players[ProcessInt(who.whodesc().@int())];
                }
            }
            Console.WriteLine("Unknown Player description");
            throw new Exception();
        }

        private Team ProcessWhot(RecycleParser.WhotContext who)
        {
            if (who.teamp() is not null)
            {
                if (who.teamp().varp() is not null)
                {
                    var p = ProcessPlayerVar(who.teamp().varp());
                    return p.team;
                }
                else
                {
                    return ProcessWhop(who.teamp().whop()).team;
                }
            }
            else
            {
                switch (who.GetChild(1).GetText())
                {
                    case "current": return game.CurrentTeam().Current();
                    case "next": return game.CurrentTeam().PeekNext();
                    case "previous": return game.CurrentTeam().PeekPrevious();
                }
                if (who.whodesc().@int() is not null)
                {
                    return game.teams[ProcessInt(who.whodesc().@int())];
                }
            }
            Console.WriteLine("Unknown Team Description.");
            throw new Exception();
        }

        private static CardTree ProcessDeck(RecycleParser.DeckContext deck)
        {
            //var attributeCount = deck.ChildCount - 3;

            List<AttributeNode> childs = [];
            for (int i = 0; i < deck.attribute().Length; ++i)
            {
                childs.Add(new AttributeNode
                {
                    Value = $"combo{i}",
                    children = ProcessAttribute(deck.attribute(i))
                });
            }
            return new CardTree
            {
                rootNode = new AttributeNode
                {
                    Value = "Attrs",
                    children = childs
                }
            };
        }


        private static List<AttributeNode> ProcessAttribute(RecycleParser.AttributeContext attr) //TODO make this array!!
        {
            var ret = new List<AttributeNode>();
            if (attr.attribute()[0].attribute().Length == 0)
            {
                var terminalTitle = attr.namegr()[0];
                var subNode = attr.attribute()[0];

                var trueCount = (subNode.ChildCount - 3) / 2 + 1;
                for (int i = 0; i < trueCount; ++i)
                {
                    ret.Add(new AttributeNode
                    {
                        Key = terminalTitle.GetText(),
                        Value = subNode.namegr(i).GetText()
                    });
                }
            }
            else
            {
                var terminalTitle = attr.namegr()[0];
                var children = attr.attribute();

                foreach (var subNode in children)
                {
                    var childs = new List<AttributeNode>();
                    foreach (var att in subNode.attribute())
                    {
                        childs.AddRange(ProcessAttribute(att));
                    }
                    ret.Add(new AttributeNode
                    {
                        Key = terminalTitle.GetText(),
                        Value = subNode.namegr()[0].GetText(),
                        children = childs
                    });
                }
            }
            return ret;
        }

        private int ProcessInt(RecycleParser.IntContext intNode)
        {
            if (intNode.intgr() is not null)
            {
                Debug.WriteLine(intNode.GetText());
                // Can I cache this, so I don't need to parse a string every time? NO!!!
                //return int.Parse(intNode.GetText());
                return intNode.GetInt();
            }
            else if (intNode.rawstorage() is not null)
            {
                var fancy = ProcessIntStorage(intNode.rawstorage());
                return fancy.Get();
            }
            else if (intNode.pid() is not null)
            {
                var player = ProcessWhop(intNode.pid().whop());
                return player.id;
            }
            else if (intNode.tid() is not null)
            {
                var team = ProcessWhot(intNode.tid().whot());
                return team.id;
            }
            else if (intNode.@sizeof() is not null)
            {
                RecycleParser.CollectionContext coll = intNode.@sizeof().collection();
                return ProcessCollection(coll).Count();
            }
            else if (intNode.mult() is not null)
            {
                int val = ProcessInt(intNode.mult().@int(0));
                for (int i = 1; i < intNode.mult().@int().Length; i++)
                {
                    val *= ProcessInt(intNode.mult().@int(i));
                }
                return val;
            }
            else if (intNode.subtract() is not null)
            {
                return ProcessInt(intNode.subtract().@int(0)) - ProcessInt(intNode.subtract().@int(1));
            }
            else if (intNode.mod() is not null)
            {
                return ProcessInt(intNode.mod().@int(0)) % ProcessInt(intNode.mod().@int(1));
            }
            else if (intNode.divide() is not null)
            {
                var divisor = ProcessInt(intNode.divide().@int(1));
                if (divisor == 0)
                {
                    Console.WriteLine("Division by zero: " + intNode.GetText());
                }
                return ProcessInt(intNode.divide().@int(0)) / divisor;
            }
            else if (intNode.@add() is not null)
            {
                int val = ProcessInt(intNode.@add().@int(0));
                for (int i = 1; i < intNode.@add().@int().Length; i++)
                {
                    val += ProcessInt(intNode.@add().@int(i));
                }
                return val;
            }
            else if (intNode.exponent() is not null)
            {
                return Convert.ToInt32(Math.Pow(ProcessInt(intNode.exponent().@int(0)), ProcessInt(intNode.exponent().@int(1))));
            }
            else if (intNode.fibonacci() is not null)
            {
                return ProcessFibonacci(intNode.fibonacci());
            }
            else if (intNode.triangular() is not null)
            {
                return ProcessTriangular(intNode.triangular());
            }
            else if (intNode.random() is not null)
            {
                return ProcessRandom(intNode.random());
            }
            else if (intNode.sum() is not null)
            {
                var sum = intNode.sum();
                var scoring = ProcessPointStorage(sum.pointstorage()).Get();
                var coll = ProcessLocation(sum.cstorage());
                int total = 0;
                Debug.WriteLine("This is what? " + coll);
                foreach (var c in coll.cardList.AllCards())
                {
                    total += scoring.GetScore(c);
                }
                Debug.WriteLine("Sum:" + total);
                return total;
            }
            else if (intNode.scoremax() is not null)
            {
                var sum = intNode.scoremax();
                var scoring = ProcessPointStorage(sum.pointstorage()).Get();
                var coll = ProcessLocation(sum.cstorage());
                int maximum = -1;
                Debug.WriteLine("This is what? " + coll);
                foreach (var c in coll.cardList.AllCards())
                {
                    int s = scoring.GetScore(c);
                    if (s > maximum)
                    {
                        maximum = s;
                    }
                }
                Debug.WriteLine("Scoremax:" + maximum);
                return maximum;
            }
            else if (intNode.scoremin() is not null)
            {
                var sum = intNode.scoremin();
                var scoring = ProcessPointStorage(sum.pointstorage()).Get();
                var coll = ProcessLocation(sum.cstorage());
                int minimum = int.MaxValue;
                Debug.WriteLine("This is what? " + coll);
                foreach (var c in coll.cardList.AllCards())
                {
                    int s = scoring.GetScore(c);
                    if (s < minimum)
                    {
                        minimum = s;
                    }
                }
                Debug.WriteLine("Scoremin:" + minimum);
                return minimum;
            }
            else if (intNode.score() is not null)
            {
                Debug.WriteLine("trying to score" + intNode.GetText());
                var scorer = ProcessPointStorage(intNode.score().pointstorage()).Get();
                var card = ProcessCard(intNode.score().card());
                int score = scorer.GetScore(card.Get());
                Debug.WriteLine(card + " = " + score);
                return score;
            }
            else if (intNode.vari() is not null)
            {
                return ProcessIntVar(intNode.vari());
            }
            else if (intNode.aggi() is not null)
            {
                return ProcessAggIntStorage(intNode.aggi());
            }
            else
            {
                Console.WriteLine("Undefined Int Expression.");
                throw new InvalidDataException();
            }
        }

        private List<int> ProcessRange(RecycleParser.RangeContext range)
        {
            var i = range.@int();
            int int1 = ProcessInt(i[0]);
            int int2 = ProcessInt(i[1]);
            List<int> ret = [];
            for (int idx = int1; idx <= int2; idx++)
            {
                ret.Add(idx);
            }
            return ret;
        }

        private int ProcessRandom(RecycleParser.RandomContext random)
        {
            var i = random.@int();
            int int1 = ProcessInt(i[0]);
            if (random.GetChild(4) is not null) // if second integer is included
            {
                // Console.WriteLine("Second variable included.");
                int int2 = ProcessInt(i[1]);
                return ThreadSafeRandom.Next(int1, int2 + 1);
            }
            else // if no second integer
            {
                // Console.WriteLine("Second variable not included.");
                return ThreadSafeRandom.Next(0, int1 + 1);
            }
        }

        private int ProcessFibonacci(RecycleParser.FibonacciContext fib)
        {
            int int1 = ProcessInt(fib.@int());
            return Convert.ToInt32(((Math.Pow((1 + Math.Sqrt(5)) / 2, int1)) - (Math.Pow((1 - Math.Sqrt(5)) / 2, int1))) / Math.Sqrt(5));
        }

        private int ProcessTriangular(RecycleParser.TriangularContext tri)
        {
            int int1 = ProcessInt(tri.@int());
            return (int1 * (int1 + 1)) / 2;
        }

        private StorageReference<int> ProcessIntStorage(RecycleParser.RawstorageContext intSto)
        {
            var who = game.table[0];
            if (intSto.who() is not null)
            {
                who = ProcessWho(intSto.who());
            }
            else if (intSto.varo() is not null)
            {
                who = ProcessOwnerVar(intSto.varo());
            }
            return new StorageReference<int>(who.intBins, ProcessString(intSto.str()));
        }

        private StorageReference<string> ProcessStrStorage(RecycleParser.StrstorageContext strSto)
        {
            var who = game.table[0];
            if (strSto.who() is not null)
            {
                who = ProcessWho(strSto.who());
            }
            else if (strSto.varo() is not null)
            {
                who = ProcessOwnerVar(strSto.varo());
            }
            return new StorageReference<string>(who.stringBins, ProcessString(strSto.str()));
        }

        private StorageReference<PointMap> ProcessPointStorage(RecycleParser.PointstorageContext ptSto)
        {
            var who = game.table[0];
            if (ptSto.who() is not null)
            {
                who = ProcessWho(ptSto.who());
            }
            else if (ptSto.varo() is not null)
            {
                who = ProcessOwnerVar(ptSto.varo());
            }
            return new StorageReference<PointMap>(who.pointBins, ProcessString(ptSto.str()));
        }

        private SetAction<int> SetAction(RecycleParser.SetactionContext setAction)
        {
            var bin = ProcessIntStorage(setAction.rawstorage());
            var setValue = ProcessInt(setAction.@int());
            return new SetAction<int>(bin.Storage, bin.Key, setValue, script);
        }

        private SetAction<string> SetStrAction(RecycleParser.SetstractionContext setAction)
        {
            var bin = ProcessStrStorage(setAction.strstorage());
            var setValue = ProcessString(setAction.str());
            return new SetAction<string>(bin.Storage, bin.Key, setValue, script);
        }

        private SetAction<PointMap> ProcessPoints(RecycleParser.InitpointsContext points)
        {
            var bin = ProcessPointStorage(points.pointstorage());

            List<ValueTuple<string, string, int>> temp = [];
            var awards = points.awards();
            foreach (RecycleParser.AwardsContext award in awards)
            {
                StringBuilder key = new();
                StringBuilder value = new();
                int reward = ProcessInt(award.@int());
                var iter = award.subaward();
                foreach (RecycleParser.SubawardContext i in iter)
                {
                    // TODO Is this working properly? I don't think so!
                    var ii = i.str();
                    key.Append(ProcessString(ii[0])).Append(',');
                    value.Append(ProcessString(ii[1])).Append(',');
                    Debug.WriteLine("*** Found ...)" + value);
                }
                --key.Length;
                --value.Length;
                string k = key.ToString();
                string v = value.ToString();
                script?.WriteToFile("A:" + v + " " + reward);
                temp.Add(new ValueTuple<string, string, int>(k, v, reward));
            }
            var setValue = new PointMap(temp);
            return new SetAction<PointMap>(bin.Storage, bin.Key, setValue, script);
        }

        private SetAction<int> IncAction(RecycleParser.IncactionContext setAction)
        {
            var bin = ProcessIntStorage(setAction.rawstorage());
            if (setAction.@int() is not null)
            {
                var setValue = ProcessInt(setAction.@int());
                var newVal = bin.Get() + setValue;
                return new SetAction<int>(bin.Storage, bin.Key, newVal, script);
            }
            else
            {
                return new SetAction<int>(bin.Storage, bin.Key, bin.Get() + 1, script);
            }
        }
        private SetAction<int> DecAction(RecycleParser.DecactionContext setAction)
        {
            var bin = ProcessIntStorage(setAction.rawstorage());
            if (setAction.@int() is not null)
            {
                var setValue = ProcessInt(setAction.@int());
                var newVal = bin.Get() - setValue;
                return new SetAction<int>(bin.Storage, bin.Key, newVal, script);
            }
            else
            {
                return new SetAction<int>(bin.Storage, bin.Key, bin.Get() - 1, script);
            }
        }

        private CardLocReference ProcessCStorageFilter(RecycleParser.FilterContext filter)
        {
            var cList = new CardCollection(CCType.VIRTUAL);
            IEnumerable<Card>? stor2 = null;
            string name2 = "";

            if (filter.collection().cstorage() is not null)
            {
                Debug.WriteLine("Filter: cstorage collection");
                CardLocReference stor = ProcessLocation(filter.collection().cstorage());
                stor2 = stor.cardList.AllCards();
                name2 = stor.name;
            }
            else if (filter.collection().varc() is not null)
            {
                Debug.WriteLine("Filter: variable collection");

                // Should be using ProcessCollectionVar method.... TODO
                var stor = variables.Get(filter.collection().varc().GetText());
                if (stor is CardLocReference stort)
                {
                    stor2 = stort.cardList.AllCards();
                    name2 = stort.name;
                }
                else if (stor is List<Card> storc)
                {
                    stor2 = storc;
                    name2 = "FilteredCardListWithoutName";
                }
            }
            else
            {
                Console.WriteLine("Filter is missing required pieces");
                throw new NotSupportedException();
            }

            if (stor2 is not null)
            {
                string text = filter.var().GetText();
                foreach (Card card in stor2)
                {
                    variables.Put(text, card);
                    if (ProcessBoolean(filter.boolean()))
                    {
                        cList.Add(card);
                    }
                    variables.Remove(text);
                }
                /*
                if (text == "'TR" && cList.Count > 0 && script is not null)
                {
                    Console.WriteLine("Found some matches!!");
                    Console.WriteLine(cList);
                }
                */
            }
            var fancy = new CardLocReference()
            {
                cardList = cList,
                name = name2 + "{filter}" + filter.boolean().GetText(),
            };
            return fancy;
        }

        private List<object> IterateAgg(RecycleParser.CollectionContext coll, RecycleParser.VarContext var, IParseTree tree)
        {
            var stor = ProcessCollection(coll);
            var ret = new List<object>(20);
            foreach (var t in stor)
            {
                Debug.WriteLine("Iterating over aggregation of: " + t.GetType());
                variables.Put(var.GetText(), t);
                var post = ProcessAggPost(tree);
                if (post is not null)
                {
                    ret.Add(post);
                }
                variables.Remove(var.GetText());
            }
            return ret;
        }

        private GameActionCollection ProcessAgg(RecycleParser.AggContext agg)
        {
            var ret = IterateAgg(agg.collection(), agg.var(), agg.GetChild(4));
            Debug.WriteLine(ret.Count);
            GameActionCollection ret2 = [];
            foreach (var item in ret)
            {
                if (item is GameAction ga)
                {
                    ret2.Add(ga);
                }
                else
                {
                    Console.WriteLine("What is this???");
                    throw new Exception();
                }
            }
            return ret2;
        }

        private CardLocReference[] ProcessAggCStorage(RecycleParser.AggcsContext agg)
        {
            var ret = IterateAgg(agg.collection(), agg.var(), agg.GetChild(4));

            Debug.WriteLine(ret.Count);

            Debug.WriteLine("Processing agg + Cstorage: " + ((RecycleParser.CstorageContext)agg.GetChild(4)).GetText());
            var coll = new CardLocReference[ret.Count];
            for (int i = 0; i < ret.Count; i++)
            {
                coll[i] = (CardLocReference)ret[i];
            }
            return coll;
        }

        private int ProcessAggIntStorage(RecycleParser.AggiContext agg)
        {
            var ret = IterateAgg(agg.collection(), agg.var(), agg.GetChild(4));

            Debug.WriteLine(ret.Count);

            Debug.WriteLine("Processing agg + IntStorage: " + ((RecycleParser.RawstorageContext)agg.GetChild(4)).GetText());
            var sum = 0;
            foreach (object obj in ret)
            {
                var raw = (StorageReference<int>)obj;
                sum += raw.Get();
            }
            return sum;

        }
        private bool ProcessAggBool(RecycleParser.AggbContext agg)
        {
            Debug.WriteLine("Processing agg + Boolean: " + ((RecycleParser.BooleanContext)agg.GetChild(4)).GetText());

            var ret = IterateAgg(agg.collection(), agg.var(), agg.GetChild(4));

            Debug.WriteLine("Found this many: " + ret.Count);
            if (agg.GetChild(1).GetText() == "all")
            {
                var all = true;
                foreach (object obj in ret)
                {
                    Debug.WriteLine("i: " + obj);
                    all &= (bool)obj;
                }
                return all;
            }
            else // if an 'any' statement
            {
                foreach (object obj in ret)
                {
                    if ((bool)obj)
                    {
                        return true; // short circut when found a true for any case
                    }
                }
                return false;
            }
        }

        private IEnumerable<object> ProcessCollectionVar(RecycleParser.VarcContext varc)
        {
            Debug.WriteLine("Processing collection type: var.");
            var stor = variables.Get(varc.GetText());
            if (stor is CardLocReference clr) // #1
            {
                return clr.cardList.AllCards();
            }
            else if (stor is CardLocReference[] clra) // #2
            {
                return clra;
            }
            else if (stor is string[] sa)
            {
                return sa;
            }
            else if (stor is List<CardLocReference> clocr) // #4
            {
                return clocr;
            }
            else if (stor is Team t)
            {
                return t.teamPlayers;
            }
            else if (stor is List<int> rsto)
            {
                return (List<object>)stor;
            }
            else if (stor is List<Card> cards) // #3
            {
                return cards;
            }
            else if (stor is List<object> objs) // #??
            {
                return objs;
            }
            else
            {
                Console.WriteLine(stor.GetType().ToString());
                foreach (var s in (List<object>)stor)
                {
                    Console.WriteLine(s.GetType().ToString());
                }
                throw new TypeAccessException();
            }
        }

        private IEnumerable<object> ProcessCollection(RecycleParser.CollectionContext collection)
        {
            string text = collection.GetText();
            if (text == "player")
            {
                Debug.WriteLine("Processing collection type: players.");
                return game.players;
            }
            else if (text == "team")
            {
                Debug.WriteLine("Processing collection type: team.");
                return game.teams;
            }
            else if (collection.varc() is not null)
            {
                return ProcessCollectionVar(collection.varc());
            }
            else if (collection.cstorage() is not null)
            {
                Debug.WriteLine("Processing collection type: Cstorage.");
                var stor = ProcessLocation(collection.cstorage());
                return stor.cardList.AllCards();
            }
            else if (collection.strcollection() is not null)
            {
                Debug.WriteLine("Processing collection type: string collection.");

                return ProcessStringCollection(collection.strcollection());
            }
            else if (collection.cstoragecollection() is not null)
            {
                Debug.WriteLine("Processing collection type: Cstorage collection.");

                return ProcessCStorageCollection(collection.cstoragecollection());
            }
            else if (collection.whot() is not null)
            {
                Debug.WriteLine("Processing collection type: whot.");
                var t = ProcessWhot(collection.whot());
                Debug.WriteLine(t.teamPlayers);

                return t.teamPlayers;
            }
            else if (collection.range() is not null)
            {
                Debug.WriteLine("Processing collection type: range.");

                var lst = ProcessRange(collection.range());
                // WHY ARE WE CLONING THE RANGE AND NOT OTHERS???
                List<object> newlst = [];
                foreach (int num in lst)
                {
                    newlst.Add((object)num);
                }
                return newlst;
            }
            else if (collection.filter() is not null)
            {
                Debug.WriteLine("Processing collection type: filter.");

                // need new case for cstoragecollection 
                if (collection.filter().collection() is not null &&
                    collection.filter().collection().cstoragecollection() is not null)
                {
                    Debug.WriteLine("We made it!!!");
                    return ProcessCStorageCollectionFilter(collection.filter());
                }

                // Only do this if it is a collection filter
                else if (collection.filter().collection() is not null &&
                    collection.filter().collection().cstorage() is not null)
                {
                    var filter = ProcessCStorageFilter(collection.filter());
                    return filter.cardList.AllCards();
                }

                else
                {
                    return ProcessCollectionFilter(collection.filter());
                }


            }
            else if (collection.other() is not null)
            {
                return ProcessOther(collection.other());
            }
            else
            {//var
                Console.WriteLine("Processing collection type: UNKNOWN.");
                throw new Exception();
                //return (IEnumerable<object>)Get(collection.GetText());
            }
        }

        private List<object> ProcessCollectionFilter(RecycleParser.FilterContext filter)
        {

            if (filter.collection() is not null)
            {
                Debug.WriteLine("Phew!");
                var coll = ProcessCollection(filter.collection());
                var flist = new List<object>();

                foreach (object c in coll)
                {
                    string text = filter.var().GetText();
                    variables.Put(text, c);
                    if (ProcessBoolean(filter.boolean()))
                    {
                        flist.Add(c);
                    }
                    variables.Remove(text);
                }
                return flist;
            }
            else
            {
                Console.WriteLine("Collection Filter missing the collection??");
                throw new NotSupportedException();
            }
        }

        private CardLocReference[] ProcessCStorageCollectionFilter(RecycleParser.FilterContext filter)
        {

            if (filter.collection().cstoragecollection() is not null)
            {
                Debug.WriteLine("Phew!");
                var cstorage = ProcessCStorageCollection(filter.collection().cstoragecollection());

                var ret = new List<CardLocReference>(cstorage.Length);

                for (int i = 0; i < cstorage.Length; i++)
                {
                    string text = filter.var().GetText();
                    var cardloc = cstorage[i];
                    variables.Put(text, cardloc);
                    // WHY DO WE NEED cardloc.Count() > 0???
                    if (cardloc.Count() > 0 && ProcessBoolean(filter.boolean()))
                    {
                        ret.Add(cardloc);
                    }
                    variables.Remove(text);
                }
                return [.. ret];
            }
            else
            {
                Console.WriteLine("Card Storage Collection Filter missing collection???");
                throw new NotSupportedException();
            }
        }

        private object? ProcessAggPost(IParseTree parseTree)
        {
            if (parseTree is RecycleParser.Multiaction2Context)
            {
                return (ICloneable)ProcessMultiaction(parseTree);
            }
            else if (parseTree is RecycleParser.ActionContext ac)
            {
                Debug.WriteLine("Processing action.");
                return ProcessAction(ac);
            }
            else if (parseTree is RecycleParser.BooleanContext bc)
            {
                Debug.WriteLine("Processing boolean.");
                return ProcessBoolean(bc);
            }
            else if (parseTree is RecycleParser.CstorageContext csto)
            {
                Debug.WriteLine("Finding card.");
                return ProcessLocation(csto);
            }
            else if (parseTree is RecycleParser.CondactContext ca)
            {
                Debug.WriteLine("Processing condition for conditional action(s).");
                ProcessSingleDo(ca);

                return null;
            }
            else if (parseTree is RecycleParser.RawstorageContext rsa)
            {
                return ProcessIntStorage(rsa);
            }
            Debug.WriteLine("error: Could not parse " + parseTree.GetText());
            throw new NotSupportedException();
        }

        private object ProcessTyped(RecycleParser.TypedContext typed)
        {
            if (typed.@int() is not null)
            {
                Debug.WriteLine("Processing type: int");
                return ProcessInt(typed.@int());
            }
            else if (typed.boolean() is not null)
            {
                Debug.WriteLine("Processing type: boolean");
                return ProcessBoolean(typed.boolean());
            }
            else if (typed.str() is not null)
            {
                Debug.WriteLine("Processing type: str");
                return ProcessString(typed.str());
            }
            else if (typed.collection() is not null)
            {
                Debug.WriteLine("Processing type: collection");
                return ProcessCollection(typed.collection());
            }
            Console.WriteLine("Missing a typed expression???");
            throw new NotSupportedException();
        }

        private List<GameActionCollection> ProcessLet(RecycleParser.LetContext let)
        {
            var ret = new List<GameActionCollection>(); //TODO check this
            // maybe don't need ProcessTyped ? 
            variables.Put(let.var().GetText(), ProcessTyped(let.typed()));
            if (let.multiaction() is not null)
            {
                Debug.WriteLine("Processing let multiaction");
                ret.AddRange(ProcessMultiaction(let.multiaction()));
            }
            else if (let.action() is not null)
            {
                Debug.WriteLine("Processing let action");
                ret.Add(ProcessAction(let.action()));
            }
            else if (let.condact() is not null)
            {
                Debug.WriteLine("Processing let conditional action " + let.condact().GetText());
                ProcessSingleDo(let.condact());
            }
            variables.Remove(let.var().GetText());
            return ret;
        }

        private string ProcessString(RecycleParser.StrContext str)
        {
            if (str.namegr() is not null)
            {
                return str.namegr().GetText();
            }
            else if (str.cardatt() is not null)
            {
                return ProcessCardatt(str.cardatt());
            }
            else if (str.vars() is not null)
            {
                return ProcessStringVar(str.vars());
            }
            else if (str.strstorage() is not null)
            {
                return ProcessStrStorage(str.strstorage()).Get();
            }
            else
            {
                Console.WriteLine("This is not a string...");
                throw new InvalidDataException();
            }
        }

        private int ProcessIntVar(RecycleParser.VariContext varContext)
        {
            var temp = variables.Get(varContext.GetText());
            if (temp is StorageReference<int> raw)
            {
                return raw.Get();
            }
            else if (temp is int v) { return v; }
            else { throw new Exception("Not an int! Temp is " + temp.GetType()); }
        }

        private Owner ProcessOwnerVar(RecycleParser.VaroContext var)
        {
            var temp = variables.Get(var.GetText());
            if (temp is Player p)
            {
                return p;
            }
            else if (temp is Team t)
            {
                return t;
            }
            else { throw new Exception("Not an owner! Temp is " + temp.GetType()); }
        }

        private Player ProcessPlayerVar(RecycleParser.VarpContext var)
        {
            var temp = variables.Get(var.GetText());
            if (temp is Player p)
            {
                return p;
            }
            else { throw new Exception("Not an owner! Temp is " + temp.GetType()); }
        }

        private CardLocReference ProcessCardVar(RecycleParser.VarcardContext card)
        { //TODO get card instead of just top card of location when ret is Card
            var ret = variables.Get(card.GetText());
            if (ret is CardLocReference loc)
            {
                Debug.WriteLine("Are We Here??");
                if (loc.locIdentifier != CardLocTypes.UNDEFINED)
                {
                    return loc.ShallowCopy();
                }

                // ADDING THIS TO MAKE FILTERS WORK!!!!
                return loc.ShallowCopy();
            }
            else if (ret is Card c)
            {
                CardCollection cardl = c.Owner.ShallowCopy();
                CardLocReference clr = new() { cardList = cardl, name = "manufactured variable"};
                clr.SetLocId(c);
                return clr;
            }
            else if (ret is List<Card> clist)
            {
                var cctemp = new CardCollection(CCType.VIRTUAL);
                foreach (var cc in clist)
                {
                    cctemp.Add(cc);
                }
                return new CardLocReference()
                {
                    cardList = cctemp,
                    name = "{cardvar}"
                };
            }
            Console.WriteLine("Error, " + card.GetText() + " is not a  card, type is " + ret.GetType());
            throw new NotImplementedException();
        }

        private string ProcessStringVar(RecycleParser.VarsContext var)
        {
            var temp = variables.Get(var.GetText());
            if (temp is string s)
            {
                return s;
            }
            else
            {
                Console.WriteLine("Error, " + var.GetText() + " is not a string, type is: " + temp.GetType());
                throw new NotImplementedException();
            }
        }

        private CardLocReference ProcessCardStorageVar(RecycleParser.VarcsContext var)
        {
            var temp = variables.Get(var.GetText());
            if (temp is CardLocReference loc)
            {
                return loc;
            }
            else if (temp is List<Card> cards)
            {
                // Why does this happen???
                // I don't think I want to ever be in this method...
                /*CardCollection mycards = new(CCType.VIRTUAL);
                foreach (var card in cards)
                {
                    mycards.Add(card);
                }
                */
                CardCollection mycards = new(CCType.VIRTUAL, cards);
                var fancy = new CardLocReference()
                {
                    cardList = mycards,
                    name = var.GetText() + "WEIRD",
                };
                return fancy;
            }
            else
            {
                Console.WriteLine("Error, type is: " + temp.GetType());
                if (temp is List<CardLocReference> lc)
                {
                    foreach (var c in lc)
                    {
                        Console.WriteLine(c);
                    }
                }
                // WHY ARE YOU BROKEN???
                throw new NotImplementedException();
            }
        }

        private PointMap ProcessPointVar(RecycleParser.VarpContext var)
        {
            var temp = variables.Get(var.GetText());
            if (temp is PointMap pm)
            {
                return pm;
            }
            else
            {
                Console.WriteLine("Error, type is: " + temp.GetType());
                throw new NotImplementedException();
            }
        }

        private static string[] ProcessStringCollection(RecycleParser.StrcollectionContext strcollectionContext)
        {
            string text = strcollectionContext.GetText();
            char[] delimiter = [','];
            text = text.Replace("(", string.Empty);
            text = text.Replace(")", string.Empty);
            var newlst = text.Split(delimiter);
            return newlst;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            { Console.WriteLine("obj is null"); return false; }

            if (obj is not GameIterator other)
            { Console.WriteLine("obj as gameiterator is null"); return false; }

            if (other.rules != rules)
            { Console.WriteLine("rules not equal"); return false; }

            if (!other.variables.Equals(variables))
            { Console.WriteLine("variables not equal"); return false; }

            if (!other.game.Equals(game))
            { Console.WriteLine("Games not equal"); return false; }

            return true;
        }
        public override int GetHashCode() { return 0; }
    }
}


              