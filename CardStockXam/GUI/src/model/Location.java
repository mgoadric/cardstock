package model;

import javafx.collections.ObservableList;

public class Location {
    private String cardId;
    private Table table;
    private boolean forPlayer;

/*
    public Location(Cards cards) { // for storing cards(such as a player's hand, or deck)
        this.cards = cards;
    }
*/

    public Location(Table table, String cardId) {
        this.table = table;
        this.cardId = cardId;
    }

    public Pair<ObservableList, Integer> getAttribute() {//TODO
//        if (forPlayer) {
//            return player.getAttr(attr);
//        }
//        else {
//            ObservableList items = table.getItems();
//            for (int i = 0; i < items.size(); i++) {
//                String curr = (String) items.get(i);
//                if (curr == attr) {
//                    return new Pair<>(items, i);
//                }
//            }
//        }
        return null;
    }

    public Cards getHand() {
        return table.getTableCards(cardId);
    }
}
