package application;

import java.util.ArrayList;

public class Game {
	public int numPlayers;
	public ArrayList<Cards> cardLocs;
	public String[] playerInfo; //Rawstorage
	public ArrayList<Move> moves;
	
	public Game(int numPlayers, ArrayList<Cards> cardLocs, ArrayList<Move> moves) {
		this.numPlayers = numPlayers;
		this.cardLocs = cardLocs;
		this.moves = moves;
	}
}
