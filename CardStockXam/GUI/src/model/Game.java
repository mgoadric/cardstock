package model;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;

import java.util.ArrayList;

public class Game {
	public int numPlayers;
	public Table table;
	public ArrayList<Cards> cardLocs;
	public ObservableList<RawStorage> rawInfo;
    public ObservableList<Memory> memInfo;
	public ArrayList<Move> moves;
	
	public Game(int numPlayers, Table table, ObservableList<RawStorage> rawInfo, ArrayList<Cards> cardLocs, ArrayList<Move> moves) {
		this.numPlayers = numPlayers;
        this.table = table;
		this.rawInfo = rawInfo;
		this.cardLocs = cardLocs;
		this.moves = moves;
        memInfo = FXCollections.observableArrayList();
	}
}
