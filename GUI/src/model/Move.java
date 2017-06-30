package model;

import javafx.scene.control.TableView;
import java.util.ArrayList;

public class Move {
    private CardMove cardMove;
    private DataMove dataMove;
    private OrderMove orderMove;
    private int moveId = 0;
    private int currentPlayer;

    public Move(Card card, Location startLoc, Location endLoc, int player) {
        cardMove = new CardMove(card, startLoc, endLoc);
        currentPlayer = player;
    }

    public Move(TableView<RawStorage> table, RawStorage stor, int player) {
        dataMove = new DataMove<>(table, stor);
        moveId = 1;
        currentPlayer = player;
    }

    public Move(TableView<Memory> table, Memory mem, int player) {
        dataMove = new DataMove<>(table, mem);
        moveId = 1;
        currentPlayer = player;
    }

    public Move(Location loc, ArrayList<Card> cards, int player) {
        orderMove = new OrderMove(loc, cards);
        moveId = 2;
        currentPlayer = player;
    }

    public int getCurrentPlayer() {
        return currentPlayer;
    }

    public String execute() {
        if (moveId == 0) {
            return cardMove.execute();
        }
        else if (moveId == 1){
            return dataMove.execute();
        }
        else {
            return orderMove.execute();
        }
    }

    public String revert() {
        if (moveId == 0) {
            return cardMove.revert();
        }
        else if (moveId == 1){
            return dataMove.revert();
        }
        else {
            return orderMove.revert();
        }
    }

    public String toString() {
        if (moveId == 0) {
            return "moves card " + cardMove.card + " from " + cardMove.startLocation.getHand().getName() + " to " + cardMove.endLocation.getHand().getName();
        }
        else if (moveId == 1){
            return "data move";
        }
        else {
            return "order move";
        }
    }
}