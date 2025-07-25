using CardStock.Players;
using CardStock.FreezeFrame;
using System.Diagnostics;

namespace CardStock.CardEngine
{
    public class CardGame
    {

        public Dictionary<String, List<Card>> sourceDeck = [];
        public Owner[] table = new Owner[1];
        public Player[] players;
        public List<Team> teams = [];
        public Stack<StageCycle<Player>> currentPlayer = new();
        public Stack<StageCycle<Team>> currentTeam = new();

        public CardGame()
        {
            table[0] = new Owner("table", 0);
            // ADDING HERE TO MAKE HASHCODE NOT FAIL
            players = [];

        }

        private CardGame CloneCommon()
        {
            var temp = new CardGame(); //here, players is being initialzed as an empty list of players

            // Clone Source Deck and Index Cards
            //*****************
            foreach (KeyValuePair<String, List<Card>> kvp in sourceDeck)
            {
                if (!temp.sourceDeck.ContainsKey(kvp.Key))
                {
                    temp.sourceDeck[kvp.Key] = [];
                }
                for (int i = 0; i < sourceDeck[kvp.Key].Count; i++)
                {
                    Card c = sourceDeck[kvp.Key][i].Clone();
                    temp.sourceDeck[kvp.Key].Add(c);
                }
            }

            // Clone table
            temp.table[0] = table[0].Clone();

            // Clone players in the same play order
            temp.players = new Player[players.Length];
            for (int i = 0; i < players.Length; i++)
            {
                Player op = players[i];
                Player newPlayer = op.Clone();
                temp.players[i] = newPlayer;
            }

            // Clone teams in the same team order, look up their players
            foreach (Team orig in teams)
            {
                Team newTeam = orig.Clone();
                foreach (Player p in orig.teamPlayers)
                {
                    Player newPlayer = temp.players[p.id];
                    newPlayer.team = newTeam;
                    newTeam.teamPlayers.Add(newPlayer);
                }
                temp.teams.Add(newTeam);
            }

            // Reconstruct team and player cycles
            foreach (var cycle in this.currentPlayer.Reverse())
            {
                var newCycle = new StageCycle<Player>(temp.players)
                {
                    idx = cycle.idx,
                    queuedNext = cycle.queuedNext
                };
                temp.currentPlayer.Push(newCycle);
            }

            foreach (var cycle in this.currentTeam.Reverse())
            {
                var newCycle = new StageCycle<Team>(temp.teams)
                {
                    idx = cycle.idx,
                    queuedNext = cycle.queuedNext
                };
                temp.currentTeam.Push(newCycle);
            }

            return temp;
        }

        // TODO Add a cloneDummy method that returns empty cards when you can't see them
        // and a method to fill in the dummy cards randomly, essentially split 
        // CloneSecret into two pieces....

        // keeps your hand and visible cards the same, but all other hidden cards
        // are randomized (for each possible run) - so that AI players don't just
        // know everyone's cards (bc need some numbers to make decisions)
        public CardGame CloneSecret(int playerIdx)
        {
            Debug.WriteLine("clonesecret player:" + playerIdx);

            var temp = CloneCommon();

            // Make set of indicies for all the cards, to be removed when they are seen
            Dictionary<String, HashSet<int>> free = [];
            foreach (KeyValuePair<String, List<Card>> kvp in sourceDeck)
            {
                free[kvp.Key] = [];
                for (int i = 0; i < kvp.Value.Count; i++)
                {
                    free[kvp.Key].Add(i);
                }
            }

            CloneVisibleCards(players, temp.players, temp.sourceDeck, free, playerIdx);
            CloneVisibleCards(teams, temp.teams, temp.sourceDeck, free, -1);
            CloneVisibleCards(table, temp.table, temp.sourceDeck, free, -1);

            Dictionary<String, List<int>> vals = [];
            foreach (KeyValuePair<String, HashSet<int>> kvp in free)
            {
                vals[kvp.Key] = [.. free[kvp.Key]];
            }

            // Shuffle vals for each free location
            Dictionary<String, IEnumerator<int>> cardsLeft = [];
            foreach (KeyValuePair<String, List<int>> kvp in vals)
            {
                int n = vals[kvp.Key].Count;
                while (n > 1)
                {
                    n--;
                    int k = ThreadSafeRandom.Next(n + 1);
                    (vals[kvp.Key][n], vals[kvp.Key][k]) = (vals[kvp.Key][k], vals[kvp.Key][n]);
                }
                cardsLeft[kvp.Key] = vals[kvp.Key].GetEnumerator();
                cardsLeft[kvp.Key].MoveNext();
            }


            // Assigning will need card's name
            AssignNonVisibleCards(players, temp.players, temp.sourceDeck, cardsLeft, playerIdx);
            AssignNonVisibleCards(teams, temp.teams, temp.sourceDeck, cardsLeft, playerIdx);
            AssignNonVisibleCards(table, temp.table, temp.sourceDeck, cardsLeft, playerIdx);

            Debug.WriteLine("returning from clonesecret");

            return temp;
        }

