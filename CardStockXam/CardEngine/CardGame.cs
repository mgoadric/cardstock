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
		public CardGame(){
			
		}
		public CardGame(int numPlayers){
			
			for (int i = 0; i < numPlayers; ++i){
				players.Add(new Player());
			}
			currentPlayer.Push(new PlayerCycle(players));
			//var first = new Card();
		}
		public CardGame CloneCommon(){
			var temp = new CardGame (this.players.Count);
			//Console.WriteLine ("Num Players:" + temp.players.Count);
			temp.DeclaredName = "Special";
			//copy/reassign players
			//*********************
			//cache indexes of players for efficient clone
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
				this.players [i].CopyStructure (temp.players [i]);
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
							toAdd.owner = temp.players [p].cardBins [loc];
							free.Remove (cardIdxs [card]);
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
						temp.tableCards [bin]
						.Add (toAdd);
						free.Remove (cardIdxs [card]);
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
							temp.players [p].cardBins [loc]
								.Add (toAdd);
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

		public void AddPlayers(int numPlayers){
			for (int i = 0; i < numPlayers; ++i){
				
				players.Add(new Player());
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

				//Console.WriteLine(sourceDeck.Last());
			}
			//Console.ReadKey();
		}
		public void SetDeck(Tree cardAttributes){
			var combos = cardAttributes.combinations();
			foreach (var combo in combos){
				sourceDeck.Add(new Card(combo));
				//Console.WriteLine(sourceDeck.Last());
			}
			//Console.ReadKey();
		}
		public void PopulateLocation(string cardLocation){
			var location = tableCards[cardLocation];
			foreach (var card in sourceDeck){
				location.Add(card);
			}
		}
		public void PopulateLocation(CardCollection cardLocation){
			foreach (var card in sourceDeck){
				cardLocation.Add(card);
			}
		}
		public void DealEvery(int numCards,string cardLocation,string destination){
			var location = tableCards[cardLocation];
			foreach (var player in players){
				for (int i = 0; i < numCards; ++i){
					player.AddCard(location.Remove(),destination);
				}
			}
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
			//Console.WriteLine (j.ToString ());
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
			possibles[choice].Execute();
			
		}
		public List<Card> FilterCardsFromLocation(CardFilter filter, string sourceLocation, int locationNumber,  string sourceBucket){
			if (sourceLocation == "T"){//Table
				var bin = tableCards[sourceBucket];
				var possibilities = filter.FilterList(bin);
				return new List<Card>(possibilities.AllCards());
			}
			else if (sourceLocation == "P") {//Player
				var p = players[locationNumber];
				var bin = p.cardBins[sourceBucket];
				var possibilities = filter.FilterList(bin);
				return new List<Card>(possibilities.AllCards());
			}
			return new List<Card>();//String didn't match a location
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
			//Console.WriteLine(choice);
			choices[choice].ExecuteAll();
		}
		public String SerializeGAC(List<GameActionCollection> list){
			StringBuilder b = new StringBuilder ();
			b.Append ("{ items:[");
			foreach (var item in list) {
				b.Append ("[");
				foreach (var ga in item) {
					b.Append (ga.Serialize ());
					b.Append (",");
				}
				b.Remove (b.Length - 1, 1);
				b.Append ("],");
			}
			b.Remove (b.Length - 1, 1);
			b.Append ("]}");
			return b.ToString ();
		}
		public void PlayerMakeChoices(List<GameActionCollection> choices, int playerIdx, int numberOfChoices){
			var temp = numberOfChoices;
			while (temp > 0){
				var choice = currentPlayer.Peek().playerList[playerIdx].decision.MakeAction(choices,rand);
				//Console.WriteLine(choice);
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
	}
}