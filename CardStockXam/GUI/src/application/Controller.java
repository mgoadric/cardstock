package application;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;

import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.TextField;
import javafx.scene.layout.AnchorPane;
import javafx.stage.FileChooser;

public class Controller {
	
	@FXML
	TextField errorField;
	
	@FXML
	AnchorPane pane;

	@FXML
	Button forward;

	@FXML
	Button backward;

	@FXML
	ChoiceBox<Integer> gameSelect;

	private Game currentGame;
	private int numPlayers;
	public ArrayList<Cards> cardLocs;
	public String[] playerInfo;
	public ArrayList<Move> moves;
	private ArrayList<Game> games;
	private ArrayList<TextField> textFields;
	private Double[] plocX = {572.0, 572.0, 75.0, 1049.0};
	private Double[] plocY = {51.0, 713.0, 396.0, 396.0};
	private Double[] tlocX = {398.0, 398.0, 709.0, 709.0};
	private Double[] tlocY = {336.0, 450.0, 336.0, 450.0};

	@FXML
	public void initialize() {
		textFields = new ArrayList<>();
		gameSelect.getSelectionModel().selectedIndexProperty().addListener((v,vOld,vNew) -> {
			int choice = vNew.intValue();
			if (choice >= 0) {
				currentGame = games.get(choice);
				clearCanvas();
				newGame();
			}
		});
		clearCanvas();
	}
	
	@FXML
	public void forward() {
		//TODO
	}
	
	@FXML
	public void backward() {
		//TODO
	}

	public void openDataFile() {
		errorField.setText("Opening");
		File dataFile = getDataFile();
		if (dataFile != null) {
			try {
				errorField.setText("Adding games");
				games = parseDataFrom(dataFile);
			} catch (IOException e) {
				errorField.setText(e.toString());
				e.printStackTrace();
			}
			clearCanvas();
			addGames();
		}
		else {
			errorField.setText("Invalid file");
		}
	}

	private void clearCanvas() {
		errorField.setText("All good");
		textFields.clear();
		pane.getChildren().clear();
	}

	private void addGames() {
		for (int i = 1; i <= games.size(); i++) {
			gameSelect.getItems().add(i);
		}
	}
	
	@FXML
	private void newGame() {
		this.numPlayers = currentGame.numPlayers;
		this.cardLocs = currentGame.cardLocs;
		this.moves = currentGame.moves;
		System.out.println(numPlayers);
		System.out.println(cardLocs.toString());
		addCards();
		updateCardLocations();
	}


	private void addCards() {
		for (int i = 0; i < numPlayers; i++) {
			TextField temp = new TextField();
			temp.setLayoutX(plocX[i]);
			temp.setLayoutY(plocY[i]);
			temp.setScaleX(temp.getScaleX()*1.5);
			temp.setScaleY(temp.getScaleX()*1.3);
			temp.setEditable(false);
			temp.setText("Player " + (i + 1) + ": ");
			textFields.add(temp);
		}
		for (int i = 0; i < cardLocs.size(); i++) {
			Cards tempCard = cardLocs.get(i);
			if (!tempCard.playerOwned) {
				TextField temp = new TextField();
				temp.setLayoutX(tlocX[tempCard.location]);
				temp.setLayoutY(tlocY[tempCard.location]);
				temp.setScaleX(temp.getScaleX()*2);
				temp.setScaleY(temp.getScaleX()*1.3);
				temp.setEditable(false);
				textFields.add(temp);
			}
		}
		pane.getChildren().addAll(textFields);
	}

	private void updateCardLocations() {
		for (int i = 0; i < cardLocs.size(); i++) {
			Cards temp = cardLocs.get(i);
			System.out.println(temp.playerOwned);
			if (temp.playerOwned) {
				updatePlayerText(textFields.get(temp.location), temp.cards, temp.location);
			}
			else {
				updateTableText(textFields.get(temp.location + numPlayers), temp.cards);
			}
		}
	}

	private void updateTableText(TextField textField, ArrayList<String> cards) {
		textField.setText(getCardText(cards));
	}

	private void updatePlayerText(TextField textField, ArrayList<String> cards, int loc) {
		String str = "Player " + (loc + 1) + ": ";
		str += getCardText(cards);
		//TODO, insert raw info
		textField.setText(str);		
	}
	
	private String getCardText(ArrayList<String> cards) {
		String str = "";
		for (int i = 0; i < cards.size(); i++) {
			str += cards.get(i) + " ";
		}
		return str.trim();
	}

	//parses text file for info
	//Should numPlayers be constant, and just at beginning?
	//Are these delimiters safe?
	private ArrayList<Game> parseDataFrom(File dataFile) throws IOException {
		FileReader fileReader = new FileReader(dataFile);
		BufferedReader reader = new BufferedReader(fileReader);

		ArrayList<Game> result = new ArrayList<>();
		String line;

		while ((line = reader.readLine()) != null) {
			int numPlayers = 0;
			ArrayList<Cards> cardLocs = new ArrayList<>();
			ArrayList<Move> moves = new ArrayList<>();
						
			//get num players
			numPlayers = Integer.valueOf(line);
			line = reader.readLine();
			
			//get card locations
			while (!line.equals("!")) {
				cardLocs.add(fromLine(line));
				line = reader.readLine();
			}
			line = reader.readLine();
			
			//get move list
			while (line != null && !line.equals("|")) {
				//TODO handle moves
				line = reader.readLine();
			}
			result.add(new Game(numPlayers, cardLocs, moves));
		}
		reader.close();
		return result;
	}

//Card format ex: P1 2 3 Ace
private Cards fromLine(String line) {//TODO, change delimiter if cards can/do have spaces
	String[] ar = line.split(" ");
	String id = ar[0];
	boolean playerOwned = false;
	if (id.charAt(0) == ('P')) {playerOwned = true;}
	int loc = Character.getNumericValue(id.charAt(1));
	
	ArrayList<String> list = new ArrayList<String>(Arrays.asList(ar));
	list.remove(0);
	return new Cards(list, loc, playerOwned);
}

public File getDataFile() {
	FileChooser chooser = new FileChooser();
	chooser.setTitle("Select test data");
	return chooser.showOpenDialog(null);
}
}
