using System.Diagnostics;
using System.Net.NetworkInformation;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame {

    public abstract class GameAction(char prefix, Transcript script) {
        public bool inChoice = false;
        public bool complete;
        public CardGame cg;
        public Transcript? script = script;
        public char prefix = prefix;
        public void ExecuteActual()
        {
            inChoice = false;
            prefix = char.ToUpper(prefix);
            Execute();
        }
        public void TempExecute()
        {
            inChoice = true;
            prefix = char.ToLower(prefix);
            Execute();
        }
        public abstract void Execute();
        public abstract void Undo();
    }

    public class GameActionCollection : List<GameAction>
    {

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

    public class CardMoveAction : GameAction
    {
        public CardLocReference startLocation;
        public CardLocReference endLocation;
        public CardCollection owner;
        public Card cardToMove;
        public bool actualloc;
        public int ownerIndex;
        public CardMoveAction(CardLocReference start, CardLocReference end, Transcript script) : base('M', script)
        {
            if (start.cardList.type == CCType.MEMORY)
            {
                Debug.WriteLine("start is a mem loc " + start.name + ", " + end.name);
                throw new NotSupportedException();
            }
            if (start.cardList.type == CCType.VIRTUAL)
            {
                Debug.WriteLine("start is a virtual loc " + start.name + ", " + end.name);
                actualloc = true;
            }
            if (end.cardList.type == CCType.VIRTUAL || end.cardList.type == CCType.MEMORY)
            {
                Debug.WriteLine("end is not physical");
                throw new NotSupportedException();
            }
            startLocation = start;
            endLocation = end;

            if (start.cardList.type == CCType.VISIBLE && end.cardList.type != CCType.VISIBLE)
            {
                //Console.WriteLine("Hiding a card that is known!!! " + start.cardList.name + " -> " + end.car);
            }
        }

        public override void Execute()
        {
            try
            {
                if (startLocation.Count() != 0)
                {

                    cardToMove = startLocation.Remove();

                    endLocation.Add(cardToMove);
                    owner = cardToMove.Owner;
                    cardToMove.Owner = endLocation.cardList;

                    var arrow = " -> ";
                    if (inChoice) { arrow = " ?-> "; }

                    script?.WriteToFile(prefix + ":" + cardToMove.ToString() + " " + owner.TranscriptName() + arrow + endLocation.cardList.TranscriptName());

                    Debug.WriteLine("Moved Card '" + cardToMove + " to " + endLocation.locIdentifier);

                    // Track here to see if it moved from a visible to invisible location TODO
                    // Then record the invisible as the last known location.
                }
                else
                {
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
            if (complete)
            {
                Debug.WriteLine("Undoing FancyCardMoveAction. Putting back in: " + startLocation.name);
                var cardFound = endLocation.Remove();
                if (cardFound != cardToMove)
                {
                    Console.WriteLine("Cards are not equal!!!");
                    throw new Exception();
                }
                startLocation.Add(cardToMove);

                // Is this going back in the right index location? I DON'T THINK SO
                // I think it is always at the end of the list??
                // Does it matter? I THINK SO
                if (actualloc)
                {
                    owner.Add(cardToMove);
                }
                cardToMove.Owner = owner;
            }
            else
            {
                Debug.WriteLine("move has not been executed yet");
                throw new NotSupportedException();
            }
        }
        public override string ToString()
        {
            return "CardMoveAction: StartLocation: " + startLocation.name + "; EndLocation: " + endLocation.name;
        }
    }
    
    public class CardSwapAction : GameAction
    {
        public CardLocReference startLocation;
        public CardLocReference endLocation;
        public CardCollection owner1;
        public CardCollection owner2;
        public Card card1;
        public Card card2;
        public bool actualloc1;
        public bool actualloc2;
        public CardSwapAction(CardLocReference start, CardLocReference end, Transcript script) : base('W', script)
        {
            if (start.cardList.type == CCType.MEMORY)
            {
                Console.WriteLine("start is a mem loc " + start.name + ", " + end.name);
                throw new NotSupportedException();
            }
            if (start.cardList.type == CCType.VIRTUAL)
            {
                Debug.WriteLine("start is a virtual loc " + start.name + ", " + end.name);
                actualloc1 = true;
            }
            if (end.cardList.type == CCType.VIRTUAL)
            {
                actualloc2 = true;
            }
            if (end.cardList.type == CCType.MEMORY)
            {
                Console.WriteLine("end is a mem loc");
                throw new NotSupportedException();
            }
            startLocation = start;
            endLocation = end;

            if (start.cardList.type == CCType.VISIBLE && end.cardList.type != CCType.VISIBLE)
            {
                //Console.WriteLine("Hiding a card that is known!!! " + start.cardList.name + " -> " + end.car);
            }
        }

        public override void Execute()
        {
            try
            {
                if (startLocation.Count() != 0 && endLocation.Count() != 0)
                {

                    card1 = startLocation.Remove();
                    card2 = endLocation.Remove();
                    startLocation.Add(card2);
                    endLocation.Add(card1);
                    owner1 = card1.Owner;
                    owner2 = card2.Owner;
                    card1.Owner = owner2;
                    card2.Owner = owner1;
                    if (actualloc1)
                    {
                        owner1.Add(card2);
                    }
                    if (actualloc2)
                    {
                        owner2.Add(card1);
                    }

                    var arrow = " <-> ";
                    if (inChoice) { arrow = " ?<-> "; }

                    script?.WriteToFile(prefix + ":" + card1.ToString() + " " + owner1.TranscriptName() + arrow + card2.ToString() +  owner2.TranscriptName());

                    Debug.WriteLine("Swapped Cards '" + card1 + " to " + endLocation.locIdentifier);

                    // Track here to see if it moved from a visible to invisible location TODO
                    // Then record the invisible as the last known location.
                }
                else
                {
                    Console.WriteLine("error: attempting to move from empty location " + startLocation.ToString()); //TODO debug here
                    Console.WriteLine("swapping to " + endLocation.ToString());
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
            if (complete)
            {
                Debug.WriteLine("Undoing FancyCardSwapAction. Putting them back.");
                card1 = startLocation.Remove();
                card2 = endLocation.Remove();
                startLocation.Add(card2);
                endLocation.Add(card1);
                owner1 = card1.Owner;
                owner2 = card2.Owner;
                card1.Owner = owner2;
                card2.Owner = owner1;
                if (actualloc1)
                {
                    owner1.Add(card2);
                }
                if (actualloc2)
                {
                    owner2.Add(card1);
                }
            }
            else
            {
                Debug.WriteLine("swap has not been executed yet");
                throw new NotSupportedException();
            }
        }
        public override string ToString()
        {
            return "CardSwapAction: StartLocation: " + startLocation.name + "; EndLocation: " + endLocation.name;
        }
    }


    public class ShuffleAction : GameAction
    {
        private readonly CardLocReference locations;
        private readonly CardCollection unshuffled;

        public ShuffleAction(CardLocReference locations, Transcript script) : base('O', script)
        {
            this.locations = locations;
            unshuffled = new CardCollection(CCType.VIRTUAL);
        }

        public override void Execute()
        {
            foreach (Card c in locations.cardList.AllCards())
            {
                unshuffled.Add(c);
            }
            locations.cardList.Shuffle();
            script?.WriteToFile(prefix + ":" + locations.name);
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

    public class CardRememberAction : GameAction
    {
        readonly CardLocReference startLocation;
        readonly CardLocReference endLocation;
        public CardRememberAction(CardLocReference start, CardLocReference end, Transcript script) : base('R', script)
        {
            startLocation = start;
            endLocation = end;
            if (endLocation.cardList.type != CCType.MEMORY)
            {
                throw new InvalidOperationException();
            }
        }
        public override void Execute()
        {
            var cardToCopy = startLocation.Get();
            endLocation.Add(cardToCopy);
            script?.WriteToFile(prefix + ":" + cardToCopy.ToString() + " " + startLocation.cardList.TranscriptName() + "->" + endLocation.cardList.TranscriptName());
        }
        public override void Undo()
        {
            endLocation.Remove();
        }
        public override string ToString()
        {
            return "CardRememberAction: Starting loaction: " + startLocation.name + "; Ending location: " + endLocation.name;
        }
    }

    public class CardForgetAction : GameAction
    {
        private readonly CardLocReference endLocation;
        private readonly CardCollection notforgotten;

        public CardForgetAction(CardLocReference end, Transcript script) : base('F', script)
        {
            if (end.cardList.type == CCType.MEMORY)
            {
                endLocation = end;
                notforgotten = new CardCollection(CCType.VIRTUAL);
            }
            else
            {
                Debug.WriteLine(end.name);
                throw new InvalidOperationException();
            }
        }
        public override void Execute()
        {
            notforgotten.Add(endLocation.Remove());
            script?.WriteToFile(prefix + ":" + endLocation.cardList.TranscriptName());
        }
        public override void Undo()
        {
            endLocation.Add(notforgotten.Remove());
        }
        public override string ToString()
        {
            return "CardForgetAction: To be removed: " + endLocation.name;
        }
    }

    /************
     * Passing Action
     ********/
    public class TurnAction(Transcript script) : GameAction('Y', script)
    {
        public override void Execute()
        {
            script?.WriteToFile(prefix + ":passing");
        }
        public override void Undo()
        {

        }
        public override string ToString()
        {
            return "TurnAction";
        }
    }

    public class TeamCreateAction : GameAction {
        private readonly List<List<int>> teamList;
        public TeamCreateAction(List<List<int>> teamList, CardGame cg, Transcript script) : base('E', script)
        {
            this.teamList = teamList;
            this.cg = cg;
        }

        public override void Execute()
        {
            var numTeams = teamList.Count;
            for (int i = 0; i < numTeams; i++)
            {
                var newTeam = new Team("" + i, i);
                var teamStr = prefix + ":";
                for (int j = 0; j < teamList[i].Count; j++)
                {
                    newTeam.teamPlayers.Add(cg.players[teamList[i][j]]);
                    cg.players[teamList[i][j]].team = newTeam;
                }
                teamStr += i + " ";
                cg.teams.Add(newTeam);
                script?.WriteToFile(teamStr);
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
        readonly CardCollection location;
        readonly CardCollection before = new(CCType.VIRTUAL);
        readonly Tree deck;
        readonly string name;
        public InitializeAction(CardCollection loc, Tree d, string n, CardGame cg, Transcript script) : base('D', script)
        {
            location = loc;
            deck = d;
            name = n;
            this.cg = cg;
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

    public class IntAction(DefaultStorage<int> storage, string bKey, int v, Transcript script) : GameAction('S', script) {

        readonly DefaultStorage<int> bins = storage;
        readonly string key = bKey;
        readonly int value = v;
        int oldValue;

        public override void Execute() {
            oldValue = bins[key];
            bins[key] = value;
            complete = true;
            script?.WriteToFile(prefix + ":" + bins.owner.name + " " + key + " " + value);
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

    public class StrAction(DefaultStorage<string> storage, string bKey, string v, Transcript script) : GameAction('G', script) {

        readonly DefaultStorage<string> bins = storage;
        readonly string key = bKey;
        readonly string value = v;
        string oldValue;

        public override void Execute() {
            oldValue = bins[key];
            bins[key] = value;
            complete = true;
            script?.WriteToFile(prefix + ":" + bins.owner.name + " " + key + " " + value);
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

    public class PointsAction(DefaultStorage<PointMap> storage, string bKey, PointMap v, Transcript script) : GameAction('P', script)
    {

        private readonly DefaultStorage<PointMap> bins = storage;
        private readonly string key = bKey;
        private readonly PointMap value = v;
        private PointMap oldValue;

        public override void Execute()
        {
            oldValue = bins[key];
            bins[key] = value;
            complete = true;
            script?.WriteToFile(prefix + ":" + bins.owner.name + " " + key + " " + value);
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
            return "PointsAction: value: " + value.ToString();
        }
    }

    public class NextAction(StageCycle<Player> playerCycle, int idx, Transcript script) : GameAction('N', script)
    {
        private readonly StageCycle<Player> playerCycle = playerCycle;
        private readonly int idx = idx;
        private int former = -1;

        public override void Execute()
        {
            // someone already in the queue
            if (playerCycle.queuedNext != -1) {
                former = playerCycle.queuedNext;
			}
            playerCycle.SetNext(idx);
            script?.WriteToFile(prefix + ":p" + idx);
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
        private readonly int idx;
        private int former;
        public SetPlayerAction(int idx, CardGame cg, Transcript script) : base('T', script)
        {
            this.idx = idx;
            this.cg = cg;
        }

        public override void Execute()
        {
            former = cg.CurrentPlayer().Current().id;
            cg.CurrentPlayer().SetMember(idx);
            script?.WriteToFile(prefix + ":" + cg.CurrentPlayer().CurrentName());
        }

        public override void Undo()
        {
            cg.CurrentPlayer().SetMember(former);
            //script.WriteToFile(prefix + ": " + cg.CurrentPlayer().CurrentName());
        }

		public override string ToString()
		{
            return "SetPlayerAction: Set player: " + idx.ToString();
		}
    }

    // NOT A REAL GAME ACTION, USED IN RECURSEDO FOR GENERATING CHOICES...
    public class LoopAction(string v, object item, int level) : GameAction('L', null){
        public string var = v;
        public object item = item;
        public int level = level;

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