package model;

public class CardMove {
    public Card card;
	public Location startLocation;
	public Location endLocation;

    public CardMove(Card card, Location startLoc, Location endLoc) {
        this.card = card;
        startLocation = startLoc;
        endLocation = endLoc;
    }

	public String execute() {return performAction(startLocation, endLocation);}

    public String revert() {return performAction(endLocation, startLocation);}

    private String performAction(Location start, Location end) {
        Cards startHand = start.getHand();
        Cards endHand = end.getHand();
        Card removed = startHand.remove(card);
        endHand.add(removed);
        return createTranscript(start, end, removed, startHand, endHand);
    }

    private String createTranscript(Location start, Location end, Card removed, Cards startHand, Cards endHand) {
        String startId = "";
        String endId = "";
        if (start.getForPlayer()) {
            startId = "Player " + start.getPlayerId();
        }
        if (end.getForPlayer()) {
            endId = "Player " + end.getPlayerId();
        }
        return "Moved card " + removed.toString().replace("\n", " ") +
                " from " + startId + " " + startHand.getName() +
                " to "   + endId   + " " + endHand.getName();
    }
}

