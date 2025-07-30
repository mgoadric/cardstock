using System.Diagnostics;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame {

    public abstract class GameAction {
        public bool inChoice = false;
        public bool complete;
        public CardGame cg;
        public Transcript script;
        public void ExecuteActual(){
            inChoice = false;
            Execute();
        }
        public void TempExecute()
        {
            inChoice = true;
            Execute();
        }
        public abstract void Execute();
        public abstract void Undo();
    }

    public class GameActionCollection : List<GameAction>
    {
        public GameActionCollection() : base()
        {

        }
        public void ExecuteAll()
        {
            foreach (var gameColl in this)
            {
                gameColl.ExecuteActual();
            }
        }
        public void UndoAll()
        {
            foreach (var gameColl in this)
            {
                Debug.WriteLine("Undoing actions in gameActionCollection" + gameColl);
                gameColl.Undo();
            }
        }
        public override string ToString()
        {
            string toReturn = "";
            foreach (var g in this)
            {
                toReturn += g.ToString();
            }
            return toReturn;
        }
    }

    public class CardMoveAction : GameAction {
        public CardLocReference startLocation;
        public CardLocReference endLocation;
        public CardCollection owner;
        public bool actualloc;
        public CardMoveAction(CardLocReference start, CardLocReference end, Transcript script) {
            if (end.cardList.type == CCType.VIRTUAL) {
				Debug.WriteLine("end is not physical");
				throw new NotSupportedException();
            }
            startLocation = start;
            endLocation = end;
            this.script = script;
        }

        public override void Execute() {
            try {
                if (startLocation.Count() != 0) {

                    Card cardToMove = startLocation.Remove();
                    if (startLocation.actual) {
                        actualloc = true;
                    }

                    endLocation.Add(cardToMove);
                    owner = cardToMove.owner;
                    cardToMove.owner = endLocation.cardList;

                    var prefix = "M:";
                    var arrow = " -> ";
                    if (inChoice) { prefix = "N:"; arrow = " ?-> "; }

                    script.WriteToFile(prefix + cardToMove.ToString() + " " + owner.TranscriptName() + arrow + endLocation.cardList.TranscriptName());

                    Debug.WriteLine("Moved Card '" + cardToMove + " to " + endLocation.locIdentifier);
                }
                else {
                    Console.WriteLine("error: attempting to move from empty location " + startLocation.ToString()); //TODO debug here
                    Console.WriteLine("moving to " + endLocation.ToString());
                    throw new Exception();
                }
            }
            catch
            {
                Debug.WriteLine(startLocation.name);
                foreach (var card in startLocation.cardList.AllCards())
                {
                    Debug.WriteLine(card);
                }
                throw;
            }
            complete = true;
        }

        public override void Undo()
        {
            if (complete) {
                Debug.WriteLine("Undoing FancyCardMoveAction. Putting back in: " + startLocation.name); 
                var cardToMove = endLocation.Remove();
                startLocation.Add(cardToMove);
                if (actualloc) {
                    owner.Add(cardToMove);
                }
                cardToMove.owner = owner;
            }
            else {
                Debug.WriteLine("move has not been executed yet");
                throw new NotSupportedException();
            }
        }
        public override string ToString()
        {
            return "CardMoveAction: StartLocation: "
                                                         + startLocation.name + "; EndLocation: " + endLocation.name;
            
        }
    }

    public class ShuffleAction : GameAction
    {
        private CardLocReference locations;
        private CardCollection unshuffled;

        public ShuffleAction(CardLocReference locations, Transcript script)
        {
            this.locations = locations;
            unshuffled = new CardCollection(CCType.VIRTUAL);
            this.script = script;
        }

        public override void Execute() {
            foreach (Card c in locations.cardList.AllCards())
            {
                unshuffled.Add(c);
            }
            locations.cardList.Shuffle();
			script.WriteToFile("O:" + locations.cardList); 
		}
        public override void Undo()
        {
            locations.cardList.Clear();
            foreach (Card c in unshuffled.AllCards())
            {
                locations.Add(c);
            }
        }
		public override string ToString()
		{
            return "ShuffleAction. Location: " + locations.name;
		}
    }


    public class TurnAction : GameAction {
        public TurnAction(Transcript script)
        {
            this.script = script;
        }

        public override void Execute()
        {
            script.WriteToFile("P:passing");
        }
        public override void Undo() {

        }
		public override string ToString()
		{
            return "TurnAction";
		}
    }

    public class TeamCreateAction : GameAction {
        private List<List<int>> teamList;
        public TeamCreateAction(List<List<int>> teamList, CardGame cg, Transcript script) {
            this.teamList = teamList;
            this.cg = cg;
            this.script = script;
        }

        public override void Execute()
        {
            var numTeams = teamList.Count;
            for (int i = 0; i < numTeams; i++)
            {
                var newTeam = new Team("" + i, i);
                var teamStr = "T:";
                for (int j = 0; j < teamList[i].Count; j++)
                {
                    newTeam.teamPlayers.Add(cg.players[teamList[i][j]]);
                    cg.players[teamList[i][j]].team = newTeam;
                }
                teamStr += i + " ";
                cg.teams.Add(newTeam);
                script.WriteToFile(teamStr);
            }

            cg.currentTeam.Push(new StageCycle<Team>(cg.teams));
            Debug.WriteLine("NUMTEAMS:" + cg.teams.Count);
		}

        public override void Undo()
        {
            throw new NotImplementedException();
        }
		public override string ToString()
		{
            return "TeamCreateAction: " + teamList.ToString();
		}
    }

    public class InitializeAction : GameAction {
        CardCollection location;
        CardCollection before;
        Tree deck;
        string name;
        public InitializeAction(CardCollection loc, Tree d, string n, CardGame cg, Transcript script) {
            location = loc;
            before = new CardCollection(CCType.VIRTUAL);
            deck = d;
            this.name = n;
            this.cg = cg;
            this.script = script;
        }
        public override void Execute() {
            foreach (Card c in location.AllCards())
            {
                before.Add(c);
            }
            cg.SetDeck(deck, location, name, script);
        }
        public override void Undo()
        {
            location.Clear();
            foreach (Card c in before.AllCards())
            {
                location.Add(c);
            }
        }
		public override string ToString()
		{
            return "InitializeAction: " + "Location: " + location.name + "; Cards: " + location.AllCards();
		}
    }

    public class IntAction : GameAction {

        DefaultStorage<int> bins;
        string key;
        int value;
        int oldValue;

        public IntAction(DefaultStorage<int> storage, string bKey, int v, Transcript script) {
            bins = storage;
            key = bKey;
            value = v;
            this.script = script;
        }
        public override void Execute() {
            oldValue = bins[key];
            bins[key] = value;
            complete = true;
            script.WriteToFile("S:" + bins.owner.name + " " + key + " " + value);
        }
        public override void Undo() {
            if (complete)
            {
                bins[key] = oldValue;
                complete = false;
            }
            else {
                throw new UnauthorizedAccessException();
            }
        }
		public override string ToString()
		{
            return "IntAction: value: " + value.ToString();
		}
    }

        public class StrAction : GameAction {

        DefaultStorage<string> bins;
        string key;
        string value;
        string oldValue;

        public StrAction(DefaultStorage<string> storage, string bKey, string v, Transcript script) {
            bins = storage;
            key = bKey;
            value = v;
            this.script = script;
        }
        public override void Execute() {
            oldValue = bins[key];
            bins[key] = value;
            complete = true;
            script.WriteToFile("S:" + bins.owner.name + " " + key + " " + value);
        }
        public override void Undo() {
            if (complete)
            {
                bins[key] = oldValue;
                complete = false;
            }
            else {
                throw new UnauthorizedAccessException();
            }
        }
		public override string ToString()
		{
            return "StrAction: value: " + value.ToString();
		}
    }


    public class PointsAction : GameAction
    {

        DefaultStorage<PointMap> bins;
        string key;
        PointMap value;
        PointMap oldValue;

        public PointsAction(DefaultStorage<PointMap> storage, string bKey, PointMap v, Transcript script)
        {
            bins = storage;
            key = bKey;
            value = v;
            this.script = script;
        }
        public override void Execute()
        {
            oldValue = bins[key];
            bins[key] = value;
            complete = true;
            script.WriteToFile("S:" + bins.owner.name + " " + key + " " + value);
        }
        public override void Undo()
        {
            if (complete)
            {
                bins[key] = oldValue;
                complete = false;
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }
        public override string ToString()
        {
            return "IntAction: value: " + value.ToString();
        }
    }

    public class NextAction : GameAction
    {
        private StageCycle<Player> playerCycle;
        private int idx;
        private int former = -1;

        public NextAction(StageCycle<Player> playerCycle, int idx) {
            this.playerCycle = playerCycle;
            this.idx = idx;
        }

        public override void Execute()
        {
            // someone already in the queue
            if (playerCycle.queuedNext != -1) {
                former = playerCycle.queuedNext;
			}
            playerCycle.SetNext(idx);
        }

        public override void Undo()
        {
            if (former != -1)
            {
                playerCycle.SetNext(former);
            } else {
                playerCycle.RevertNext();
            }
            //Console.WriteLine("Reverting: " + former);

        }
		public override string ToString()
		{
            return "NextAction: Next player: " + idx.ToString();
		}
    }

    public class SetPlayerAction : GameAction
    {
        private int idx;
        private int former;
        public SetPlayerAction(int idx, CardGame cg, Transcript script) {
            this.idx = idx;
            this.cg = cg;
            this.script = script;
        }

        public override void Execute()
        {
            former = cg.CurrentPlayer().Current().id;
            cg.CurrentPlayer().SetMember(idx);
            script.WriteToFile("t: " + cg.CurrentPlayer().CurrentName());
        }

        public override void Undo()
        {
            cg.CurrentPlayer().SetMember(former);
            script.WriteToFile("t: " + cg.CurrentPlayer().CurrentName());
        }

		public override string ToString()
		{
            return "SetPlayerAction: Set player: " + idx.ToString();
		}
    }

    // NOT A REAL GAME ACTION, USED IN RECURSEDO FOR GENERATING CHOICES...
    public class LoopAction : GameAction{
        public string var;
        public object item;
        public int level;

        public LoopAction(string v, object item, int level){
            this.var = v;
            this.item = item;
            this.level = level;
        }

        public override void Execute()
        {
            throw new Exception();
        }

        public override void Undo()
        {
            throw new Exception();
        }
		public override string ToString()
		{
            return "LoopAction: " + var;
		}
    }
}