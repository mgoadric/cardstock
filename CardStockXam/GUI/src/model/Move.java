package model;

public class Move {
    private CardMove cardMove;
    private DataMove dataMove;
    private boolean isCardMove;
    private int currentPlayer;

    public Move(String str) {//TODO, may have to include alt that changes values
        dataMove = new DataMove(str);
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

    public void execute() {
        if (isCardMove) {
            cardMove.execute();
        }
        else {
            dataMove.execute();
        }
    }

    public void revert() {
        if (isCardMove) {
            cardMove.revert();
        }
        else {
            dataMove.revert();
        }
    }
}