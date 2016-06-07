package application;

import java.util.ArrayList;

public class Cards {
	public ArrayList<String> cards;
	public int location;
	public boolean playerOwned;
	
	public Cards(ArrayList<String> cards, int loc, boolean owned) {
		this.cards = cards;
		location = loc;
		playerOwned = owned;
	}
	
	public String toString() {
		String temp = "";
		for (String card : cards) {
			temp += card;
			temp += " ";
		}
		return temp.trim();
	}
}
