package model;

import javafx.scene.control.TextArea;

import java.util.ArrayList;

public class Cards {
	private ArrayList<Card> cards;
	public String name;
	public boolean playerOwned;
    public double x,y;
    private final double CARDWIDTH = 25;

	public Cards(boolean owned) {
		cards = new ArrayList<>();
		playerOwned = owned;
	}

    public Cards(String name, boolean owned) {
        this.name = name;
        cards = new ArrayList<>();
        this.playerOwned = owned;
    }

	public Cards(ArrayList<Card> cards, boolean owned) {
		this.cards = cards;
		playerOwned = owned;
	}

	public void add(Card card) {
        cards.add(card);
        alignCards();
        //TODO update text
    }
    public void remove(Card card) {
        cards.remove(card);
        //TODO update text
    }

	public Card get(int index) { return cards.get(index);}

	public Card get(String desc) {
		for (Card card : cards) {
			if (card.toString().equals(desc)) {return card;}
		}
		return null;
	}

    public void setName(String name) {
        this.name = name;
    }

    public void addValueToCard(String key, Object value, Object v) {
        for (Card card : cards) {
            if (card.hasAttribute(value)) {
                card.addAttribute(key, v);
            }
        }
    }

    public void alignCards() {
        for (int i = 0; i < cards.size(); i++) {
            double xcoord = x - CARDWIDTH - (CARDWIDTH * cards.size() / 2) + (i * CARDWIDTH);
            cards.get(i).setCenter(xcoord, y);
        }
    }

    public ArrayList<TextArea> getAll() {
        ArrayList<TextArea> ret = new ArrayList<>();
        for (Card card : cards) {
            ret.add(card.rect);
        }
        return ret;
    }

	public String toString() {
		String temp = "";
		for (Card card : cards) {
			temp += card.toString();
			temp += " | ";
		}
		return temp.trim();
	}

    public void setCenter(double x, double y) {
        this.x = x;
        this.y = x;
    }
}
