package application;

import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.TextField;
import javafx.scene.layout.AnchorPane;
import javafx.stage.FileChooser;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;

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
	private ArrayList<Cards> cardLocs;
	private ArrayList<Move> moves;
	private ArrayList<Game> games;
	private Table table;

	@FXML
	public void initialize() {
		table = new Table();
        gameSelect.getSelectionModel().selectedIndexProperty().addListener((v,vOld,vNew) -> {
			int choice = vNew.intValue();
			if (choice >= 0) {
				currentGame = games.get(choice);
				clearCanvas();
				newGame();
			}
		});
	}

    @FXML
    private void newGame() {
        this.numPlayers = currentGame.numPlayers;
        this.cardLocs = currentGame.cardLocs;
        this.moves = currentGame.moves;
        addCards();
        updateCardLocations();
        table.setLocs();
        paint();
    }
	
	@FXML
	public void forward() {
		//TODO
        paint();
	}
	
	@FXML
	public void backward() {
		//TODO
        paint();
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
		table = new Table();
		pane.getChildren().clear();

	}

	private void addGames() {
		for (int i = 1; i <= games.size(); i++) {
			gameSelect.getItems().add(i);
		}
	}


	private void addCards() {
		for (int i = 0; i < numPlayers; i++) {
			Player player = new Player(i);
            table.addPlayer(player);
		}
		for (int i = 0; i < cardLocs.size(); i++) {
			Cards tempCard = cardLocs.get(i);
			if (!tempCard.playerOwned) {
				TextField temp = new TextField();
				table.addToCenter(temp);
			}
		}
	}

	private void updateCardLocations() {
		//TODO
	}

    private void paint() {
        table.paint(pane);
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
	return new Cards(list, playerOwned);
}

public File getDataFile() {
	FileChooser chooser = new FileChooser();
	chooser.setTitle("Select test data");
	return chooser.showOpenDialog(null);
}
}
