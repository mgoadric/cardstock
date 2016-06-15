package model;

import javafx.scene.control.TableView;

public class Move {
    private CardMove cardMove;
    private DataMove dataMove;
    private boolean isCardMove;
    private int currentPlayer;

    public Move(TableView<RawStorage> table, RawStorage stor) {//TODO, may have to include alt that changes values
        dataMove = new DataMove(table, stor);
        isCardMove = false;
    }

    public Move(Card card, Location startLoc, Location endLoc) {
        cardMove = new CardMove(card, startLoc, endLoc);
        isCardMove = true;
    }

    public void setCurrentPlayer(int num) {
        currentPlayer = num;
    }
    public int getCurrentPlayer() {
        return currentPlayer;
    }

    public String execute() {
        if (isCardMove) {
            return cardMove.execute();
        }
        else {
            return dataMove.execute();
        }
    }

    public String revert() {
        if (isCardMove) {
            return cardMove.revert();
        }
        else {
            return dataMove.revert();
        }
    }
}