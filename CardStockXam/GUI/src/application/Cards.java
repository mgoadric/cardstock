package application;

import java.util.ArrayList;

public class Cards {
	public ArrayList<String> cards;
	public boolean playerOwned;

	public Cards(boolean owned) {
		cards = new ArrayList<>();
		playerOwned = owned;
	}
	public Cards(ArrayList<String> cards, boolean owned) {
		this.cards = cards;
		playerOwned = owned;
	}

    public void add(String card) {
        cards.add(card);
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
