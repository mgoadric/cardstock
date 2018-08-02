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
            // ADDING HERE TO MAKE HASHCODE NOT FAIL
            players = new Player[0];
            
        }

        public CardGame CloneCommon() {
            var temp = new CardGame(false, null); //here, players is being initialzed as an empty list of players
            temp.DeclaredName = "Special";

            // Clone Source Deck and Index Cards
            //*****************
            for (int i = 0; i < sourceDeck.Count; ++i)
            {
                Card c = sourceDeck[i].Clone();
                temp.sourceDeck.Add(c);
            }

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

            // Make set of indicies for all the cards, to be removed when they are seen
            HashSet<int> free = new HashSet<int>();     
            for (int i = 0; i < sourceDeck.Count; ++i) {
                free.Add(i);
            }

            Debug.WriteLine("Calling CloneVisibleCardsfor Players");
            CloneVisibleCards(players, temp.players, temp.sourceDeck, free, playerIdx);
            Debug.WriteLine("Calling CloneVisibleCardsfor Teams");
            CloneVisibleCards(teams, temp.teams, temp.sourceDeck, free, -1);
            Debug.WriteLine("Calling CloneVisibleCardsfor Table");
            CloneVisibleCards(table, temp.table, temp.sourceDeck, free, -1);
            Debug.WriteLine("Finished Visible Cloning");

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

            Debug.WriteLine("Calling AssignNonVisibleCards for Players");
            AssignNonVisibleCards(players, temp.players, temp.sourceDeck, cardsLeft, playerIdx);
            Debug.WriteLine("Calling AssignNonVisibleCards for Teams");
            AssignNonVisibleCards(teams, temp.teams, temp.sourceDeck, cardsLeft, playerIdx);
            Debug.WriteLine("Calling AssignNonVisibleCards for Table");
            AssignNonVisibleCards(table, temp.table, temp.sourceDeck, cardsLeft, playerIdx);
            Debug.WriteLine("Finished AssignNonVisibleCards");
 
            Debug.WriteLine("Numplayers at end of clonesecret: " + temp.CurrentPlayer().memberList.Count);
            Debug.WriteLine("returning from clonesecret");

            return temp;
        }

        public CardGame Clone()
        {

            var temp = CloneCommon();

            Debug.WriteLine("Calling for Players");
            CloneCards(players, temp.players, temp.sourceDeck);
            Debug.WriteLine("Calling for Teams");
            CloneCards(teams, temp.teams, temp.sourceDeck);
            Debug.WriteLine("Calling for Table");
            CloneCards(table, temp.table, temp.sourceDeck);
            Debug.WriteLine("Finished Cloning");

            return temp;
        }

        public void CloneCards(IEnumerable<Owner> owners, IReadOnlyList<Owner> tempowners,
                               List<Card> tempsourceDeck)
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
                            var tempCollection = tempowners[owner.id].cardBins[type][loc];

                            foreach (var card in collection.AllCards())
                            {
                                // Look up card by index, and reference the new cloned card
                                var toAdd = tempsourceDeck[card.id];
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
                                      List<Card> tempsourceDeck, HashSet<int> free, int playerIdx)
        {
            foreach (Owner owner in owners)
            {
                foreach (CCType type in Enum.GetValues(typeof(CCType)))
                {
                    // WHAT ABOUT TEAMS???
                    if (type == CCType.VISIBLE || type == CCType.MEMORY || (type == CCType.INVISIBLE
                                                                            && owner.GetType() == typeof(Player)
                                                                            && owner.id == playerIdx))
                    {
                        foreach (var loc in owner.cardBins[type].Keys())
                        {
                            var collection = owner.cardBins[type][loc];

                            Debug.WriteLine("Initial Collection:" + collection);

                            var tempCollection = tempowners[owner.id].cardBins[type][loc];
                            foreach (var card in collection.AllCards())
                            {
                                // Look up card by index, and reference the new cloned card
                                var toAdd = tempsourceDeck[card.id];
                                tempCollection.Add(toAdd);
                                if (type != CCType.MEMORY)
                                {
                                    toAdd.owner = tempCollection;
                                    free.Remove(card.id);
                                }
                            }

                            Debug.WriteLine("Cloned Collection:" + tempCollection);

                        }
                    }
                }
            }
        }

        public void AssignNonVisibleCards(IEnumerable<Owner> owners, IReadOnlyList<Owner> tempowners,
                                          List<Card> tempsourceDeck, IEnumerator<int> cardsLeft, int playerIdx)
        {

            foreach (Owner owner in owners)
            {
                foreach (CCType type in Enum.GetValues(typeof(CCType)))
                {
                    // WHAT ABOUT TEAMS
                    if (type == CCType.HIDDEN || (type == CCType.INVISIBLE 
                                                  && (owner.GetType() != typeof(Player) 
                                                      || owner.id != playerIdx)))
                    {
                        foreach (var loc in owner.cardBins[type].Keys())
                        {
                            var collection = owner.cardBins[type][loc];

                            Debug.WriteLine("Initial Collection:" + collection);

                            var tempCollection = tempowners[owner.id].cardBins[type][loc];

                            for (int i = 0; i < collection.Count; i++)
                            {
                                // Look up card by index, and reference the new cloned card
                                var toAdd = tempsourceDeck[cardsLeft.Current];
                                cardsLeft.MoveNext();
                                tempCollection.Add(toAdd);
                                toAdd.owner = tempCollection;
                            }

                            Debug.WriteLine("Reconstructed Collection:" + tempCollection);

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
                var newCard = new Card(combo.Flatten(), sourceDeck.Count);
                newCard.owner = loc;
                sourceDeck.Add(newCard);
                loc.Add(newCard);
                WriteToFile("C:" + newCard.ToString() + " " + loc.owner.owner.name + " " + loc.type +
                    " " + loc.name); 
            }
            //Console.ReadKey();
        }

        public int PlayerMakeChoice(List<GameActionCollection> choices, int playerIdx) {
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
            return choice;
        }

        public override string ToString() {
            var ret = "\r\n" + "Table: \r\n";
            ret += table[0].ToString() + "\r\n";
            ret += "Players:\n";
            foreach (var player in players) {
                ret += player + "\n";
            }
            return ret;
        }
        
        public override bool Equals(System.Object obj) // In Progress
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
            if (!(othergame.players.Count() == players.Count()) ||
                                        !(othergame.teams.Count() == teams.Count()))
            { Console.WriteLine("Player count or team count not equal"); return false; }

            if (!(sourceDeck.SequenceEqual(othergame.sourceDeck)))
            { Console.WriteLine("Source Deck not equal"); return false; }

            if (!(table[0].intBins.Equals(othergame.table[0].intBins)))
            { //Console.WriteLine("table int bins not equal");
                return false; }
            
            //if (!(table[0].pointBins.Equals(othergame.table[0].pointBins))) // IF POINT MAPS NEVER CHANGE;; IF THEY DO, NEED DIFFERENT CLONE
            //{ Console.WriteLine("Table pointBins not equal"); return false; }

            if (!(table[0].stringBins.Equals(othergame.table[0].stringBins)))
            { Console.WriteLine("table Stringbins not equal"); return false; }
            
            if (!(table[0].cardBins.SequenceEqual(othergame.table[0].cardBins)))
            { //Console.WriteLine("table cardbins not equal"); 
                return false; }

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
            hash ^= table[0].intBins.GetHashCode();
            //hash ^= table[0].pointBins.GetHashCode();
            hash ^= table[0].stringBins.GetHashCode();
            foreach(CCType type in Enum.GetValues(typeof(CCType)))
            {
                if (type != CCType.VIRTUAL) { hash ^= table[0].cardBins[type].GetHashCode(); }
            }

            foreach(StageCycle<Player> scp in currentPlayer)
            { hash ^= scp.GetHashCode(); }
            foreach (StageCycle<Team> sct in currentTeam)
            { hash ^= sct.GetHashCode(); }
          

            return hash;
        }

        // TODO Can we move this to another location and call it a Logging class?
        public void WriteToFile(string text)
        {
			if (logging) //logging
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