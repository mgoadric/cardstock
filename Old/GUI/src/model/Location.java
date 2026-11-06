package model;

public class Location {
    private String cardId;
    private Table table;
    private int playerId;
    private boolean forPlayer;

    public Location(Table table, String cardId) { // for cards on table
        this.table = table;
        this.cardId = cardId;
        forPlayer = false;
    }

    public Location(Table table, String cardId, int playerId) { // for cards players have
        this.table = table;
        this.cardId = cardId;
        this.playerId = playerId;
        forPlayer = true;
    }

    public Cards getHand() {
        if (!forPlayer) {
            return table.getTableCards(cardId);
        }
        else {
            return table.getPlayerCards(playerId, cardId);
        }
    }

    public int getPlayerId() {return playerId;}
    public boolean getForPlayer() {return forPlayer;}
}