        public CardGame Clone()
        {

            var temp = CloneCommon();

            CloneCards(players, temp.players, temp.sourceDeck);
            CloneCards(teams, temp.teams, temp.sourceDeck);
            CloneCards(table, temp.table, temp.sourceDeck);

            return temp;
        }

        private static void CloneCards(IEnumerable<Owner> owners, IReadOnlyList<Owner> tempowners,
                               Dictionary<String, List<Card>> tempsourceDeck)
        {
            foreach (Owner owner in owners)
            {
                foreach (var collection in owner.cardBins.Values())
                {
                    var tempCollection = tempowners[owner.id].cardBins[collection.type, collection.name];

                    foreach (var card in collection.AllCards())
                    {
                        // Look up card by index, and reference the new cloned card
                        var toAdd = tempsourceDeck[card.name][card.id];
                        tempCollection.Add(toAdd);
                        toAdd.owner = tempCollection;
                    }
                }
            }
        }

        private static void CloneVisibleCards(IEnumerable<Owner> owners, IReadOnlyList<Owner> tempowners,
                                      Dictionary<String, List<Card>> tempsourceDeck, Dictionary<String, HashSet<int>> free, int playerIdx)
        {
            foreach (Owner owner in owners)
            {
                foreach (var collection in owner.cardBins.Values())
                {
                    // WHAT ABOUT TEAMS???
                    if (collection.type == CCType.VISIBLE || (
                            collection.type == CCType.INVISIBLE
                            && owner.GetType() == typeof(Player)
                            && owner.id == playerIdx))
                    {
                        Debug.WriteLine("Initial Collection:" + collection);

                        var tempCollection = tempowners[owner.id].cardBins[collection.type, collection.name];
                        foreach (var card in collection.AllCards())
                        {
                            // Look up card by index, and reference the new cloned card

                            var toAdd = tempsourceDeck[card.name][card.id];
                            tempCollection.Add(toAdd);
                            toAdd.owner = tempCollection;
                            free[card.name].Remove(card.id);
                        }

                        Debug.WriteLine("Cloned Collection:" + tempCollection);
                    }
                }
            }
        }

        private static void AssignNonVisibleCards(IEnumerable<Owner> owners, IReadOnlyList<Owner> tempowners,
                                          Dictionary<String, List<Card>> tempsourceDeck, Dictionary<String, IEnumerator<int>> cardsLeft, int playerIdx)
        {

            foreach (Owner owner in owners)
            {
                foreach (var collection in owner.cardBins.Values())
                {
                    // WHAT ABOUT TEAMS
                    if (collection.type == CCType.HIDDEN ||
                        (collection.type == CCType.INVISIBLE
                                                  && (owner.GetType() != typeof(Player)
                                                      || owner.id != playerIdx)))
                    {
                        Debug.WriteLine("Initial Collection:" + collection);

                        var tempCollection = tempowners[owner.id].cardBins[collection.type, collection.name];

                        for (int i = 0; i < collection.Count; i++)
                        {
                            // figure out type of card
                            String type = collection.Get(i).name;

                            // Look up card by index, and reference the new cloned card
                            var toAdd = tempsourceDeck[type][cardsLeft[type].Current];
                            cardsLeft[type].MoveNext();
                            tempCollection.Add(toAdd);
                            toAdd.owner = tempCollection;
                        }

                        Debug.WriteLine("Reconstructed Collection:" + tempCollection);
                    }
                }
            }
        }

        // TODO Find a better way to initialize AI Players
        public void AddPlayers(int numPlayers, GameIterator gameContext)
        {
            players = new Player[numPlayers];
            for (int i = 0; i < numPlayers; ++i)
            {
                players[i] = new Player("p" + i, i);
                Perspective perspective = new(i, gameContext);
                players[i].decision = new RandomPlayer(perspective);
            }
            currentPlayer.Push(new StageCycle<Player>(players));
        }

        public StageCycle<Player> CurrentPlayer()
        {
            return currentPlayer.Peek();
        }
        public void PushPlayer()
        {
            currentPlayer.Push(new StageCycle<Player>(currentPlayer.Peek()));
        }
        public void PopPlayer()
        {
            currentPlayer.Pop();
        }

        public StageCycle<Team> CurrentTeam()
        {
            return currentTeam.Peek();
        }
        public void PushTeam()
        {
            currentTeam.Push(new StageCycle<Team>(currentTeam.Peek()));
        }
        public void PopTeam()
        {
            currentTeam.Pop();
        }

        public void SetDeck(Tree cardAttributes, CardCollection loc, String name, Transcript script)
        {
            var combos = cardAttributes.Combinations();
            foreach (var combo in combos)
            {
                if (!sourceDeck.ContainsKey(name))
                {
                    sourceDeck[name] = [];
                }
                var newCard = new Card(combo.Flatten(), sourceDeck[name].Count, name)
                {
                    owner = loc
                };
                // use the name to determine which sourceDeck to add
                sourceDeck[name].Add(newCard);
                loc.Add(newCard);
                script.WriteToFile("C:" + newCard.ToString() + " " + loc.owner.owner.name + " " + loc.type +
                    " " + loc.name);
            }
            //Console.ReadKey();
        }

