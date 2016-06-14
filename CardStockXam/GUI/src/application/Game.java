package application;

import javafx.collections.ObservableList;
import model.Cards;
import model.Move;
import model.Table;

import java.util.ArrayList;

public class Game {
	public int numPlayers;
	public Table table;
	public ArrayList<Cards> cardLocs;
	public ObservableList<String> teams;
	public ArrayList<Move> moves;
	
	public Game(int numPlayers, Table table, ObservableList<String> teams, ArrayList<Cards> cardLocs, ArrayList<Move> moves) {
		this.numPlayers = numPlayers;
        this.table = table;
		this.teams = teams;
		this.cardLocs = cardLocs;
		this.moves = moves;
	}
}
