package application;

public class Move {
	public String startCard;
	public int startLocation;
	public String endLocation;
	
	public Move(String start, int loc, String endLoc) {
		startCard = start;
		startLocation = loc;
		endLocation = endLoc;
	}
}