        public int PlayerMakeChoice(int numChoices, int playerIdx)
        {
            Debug.WriteLine("In player make choice");
            Debug.WriteLine("Player turn: " + CurrentPlayer().idx);

            var choice = currentPlayer.Peek().memberList[playerIdx].decision.MakeAction(numChoices);

            Debug.WriteLine("Choice: " + choice);
            return choice;
        }

        public override string ToString()
        {
            var ret = "\r\n" + "Table: \r\n";
            ret += table[0].ToString() + "\r\n";
            ret += "Players:\n";
            foreach (var player in players)
            {
                ret += player + "\n";
            }
            return ret;
        }

        public override bool Equals(System.Object? obj) // In Progress
        {
            //Console.WriteLine("CALLING CARDGAME EQUALITY");
            // COMMENTED OUT ALL WRITELINES EXCEPT ONES THAT SHOULD ALMOST NEVER SHOW UP

            // CHECK OBJECT IS CARDGAME
            if (obj == null)
            { Console.WriteLine("obj is null"); return false; }

            CardGame othergame = obj as CardGame;
            if ((System.Object)othergame == null)
            { Console.WriteLine("obj as cardgame is null"); return false; }


            // CHECK NECESSARY PARTS OF CARD GAME (COULD BE MISSING SOME NOW)
            if (!(othergame.teams.Count == teams.Count))
            { Console.WriteLine("Player count or team count not equal"); return false; }

            // if (!(sourceDeck.SequenceEqual(othergame.sourceDeck))) NOT COMPARING DIFFERENT SOURCEDECKS
            //{ Console.WriteLine("Source Deck not equal"); return false; }

            if (!(table[0].Equals(othergame.table[0])))
            { return false; }

            if (!(players.SequenceEqual(othergame.players)))
            { //Console.WriteLine("Player list not equal");
                return false;
            }

            if (!(teams.SequenceEqual(othergame.teams)))
            { Console.WriteLine("Team List not equal"); return false; }

            if (!(currentPlayer.SequenceEqual(othergame.currentPlayer)))
            { Console.WriteLine("Stack of player StageCycles not equal"); return false; }

            if (!(currentTeam.SequenceEqual(othergame.currentTeam)))
            { Console.WriteLine("Stack of team StageCycles not equal"); return false; }

            return true;
        }

        public override int GetHashCode() // TESTING
        {
            int hash = 0;
            foreach (var card in sourceDeck) { hash ^= card.GetHashCode(); }
            foreach (var player in players) { hash ^= player.GetHashCode(); }
            foreach (var team in teams) { hash ^= team.GetHashCode(); }
            hash ^= table[0].GetHashCode();
            foreach (StageCycle<Player> scp in currentPlayer)
            { hash ^= scp.GetHashCode(); }
            foreach (StageCycle<Team> sct in currentTeam)
            { hash ^= sct.GetHashCode(); }
            return hash;
        }

    }
        
    public class InfoSetComparison(int playeridx) : IEqualityComparer<Tuple<CardGame, int>>
    {
        private readonly int playeridx = playeridx;

        public bool Equals(Tuple<CardGame, int> g1, Tuple<CardGame, int> g2)
        {
            // Info sets are the equal if the visible cards on the board and the visible cards in hand are the same
            if (g1.Item2 != g2.Item2)
            { return false; }

            (CardGame game1, _) = g1;
            (CardGame game2, _) = g2;


            if (!(game1.teams.Count == game2.teams.Count))
            { Console.WriteLine("Player count or team count not equal"); return false; }

            if (!(game1.table[0].BetterEquals(game2.table[0], true, playeridx)))
            { return false; }

            for (int i = 0; i < g1.Item1.players.Length; i++)
            {
                if (!(game1.players[i].BetterEquals(game2.players[i], true, playeridx)))
                { return false; }
            }

            for (int i = 0; i < g1.Item1.players.Length; i++)
            {
                if (!(game1.teams[i].BetterEquals(game2.teams[i], true, playeridx)))
                { return false; }
            }

            if (!(game1.currentPlayer.SequenceEqual(game2.currentPlayer)))
            { Console.WriteLine("Stack of player cycles not equal"); return false; }

            if (!(game1.currentTeam.SequenceEqual(game2.currentTeam)))
            { Console.WriteLine("Stack of team StageCycles not equal"); return false; }

            return true;
        }
        public int GetHashCode(Tuple<CardGame, int> tuple)
        {
            int hash = 0;
            (CardGame game, int movera) = tuple;
            foreach (var player in game.players) { hash ^= player.GetBetterHashCode(true, playeridx); }
            foreach (var team in game.teams) { hash ^= team.GetBetterHashCode(true, playeridx); }
            hash ^= game.table[0].GetBetterHashCode(true, playeridx);
            foreach (StageCycle<Player> scp in game.currentPlayer)
            { hash ^= scp.GetHashCode(); }
            foreach (StageCycle<Team> sct in game.currentTeam)
            { hash ^= sct.GetHashCode(); }
            return hash;
        }
    }
}