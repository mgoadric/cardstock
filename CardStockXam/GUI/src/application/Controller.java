package application;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.layout.AnchorPane;
import javafx.stage.FileChooser;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class Controller {

    @FXML
    TextField errorField;

    @FXML
    TextField currentMoveField;

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
    private int currentMove;
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
        currentMove = 0;
        addCards();
        updateCardLocations();
        table.setLocs();
        addTeams(currentGame.teams);
        paint();
    }

    @FXML
    public void forward() {
        //TODO
        Move move = moves.get(currentMove);

        currentMove++;
        paint();
    }

    @FXML
    public void backward() {
        //TODO
        Move move = moves.get(currentMove);
        currentMove--;
        paint();
    }

    public void openDataFile() {
        errorField.setText("Opening");
        File dataFile = getDataFile();
        if (dataFile != null) {
            try {
                errorField.setText("Adding games");
                games = parseDataFrom(dataFile);
                //games = protoParseDataFrom(dataFile);
            } catch (IOException e) {
                errorField.setText(e.toString());
                e.printStackTrace();
            }
            gameSelect.getItems().clear();
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
            Cards tempDeck = cardLocs.get(i);
            if (!tempDeck.playerOwned) {
                TextArea temp = new TextArea();
                temp.setText(tempDeck.toString());
                table.addToCenter(temp);
            }
        }
    }

    private void addTeams(ObservableList<String> teams) {
        ListView teamList = new ListView(teams);
        teamList.setPrefHeight(teams.size() * 24 + 2);
        teamList.setPrefWidth(150);
        pane.getChildren().add(teamList);
    }

    private void updateCardLocations() {
        //TODO
    }

    private void paint() {
        table.paint(pane);
        currentMoveField.setText("Current move: " + currentMove);
    }


    private ArrayList<Game> parseDataFrom(File dataFile) throws IOException {
        FileReader fileReader = new FileReader(dataFile);
        BufferedReader reader = new BufferedReader(fileReader);
        ArrayList<Cards> cardLocs = new ArrayList<>();
        Cards startingDeck = new Cards(false);
        ArrayList<Move> moves = new ArrayList<>();
        ObservableList<String> teams = FXCollections.observableArrayList();
        ArrayList<Game> result = new ArrayList<>();


        String line = reader.readLine();
        numPlayers = Integer.valueOf(line.split(" ")[1]);

        while ((line = reader.readLine()) != null) {
            char lineId = line.charAt(0);

            if (lineId == 'T') { //Team
                String[] players = line.split(" ");
                String team = "Team "; //TODO make this data structure?
                for (int i = 1; i < players.length; i++) {
                    team += players[i] + " ";
                }
                teams.add(team.trim());
            }

            else if (lineId == 'C') { //Card
                String[] parts = line.split(" \\{");
                for (String part : parts) {
                    String temp = part;
                    if (temp.contains("value")) {
                        temp = temp.replace("(value)", "");
                        Card newCard = new Card("value",temp);
                        startingDeck.add(newCard);
                        break; //if more info, don't break
                    }
                }
            }
            else if (lineId == 'M') { //Move, TODO

            }

            else if (lineId == 'A') {
                String[] parts = line.split(" ");
                startingDeck.addValueToCard("reward", parts[1], parts[2]);
            }

            else if (lineId == '|') {
                cardLocs.add(startingDeck);
                result.add(new Game(numPlayers, teams, cardLocs, moves));
                cardLocs = new ArrayList<>();
                startingDeck = new Cards(false);
                moves = new ArrayList<>();
                teams = FXCollections.observableArrayList();
            }
        }
        reader.close();
        return result;
    }

/*  Deprecated
    private ArrayList<Game> protoParseDataFrom(File dataFile) throws IOException {
        FileReader fileReader = new FileReader(dataFile);
        BufferedReader reader = new BufferedReader(fileReader);

        ArrayList<Game> result = new ArrayList<>();
        String line;

        while ((line = reader.readLine()) != null) {
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
                line = reader.readLine();
            }
            result.add(new Game(numPlayers, cardLocs, moves));
        }
        reader.close();
        return result;
    }

    //Card format ex: P1 2 3 Ace
    private Cards fromLine(String line) {
        String[] ar = line.split(" ");
        String id = ar[0];
        boolean playerOwned = false;
        if (id.charAt(0) == ('P')) {playerOwned = true;}
        int loc = Character.getNumericValue(id.charAt(1));

        ArrayList<String> list = new ArrayList<String>(Arrays.asList(ar));
        list.remove(0);
        return new Cards(list, playerOwned);
    }

     private String getCardText(ArrayList<String> cards) {
        String str = "";
        for (int i = 0; i < cards.size(); i++) {
            str += cards.get(i) + " ";
        }
        return str.trim();
    }
*/
    private File getDataFile() {
        FileChooser chooser = new FileChooser();
        chooser.setTitle("Select test data");
        return chooser.showOpenDialog(null);
    }
}
