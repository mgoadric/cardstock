using Antlr4.Runtime.Tree;
using CardStock.CardEngine;
using CardStock.Scoring;
using System.Diagnostics;

namespace CardStock.FreezeFrame
{
    public class GameIterator
    {
        private readonly Stack<Queue<IParseTree>> iterStack;
        private readonly HashSet<IParseTree> iteratingSet;
        private RecycleVariables variables;
        private Transcript script;

        public RecycleParser.GameContext rules;
        public CardGame game;
        public World gameWorld;
        public int totalChoices;
        public List<Tuple<int, int>> choiceList = [];
        public List<Tuple<int, double[]>> allLeadList = [];
        public List<Tuple<int, double>> spreadList = [];

        public GameIterator(RecycleParser.GameContext context, CardGame mygame, World gameWorld, string fileName, bool fresh = true)
        {
            this.gameWorld = gameWorld;
            rules = context;
            game = mygame;
            iterStack = new Stack<Queue<IParseTree>>();
            iteratingSet = [];
            variables = new RecycleVariables();

            if (fresh)
            {
                script = new Transcript(true, fileName);
                Debug.WriteLine("Processing declarations.");
                foreach (RecycleParser.DeclareContext declare in rules.declare())
                {
                    ProcessDeclare(declare);
                }

                Debug.WriteLine("Setting up game.");
                ProcessSetup(rules.setup()).ExecuteAll();

                iterStack.Push(new Queue<IParseTree>());
                var topLevel = iterStack.Peek();
                for (int i = 3; i < rules.ChildCount - 2; ++i)
                {
                    topLevel.Enqueue(rules.GetChild(i));
                }
            }
        }

        public GameIterator Clone(CardGame newgame) {

            var ret = new GameIterator(rules, newgame, gameWorld, "clone", false)
            {
                script = new Transcript(false, null)
            };

            foreach (var queue in iterStack.Reverse()) {
                var newQueue = new Queue<IParseTree>();
                foreach (var thing in queue) {
                    newQueue.Enqueue(thing);
                }

                ret.iterStack.Push(newQueue);
            }

            foreach (var node in iteratingSet) {
                ret.iteratingSet.Add(node);
            }

            ret.variables = variables.Clone(newgame);

            return ret;
        }

        public void AddLeadsList(Tuple<int, double[]> leads) {
            allLeadList.Add(leads);
        }

