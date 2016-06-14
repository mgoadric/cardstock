package model;

import java.util.ArrayList;

public class Cards {
	private ArrayList<Card> cards;
	public boolean playerOwned;

	public Cards(boolean owned) {
		cards = new ArrayList<>();
		playerOwned = owned;
	}
	public Cards(ArrayList<Card> cards, boolean owned) {
		this.cards = cards;
		playerOwned = owned;
	}

	public void add(Card card) {
        cards.add(card);
    }

	public Card get(int index) { return cards.get(index);}

	public Card get(String desc) {
		for (Card card : cards) {
			if (card.toString().equals(desc)) {return card;}
		}
		return null;
	}

	public void remove(Card card) {
		cards.remove(card);
	}

    public void addValueToCard(String key, Object value, Object v) {
        for (Card card : cards) {
            if (card.hasAttribute(value)) {
                card.addAttribute(key, v);
            }
        }
    }

	public String toString() {
		String temp = "";
		for (Card card : cards) {
			temp += card.toString();
			temp += " | ";
		}
		return temp.trim();
	}


}
