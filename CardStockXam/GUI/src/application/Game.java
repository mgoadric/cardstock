package application;

import javafx.collections.ObservableList;

import java.util.ArrayList;

public class Game {
	public int numPlayers;
	public ArrayList<Cards> cardLocs;
	public ObservableList<String> teams;
	public String[] playerInfo; //Rawstorage
	public ArrayList<Move> moves;
	
	public Game(int numPlayers, ObservableList<String> teams, ArrayList<Cards> cardLocs, ArrayList<Move> moves) {
		this.numPlayers = numPlayers;
		this.teams = teams;
		this.cardLocs = cardLocs;
		this.moves = moves;
	}
}
