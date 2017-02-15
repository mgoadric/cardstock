using System;
using System.Collections.Generic;
using System.Linq;
using Players;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace CardEngine
{
	
	public class CardGame{
		public static CardGame preserved;
		private static CardGame instance;
		public string DeclaredName = "Default";
		public static CardGame Instance
   		{
	  		get 
	  		{
		         if (instance == null)
		         {
		            instance = new CardGame();
		         }
		         return instance;
		     }
			set{
				instance = value;
			}
		}
		public static Random rand = new Random();
		public List<Card> sourceDeck = new List<Card>();
		public CardStorage tableCards = new CardStorage();
		
		public List<Player> players = new List<Player>();
		public List<GeneralPlayer> decisionPlayers = new List<GeneralPlayer> ();
		public List<Team> teams = new List<Team>();
		public Stack<PlayerCycle> currentPlayer = new Stack<PlayerCycle>();
		public Stack<TeamCycle> currentTeam = new Stack<TeamCycle>();
		public RawStorage gameStorage = new RawStorage();
		public PointsStorage points = new PointsStorage();
        public Dictionary<String, object> vars = new Dictionary<string, object>();
		public CardGame(){
			
		}
		public CardGame(int numPlayers) {
            AddPlayers(numPlayers);
			currentPlayer.Push(new PlayerCycle(players)); //TODO call allplayers?
		}
		public CardGame CloneCommon(){
			var temp = new CardGame (this.players.Count); //here, players is being initialzed as an empty list of players
			temp.DeclaredName = "Special";
			Dictionary<Player, int> playerIdxs = new Dictionary<Player, int>();
			for (int i = 0; i < this.players.Count; ++i) {
				playerIdxs [players [i]] = i;
			}

			for (int i = 0; i < this.teams.Count; ++i) {
				var newTeam = new Team ();
				for (int j = 0; j < this.teams [i].teamPlayers.Count; ++j) {
					newTeam.teamPlayers.Add (temp.players [playerIdxs [this.teams [i].teamPlayers [j]]]);
					temp.players [playerIdxs [this.teams [i].teamPlayers [j]]].team = newTeam;
				}
				temp.teams.Add (newTeam);
			}
			//recreate player bins

			for (int i = 0; i < this.players.Count; ++i) {
				this.players [i].CloneToOther (temp.players [i]);
			}

			//reconstruct team and player cycles
			temp.currentPlayer.Pop();
			foreach (var cycle in this.currentPlayer.Reverse()){
				var newCycle = new PlayerCycle (temp.players);
				newCycle.idx = cycle.idx;
				newCycle.turnEnded = cycle.turnEnded;
				newCycle.queuedNext = cycle.queuedNext;
				temp.currentPlayer.Push (newCycle);
			}
			temp.currentTeam.Clear();
			foreach (var cycle in this.currentTeam.Reverse()){
				var newCycle = new TeamCycle (temp.teams);
				newCycle.idx = cycle.idx;
				newCycle.turnEnded = cycle.turnEnded;

				temp.currentTeam.Push (newCycle);
			}

			return temp;
		}

		public CardGame CloneSecret(int playerIdx){
			var temp = CloneCommon ();
			//Clone Source Deck and Index Cards
			//*****************
			HashSet<int> free = new HashSet<int>();
			Dictionary<Card, int> cardIdxs = new Dictionary<Card, int>();
			for (int i = 0; i < sourceDeck.Count; ++i) {
				cardIdxs [sourceDeck [i]] = i;
				temp.sourceDeck.Add (sourceDeck[i].Clone ());
				free.Add (i);
			}
			for (int p = 0; p < players.Count; ++p) {
				foreach (var loc in players[p].cardBins.Keys()) {
					if (!loc.StartsWith ("{hidden}") || p == playerIdx) {
						foreach (var card in players[p].cardBins[loc].AllCards()) {
							var toAdd = temp.sourceDeck [cardIdxs [card]];
							temp.players [p].cardBins [loc]
							.Add (toAdd);
							if (!loc.StartsWith ("{mem}")) {
								toAdd.owner = temp.players [p].cardBins [loc];
								free.Remove (cardIdxs [card]);
							}
						}
					}
				}
			}
			temp.gameStorage = gameStorage.Clone ();
			temp.tableCards = tableCards.Clone ();
			foreach (var bin in tableCards.Keys()) {
				if (!bin.StartsWith ("{hidden}")) {
					foreach (var card in tableCards[bin].AllCards()) {
						var toAdd = temp.sourceDeck [cardIdxs [card]];
						temp.tableCards [bin].Add (toAdd);
						if (!bin.StartsWith ("{mem}")) {
							free.Remove (cardIdxs [card]);
						}
					}
				}
			}
			List<int> vals = free.ToList<int> ();
			for (int p = 0; p < players.Count; ++p) {
				foreach (var loc in players[p].cardBins.Keys()) {
					if (loc.StartsWith ("{hidden}") && p != playerIdx) {
						foreach (var card in players[p].cardBins[loc].AllCards()) {
							var picked = rand.Next (0,vals.Count);
							var last = vals [vals.Count - 1];
							vals [vals.Count - 1] = vals [picked];
							vals [picked] = last;
							var toAdd = temp.sourceDeck [vals[vals.Count - 1]];
							temp.players [p].cardBins [loc].Add (toAdd);
							toAdd.owner = temp.players [p].cardBins [loc];
							vals.RemoveAt (vals.Count - 1);
						}
					}
				}
			}
			foreach (var bin in tableCards.Keys()) {
				if (bin.StartsWith ("{hidden}")) {
					foreach (var card in tableCards[bin].AllCards()) {
						var picked = rand.Next (0,vals.Count);
						var last = vals [vals.Count - 1];
						vals [vals.Count - 1] = vals [picked];
						vals [picked] = last;

						var toAdd = temp.sourceDeck [vals[vals.Count - 1]];
						temp.tableCards [bin]
							.Add (toAdd);
						
						vals.RemoveAt (vals.Count - 1);
					}
				}
			}
			temp.points = points.Clone ();

            temp.vars = CloneDictionary(vars, temp);
            return temp;
		}
		public CardGame Clone(){
			var temp = CloneCommon ();
			//Clone Source Deck and Index Cards
			//*****************
			Dictionary<Card, int> cardIdxs = new Dictionary<Card, int>();
			for (int i = 0; i < sourceDeck.Count; ++i) {
				cardIdxs [sourceDeck [i]] = i;
				temp.sourceDeck.Add (sourceDeck[i].Clone ());
			}
			for (int p = 0; p < players.Count; ++p) {
				foreach (var loc in players[p].cardBins.Keys()) {
					foreach (var card in players[p].cardBins[loc].AllCards()) {
						var toAdd = temp.sourceDeck [cardIdxs [card]];
						temp.players [p].cardBins [loc]
							.Add (toAdd);
						toAdd.owner = temp.players [p].cardBins [loc];
					}
				}
			}
			temp.gameStorage = gameStorage.Clone ();
			temp.tableCards = tableCards.Clone ();
			foreach (var bin in tableCards.Keys()) {
				foreach (var card in tableCards[bin].AllCards()) {
					var toAdd = temp.sourceDeck [cardIdxs [card]];
					temp.tableCards[bin]
						.Add (toAdd);
				}
			}
			temp.points = points.Clone ();
			return temp;
		}

        public Dictionary<String, object> CloneDictionary(Dictionary<String, object> original, CardGame g)
        {
            Dictionary<String, object> ret = new Dictionary<String, object>();
            foreach (KeyValuePair<String, object> entry in original)
            {
                var key = entry.Key;
                var o = entry.Value;
                Console.WriteLine("type: " + o.GetType());
                if (o is int) { ret.Add(key, (int)o); }
                else if (o is bool) { ret.Add(key, (bool)o); }
                else if (o is string) { ret.Add(key, (string)o); }
                else if (o is Card)
                {
                    var c = (o as Card).Clone();
                    ret.Add(key, c);
                }
                else if (o is FancyCardLocation)
                {
                    var l = (o as FancyCardLocation).Clone();
                    ret.Add(key, l);
                }
                else if (o is FancyRawStorage)
                {
                    var r1 = o as FancyRawStorage;
                    var r2 = new FancyRawStorage(r1.storage.Clone(), r1.key);
                    ret.Add(key, r2);
                }
                else if (o is GameActionCollection)
                {
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
                    var p1 = o as Player;
                    Console.WriteLine("should assign p");
                    foreach (Player p in g.players)
                    {
                        if (p.Equals(p1))
                        {
                            ret.Add(key, p);
                            Console.WriteLine("assigning p");
                            break;
                        }
                    }
                }
                else if (o is Team)
                {
                    var t1 = o as Team;
                    Console.WriteLine("should assign t");
                    foreach (Team t in g.teams)
                    {
                        if (t.Equals(t1))
                        {
                            ret.Add(key, t);
                            Console.WriteLine("assigning t");
                            break;
                        }
                    }
                }
                else { Console.WriteLine("Error: object " + o.ToString() + " is  type " + o.GetType()); }
            }
            return ret;
        }

        public void AddPlayers(int numPlayers){
			for (int i = 0; i < numPlayers; ++i){
				players.Add(new Player() { name = "p" + i });
				players [i].decision = i  == 0 ? new GeneralPlayer () : new GeneralPlayer ();
			}
            currentPlayer.Push(new PlayerCycle(players));
		}
		public void PushPlayer(){
			currentPlayer.Push(new PlayerCycle(currentPlayer.Peek()));
		}
		public void PopPlayer(){
			currentPlayer.Pop();
		}
		
		public TeamCycle CurrentTeam(){
			return currentTeam.Peek();
		}
		public void PushTeam(){
			currentTeam.Push(new TeamCycle(currentTeam.Peek()));
		}
		public void PopTeam(){
			currentTeam.Pop();
		}
		
		public PlayerCycle CurrentPlayer(){
			return currentPlayer.Peek();
		}
		public void SetDeck(Tree cardAttributes,CardCollection loc){
			var combos = cardAttributes.combinations();
			foreach (var combo in combos){
				var newCard = new Card (combo);
				sourceDeck.Add (newCard);
				loc.Add(newCard);
                WriteToFile("C:" + newCard.ToOutputString() + loc.name);
            }
			//Console.ReadKey();
		}
		public JObject GameState(int requestingPlayer){
			StringBuilder j = new StringBuilder ("{ players:[");
			bool first = true;
			foreach (var player in players) {
				if (!first) {
					j.Append (",");
				}
				j.Append ("{");
				j.Append("cards:[");
				bool innerFirst = true;
				foreach (var cardBin in player.cardBins.Keys()) {
					if (!innerFirst) {
						j.Append (",");
					}
					j.Append ("{name:\"" + cardBin + "\",");
					j.Append ("contents:[");
					bool innerinnerFirst = true;
					foreach (var card in player.cardBins[cardBin].AllCards()) {
						if (!innerinnerFirst) {
							j.Append (",\n");
						}
						j.Append (card.Serialize());

						innerinnerFirst = false;
					}
					innerFirst = false;
					j.Append ("]}");
				}
				j.Append ("]}\n");
				first = false;
			}
			j.Append ("],");
			j.Append("gamecards:[");
			bool outterFirst = true;
			foreach (var cardBin in tableCards.Keys()) {
				if (!outterFirst) {
					j.Append (",");
				}
				j.Append ("{name:\"" + cardBin + "\",");
				j.Append ("contents:[");
				bool innerinnerFirst = true;
				foreach (var card in tableCards[cardBin].AllCards()) {
					if (!innerinnerFirst) {
						j.Append (",\n");
					}
					j.Append (card.Serialize());

					innerinnerFirst = false;
				}
				outterFirst = false;
				j.Append ("]}");
			}
			j.Append ("]");
			j.Append("}");
			return (JObject) JsonConvert.DeserializeObject (j.ToString ());
		}
		public void SetValue(int idx, int value){
			gameStorage.storage[idx] = value;
		}
		public int GetValue(int idx){
			return gameStorage.storage[idx];
		}
		public void IncrValue(int idx, int incr){
			gameStorage.storage[idx] += incr;
		}
		public void PromptPlayer(Player p, string storageName, int minValue, int maxValue){
			
			var possibles = new List<GameAction>();
			for (int i = minValue; i < maxValue; ++i){
				possibles.Add(new IntAction(p.storage,storageName,i));
			}
			var choice = p.MakeAction(possibles,rand);
			Console.WriteLine("Choice:" + choice);
			possibles[choice].ExecuteActual();
			
		}
		public GameAction ChangeGameState(string bucket, int value){
			return new IntAction(this.gameStorage,bucket,value);
		}
		public GameAction ChangePlayerState(int playerIdx, string bucket, int value){
			return new IntAction(players[playerIdx].storage,bucket,value);
		}
		public void PlayerMakeChoice(List<GameActionCollection> choices, int playerIdx){
			var strDescription = SerializeGAC (choices);
			var json = (JObject) JsonConvert.DeserializeObject (strDescription);
            var choice = currentPlayer.Peek().playerList[playerIdx].decision.MakeAction(json,rand);
            choices[choice].ExecuteAll();
		}
        public String SerializeGAC(List<GameActionCollection> list){
            StringBuilder b = new StringBuilder();
            b.Append("{ items:[");
            foreach (var item in list){
                b.Append("[");
                foreach (var ga in item){
                    b.Append(ga.Serialize());
                    b.Append(",");
                }
                b.Remove(b.Length - 1, 1);
                b.Append("],");
            }
            b.Remove(b.Length - 1, 1);
            b.Append("]}");
            return b.ToString();
        }
        public void PlayerMakeChoices(List<GameActionCollection> choices, int playerIdx, int numberOfChoices){
			var temp = numberOfChoices;
			while (temp > 0){
				var choice = currentPlayer.Peek().playerList[playerIdx].decision.MakeAction(choices,rand);
				choices[choice].ExecuteAll();
				choices.RemoveAt(choice);
				--temp;
			}
		}
		public override string ToString(){
			var ret = "Table Deck:\n";
			ret += tableCards.ToString ();
			ret += "Players:\n";
			foreach (var player in players){
				ret += player.ToString() + "\n";
			}
			return ret;
		}
        public void WriteToFile(string text)
        {
            ParseEngine.WriteToFile(text);
        }
    }
}