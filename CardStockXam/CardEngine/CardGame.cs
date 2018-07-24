using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Players;
using System.Text;
using FreezeFrame;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CardEngine
{
    public class CardGame {

        public string DeclaredName = "Default";
        public static Random rand = new Random();

        public List<Card> sourceDeck = new List<Card>();
        public List<Owner> table = new List<Owner>();
        public List<Player> players = new List<Player>(); 
        public List<Team> teams = new List<Team>();
        public Stack<StageCycle<Player>> currentPlayer = new Stack<StageCycle<Player>>(); 
        public Stack<StageCycle<Team>> currentTeam = new Stack<StageCycle<Team>>();

        public Dictionary<String, object> vars = new Dictionary<string, object>();

        public bool logging;
        public string fileName;

        // TODO should have card map?
        public Dictionary<string, Card> fancyCardMap = new Dictionary<string, Card>();
        public Dictionary<string, CardLocReference> fancyCardLocMap = new Dictionary<string, CardLocReference>();
        public Dictionary<string, IntStorageReference> FancyIntStorageMap = new Dictionary<string, IntStorageReference>();
        public Dictionary<string, Player> playerMap = new Dictionary<string, Player>();
        public Dictionary<string, Team> teamMap = new Dictionary<string, Team>();

        public CardGame(bool logging, string fileName) {
            this.logging = logging;
            this.fileName = fileName;
            table.Add(new Owner("table", 0));

        }

        public CardGame CloneCommon() {
            var temp = new CardGame(false, null); //here, players is being initialzed as an empty list of players
            temp.DeclaredName = "Special";

            // Clone table
            temp.table.Clear();
            temp.table.Add(table[0].Clone());

            // Clone players in the same play order
            foreach (Player op in players) {
                Player newPlayer = op.Clone();
                temp.players.Add(newPlayer);
            }

            // Clone teams in the same team order, look up their players
            foreach (Team orig in teams) {
                Team newTeam = orig.Clone();
                foreach (Player p in orig.teamPlayers) {
                    Player newPlayer = temp.players[p.id];
                    newPlayer.team = newTeam;
                    newTeam.teamPlayers.Add(newPlayer);
                }
                temp.teams.Add(newTeam);
            }

            // Reconstruct team and player cycles
            // SHOULD THIS BE IN THE STAGECYCLE CLASS???
            foreach (var cycle in this.currentPlayer.Reverse()) {
                var newCycle = new StageCycle<Player>(temp.players, temp);
                newCycle.idx = cycle.idx;
                newCycle.turnEnded = cycle.turnEnded;
                newCycle.queuedNext = cycle.queuedNext;
                temp.currentPlayer.Push(newCycle);
            }

            foreach (var cycle in this.currentTeam.Reverse()) {
                var newCycle = new StageCycle<Team>(temp.teams, temp);
                newCycle.idx = cycle.idx;
                newCycle.turnEnded = cycle.turnEnded;
                newCycle.queuedNext = cycle.queuedNext;
                temp.currentTeam.Push(newCycle);
            }

            return temp;
        }

        // keeps your hand and visible cards the same, but all other hidden cards
        // are randomized (for each possible run) - so that AI players don't just
        // know everyone's cards (bc need some numbers to make decisions)
        public CardGame CloneSecret(int playerIdx) {
            Debug.WriteLine("clonesecret player:" + playerIdx);

            var temp = CloneCommon();

            Debug.WriteLine("Playerlist: " + temp.CurrentPlayer().memberList.Count());
            Debug.WriteLine(playerIdx);
            Debug.WriteLine("Num players in clone secret: " + temp.players.Count());

            // Clone Source Deck and Index Cards
            HashSet<int> free = new HashSet<int>();
            Dictionary<Card, int> cardIdxs = new Dictionary<Card, int>(new IdentityEqualityComparer<Card>());
            for (int i = 0; i < sourceDeck.Count; ++i) {
                cardIdxs[sourceDeck[i]] = i;
                temp.sourceDeck.Add(sourceDeck[i].Clone());
                free.Add(i);
            }

            for (int p = 0; p < players.Count; p++) {
                foreach (var loc in players[p].cardBins.Keys()) {
                    if (loc.StartsWith("{visible}") || loc.StartsWith("{mem}") || (loc.StartsWith("{invisible}") && p == playerIdx)) {
                        foreach (var card in players[p].cardBins[loc].AllCards()) {
                            var toAdd = temp.sourceDeck[cardIdxs[card]];
                            temp.players[p].cardBins[loc].Add(toAdd);
                            if (!loc.StartsWith("{mem}")) {
                                toAdd.owner = temp.players[p].cardBins[loc];
                                free.Remove(cardIdxs[card]);
                            }
                        }
                    }
                }
            }

            temp.tableCards = tableCards.Clone();
            foreach (var bin in tableCards.Keys()) {
                if (!bin.StartsWith("{hidden}") && !bin.StartsWith("{invisible}")) {
                    foreach (var card in tableCards[bin].AllCards()) {
                        var toAdd = temp.sourceDeck[cardIdxs[card]];
                        temp.tableCards[bin].Add(toAdd);
                        if (!bin.StartsWith("{mem}")) {
                            free.Remove(cardIdxs[card]);
                            toAdd.owner = temp.tableCards[bin];
                        }
                    }
                }
            }

            List<int> vals = free.ToList<int>();
            for (int p = 0; p < players.Count; ++p) {
                foreach (var loc in players[p].cardBins.Keys()) { 
                    if (loc.StartsWith("{hidden}") || (loc.StartsWith("{invisible}") && p != playerIdx)) {
                       
                        foreach (var card in players[p].cardBins[loc].AllCards()) { 
                            var picked = rand.Next(0, vals.Count);
                            var last = vals[vals.Count - 1];
                            vals[vals.Count - 1] = vals[picked];
                            vals[picked] = last;
                            var toAdd = temp.sourceDeck[vals[vals.Count - 1]];
                            temp.players[p].cardBins[loc].Add(toAdd);
                            toAdd.owner = temp.players[p].cardBins[loc];
                            vals.RemoveAt(vals.Count - 1);
                        }
                    }
                }
            }

            foreach (var bin in tableCards.Keys()) {
                if (bin.StartsWith("{hidden}") || bin.StartsWith("{invisible}")) {
                    foreach (var card in tableCards[bin].AllCards()) {
                        var picked = rand.Next(0, vals.Count);
                        var last = vals[vals.Count - 1];
                        vals[vals.Count - 1] = vals[picked];
                        vals[picked] = last;

                        var toAdd = temp.sourceDeck[vals[vals.Count - 1]];
                        if (!bin.StartsWith("{mem}"))
                        {
                            toAdd.owner = temp.tableCards[bin];
                        }
                        temp.tableCards[bin].Add(toAdd);

                        vals.RemoveAt(vals.Count - 1);
                    }
                }
            }

            temp.vars = CloneDictionary(vars);
            Debug.WriteLine("Numplayers at end of clonesecret: " + temp.CurrentPlayer().memberList.Count);
            Debug.WriteLine("returning from clonesecret");

            return temp;
        }

        public CardGame Clone()
        {

            var temp = CloneCommon();

            // Clone Source Deck and Index Cards
            //*****************
            Dictionary<Card, int> cardIdxs = new Dictionary<Card, int>(new IdentityEqualityComparer<Card>()); ;
            for (int i = 0; i < sourceDeck.Count; ++i)
            {
                cardIdxs[sourceDeck[i]] = i;
                temp.sourceDeck.Add(sourceDeck[i].Clone());
            }

            CloneCards(players, temp.players, temp.sourceDeck, cardIdxs);
            CloneCards(teams, temp.teams, temp.sourceDeck, cardIdxs);
            CloneCards(table, temp.table, temp.sourceDeck, cardIdxs);

            return temp;
        }

        public void CloneCards(IEnumerable<Owner> owners, IReadOnlyList<Owner> tempowners, 
                               List<Card> tempsourceDeck, Dictionary<Card, int> cardIdxs) {
            foreach (Owner owner in owners)
            {
                foreach (CCType type in Enum.GetValues(typeof(CCType)))
                {
                    if (type != CCType.VIRTUAL)
                    {
                        foreach (var loc in owner.cardBins[type].Keys())
                        {
                            var collection = owner.cardBins[type][loc];
                            foreach (var card in collection.AllCards())
                            {
                                // Look up card by index, and reference the new cloned card
                                var toAdd = tempsourceDeck[cardIdxs[card]];
                                var tempCollection = tempowners[owner.id].cardBins[type][loc];
                                tempCollection.Add(toAdd);
                                if (type != CCType.MEMORY)
                                {
                                    toAdd.owner = tempCollection;
                                }
                            }
                        }
                    }
                }
            }
        }

        public Dictionary<String, object> CloneDictionary(Dictionary<String, object> original)
        {

            //TODO:
            //remove all non-primitive copies
            //use hashtables (name/hashcode/whatever -> object)

            Dictionary<String, object> ret = new Dictionary<String, object>();
            foreach (KeyValuePair<String, object> entry in original)
            {
                var key = entry.Key;
                var o = entry.Value;
                Debug.WriteLine("type: " + o.GetType());
                if (o is int) { ret.Add(key, (int)o); }
                else if (o is bool) { ret.Add(key, (bool)o); }
                else if (o is string) { ret.Add(key, (string)o); }
                else if (o is Card) {
                    // same question here? TODO
                    //var c = fancyCardMap[(o as Card).attributes.Key];
                    var save = (o as Card);
                    Card c = save.Clone();
                    c.owner = fancyCardLocMap[save.owner.loc.name].cardList;

                    //instead
                    //find card in same location
                    //add that card instead of c
                    ret.Add(key, c);
                }
                else if (o is CardLocReference)
                {
                    var l = fancyCardLocMap[(o as CardLocReference).name];
                    ret.Add(key, l);
                }
                else if (o is IntStorageReference)
                {
                    var rs = FancyIntStorageMap[(o as IntStorageReference).key];
                    ret.Add(key, rs);
                }
                else if (o is GameActionCollection) //TODO what do i do here?
                {
                    Console.WriteLine("You're copying a GameActionCollection???");
                    var coll = o as GameActionCollection;
                    var newcoll = new GameActionCollection();
                    foreach (GameAction ac in coll)
                    {
                        newcoll.Add(ac);
                    }
                    ret.Add(key, newcoll);
                }
                else if (o is Player)
                {
                    var p = playerMap[(o as Player).name];
                    ret.Add(key, p);
                }
                else if (o is Team)
                {
                    var t = teamMap[(o as Team).id];
                    ret.Add(key, t);
                }
                else if (o is string[])
                {
                    string[] str = new string[(o as string[]).Length];
                    str = (string[])(o as string[]).Clone();

                    ret.Add(key, str);
                }
                else if (o is List<Card>)
                {
                    List<Card> l = new List<Card>();
                    foreach (Card c in o as List<Card>) {
                        Card copy = c.Clone();

                        copy.owner = fancyCardLocMap[c.owner.loc.name].cardList;

                        l.Add(c);
                    }
                    ret.Add(key, l);

                }
                else { Console.WriteLine("Error: object " + o + " is  type " + o.GetType()); }
            }
            /*Console.WriteLine("original:");
            foreach (object o in original){
                Console.WriteLine(o.ToString());
            }
            Console.WriteLine(original.Count);
            Console.WriteLine("new:");
            foreach (object o in original){
                Console.WriteLine(o.ToString());
            }
            Console.WriteLine(ret.Count);*/

            return ret;
        }

        public void AddPlayers(int numPlayers, GameIterator gameContext) {
            for (int i = 0; i < numPlayers; ++i) {
                players.Add(new Player("p" + i);
                AddToMap(players[i]);
                Perspective perspective = new Perspective(i, this, gameContext);
                players[i].decision = new RandomPlayer(perspective, gameContext.gameWorld);
            }
            currentPlayer.Push(new StageCycle<Player>(players, this));
        }
        public void PushPlayer() {
            currentPlayer.Push(new StageCycle<Player>(currentPlayer.Peek()));
        }
        public void PopPlayer() {
            currentPlayer.Pop();
        }

        public StageCycle<Team> CurrentTeam() {
            return currentTeam.Peek();
        }
        public void PushTeam() {
            currentTeam.Push(new StageCycle<Team>(currentTeam.Peek()));
        }
        public void PopTeam() {
            currentTeam.Pop();
        }

        public StageCycle<Player> CurrentPlayer() {
            return currentPlayer.Peek();
        }
        public void SetDeck(Tree cardAttributes, CardCollection loc) {
            var combos = cardAttributes.combinations();
            foreach (var combo in combos) {
                var newCard = new Card(combo);
                sourceDeck.Add(newCard);
                loc.Add(newCard);
                WriteToFile("C:" + newCard.ToOutputString() + loc.name); // What happened?
            }
            //Console.ReadKey();
        }

        public void PlayerMakeChoice(List<GameActionCollection> choices, int playerIdx) {
            Debug.WriteLine("In player make choice");
            Debug.WriteLine("Num choices: " + choices.Count());
            /*foreach (GameActionCollection c in choices)
            {
               Debug.WriteLine("Choices: " + c);
            }*/
            Debug.WriteLine("Player turn: " + CurrentPlayer().idx);


            var choice = currentPlayer.Peek().memberList[playerIdx].decision.MakeAction(choices, rand);
            Debug.WriteLine("Executing choices");
            Debug.WriteLine("Num choices: " + choices.Count());
            Debug.WriteLine("Choice: " + choice);
            choices[choice].ExecuteAll();
        }

        public void AddToMap(object o) {
            IDictionary dict = null;
            string id = "";
            if (o is CardLocReference) {
                dict = fancyCardLocMap;
                id = (o as CardLocReference).name;
            }
            else if (o is IntStorageReference) {
                dict = FancyIntStorageMap;
                id = (o as IntStorageReference).GetName();
                //Console.WriteLine(id);
            }
            else if (o is Player) {
                dict = playerMap;
                id = (o as Player).name;
            }
            else if (o is Team) {
                dict = teamMap;
                id = (o as Team).id;
                // TODO changed here - what should id be to make it generalized??????
                //} else if (o is Card) {
                //     dict = fancyCardMap;
                //    Console.WriteLine((o as Card).attributes.Key);
                //id = (o as Card).attributes.Key;
                // should be suit + rank? but not always exists...
                // should be 
                //id = (o as Card).ReadAttributes(
            }
            else { Debug.WriteLine("unknown type in AddToMap: " + o.GetType()); }
            if (!dict.Contains(id)) { dict.Add(id, o); }
            //else { Console.WriteLine("dict already contains " + id); }
        }
        public override string ToString() {
            var ret = "Table Deck:\n";
            ret += tableCards.ToString();
            ret += "Players:\n";
            foreach (var player in players) {
                ret += player + "\n";
            }
            return ret;
        }

        public override bool Equals(System.Object obj) // In Progress
        {
            Console.WriteLine("CALLING CARDGAME EQUALITY");

            
            // CHECK OBJECT IS CARDGAME
            if (obj == null)
            { return false; }
            //Console.WriteLine("1");
            CardGame othergame = obj as CardGame;
            if ((System.Object)othergame == null)
            { return false; }

            //Console.WriteLine("2");
            // CHECK NECESSARY PARTS OF CARD GAME
            if (!(othergame.players.Count() == this.players.Count()) ||
                                        !(othergame.teams.Count() == this.teams.Count()))
            { return false; }
            //Console.WriteLine("3");
            if (!(sourceDeck.SequenceEqual(othergame.sourceDeck)))
            { return false; }

            //Console.WriteLine("4");
           
            if (!(tableCards.Equals(othergame.tableCards))) 
            { return false; }
            //Console.WriteLine("4.5");

            if (!(tableIntStorage.Equals(othergame.tableIntStorage)))
            { return false; }
            //Console.WriteLine("5");
            if (!(points.Equals(othergame.points)))
            { return false; }
            //Console.WriteLine("6");

            if (!(currentPlayer.SequenceEqual(othergame.currentPlayer)))
            { return false; }
            
            //Console.WriteLine("7");
            if (!(currentTeam.SequenceEqual(othergame.currentTeam)))
            { return false; }
            //Console.WriteLine("8");
            if (!(players.SequenceEqual(othergame.players)))
            { return false; }
            //Console.WriteLine("9");
            if (!(teams.SequenceEqual(othergame.teams)))
            { return false; }
            //Console.WriteLine("10");
           
            return true;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            foreach (var card in sourceDeck) { hash ^= card.GetHashCode(); }
            foreach (var player in players) { hash ^= player.GetHashCode(); }
            foreach (var team in teams) { hash ^= team.GetHashCode(); }
            hash ^= tableCards.GetHashCode();
            hash ^= tableIntStorage.GetHashCode();
            hash ^= points.GetHashCode();

            Stack<StageCycle<Player>> playercopy = currentPlayer;
            Stack<StageCycle<Team>> teamcopy = currentTeam;

            while (playercopy.Count != 0) { hash ^= playercopy.Pop().GetHashCode(); }
            while (teamcopy.Count != 0) { hash ^= teamcopy.Pop().GetHashCode(); }

            return hash;
        }

        public void WriteToFile(string text)
        {
			if (logging)
			{
				using (StreamWriter file = new StreamWriter(fileName + ".txt", true))
				{
					file.WriteLine(text);
				}
			}
		}
    }

    public sealed class IdentityEqualityComparer<T> : IEqualityComparer<T>
    where T : class
    {
        public int GetHashCode(T value)
        {
            return RuntimeHelpers.GetHashCode(value);
        }

        public bool Equals(T left, T right)
        {
            return left == right; 
        }
    }
}
        // NEEDS TO MOVE INTO SEPARATE CLASS AND BE A MEMBER OF GAMEITERATOR
        public Dictionary<String, object> vars = new Dictionary<string, object>();