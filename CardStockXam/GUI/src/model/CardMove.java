package model;

public class CardMove {
	public String cardDesc;
	public Location startLocation;
	public Location endLocation;
	
	public CardMove(String desc, Location startLoc, Location endLoc) {
		cardDesc = desc;
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
    //This currently uses getPointer to get a row in a table view
    //Cards will not be in a table view, but rather as individual objects
    private void performAction(Location start, Location end) {
        Cards startHand = start.getHand();
        Cards endHand = end.getHand();
        Card card = startHand.get(cardDesc);
        startHand.remove(card);
        endHand.add(card);
    }
}

