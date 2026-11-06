package model;

import java.util.ArrayList;

public class OrderMove {
    private Location loc;
    private ArrayList<Card> cards;
    private ArrayList<Card> revertTo;

    public OrderMove(Location loc, ArrayList<Card> cards) {
        this.loc = loc;
        this.cards = cards;
    }

    public String execute() {
        revertTo = loc.getHand().reorder(cards);
        return "Reordered " + loc.getHand().getName();
    }

    public String revert() {
        loc.getHand().reorder(revertTo);
        return "Deordered " + loc.getHand().getName();
    }
}
