package model;

import javafx.scene.control.TextField;
import javafx.scene.control.TextInputControl;

import java.util.ArrayList;

public class Cards {
	private ArrayList<Card> cards;
    private TextField nameField;
	private String name;
	private boolean playerOwned;
    private double x,y;
    private final double CARDWIDTH = 20;
    private boolean expandMode = true;
    private Table owner;

    public Cards(String name, boolean owned, Table owner) {
        cards = new ArrayList<>();
        this.name = name;
        this.playerOwned = owned;
        name.
        this.owner = owner;
        setupNameField();
        alignCards();
    }

	public void add(Card card) {
        card.setOwner(this);
        cards.add(card);
        alignCards();
        updateName();
    }
    public Card remove(Card card) {
        for (int i = cards.size()-1; i >= 0; i--) {
            Card temp = cards.get(i);
            if (temp.matches(card)) {
                Card removedCard = cards.remove(i);
                alignCards();
                updateName();
                return removedCard;
            }
        }
        System.out.println(card.toString() + " failed to be removed");
        return null;
    }

    public Card get(int index) { return cards.get(index);}

	public Card get(String desc) {
		for (Card card : cards) {
			if (card.toString().equals(desc)) {return card;}
		}
		return null;
	}

    public String getName() {return name;}
    public void setName(String name) {
        this.name = name;
        updateName();
    }

    public void switchExpandMode() {
        expandMode = !expandMode;
        alignCards();
        owner.paint();
    }

    public void addValueToCard(String key, Object value, Object v) {
        for (Card card : cards) {
            if (card.hasAttribute(value)) {
                card.addAttribute(key, v);
            }
        }
    }

    public void alignCards() {
        if (expandMode) {
            for (int i = 0; i < cards.size(); i++) {
                double xcoord = x - CARDWIDTH - (CARDWIDTH * cards.size() / 2) + (i * CARDWIDTH);
                cards.get(i).setCenter(xcoord, y);
            }
        }
        else {alignUnexpanded();}
    }

    public ArrayList<TextInputControl> getAll() {
        ArrayList<TextInputControl> ret = new ArrayList<>();
        if (expandMode) {
            for (Card card : cards) {
                ret.add(card.rect);
            }
        }
        else {
            if (cards.size() > 0) {
                ret.add(getLast().rect);
            }
        }
        ret.add(nameField);
        return ret;
    }

	public String toString() {
		String temp = name;
		for (Card card : cards) {
			temp += card.toString();
			temp += " | ";
		}
        if (temp.length() == name.length()) {return name + " empty collection";}
		return temp.trim();
	}

    public void setCenter(double x, double y) {
        this.x = x;
        this.y = y;
        nameField.setLayoutX(x - (nameField.getPrefWidth() / 2));
            nameField.setLayoutY(y + 50);
        alignCards();
    }

    public boolean matchesWith(String toMatch) {
        return name.equals(toMatch);
    }

    private void setupNameField() {
        nameField = new TextField();
        nameField.setPrefWidth(150);
        nameField.setPrefHeight(40);
        nameField.setEditable(false);
        updateName();
    }

    private void updateName() {
        nameField.setText(name + "[" + cards.size() + "]");
    }

    public ArrayList<Card> reorder(ArrayList<Card> orderedCards) {
        ArrayList<Card> ret = cards;
        for (int i = 0; i < orderedCards.size(); i++) {
            Card current = orderedCards.get(i);
            for (int j = i; j < cards.size(); j++) {
                Card temp = cards.get(j);
                if (current.matches(temp)) {
                    cards.set(j, cards.get(i));
                    cards.set(i, temp);
                    break;
                }
            }
        }
        alignCards();
        return ret;
    }

    private void alignUnexpanded() {
        Card last = getLast();
        if (last != null) {
            last.setCenter(x - (CARDWIDTH * 3 / 2), y);
        }
    }

    private Card getLast() {
        if (cards.size() > 0) {
            return cards.get(cards.size() - 1);
        }
        return null;
    }
}
