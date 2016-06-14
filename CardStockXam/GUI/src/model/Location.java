package model;

import javafx.collections.ObservableList;
import javafx.scene.control.TableView;

public class Location {
    public TableView table;
    public String attr;
    public Player player;
    public Cards cards;
    public boolean forPlayer;

    public Location(String attr, TableView table) { // for cardList storage
        this.attr = attr;
        table = new TableView();
        forPlayer = false;
    }

    public Location(String attr, Player p) { // for person storage
        this.attr = attr;
        this.player = p;
        forPlayer = true;
    }

    public Location(Cards cards) { // for storing cards(such as a player's hand, or deck)
        this.cards = cards;
    }

    public Pair<ObservableList, Integer> getAttribute() {
        if (forPlayer) {
            return player.getAttr(attr);
        }
        else {
            ObservableList items = table.getItems();
            for (int i = 0; i < items.size(); i++) {
                String curr = (String) items.get(i);
                if (curr == attr) {
                    return new Pair<>(items, i);
                }
            }
        }
        return null;
    }

    public Cards getHand() {
        return cards;
    }
}
