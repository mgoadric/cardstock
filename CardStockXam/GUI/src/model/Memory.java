package model;

import java.util.ArrayList;

public class Memory implements BasicMemory {
    private String key;
    private ArrayList<Card> cards;

    public Memory(String key, ArrayList<Card> cards) {
        this.key = key;
        this.cards = cards;
    }

    public String getKey() {
        return key;
    }

    public ArrayList<Card> getCard() {
        return cards;
    }
    public String toString() {
        return key + " " + cards.toString();
    }

    @Override
    public String toMatchingString() {
        return key;
    }

    @Override
    public boolean matches(BasicMemory m) {
        return this.toMatchingString().equals(m.toMatchingString());
    }
}
