package model;

public class Move {
    private CardMove cardMove;
    private PointMove pointMove;
    private boolean isCardMove;

    public Move(Location loc, int val, boolean increment) {
        if (!increment) {
            val = val * -1;
        }
        pointMove = new PointMove(loc, val);
        isCardMove = false;
    }

    public Move(Card card,   Location startLoc, Location endLoc) {
        cardMove = new CardMove(card, startLoc, endLoc);
        isCardMove = true;
    }

    public void execute() {
        if (isCardMove) {
            cardMove.execute();
        }
        else {
            pointMove.execute();
        }
    }

    public void revert() {
        if (isCardMove) {
            cardMove.revert();
        }
        else {
            pointMove.revert();
        }
    }
}