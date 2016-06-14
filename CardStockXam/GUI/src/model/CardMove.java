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

	public void execute() {
		performAction(startLocation, endLocation);
	}

    public void revert() {
        performAction(endLocation, startLocation);
    }

    //TODO
    private void performAction(Location start, Location end) {
        Cards startHand = start.getHand();
        Cards endHand = end.getHand();
        Card removed = startHand.remove(card);
        endHand.add(removed);
    }
}

