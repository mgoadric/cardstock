package model;

import javafx.collections.ObservableList;

import java.util.ArrayList;

public class Game {
	public int numPlayers;
	public Table table;
	public ArrayList<Cards> cardLocs;
	public ObservableList<RawStorage> info;
	public ArrayList<Move> moves;
	
	public Game(int numPlayers, Table table, ObservableList<RawStorage> info, ArrayList<Cards> cardLocs, ArrayList<Move> moves) {
		this.numPlayers = numPlayers;
        this.table = table;
		this.info = info;
		this.cardLocs = cardLocs;
		this.moves = moves;
	}
}
