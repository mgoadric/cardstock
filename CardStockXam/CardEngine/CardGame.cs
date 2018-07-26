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
        public Owner[] table = new Owner[1];
        public Player[] players; 
        public List<Team> teams = new List<Team>();
        public Stack<StageCycle<Player>> currentPlayer = new Stack<StageCycle<Player>>(); 
        public Stack<StageCycle<Team>> currentTeam = new Stack<StageCycle<Team>>();

        // For writing the game transcript. DOES THIS BELONG HERE???
        public bool logging;
        public string fileName;

        public CardGame(bool logging, string fileName) {
            this.logging = logging;
            this.fileName = fileName;
            table[0] = new Owner("table", 0);

        }

        public CardGame CloneCommon() {
            var temp = new CardGame(false, null); //here, players is being initialzed as an empty list of players
            temp.DeclaredName = "Special";

            // Clone table
            temp.table[0] = table[0].Clone();

            // Clone players in the same play order
            temp.players = new Player[players.Length];
            for (int i = 0; i < players.Length; i++) {
                Player op = players[i];
                Player newPlayer = op.Clone();
                temp.players[i] = newPlayer;
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
            // SHOULD THIS BE IN THE STAGECYCLE CLASS??? DUPLICATE CODE!!!
            foreach (var cycle in this.currentPlayer.Reverse()) {
                var newCycle = new StageCycle<Player>(temp.players, temp);
                newCycle.idx = cycle.idx;
                newCycle.queuedNext = cycle.queuedNext;
                temp.currentPlayer.Push(newCycle);
            }

            foreach (var cycle in this.currentTeam.Reverse()) {
                var newCycle = new StageCycle<Team>(temp.teams, temp);
                newCycle.idx = cycle.idx;
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

            CloneVisibleCards(players, temp.players, temp.sourceDeck, cardIdxs, free, playerIdx);
            CloneVisibleCards(teams, temp.teams, temp.sourceDeck, cardIdxs, free, -1);
            CloneVisibleCards(table, temp.table, temp.sourceDeck, cardIdxs, free, -1);

            List<int> vals = free.ToList<int>();

            // Shuffle the free list
            int n = vals.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                int value = vals[k];
                vals[k] = vals[n];
                vals[n] = value;
            }
            IEnumerator<int> cardsLeft = vals.GetEnumerator();
            cardsLeft.MoveNext();

            AssignNonVisibleCards(players, temp.players, temp.sourceDeck, cardIdxs, cardsLeft, playerIdx);
            AssignNonVisibleCards(teams, temp.teams, temp.sourceDeck, cardIdxs, cardsLeft, playerIdx);
            AssignNonVisibleCards(table, temp.table, temp.sourceDeck, cardIdxs, cardsLeft, playerIdx);
 
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
                               List<Card> tempsourceDeck, Dictionary<Card, int> cardIdxs)
        {
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

        public void CloneVisibleCards(IEnumerable<Owner> owners, IReadOnlyList<Owner> tempowners,
                                      List<Card> tempsourceDeck, Dictionary<Card, int> cardIdxs,
                                      HashSet<int> free, int playerIdx)
        {
            foreach (Owner owner in owners)
            {
                foreach (CCType type in Enum.GetValues(typeof(CCType)))
                {
                    if (type == CCType.VISIBLE || type == CCType.MEMORY || (type == CCType.INVISIBLE && owner.id == playerIdx))
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
                                    free.Remove(cardIdxs[card]);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void AssignNonVisibleCards(IEnumerable<Owner> owners, IReadOnlyList<Owner> tempowners,
                                          List<Card> tempsourceDeck, Dictionary<Card, int> cardIdxs,
                                          IEnumerator<int> cardsLeft, int playerIdx)
        {

            foreach (Owner owner in owners)
            {
                foreach (CCType type in Enum.GetValues(typeof(CCType)))
                {
                    if (type == CCType.HIDDEN || (type == CCType.INVISIBLE && owner.id != playerIdx))
                    {
                        foreach (var loc in owner.cardBins[type].Keys())
                        {
                            var collection = owner.cardBins[type][loc];
                            for (int i = 0; i < collection.Count; i++)
                            {
                                // Look up card by index, and reference the new cloned card
                                var toAdd = tempsourceDeck[cardsLeft.Current];
                                cardsLeft.MoveNext();
                                var tempCollection = tempowners[owner.id].cardBins[type][loc];
                                tempCollection.Add(toAdd);
                                toAdd.owner = tempCollection;
                            }
                        }
                    }
                }
            }
        }
               
        public void AddPlayers(int numPlayers, GameIterator gameContext) {
            players = new Player[numPlayers];
            for (int i = 0; i < numPlayers; ++i) {
                players[i] = new Player("p" + i, i);
                Perspective perspective = new Perspective(i, this, gameContext);
                players[i].decision = new RandomPlayer(perspective);
            }
            currentPlayer.Push(new StageCycle<Player>(players, this));

        }

        public StageCycle<Player> CurrentPlayer() {
            return currentPlayer.Peek();
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

        public override string ToString() {
            var ret = "Table Deck:\n";
            ret += table[0].cardBins.ToString();
            ret += "Players:\n";
            foreach (var player in players) {
                ret += player + "\n";
            }
            return ret;
        }
        /*
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
        }*/

        // TODO Can we move this to another location and call it a Logging class?
        public void WriteToFile(string text)
        {
			if (false)
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
        ;