        public void AddSpreadList(Tuple<int, double> spreads)
        {
            spreadList.Add(spreads);
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

        public bool AdvanceToChoice() {
            int count = 0;
            while (iterStack.Count != 0 && !ProcessSubStage()) {
                count++;
                if (count > 200) {
                    Console.WriteLine("Game stuck in loop");
                    return true; // game stuck in loop
                }
            }
            if (iterStack.Count == 0) {
                return true; // game over
            }
            Debug.WriteLine(iterStack.Count);
            return false; // interupted by player decision
        }

        public int ProcessChoice()
        {
            var allOptions = BuildOptions();

            /* DEBUG
            foreach (GameActionCollection gac in allOptions) {
                Console.WriteLine("New action list!");
                foreach (GameAction action in gac)
                {
                    Console.WriteLine("\t" + action);
                }
            }
            */
            

            int choice = game.PlayerMakeChoice(allOptions.Count, game.CurrentPlayer().idx);

            if (allOptions.Count != 0)
            {
                Debug.WriteLine("processed choices");
                Debug.WriteLine("Choice count for P" + game.CurrentPlayer().idx + ":" + allOptions.Count);
                allOptions[choice].ExecuteAll();

                Debug.WriteLine("player choice made");
                Debug.WriteLine(game.CurrentPlayer().memberList.Count);
            }
            else
            {
                Console.WriteLine("NO Choice Available");
                throw new InvalidOperationException();
            }

            PopCurrentNode();
            choiceList.Add(new Tuple<int, int>(game.CurrentPlayer().idx, allOptions.Count));
            totalChoices++;
            return choice;
        }

        public List<GameActionCollection> BuildOptions()
        {
            Debug.WriteLine("trying to process choice (in processchoice)");
            Debug.WriteLine("Player turn: " + game.CurrentPlayer().idx);
            Debug.WriteLine("Processing choice.");
            var sub = CurrentNode();
            if (sub is RecycleParser.MultiactionContext choice)
            {
                var choices = choice.condact();
                var allOptions = new List<GameActionCollection>();
                for (int i = 0; i < choices.Length; ++i)
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
            throw new Exception();
        }

        public Tuple<List<Tuple<int, int>>, int> ProcessScore()
        {
            var ret = new List<Tuple<int, int>>();
            var scoreMethod = rules.scoring();

            game.PushPlayer();
            game.CurrentPlayer().SetMember(0);
            for (int i = 0; i < game.players.Length; ++i)
            {
                var working = ProcessInt(scoreMethod.@int());
                script.WriteToFile("s:" + working + " " + i);
                ret.Add(new Tuple<int, int>(working, i));
                game.CurrentPlayer().Next();
                script.WriteToFile("t: " + game.CurrentPlayer().CurrentName());
            }
            game.PopPlayer();

            ret.Sort();
            int mult = -1;
            if (scoreMethod.GetChild(2).GetText() == "max")
            {
                ret.Reverse();
                mult = 1;
            }

            return new Tuple<List<Tuple<int, int>>, int>(ret, mult);
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
            if (setupNode.playercreate() != null)
            {
                Debug.WriteLine("Creating players.");
                var playerCreate = setupNode.playercreate() as RecycleParser.PlayercreateContext;
                var numPlayers = 2;
                if (playerCreate.@int() != null)
                {
                    numPlayers = ProcessInt(playerCreate.@int());
                }
                else
                {
                    // Where is the int?
                    throw new Exception();
                }
                script.WriteToFile("nump:" + numPlayers);
                game.AddPlayers(numPlayers, this);
                script.WriteToFile("t: " + game.currentPlayer.Peek().CurrentName());
                gameWorld.numPlayers = numPlayers;
                //gameWorld.PopulateLead();
            }
            if (setupNode.teamcreate() != null)
            {
                Debug.WriteLine("Creating teams.");
                var teamCreate = ProcessTeamCreate(setupNode.teamcreate(), game);
                ret.Add(new TeamCreateAction(teamCreate, game, script));
            }
            if (setupNode.deckcreate() != null)
            {
                Debug.WriteLine("Creating decks.");
                var decks = setupNode.deckcreate();
                foreach (var deckinit in decks)
                {
                    ret.Add(ProcessDeckCreate(deckinit));
                }
            }
            if (setupNode.repeat() != null)
            {
                foreach (var rep in setupNode.repeat())
                {
                    if (CheckDeckRepeat(rep))
                    {
                        ret.AddRange(ProcessRepeat(rep));
                    }
                    else
                    {
                        throw new InvalidDataException();
                    }
                }
            }
            if (setupNode.teamcreate() == null)
            {
                Debug.WriteLine("Creating teams.");
                var teamcreate = ProcessTeamCreate(null, game);
                ret.Add(new TeamCreateAction(teamcreate, game, script));
            }
            return ret;
        }
        private List<List<int>> ProcessTeamCreate(RecycleParser.TeamcreateContext teamcreate, CardGame cg)
        {
            var ret = new List<List<int>>();
            if (teamcreate != null)
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
            if (reps.action().deckcreate() != null)
            {
                return true;
            }
            else if (reps.action().repeat() != null)
            {
                return CheckDeckRepeat(reps.action().repeat());
            }
            return false;
        }

        private InitializeAction ProcessDeckCreate(RecycleParser.DeckcreateContext deckinit) 
        {
            var locstorage = ProcessLocation(deckinit.cstorage()); 
            var deckTree = ProcessDeck(deckinit.deck());
            if (deckinit.str() == null)
            {
                return new InitializeAction(locstorage.cardList, deckTree, "DEFAULT", game, script);
            }
            else
            {
                return new InitializeAction(locstorage.cardList, deckTree, ProcessString(deckinit.str()), game, script);
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
                Debug.WriteLine(sub.GetType());
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
                if (multiaction.agg() != null)
                {
                    //List<GameAction> test = (List<CardEngine.GameAction>)ProcessAgg(multiaction.agg());
                    //Debug.WriteLine(test[0].GetType());
                    Debug.WriteLine("Processing multiaction aggregation.");
                    lst.Add(ProcessAgg(multiaction.agg()) as GameActionCollection);
                    //lst.AddRange((List<GameActionCollection>)ProcessAgg(multiaction.agg()));
                }
                else if (multiaction.let() != null)
                {
                    Debug.WriteLine("Processing multiaction let statement.");
                    lst.AddRange(ProcessLet(multiaction.let()));
                }
                else if (multiaction.GetChild(1).GetText() == "choice")
                {
                    Debug.WriteLine("Processing multiaction choice block in PROCESSMULTIACTION????.");
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
                if (multi.agg() != null)
                {
                    Debug.WriteLine("Processing multiaction2 aggregation.");
                    lst.Add(ProcessAgg(multi.agg()) as GameActionCollection);
                }
                else if (multi.let() != null)
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
            var stackTrees = new Stack<IteratingTree>();
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
            var stackAct = new Stack<GameAction>();
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
                    if (current.tree != null)
                    {
                        var currentTree = current.tree;
                        if (currentTree is RecycleParser.CondactContext)
                        {
                            var condact = currentTree as RecycleParser.CondactContext;
                            // if the boolean returns true (and exists), 
                            // push the resulting action/multiaction items
                            // on the current stack of iterable items
                            if (condact.boolean() == null || ProcessBoolean(condact.boolean()))
                            {
                                if (condact.action() != null)
                                {

                                    stackTree.Push(condact.action());
                                }
                                if (condact.multiaction2() != null)
                                {
                                    stackTree.Push(condact.multiaction2());
                                }
                            }
                        }

                        else if (currentTree is RecycleParser.Multiaction2Context)
                        {
                            Debug.WriteLine("Finding game actions recursively in a multiaction2 statement.");

                            var multi = currentTree as RecycleParser.Multiaction2Context;
                            // is any or and
                            if (multi.agg() != null)
                            {
                                Debug.WriteLine("multiaction context 2 agg pushed to stack");
                                stackTree.Push(multi.agg());
                            }
                            // is let 
                            else if (multi.let() != null)
                            {
                                stackTree.Push(multi.let());
                            }
                            else
                            { // is do
                              // push all condacts onto current stack
                              // to be processed
                                for (int i = multi.condact().Length - 1; i >= 0; i--)
                                {
                                    stackTree.Push(multi.condact()[i]);
                                }
                            }
                        }
                        else if (currentTree is RecycleParser.MultiactionContext)
                        {
                            Debug.WriteLine("Finding game actions recursively in a multiaction.");
                            // terrible terrible ! someday TODO make this not copy paste
                            // included to allow multiactions after let statement 
                            // if rewritten (to be actually recursive etc etc)
                            // could streamline multi & multi2 to be the same thing
                            var multi = currentTree as RecycleParser.MultiactionContext;
                            if (multi.agg() != null)
                            {
                                stackTree.Push(multi.agg());
                            }
                            // is let 
                            else if (multi.let() != null)
                            {
                                stackTree.Push(multi.let());
                            }
                            else
                            { // is do
                              // push all condacts onto current stack
                              // to be processed

                                for (int i = multi.condact().Length - 1; i >= 0; i--)
                                {
                                    Debug.WriteLine(multi.condact()[i].GetType());
                                    stackTree.Push(multi.condact()[i]);
                                }
                            }

                        }
                        else if (currentTree is RecycleParser.AggContext)
                        {
                            Debug.WriteLine("Finding game actions recursively in an aggregation statement.");

                            var agg = currentTree as RecycleParser.AggContext;
                            var collection = ProcessCollection(agg.collection());
                            if (agg.GetChild(1).GetText() == "any")
                            {
                                // if there is something in the collection
                                if (collection.ToList().Count > 0)
                                {
                                    bool first = true;
                                    object firstItem = null;
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
                        else if (currentTree is RecycleParser.LetContext)
                        {
                            // push name of var, statement after var, name/value pair
                            Debug.WriteLine("Finding game actions recursively in a let statement.");

                            var let = currentTree as RecycleParser.LetContext;
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
                        else if (currentTree is RecycleParser.ActionContext)
                        {
                            Debug.WriteLine("Finding game actions recursively in an action. ");

                            var actions = ProcessAction(currentTree as RecycleParser.ActionContext);
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
                            Debug.WriteLine("failed to parse type " + current.GetType());
                        }
                    }
                    else
                    {//var context

                        if (current.item != null)
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
                    if (!(act is LoopAction))
                    {
                        Debug.WriteLine(act);
                        Debug.WriteLine("Adding non-loop action to collection.");
                        coll.Add(act);
                    }
                }

                while (stackAct.Count > 0 && !(stackAct.Peek() is LoopAction))
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
                }

                // if there are still loopactions,
                //   remove the current one, 
                var currentLevel = 0;
                if (stackAct.Count > 0)
                {
                    var loop = stackAct.Pop() as LoopAction;
                    currentLevel = loop.level;
                    variables.Remove(loop.var);
                }
                // undo everything (until
                bool unwinding = true;
                while (unwinding)
                {
                    // "normal" - item before is loopaction & same level
                    // up one level - item before is loopaction & different level
                    // up one level - items need to be undone before finding loopaction, but is different level
                    // up n levels - 

                    while (stackAct.Count > 0 && !(stackAct.Peek() is LoopAction))
                    {
                        Debug.WriteLine("popping off non-loop action (second time)" + stackAct.Peek());
                        stackAct.Pop().Undo();
                    }
                    if (stackAct.Count > 0)
                    {
                        var loop = stackAct.Peek() as LoopAction;

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
                        unwinding = false;
                    }
                }
            }
            return all;
        }

        //this just queues the appropriate actions if condition is met, doesn't execute
        private bool ProcessStage(RecycleParser.StageContext stage) {
            string text = stage.GetChild(2).GetText();
            if (stage.endcondition().boolean() != null) {

                if (!iteratingSet.Contains(stage)) {
                    if (text == "player")
                    {
                        game.PushPlayer();
                    } else if (text == "team") {
                        game.PushTeam();
                    }
                }

                if (!ProcessBoolean(stage.endcondition().boolean())) {
                    Debug.WriteLine("Processing end of stage condition.");

                    //Debug.WriteLine("Hit Boolean while!");
                    iterStack.Push(new Queue<IParseTree>());
                    var topLevel = iterStack.Peek();
                    Debug.WriteLine("Current Player: " + game.CurrentPlayer().idx + ", " + game.players[game.CurrentPlayer().idx]);
                    Debug.WriteLine("Num players (gameiterator): " + game.CurrentPlayer().memberList.Count);
                    foreach (var player in game.players) {
                        //Console.WriteLine ("HANDSIZE: " + player.cardBins ["{hidden}HAND"].Count);
                    }
                    for (int i = 4; i < stage.ChildCount - 1; ++i) {
                        //TimeStep.Instance.treeLoc.Push(i - 4);
                        //Debug.WriteLine (TimeStep.Instance);
                        //ProcessSubStage(stage.GetChild(i));
                        topLevel.Enqueue(stage.GetChild(i));
                        Debug.WriteLine("Child enqueued: " + stage.GetChild(i).GetText());
                        //TimeStep.Instance.treeLoc.Pop();
                    }
                    if (iteratingSet.Contains(stage)) {
                        if (text == "player") {
                            game.CurrentPlayer().Next();
                            script.WriteToFile("t: " + game.CurrentPlayer().CurrentName());
                        } else if (text == "team") {
                            game.CurrentTeam().Next();
                            script.WriteToFile("t: " + game.CurrentTeam().CurrentName());
                            Debug.WriteLine("Next team is " + game.CurrentTeam().Current());
                        }
                    }

                } else {
                    PopCurrentNode();

                    if (iteratingSet.Contains(stage)) {
                        iteratingSet.Remove(stage);
                        if (text == "player") {
                            game.PopPlayer();
                        } else if (text == "team") {
                            game.PopTeam();
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
            if (actionNode.teamcreate() != null)
            {
                var teamCreate = ProcessTeamCreate(actionNode.teamcreate(), game);
                ret.Add(new TeamCreateAction(teamCreate, game, script));
            }
            else if (actionNode.initpoints() != null)
            {
                var pointAction = actionNode.initpoints();
                ret.Add(PointAction(pointAction));
            }
            else if (actionNode.moveaction() != null)
            {
                Debug.WriteLine("MOVE: '" + actionNode.GetText() + "'");
                var move = actionNode.moveaction();
                ret.Add(ProcessMove(move));
            }
            else if (actionNode.shuffleaction() != null)
            {
                var locations = ProcessLocation(actionNode.shuffleaction().cstorage());
                ret.Add(ProcessShuffle(locations));
            }
            else if (actionNode.setaction() != null)
            {
                var setAction = actionNode.setaction();
                ret.Add(SetAction(setAction));
            }
            else if (actionNode.setstraction() != null)
            {
                var setstrAction = actionNode.setstraction();
                ret.Add(SetStrAction(setstrAction));
            }
            else if (actionNode.incaction() != null)
            {
                var incAction = actionNode.incaction();
                ret.Add(IncAction(incAction));
            }
            else if (actionNode.decaction() != null)
            {
                var decAction = actionNode.decaction();
                ret.Add(DecAction(decAction));
            }
            else if (actionNode.cycleaction() != null)
            {
                ret.Add(CycleAction(actionNode.cycleaction()));
            }
            else if (actionNode.deckcreate() != null)
            {
                ret.Add(ProcessDeckCreate(actionNode.deckcreate()));
            }
            else if (actionNode.turnaction() != null)
            {
                ret.Add(new TurnAction());
            }
            else if (actionNode.repeat() != null)
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
            string text1 = cycle.GetChild(1).GetText();
            string text2 = cycle.GetChild(2).GetText();
            if (text1 == "next")
            {
                //Set next player
                if (cycle.owner() != null)
                {
                    var idx = ProcessOwner(cycle.owner());
                    return new NextAction(game.CurrentPlayer(), idx);
                }
                else if (cycle.varo() != null)
                {
                    var p = ProcessOwnerVar(cycle.varo());
                    if (p is Player p2)
                    {
                        return new NextAction(game.CurrentPlayer(), p2.id);
                    }
                    else
                    {
                        // THIS IS A TEAM??
                        // TODO better exeption type mismatch
                        throw new NotImplementedException();
                    }
                }
                else if (text2 == "next")
                {
                    return new NextAction(game.CurrentPlayer(), game.CurrentPlayer().PeekNext().id);
                }
                else if (text2 == "current")
                {
                    return new NextAction(game.CurrentPlayer(), game.CurrentPlayer().Current().id);
                }
                else if (text2 == "previous")
                {
                    return new NextAction(game.CurrentPlayer(), game.CurrentPlayer().PeekPrevious().id);
                }
            }
            else if (text1 == "current")
            {
                //Set next player
                if (cycle.owner() != null)
                {
                    var idx = ProcessOwner(cycle.owner());
                    return new SetPlayerAction(idx, game, script);
                }
                else if (cycle.varo() != null)
                {
                    var p = ProcessOwnerVar(cycle.varo());
                    if (p is Player p2)
                    {
                        return new SetPlayerAction(p2.id, game, script);
                    }
                    else
                    {
                        // THIS IS A TEAM??
                        // TODO better exeption type mismatch
                        throw new NotImplementedException();
                    }                    
                }
                else if (text2 == "next")
                {
                    return new SetPlayerAction(game.CurrentPlayer().PeekNext().id, game, script);
                }
                else if (text2 == "current")
                {
                    return new SetPlayerAction(game.CurrentPlayer().Current().id, game, script);
                }
                else if (text2 == "previous")
                {
                    return new SetPlayerAction(game.CurrentPlayer().PeekPrevious().id, game, script);
                }
            }
            return null;
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
            if (cond.boolean() == null || ProcessBoolean(cond.boolean())) { DoAction(cond); }
        }

        private void DoAction(RecycleParser.CondactContext cond)
        {
            if (cond.multiaction2() != null)
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
            if (rep.@int() != null)
            {
                idx = ProcessInt(rep.@int());
                for (int i = 0; i < idx; i++)
                {
                    ret.AddRange(ProcessAction(rep.action()));
                }
            }
            else
            { //'all'
                var card1 = ProcessCard(rep.moveaction().card()[0]);
                var card2 = ProcessCard(rep.moveaction().card()[1]);
                idx = card1.cardList.Count;
                for (int i = 0; i < idx; i++)
                {
                    ret.Add(new CardMoveAction(card1, card2, script));

                }
            }
            return ret;
        }

        // TODO if cards can belong to the table or teams, need more cases
        private int ProcessOwner(RecycleParser.OwnerContext owner)
        {
            Debug.WriteLine("Got to OWNER");
            var resultingCard = ProcessCard(owner.card()).Get();
            Debug.WriteLine("Result :" + resultingCard);
            return ((Player)resultingCard.owner.owner.owner).id;
            // Will this crash if not owned by a player?
        }

        private bool ProcessBoolean(RecycleParser.BooleanContext boolNode)
        {
            if (boolNode.intop() != null)
            {

                var intop = boolNode.intop();
                int trueOne = ProcessInt(boolNode.@int(0));
                int trueTwo = ProcessInt(boolNode.@int(1));
                if (intop.EQOP() != null)
                {
                    switch (intop.EQOP().GetText())
                    {
                        case "==": return trueOne == trueTwo;
                        case "!=": return trueOne != trueTwo;
                    }
                }
                else if (intop.COMPOP() != null)
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
            else if (boolNode.UNOP() != null)
            {
                return !ProcessBoolean(boolNode.boolean(0));
            }
            else if (boolNode.BOOLOP() != null)
            {
                string text = boolNode.BOOLOP().GetText();
                if (text == "or")
                {
                    bool flag = false;
                    foreach (var boolean in boolNode.boolean())
                    {
                        flag |= ProcessBoolean(boolean);
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
                    foreach (var boolean in boolNode.boolean())
                    {
                        flag &= ProcessBoolean(boolean);
                        if (!flag)
                        {
                            return flag;
                        }
                    }
                    return flag;
                }
            }
            else if (boolNode.EQOP() != null)
            {
                bool eq = false;
                if (boolNode.EQOP().GetText() == "==")
                {
                    eq = true;
                }

                if (boolNode.str().Length > 0)
                {
                    var t1 = ProcessString(boolNode.str()[0]);
                    var t2 = ProcessString(boolNode.str()[1]);
                    return eq == t1.Equals(t2);
                }
                else if (boolNode.card().Length > 0)
                {
                    var card1 = ProcessCard(boolNode.card()[0]);
                    var card2 = ProcessCard(boolNode.card()[1]);
                    return eq == card1.Equals(card2);
                }
                else if (boolNode.whop().Length > 0)
                {
                    var p1 = ProcessWhop(boolNode.whop()[0]);
                    var p2 = ProcessWhop(boolNode.whop()[1]);
                    return eq == p1.Equals(p2);
                }
                else if (boolNode.whot().Length > 0)
                {
                    var t1 = ProcessWhot(boolNode.whot()[0]);
                    var t2 = ProcessWhot(boolNode.whot()[1]);
                    return eq == t1.Equals(t2);
                }
            }
            else if (boolNode.aggb() != null)
            {
                return (bool)ProcessAggBool(boolNode.aggb());
            }
            throw new NotSupportedException();
        }

        private CardMoveAction ProcessMove(RecycleParser.MoveactionContext move)
        {
            var locOne = ProcessCard(move.card()[0]);
            var locTwo = ProcessCard(move.card()[1]);
            return new CardMoveAction(locOne, locTwo, script);
        }

        private ShuffleAction ProcessShuffle(CardLocReference locations)
        {
            return new ShuffleAction(locations, script);
        }

        private CardLocReference ProcessCard(RecycleParser.CardContext card)
        {
            if (card.maxof() != null)
            {
                var scoring = ProcessPointStorage(card.maxof().pointstorage()).Get();
                var coll = ProcessLocation(card.maxof().cstorage());
                var max = -1;
                Card maxCard = null;

                if (coll.cardList.AllCards().Count() == 0)
                {
                    throw new NotSupportedException();
                }
                foreach (var c in coll.cardList.AllCards())
                {
                    int score = scoring.GetScore(c);
                    if (score == 0)
                    {
                        // Console.WriteLine("Weird Card: " + c);
                    }
                    //Console.WriteLine(c + " = " + score);
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
                    locIdentifier = "top",
                    name = coll.name + "{MAX}"
                };
                return fancy;
            }

            if (card.minof() != null)
            {
                var scoring = ProcessPointStorage(card.minof().pointstorage()).Get();
                var coll = ProcessLocation(card.minof().cstorage());
                var min = Int32.MaxValue;
                Card minCard = null;
                foreach (var c in coll.cardList.AllCards())
                {
                    //MHG when equal, pick randomly
                    if (scoring.GetScore(c) < min || (scoring.GetScore(c) == min && ThreadSafeRandom.Next(0, 2) == 0))
                    {
                        //if (scoring.GetScore(c) < min) {
                        min = scoring.GetScore(c);
                        minCard = c;
                    }
                }
                Debug.WriteLine("MIN:" + minCard);
                var lst = new CardCollection(CCType.VIRTUAL);
                lst.Add(minCard);
                var fancy = new CardLocReference()
                {
                    cardList = lst,
                    locIdentifier = "top",
                    name = coll.name + "{MIN}"
                };
                return fancy;
            }

            if (card.varcard() != null)
            {
                return ProcessCardVar(card.varcard());
            }
            if (card.actual() != null)
            {
                var cardLocations = ProcessCard(card.actual().card());
                cardLocations.actual = true;
                return cardLocations;
            }
            else if (card.cstorage() != null)
            {//cstorage
                var loc = ProcessLocation(card.cstorage());
                if (card.@int() != null)
                {
                    //Console.WriteLine("Is this iT??");
                    var fancy = new CardLocReference()
                    {
                        cardList = loc.cardList,
                        locIdentifier = "" + ProcessInt(card.@int()),
                        name = loc.name
                    };

                    return fancy;

                }
                else
                {
                    var fancy = new CardLocReference()
                    {
                        cardList = loc.cardList,
                        locIdentifier = card.GetChild(1).GetText(),
                        name = loc.name
                    };

                    return fancy;
                }
            }
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

        private List<CardLocReference> ProcessCStorageCollection(RecycleParser.CstoragecollectionContext cstoragecoll)
        {
            if (cstoragecoll.memset() != null)
            {
                var lst = ProcessMemset(cstoragecoll.memset());
                return [.. lst];
            }
            else if (cstoragecoll.aggcs() != null)
            {
                return ProcessAggCStorage(cstoragecoll.aggcs());
            }
            else if (cstoragecoll.let() != null)
            {
                ProcessLet(cstoragecoll.let());
                Debug.WriteLine("let, returning nothing");
                return [];
            }
            throw new NotSupportedException();
        }

        private CardLocReference ProcessLocation(RecycleParser.CstorageContext loc)
        {
            string name = "";
            if (loc.unionof() != null)
            {
                CardCollection temp = new(CCType.VIRTUAL);
                if (loc.unionof().cstorage().Length > 0)
                {
                    foreach (var locChild in loc.unionof().cstorage())
                    {
                        var locs = ProcessLocation(locChild);
                        name += locs.name + " ";
                        foreach (var card in locs.cardList.AllCards())
                        {
                            temp.Add(card);
                        }
                    }
                    name = name[..^1];
                }
                else
                { //agg
                    foreach (var locs in ProcessAggCStorage(loc.unionof().aggcs()))
                    {
                        name += locs.name + " ";
                        foreach (var card in locs.cardList.AllCards())
                        {
                            temp.Add(card);
                        }
                    }
                    name = name[..^1];
                }
                var fancy = new CardLocReference()
                {
                    cardList = temp,
                    name = name + "{UNION}"
                };
                return fancy;
            }
            else if (loc.intersectof() != null)
            {
                CardCollection temp = new(CCType.VIRTUAL);
                if (loc.intersectof().cstorage().Length > 0)
                {
                    Dictionary<Card, int> cardCount = [];
                    foreach (var locChild in loc.intersectof().cstorage())
                    {
                        var locs = ProcessLocation(locChild);
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
                    foreach (KeyValuePair<Card, int> kvp in cardCount)
                    {
                        if (kvp.Value == loc.intersectof().cstorage().Length)
                        {
                            temp.Add(kvp.Key);
                        }
                    }
                    name = name[..^1];
                }
                else
                { //agg
                    Dictionary<Card, int> cardCount = [];
                    foreach (var locs in ProcessAggCStorage(loc.intersectof().aggcs()))
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
                    foreach (KeyValuePair<Card, int> kvp in cardCount)
                    {
                        if (kvp.Value == loc.intersectof().cstorage().Length)
                        {
                            temp.Add(kvp.Key);
                        }
                    }
                    name = name[..^1];
                }
                var fancy = new CardLocReference()
                {
                    cardList = temp,
                    name = name + "{INTERSECTION}"
                };
                return fancy;
            }
            else if (loc.sortof() != null)
            {
                CardCollection temp = new(CCType.VIRTUAL);
                var locs = ProcessLocation(loc.sortof().cstorage());
                // Sort the cards here, be efficient! TODO

                var fancy = new CardLocReference()
                {
                    cardList = temp,
                    name = name + "{SORTED}"
                };
                return fancy;            }
            if (loc.disjunctionof() != null)
            {
                CardCollection temp = new(CCType.VIRTUAL);
                if (loc.disjunctionof().cstorage().Length > 0)
                {
                    Dictionary<Card, int> cardCount = [];
                    foreach (var locChild in loc.disjunctionof().cstorage())
                    {
                        var locs = ProcessLocation(locChild);
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
                    foreach (KeyValuePair<Card, int> kvp in cardCount)
                    {
                        if (kvp.Value == 1)
                        {
                            temp.Add(kvp.Key);
                        }
                    }
                    name = name[..^1];
                }
                else
                { //agg
                    Dictionary<Card, int> cardCount = [];
                    foreach (var locs in ProcessAggCStorage(loc.disjunctionof().aggcs()))
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
                    foreach (KeyValuePair<Card, int> kvp in cardCount)
                    {
                        if (kvp.Value == 1)
                        {
                            temp.Add(kvp.Key);
                        }
                    }
                    name = name[..^1];
                }
                var fancy = new CardLocReference()
                {
                    cardList = temp,
                    name = name + "{DISJUNCTION}"
                };
                return fancy;
            }
            else if (loc.filter() != null)
            {
                // WILL THIS FAIL LATER???
                // OH YES IT DID! IN WEIRD WAYS
                return ProcessCStorageFilter(loc.filter());
            }
            else if (loc.locpre() != null)
            {
                Debug.WriteLine("Loc");
                return ProcessSubLocation(loc);
            }
            else if (loc.memstorage() != null)
            {
                Debug.WriteLine("Tuple Track");
                var identifier = loc.memstorage().GetChild(1).GetText();
                var resultingSet = ProcessMemset(loc.memstorage().memset());
                if (identifier == "top")
                {
                    return resultingSet[0];
                }
                else if (identifier == "bottom")
                {
                    return resultingSet[^1];
                }
                else
                {
                    return resultingSet[Int32.Parse(identifier)];
                }
            }
            // CAN WE REMOVE THIS???? NO!!!
            
            else if (loc.varcs() != null)
            {
                return ProcessCardStorageVar(loc.varcs());
            }
            
            throw new NotSupportedException();
        }

        private CardLocReference[] ProcessMemset(RecycleParser.MemsetContext memset)
        {
            if (memset.tuple() != null)
            {
                var points = ProcessPointStorage(memset.tuple().pointstorage());
                var findEm = new CardGrouping(13, points.Get());
                var cardsToScore = new CardCollection(CCType.VIRTUAL);
                var stor = ProcessLocation(memset.tuple().cstorage());
                foreach (var card in stor.cardList.AllCards())
                {
                    cardsToScore.Add(card);
                }
                var pairs = findEm.TuplesOfSize(cardsToScore, ProcessInt(memset.tuple().@int()));
                var returnList = new CardLocReference[pairs.Count];
                for (int i = 0; i < pairs.Count; ++i)
                {
                    returnList[i] = new CardLocReference()
                    {
                        cardList = pairs[i],
                        name = "{mem}" + points.GetName() + "{p" + i + "}"
                    };
                }
                return returnList;
            }
            // subset code  BUT NO NULL SET?
            if (memset.subset() != null)
            {
                Debug.WriteLine("Found a subset");
                var stor = ProcessLocation(memset.subset().cstorage());
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
                        var subset = new List<Card>();
                        foreach (var card2 in set)
                        {
                            subset.Add(card2);
                        }
                        subset.Add(card);
                        subsettemp.Add(subset);
                    }
                    subsets.AddRange(subsettemp);
                }
                Debug.WriteLine("there are now " + subsets.Count + " subsets");
                var returnList = new List<CardLocReference>();
                foreach (var cardlist in subsets)
                {
                    var cctemp = new CardCollection(CCType.VIRTUAL);
                    foreach (var card in cardlist)
                    {
                        cctemp.Add(card);
                    }
                    returnList.Add(new CardLocReference()
                    {
                        cardList = cctemp,
                        name = "{subset from " + stor.name + "}"
                    });
                }
                return [.. returnList];
            }

            // PARTITON CODE
            if (memset.partition() != null)
            {
                if (memset.partition().cstorage().Length > 0)
                {
                    var partition = new Dictionary<String, CardCollection>();
                    foreach (var memChild in memset.partition().cstorage())
                    {
                        var stor = ProcessLocation(memChild);
                        foreach (var card in stor.cardList.AllCards())
                        {
                            var attr = card.ReadAttribute(ProcessString(memset.partition().str()));
                            if (partition.ContainsKey(attr))
                            {
                                partition[attr].Add(card);
                            }
                            else
                            {
                                partition[attr] = new CardCollection(CCType.VIRTUAL);
                                partition[attr].Add(card);
                            }
                        }
                    }
                    var returnList = new List<CardLocReference>();
                    foreach (KeyValuePair<String, CardCollection> kvp in partition)
                    {
                        returnList.Add(new CardLocReference()
                        {
                            cardList = kvp.Value,
                            name = "{partition}" + "{part: " + kvp + "}"
                        });
                    }
                    return [.. returnList];
                }
                else
                {
                    var partition = new Dictionary<String, CardCollection>();
                    foreach (var stor in ProcessAggCStorage(memset.partition().aggcs()))
                    {
                        foreach (var card in stor.cardList.AllCards())
                        {
                            var attr = card.ReadAttribute(ProcessString(memset.partition().str()));
                            if (partition.TryGetValue(attr, out CardCollection? value))
                            {
                                value.Add(card);
                            }
                            else
                            {
                                partition[attr] = new CardCollection(CCType.VIRTUAL);
                                partition[attr].Add(card);
                            }
                        }

                    }
                    var returnList = new List<CardLocReference>();
                    foreach (KeyValuePair<String, CardCollection> kvp in partition)
                    {
                        returnList.Add(new CardLocReference()
                        {
                            cardList = kvp.Value,
                            name = "{partition}" + "{part: " + kvp + "}"
                        });
                    }
                    return [.. returnList];
                }
            }
            throw new Exception();
        }

        private CardLocReference ProcessSubLocation(RecycleParser.CstorageContext stor)
        {
            string desc = stor.locdesc().GetText();
            CCType prefix;
            if (desc == "vloc")
            {
                prefix = CCType.VISIBLE;
            }
            else if (desc == "iloc")
            {
                prefix = CCType.INVISIBLE;
            }
            else if (desc == "hloc")
            {
                prefix = CCType.HIDDEN;
            }
            else
            {
                prefix = CCType.MEMORY;
            }
            Player player;
            /*
            Console.WriteLine("parent: " + stor.GetText());
            Console.WriteLine("next parent: " + stor.GetText());
            Console.WriteLine("next next parent " + stor.GetText());
            Console.WriteLine(stor);
            Console.WriteLine(stor.GetText());*/
            if (stor.locpre().GetText() == "game")
            {
                string name = ProcessString(stor.str());
                var fancy = new CardLocReference()
                {
                    cardList = game.table[0].cardBins[prefix, name],
                    locIdentifier = "top",
                    name = "t " + prefix + " " + name
                };
                return fancy;
            }
            if (stor.locpre().whop() != null)
            {
                player = ProcessWhop(stor.locpre().whop());
            }
            else
            {
                player = ProcessPlayerVar(stor.locpre().varp());
            }
            var name2 = ProcessString(stor.str());
            var fancy2 = new CardLocReference()
            {
                cardList = player.cardBins[prefix, name2],
                name = player.name + " " + prefix + " " + name2
            };
            return fancy2;
        }
        private string ProcessCardatt(RecycleParser.CardattContext cardatt)
        {
            var loc = ProcessCard(cardatt.card());
            if (loc.cardList.Count > 0)
            {
                var card = loc.Get();
                if (card != null)
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
            if (who.whop() != null)
            {
                return ProcessWhop(who.whop());
            }
            else if (who.whot() != null)
            {
                return ProcessWhot(who.whot());
            }
            throw new Exception();
        }

        private Player ProcessWhop(RecycleParser.WhopContext who)
        {
            if (who.owner() != null)
            {
                var loc = ProcessCard(who.owner().card());
                return (Player)loc.Get().owner.owner.owner;
            }
            else
            {
                string text = who.GetChild(1).GetText();
                if (text == "current")
                {
                    return game.CurrentPlayer().Current();
                }
                else if (text == "next")
                {
                    return game.CurrentPlayer().PeekNext();
                }
                else if (text == "previous")
                {
                    return game.CurrentPlayer().PeekPrevious();
                }
                else if (who.whodesc().@int() != null)
                {
                    return game.players[ProcessInt(who.whodesc().@int())];
                }
            }
            throw new Exception();
        }

        private Team ProcessWhot(RecycleParser.WhotContext who)
        {
            if (who.teamp() != null)
            {
                if (who.teamp().varp() != null)
                {
                    var p = ProcessPlayerVar(who.teamp().varp());
                    if (p != null)
                    {
                        return p.team;
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
                else
                {
                    return ProcessWhop(who.teamp().whop()).team;
                }
            }
            else
            {
                string text = who.GetChild(1).GetText();
                if (text == "current")
                {
                    return game.CurrentTeam().Current();
                }
                else if (text == "next")
                {
                    //throw new NotImplementedException();
                    return game.CurrentTeam().PeekNext();
                }
                else if (text == "previous")
                {
                    //throw new NotImplementedException();
                    return game.CurrentTeam().PeekPrevious();
                }
                else if (who.whodesc().@int() != null)
                {
                    return game.teams[ProcessInt(who.whodesc().@int())];
                }
            }
            throw new Exception();
        }

        private Tree ProcessDeck(RecycleParser.DeckContext deck)
        {
            //var attributeCount = deck.ChildCount - 3;

            List<Node> childs = [];
            for (int i = 0; i < deck.attribute().Length; ++i)
            {
                childs.Add(new Node
                {
                    Value = "combo" + i,
                    children = ProcessAttribute(deck.attribute(i))
                });
            }
            return new Tree
            {
                rootNode = new Node
                {
                    Value = "Attrs",
                    children = childs
                }
            };
        }


        private List<Node> ProcessAttribute(RecycleParser.AttributeContext attr) //TODO make this array!!
        {
            var ret = new List<Node>();
            if (attr.attribute()[0].attribute().Length == 0)
            {
                var terminalTitle = attr.namegr()[0];
                var subNode = attr.attribute()[0];

                var trueCount = (subNode.ChildCount - 3) / 2 + 1;
                for (int i = 0; i < trueCount; ++i)
                {
                    ret.Add(new Node
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
                    var childs = new List<Node>();
                    foreach (var att in subNode.attribute())
                    {
                        childs.AddRange(ProcessAttribute(att));
                    }
                    ret.Add(new Node
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
            if (intNode.rawstorage() != null)
            {
                var fancy = ProcessIntStorage(intNode.rawstorage());
                return fancy.Get();
            }
            else if (intNode.INTNUM() != null && intNode.INTNUM().Any())
            {
                Debug.WriteLine(intNode.GetText());
                return int.Parse(intNode.GetText());
            }
            else if (intNode.@sizeof() != null)
            {
                RecycleParser.CollectionContext coll = intNode.@sizeof().collection();
                return ProcessCollection(coll).Count();
            }
            else if (intNode.mult() != null)
            {
                return ProcessInt(intNode.mult().@int(0)) * ProcessInt(intNode.mult().@int(1));
            }
            else if (intNode.subtract() != null)
            {
                return ProcessInt(intNode.subtract().@int(0)) - ProcessInt(intNode.subtract().@int(1));
            }
            else if (intNode.mod() != null)
            {
                return ProcessInt(intNode.mod().@int(0)) % ProcessInt(intNode.mod().@int(1));
            }
            else if (intNode.divide() != null)
            {
                return ProcessInt(intNode.divide().@int(0)) / ProcessInt(intNode.divide().@int(1));
            }
            else if (intNode.@add() != null)
            {
                return ProcessInt(intNode.@add().@int(0)) + ProcessInt(intNode.@add().@int(1));
            }
            else if (intNode.exponent() != null)
            {
                return Convert.ToInt32(Math.Pow(ProcessInt(intNode.exponent().@int(0)), ProcessInt(intNode.exponent().@int(1))));
            }
            else if (intNode.fibonacci() != null) 
            {
                return ProcessFibonacci(intNode.fibonacci());
            }
            else if (intNode.triangular() != null) 
            {
                return ProcessTriangular(intNode.triangular());
            }
            else if (intNode.random() != null)
            {
                return ProcessRandom(intNode.random());
            }
            else if (intNode.sum() != null)
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
            else if (intNode.score() != null)
            {
                Debug.WriteLine("trying to score" + intNode.GetText());
                var scorer = ProcessPointStorage(intNode.score().pointstorage()).Get();
                var card = ProcessCard(intNode.score().card());
                int score = scorer.GetScore(card.Get());
                Debug.WriteLine(card + " = " + score);
                return score;
            }
            else if (intNode.vari() != null)
            {
                return ProcessIntVar(intNode.vari());
            }
            else
            {
                throw new InvalidDataException();
            }
        }

        private List<int> ProcessRange(RecycleParser.RangeContext range)
        {
            int int1 = ProcessInt(range.@int()[0]);
            int int2 = ProcessInt(range.@int()[1]);
            List<int> ret = [];
            for (int idx = int1; idx <= int2; idx++)
            {
                ret.Add(idx);
            }
            return ret;
        }

        private int ProcessRandom(RecycleParser.RandomContext random)
        {
            int int1 = ProcessInt(random.@int()[0]);
            if (random.GetChild(4) != null) // if second integer is included
            {
                // Console.WriteLine("Second variable included.");
                int int2 = ProcessInt(random.@int()[1]);
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

        private IntStorageReference ProcessIntStorage(RecycleParser.RawstorageContext intSto)
        {
            var who = game.table[0];
            if (intSto.who() != null)
            {
                who = ProcessWho(intSto.who());
            }
            else if (intSto.varo() != null)
            {
                who = ProcessOwnerVar(intSto.varo());
            }
            return new IntStorageReference(who.intBins, ProcessString(intSto.str()));
        }

        private StrStorageReference ProcessStrStorage(RecycleParser.StrstorageContext strSto)
        {
            var who = game.table[0];
            if (strSto.who() != null)
            {
                who = ProcessWho(strSto.who());
            }
            else if (strSto.varo() != null)
            {
                who = ProcessOwnerVar(strSto.varo());
            }
            return new StrStorageReference(who.stringBins, ProcessString(strSto.str()));        }

        private PointStorageReference ProcessPointStorage(RecycleParser.PointstorageContext ptSto)
        {
            var who = game.table[0];
            if (ptSto.who() != null)
            {
                who = ProcessWho(ptSto.who());
            }
            else if (ptSto.varo() != null)
            {
                who = ProcessOwnerVar(ptSto.varo());
            }
            return new PointStorageReference(who.pointBins, ProcessString(ptSto.str()));
        }

        private GameAction SetAction(RecycleParser.SetactionContext setAction)
        {
            var bin = ProcessIntStorage(setAction.rawstorage());
            var setValue = ProcessInt(setAction.@int());
            return new IntAction(bin.Storage, bin.Key, setValue, script);
        }

        private GameAction SetStrAction(RecycleParser.SetstractionContext setAction)
        {
            var bin = ProcessStrStorage(setAction.strstorage());
            var setValue = ProcessString(setAction.str());
            return new StrAction(bin.Storage, bin.Key, setValue, script);
        }


        private GameAction PointAction(RecycleParser.InitpointsContext points)
        {
            var bin = ProcessPointStorage(points.pointstorage());

            List<ValueTuple<string, string, int>> temp = [];
            var awards = points.awards();
            foreach (RecycleParser.AwardsContext award in awards)
            {
                string key = "";
                string value = "";
                int reward = ProcessInt(award.@int());
                var iter = award.subaward();
                foreach (RecycleParser.SubawardContext i in iter)
                {
                    // TODO Is this working properly? I don't think so!
                    key += ProcessString(i.str()[0]) + ",";
                    value += ProcessString(i.str()[1]) + ",";
                    Debug.WriteLine("*** Found ...)" + value);

                }
                key = key.Substring(0, key.Length - 1);
                value = value.Substring(0, value.Length - 1);
                script.WriteToFile("A:" + value + " " + reward);
                temp.Add(new ValueTuple<string, string, int>(key, value, reward));
            }
            var setValue = new PointMap(temp);
            return new PointsAction(bin.Storage, bin.Key, setValue, script);
        }

        private GameAction IncAction(RecycleParser.IncactionContext setAction)
        {
            var bin = ProcessIntStorage(setAction.rawstorage());
            var setValue = ProcessInt(setAction.@int());
            var newVal = bin.Get() + setValue;
            return new IntAction(bin.Storage, bin.Key, newVal, script);
        }
        private GameAction DecAction(RecycleParser.DecactionContext setAction)
        {
            var bin = ProcessIntStorage(setAction.rawstorage());
            var setValue = ProcessInt(setAction.@int());
            var newVal = bin.Get() - setValue;
            return new IntAction(bin.Storage, bin.Key, newVal, script);
        }

        private CardLocReference ProcessCStorageFilter(RecycleParser.FilterContext filter)
        {
            var cList = new CardCollection(CCType.VIRTUAL);
            IEnumerable<Card> stor2 = null;
            String name2 = "";

            if (filter.collection().cstorage() != null)
            {
                Debug.WriteLine("Filter: cstorage collection");
                CardLocReference stor = ProcessLocation(filter.collection().cstorage());
                stor2 = stor.cardList.AllCards();
                name2 = stor.name;
            }
            else if (filter.collection().varc() != null)
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
                throw new NotSupportedException();
            }

            foreach (Card card in stor2)
            {
                string text = filter.var().GetText();
                variables.Put(text, card);
                if (ProcessBoolean(filter.boolean()))
                {
                    cList.Add(card);
                }
                variables.Remove(text);
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
            var ret = new List<object>();
            foreach (var t in stor)
            {
                Debug.WriteLine("Iterating over aggregation of: " + t.GetType());
                variables.Put(var.GetText(), t);
                var post = ProcessAggPost(tree);
                ret.Add(post);
                variables.Remove(var.GetText());
            }
            return ret;
        }

        private object ProcessAgg(RecycleParser.AggContext agg)
        {
            var ret = IterateAgg(agg.collection(), agg.var(), agg.GetChild(4));
            Debug.WriteLine(ret.Count);
            // Not sure what we're doing here anymore after cleanup. 
            // Are the actions executed in IterateAgg? ..
            return ret;
        }

        private List<CardLocReference> ProcessAggCStorage(RecycleParser.AggcsContext agg)
        {
            var ret = IterateAgg(agg.collection(), agg.var(), agg.GetChild(4));

            Debug.WriteLine(ret.Count);

            Debug.WriteLine("Processing agg + Cstorage: " + (((RecycleParser.CstorageContext)agg.GetChild(4)).GetText()));
            var coll = new List<CardLocReference>();
            foreach (object obj in ret)
            {
                coll.Add((CardLocReference)obj);
            }
            return coll;
        }

        private int ProcessAggIntStorage(RecycleParser.AggiContext agg)
        {
            var ret = IterateAgg(agg.collection(), agg.var(), agg.GetChild(4));

            Debug.WriteLine(ret.Count);

            Debug.WriteLine("Processing agg + IntStorage: " + (((RecycleParser.RawstorageContext)agg.GetChild(4)).GetText()));
            var sum = 0;
            foreach (object obj in ret)
            {
                var raw = (IntStorageReference)obj;
                sum += raw.Get();
            }
            return sum;
            
        }
        private bool ProcessAggBool(RecycleParser.AggbContext agg)
        {
            Debug.WriteLine("Processing agg + Boolean: " + (((RecycleParser.BooleanContext)agg.GetChild(4)).GetText()));

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
            else if (stor is List<Object> objs) // #??
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

            if (collection.varc() != null)
            {
                return ProcessCollectionVar(collection.varc());
            }
            string text = collection.GetText();
            if (collection.cstorage() != null)
            {
                Debug.WriteLine("Processing collection type: Cstorage.");
                var stor = ProcessLocation(collection.cstorage());
                return stor.cardList.AllCards();
            }
            else if (collection.strcollection() != null)
            {
                Debug.WriteLine("Processing collection type: string collection.");

                return ProcessStringCollection(collection.strcollection());
            }
            else if (collection.cstoragecollection() != null)
            {
                Debug.WriteLine("Processing collection type: Cstorage collection.");

                return ProcessCStorageCollection(collection.cstoragecollection());
            }
            else if (collection.whot() != null)
            {
                Debug.WriteLine("Processing collection type: whot.");
                var t = ProcessWhot(collection.whot());
                Debug.WriteLine(t.teamPlayers);

                return t.teamPlayers;
            }
            else if (collection.range() != null)
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
            else if (collection.filter() != null)
            {
                Debug.WriteLine("Processing collection type: filter.");

                // need new case for cstoragecollection 
                if (collection.filter().collection() != null &&
                    collection.filter().collection().cstoragecollection() != null)
                {
                    Debug.WriteLine("We made it!!!");
                    return ProcessCStorageCollectionFilter(collection.filter());
                }

                // Only do this if it is a collection filter
                else if (collection.filter().collection() != null &&
                    collection.filter().collection().cstorage() != null)
                {
                    var filter = ProcessCStorageFilter(collection.filter());
                    return filter.cardList.AllCards();
                }

                else
                {
                    return ProcessCollectionFilter(collection.filter());
                }


            }
            else if (text == "player")
            {
                Debug.WriteLine("Processing collection type: players.");

                return game.players;
            }
            else if (text == "team")
            {
                Debug.WriteLine("Processing collection type: team.");
                return game.teams;
            }
            else if (collection.other() != null)
            {
                return ProcessOther(collection.other());
            }
            else
            {//var
                Console.WriteLine("Processing collection type: UNKNOWN.");
                throw new Exception();
                //return (IEnumerable<object>)Get(collection.GetText());
            }
            throw new NotSupportedException();
        }

        private List<Object> ProcessCollectionFilter(RecycleParser.FilterContext filter)
        {

            if (filter.collection() != null)
            {
                Debug.WriteLine("Phew!");
                var coll = ProcessCollection(filter.collection());
                var flist = new List<Object>();

                foreach (Object c in coll)
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
                throw new NotSupportedException();
            }
        }

        private List<CardLocReference> ProcessCStorageCollectionFilter(RecycleParser.FilterContext filter)
        {

            if (filter.collection().cstoragecollection() != null)
            {
                Debug.WriteLine("Phew!");
                var cstorage = ProcessCStorageCollection(filter.collection().cstoragecollection());

                var flist = new List<CardLocReference>();

                foreach (CardLocReference cardloc in cstorage)
                {
                    string text = filter.var().GetText();
                    variables.Put(text, cardloc);
                    // WHY DO WE NEED cardloc.Count() > 0???
                    if (cardloc.Count() > 0 && ProcessBoolean(filter.boolean()))
                    {
                        flist.Add(cardloc);
                    }
                    variables.Remove(text);
                }
                return flist;
            }
            else
            {
                throw new NotSupportedException();
            }
        }

         private object? ProcessAggPost(IParseTree parseTree)
        {
            if (parseTree is RecycleParser.Multiaction2Context)
            {
                return (ICloneable) ProcessMultiaction(parseTree);
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
            if (typed.@int() != null)
            {
                Debug.WriteLine("Processing type: int");
                return ProcessInt(typed.@int());
            }
            else if (typed.boolean() != null)
            {
                Debug.WriteLine("Processing type: boolean");
                return ProcessBoolean(typed.boolean());
            }
            else if (typed.str() != null)
            {
                Debug.WriteLine("Processing type: str");
                return ProcessString(typed.str());
            }
            else if (typed.collection() != null)
            {
                Debug.WriteLine("Processing type: collection");
                return ProcessCollection(typed.collection());
            }
            throw new NotSupportedException();
        }

        private List<GameActionCollection> ProcessLet(RecycleParser.LetContext let)
        {
            var ret = new List<GameActionCollection>(); //TODO check this
            // maybe don't need ProcessTyped ? 
            variables.Put(let.var().GetText(), ProcessTyped(let.typed()));
            if (let.multiaction() != null)
            {
                Debug.WriteLine("Processing let multiaction");
                ret.AddRange(ProcessMultiaction(let.multiaction()));
            }
            else if (let.action() != null)
            {
                Debug.WriteLine("Processing let action");
                ret.Add(ProcessAction(let.action()));
            }
            else if (let.condact() != null)
            {
                Debug.WriteLine("Processing let conditional action " + let.condact().GetText());
                ProcessSingleDo(let.condact());
            }
            variables.Remove(let.var().GetText());
            return ret;
        }

        private string ProcessString(RecycleParser.StrContext str)
        {
            if (str.namegr() != null)
            {
                return str.namegr().GetText();
            }
            else if (str.cardatt() != null)
            {
                return ProcessCardatt(str.cardatt());
            }
            else if (str.vars() != null)
            {
                return ProcessStringVar(str.vars());
            }
            else if (str.strstorage() != null)
            {
                return ProcessStrStorage(str.strstorage()).Get();
            }
            else
            {
                throw new InvalidDataException();
            }
        }

        private int ProcessIntVar(RecycleParser.VariContext varContext)
        {
            var temp = variables.Get(varContext.GetText());
            if (temp is IntStorageReference raw)
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
                if (loc.locIdentifier != "-1")
                {
                    return loc.ShallowCopy();
                }

                // ADDING THIS TO MAKE FILTERS WORK!!!!
                return loc.ShallowCopy();
            }
            else if (ret is Card c)
            {
                CardCollection cardl = c.owner.ShallowCopy();
                CardLocReference clr = new() { cardList = cardl, name = "manufactured variable" };
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
            Debug.WriteLine("error, not a card, type is " + ret.GetType());
            throw new NotImplementedException();
        }

        private string ProcessStringVar(RecycleParser.VarsContext var)
        {
            var temp = variables.Get(var.GetText());
            if (temp is String s)
            {
                return s;
            }
            else
            {
                Debug.WriteLine("Error, not a string, type is: " + temp.GetType());
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
                CardCollection mycards = new(CCType.VIRTUAL);
                foreach (var card in cards)
                {
                    mycards.Add(card);
                }
                var fancy = new CardLocReference()
                {
                    cardList = mycards,
                    name = var.GetText() + "WEIRD",
                };
                return fancy;
            }
            else
            {
                Console.WriteLine("Error, not a string, type is: " + temp.GetType());
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
                Debug.WriteLine("Error, type is: " + temp.GetType());
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
            if (obj == null)
            { Console.WriteLine("obj is null"); return false; }

            GameIterator other = obj as GameIterator;
            if (obj == null)
            { Console.WriteLine("obj as gameiterator is null"); return false; }

            if (other.gameWorld != gameWorld)
            { Console.WriteLine("gameworlds not equal"); return false; }

            if (other.rules != rules)
            { Console.WriteLine("rules not equal"); return false; }

            if (!other.variables.Equals(variables))
            { Console.WriteLine("variables not equal"); return false; }

            if (!other.game.Equals(game))
            { Console.WriteLine("Games not equal"); return false; }

            return true;
        }
    }
}


              