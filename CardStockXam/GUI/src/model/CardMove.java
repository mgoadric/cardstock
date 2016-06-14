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
    //This currently uses getAttribute to get a row in a table view
    //Cards will not be in a table view, but rather as individual objects
    private void performAction(Location start, Location end) {
        System.out.println(card);
        System.out.println(start.toString());
        System.out.println(end.toString());
        Cards startHand = start.getHand();
        Cards endHand = end.getHand();
        System.out.println(startHand);
        System.out.println(endHand);
        startHand.remove(card);
        endHand.add(card);
    }
}

