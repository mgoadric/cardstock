package application;

public class CardMove {
	public String startCard;
	public int startLocation;
	public String endLocation;
	
	public CardMove(String start, int loc, String endLoc) {
		startCard = start;
		startLocation = loc;
		endLocation = endLoc;
	}
}
