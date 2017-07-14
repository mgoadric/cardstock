using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Players;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Diagnostics;

namespace CardEngine
{
	
	public class CardGame{

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
		public Stack<StageCycle<Player>> currentPlayer = new Stack<StageCycle<Player>>();
		public Stack<StageCycle<Team>> currentTeam = new Stack<StageCycle<Team>>();
		public RawStorage gameStorage = new RawStorage();
		public PointsStorage points = new PointsStorage();
        public Dictionary<String, object> vars = new Dictionary<string, object>();


        // TODO should have card map
        //  public static Dictionary 
        public static Dictionary<string, Card> fancyCardMap = new Dictionary<string, Card>();
        public static Dictionary<string, FancyCardLocation> fancyCardLocMap = new Dictionary<string, FancyCardLocation>();
        public static Dictionary<string, FancyRawStorage> fancyRawStorMap = new Dictionary<string, FancyRawStorage>();
        public static Dictionary<string, Player> playerMap = new Dictionary<string, Player>();
        public static Dictionary<string, Team> teamMap = new Dictionary<string, Team>();
		public CardGame(){
			
		}
		public CardGame(int numPlayers) {
            AddPlayers(numPlayers);
			//currentPlayer.Push(new PlayerCycle(players)); //TODO call allplayers?
		}
		public CardGame CloneCommon(){
			var temp = new CardGame (); //here, players is being initialzed as an empty list of players
			temp.DeclaredName = "Special";
            for (int idx = 0; idx < teams.Count; idx++){
                Team orig = teamMap[teams[idx].id];
                Team newTeam = orig.Clone();
                foreach (Player p in orig.teamPlayers){
                    Player newPlayer = playerMap[p.name].Clone();
                    newPlayer.team = newTeam;
                    temp.players.Add(newPlayer);
                    newTeam.teamPlayers.Add(newPlayer);
                }
                temp.teams.Add(newTeam);
            }
			/*Dictionary<Player, int> playerIdxs = new Dictionary<Player, int>();
			for (int i = 0; i < this.players.Count; ++i) {
				playerIdxs [players [i]] = i;
			}

			for (int i = 0; i < this.teams.Count; ++i) {
				var newTeam = new Team (i);
				for (int j = 0; j < this.teams [i].teamPlayers.Count; ++j) {
					newTeam.teamPlayers.Add (temp.players [playerIdxs [this.teams [i].teamPlayers [j]]]);
					temp.players [playerIdxs [this.teams [i].teamPlayers [j]]].team = newTeam;
				}
				temp.teams.Add (newTeam);
			}
			//recreate player bins

			for (int i = 0; i < this.players.Count; ++i) {
				this.players [i].CloneToOther (temp.players [i]);
			}*/

			//reconstruct team and player cycles
			//temp.currentPlayer.Pop();
			foreach (var cycle in this.currentPlayer.Reverse()){
				var newCycle = new StageCycle<Player> (temp.players);
				newCycle.idx = cycle.idx;
				newCycle.turnEnded = cycle.turnEnded;
				newCycle.queuedNext = cycle.queuedNext;
				temp.currentPlayer.Push (newCycle);
			}
			temp.currentTeam.Clear();
			foreach (var cycle in this.currentTeam.Reverse()){
				var newCycle = new StageCycle<Team> (temp.teams);
				newCycle.idx = cycle.idx;
				newCycle.turnEnded = cycle.turnEnded;

				temp.currentTeam.Push (newCycle);
			}

			return temp;
		}
       
        // keeps your hand and visible cards the same, but all other hidden cards
        // are randomized (for each possible run) - so that AI players don't just
        // know everyone's cards (bc need some numbers to make decisions)
		public CardGame CloneSecret(int playerIdx){
            // can get through here (at least once)
            Debug.WriteLine("clonesecret player:" + playerIdx);

			var temp = CloneCommon ();
            Debug.WriteLine("Playerlist: " + temp.CurrentPlayer().playerList.Count());
            Debug.WriteLine(playerIdx);
            Debug.WriteLine("Num players in clone secret: " + temp.players.Count());
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
							temp.players [p].cardBins [loc].Add (toAdd);
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
							toAdd.owner = temp.tableCards[bin];
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
                        if (!bin.StartsWith("{mem}"))
                        {
                            toAdd.owner = temp.tableCards[bin];
                        }
						temp.tableCards [bin].Add (toAdd);
						
						vals.RemoveAt (vals.Count - 1);
					}
				}
			}

			temp.points = points.Clone ();

            temp.vars = CloneDictionary(vars);
            Debug.WriteLine("Numplayers at end of clonesecret: " + temp.CurrentPlayer().playerList.Count);
			Debug.WriteLine("returning from clonesecret");

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
            temp.vars = CloneDictionary(this.vars);
			return temp;
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
                else if (o is FancyCardLocation)
                {
                    var l = fancyCardLocMap[(o as FancyCardLocation).name];
                    ret.Add(key, l);
                }
                else if (o is FancyRawStorage)
                {
                    var rs = fancyRawStorMap[(o as FancyRawStorage).key];
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
                    foreach (Card c in o as List<Card>){
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

        public void AddPlayers(int numPlayers){
			for (int i = 0; i < numPlayers; ++i){
				players.Add(new Player() { name = "p" + i });
                AddToMap(players[i]);
				players [i].decision = new GeneralPlayer ();
			}
            currentPlayer.Push(new StageCycle<Player>(players));
		}
		public void PushPlayer(){
			currentPlayer.Push(new StageCycle<Player>(currentPlayer.Peek()));
		}
		public void PopPlayer(){
			currentPlayer.Pop();
		}
		
		public StageCycle<Team> CurrentTeam(){
			return currentTeam.Peek();
		}
		public void PushTeam(){
			currentTeam.Push(new StageCycle<Team>(currentTeam.Peek()));
		}
		public void PopTeam(){
			currentTeam.Pop();
		}
		
		public StageCycle<Player> CurrentPlayer(){
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
		//public JObject GameState(int requestingPlayer){
		//	StringBuilder j = new StringBuilder ("{ players:[");
		//	bool first = true;
		//	foreach (var player in players) {
		//		if (!first) {
		//			j.Append (",");
		//		}
		//		j.Append ("{");
		//		j.Append("cards:[");
		//		bool innerFirst = true;
		//		foreach (var cardBin in player.cardBins.Keys()) {
		//			if (!innerFirst) {
		//				j.Append (",");
		//			}
		//			j.Append ("{name:\"" + cardBin + "\",");
		//			j.Append ("contents:[");
		//			bool innerinnerFirst = true;
		//			foreach (var card in player.cardBins[cardBin].AllCards()) {
		//				if (!innerinnerFirst) {
		//					j.Append (",\n");
		//				}
		//				j.Append (card.Serialize());

		//				innerinnerFirst = false;
		//			}
		//			innerFirst = false;
		//			j.Append ("]}");
		//		}
		//		j.Append ("]}\n");
		//		first = false;
		//	}
		//	j.Append ("],");
		//	j.Append("gamecards:[");
		//	bool outterFirst = true;
		//	foreach (var cardBin in tableCards.Keys()) {
		//		if (!outterFirst) {
		//			j.Append (",");
		//		}
		//		j.Append ("{name:\"" + cardBin + "\",");
		//		j.Append ("contents:[");
		//		bool innerinnerFirst = true;
		//		foreach (var card in tableCards[cardBin].AllCards()) {
		//			if (!innerinnerFirst) {
		//				j.Append (",\n");
		//			}
		//			j.Append (card.Serialize());

		//			innerinnerFirst = false;
		//		}
		//		outterFirst = false;
		//		j.Append ("]}");
		//	}
		//	j.Append ("]");
		//	j.Append("}");
		//	return (JObject) JsonConvert.DeserializeObject (j.ToString ());
		//}
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
			Debug.WriteLine("Choice:" + choice);
			possibles[choice].ExecuteActual();
			
		}
		public GameAction ChangeGameState(string bucket, int value){
			return new IntAction(this.gameStorage,bucket,value);
		}
		public GameAction ChangePlayerState(int playerIdx, string bucket, int value){
			return new IntAction(players[playerIdx].storage,bucket,value);
		}
		public void PlayerMakeChoice(List<GameActionCollection> choices, int playerIdx){
            // just keep choices ! just pass in choices
			//var strDescription = SerializeGAC (choices);
			//var json = (JObject) JsonConvert.DeserializeObject (strDescription);
            Debug.WriteLine("In player make choice");
			Debug.WriteLine("Num choices: " + choices.Count());
            /*foreach (GameActionCollection c in choices)
            {
               Debug.WriteLine("Choices: " + c);
            }*/
			Debug.WriteLine("Player turn: " + CurrentPlayer().idx);


			var choice = currentPlayer.Peek().playerList[playerIdx].decision.MakeAction(choices, rand, playerIdx);
            Debug.WriteLine("Executing choices");
            Debug.WriteLine("Num choices: " + choices.Count());
            Debug.WriteLine("Choice: " + choice);
            choices[choice].ExecuteAll();
		}
        // in lessthanperfectplayer - dependent on jobject for no reason - just needs a number,
        // not a list of serialized gameactions (because it just needs the count to make 
        // decisions)


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

        public static void AddToMap(object o){
            IDictionary dict = null;
            string id = "";
            if (o is FancyCardLocation){
                dict = fancyCardLocMap;
                id = (o as FancyCardLocation).name;
            }
            else if (o is FancyRawStorage){
                dict = fancyRawStorMap;
                id = (o as FancyRawStorage).key;
            }
            else if (o is Player){
                dict = playerMap;
                id = (o as Player).name;
            }
            else if (o is Team){
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
		public override string ToString(){
			var ret = "Table Deck:\n";
			ret += tableCards.ToString ();
			ret += "Players:\n";
			foreach (var player in players){
				ret += player + "\n";
			}
			return ret;
		}
        public void WriteToFile(string text)
        {
            ParseEngine.WriteToFile(text);
        }
    }
}