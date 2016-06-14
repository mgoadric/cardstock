package application;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.layout.AnchorPane;
import javafx.stage.FileChooser;
import model.*;

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
    TextField currentTurn;

    @FXML
    TextArea infoTable;

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
    private ArrayList<Move> moves;
    private ArrayList<Game> games;
    private Table table;
    private String STOCKNAME = "{hidden}STOCK";

    @FXML
    public void initialize() {
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
        this.moves = currentGame.moves;
        this.table = currentGame.table;

        currentMove = 0;
        table.setLocs();
        addInfo(currentGame.info);
        paint();
    }

    @FXML
    public void forward() {
        if (currentMove < moves.size()) {
            Move move = moves.get(currentMove);
            move.execute();
            currentMove++;
            paint();
        }
    }

    @FXML
    public void backward() {
        if (currentMove > 0) {
            Move move = moves.get(currentMove - 1);
            move.revert();
            currentMove--;
            paint();
        }
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
        pane.getChildren().clear();

    }

    private void addGames() {
        for (int i = 1; i <= games.size(); i++) {
            gameSelect.getItems().add(i);
        }
    }

    private void addInfo(ObservableList<String> info) {
        infoTable.setPrefHeight(info.size() * 24 + 2);
        infoTable.setPrefWidth(150);
        pane.getChildren().add(infoTable);
    }

    private void paint() {
        pane.getChildren().clear();
        table.paint(pane);
        addInfo(currentGame.info);
        int turn = moves.get(currentMove).getCurrentPlayer();
        currentTurn.setText("Current turn: Player " + turn);
        currentMoveField.setText("Current move: " + currentMove);
    }


    private ArrayList<Game> parseDataFrom(File dataFile) throws IOException {
        FileReader fileReader = new FileReader(dataFile);
        BufferedReader reader = new BufferedReader(fileReader);

        ArrayList<Cards> cardLocs = new ArrayList<>();
        ArrayList<Move> currentMoves = new ArrayList<>();
        ObservableList<String> info = FXCollections.observableArrayList();
        ArrayList<Game> result = new ArrayList<>();
        int scoreNum = 0;


        String line = reader.readLine();
        numPlayers = Integer.valueOf(line.split(":")[1]);
        Table newTable = setupTable();
        newTable.addToTable(new Cards(STOCKNAME, false));

        while ((line = reader.readLine()) != null) {
            char lineId = line.charAt(0);
            if (line.length() > 1) {line = line.split(":")[1];}

            if (lineId == 'T') { //Team
                String[] players = line.split(" ");
                String team = "Team "; //TODO make this data structure?
                for (int i = 0; i < players.length; i++) {
                    team += players[i] + " ";
                }
                info.add(team.trim());
            }

            else if (lineId == 'C') { //Card
                Card newCard = getCard(line);
                newTable.addToTable(newCard, STOCKNAME);
            }
            else if (lineId == 'M') { //Move
                String[] parts = line.split(" ");
                Card card = getCard(parts[0]);
                Location startLoc = getLocation(parts[1], newTable);
                Location endLoc = getLocation(parts[2], newTable);
                Move newMove = new Move(card, startLoc, endLoc);
                if (currentMoves.size() != 0) {
                    int currentPlayer = lastMove(currentMoves).getCurrentPlayer();
                    newMove.setCurrentPlayer(currentPlayer);
                }
                else {newMove.setCurrentPlayer(0);}
                currentMoves.add(newMove);
            }

            else if (lineId == 'A') { //Assignment
                String[] parts = line.split(" ");
                newTable.addValueToCards("reward", parts[0], parts[1]);
            }

            else if (lineId == 'S') { //Storage
                String[] parts = line.split(" ");
                String loc = parts[0];
                String key = parts[1];
                int value = Integer.parseInt(parts[2]);
                Move newMove = new Move(loc + " " + key + " " + value);
                currentMoves.add(newMove);
            }

            else if (lineId == 't') { //current player (turn)
                Move move = lastMove(currentMoves);
                move.setCurrentPlayer(Integer.parseInt(line));
            }

            else if (lineId == 's') { //Score
                String[] parts = line.split(" ");
                String score = parts[0];
                String won = parts[1];
                String suffix = "lost";
                if (parts[1].equals("1")) {suffix = "won";}
                Move newMove = new Move("Player " + scoreNum + ": " + score + ", " + suffix);
                currentMoves.add(newMove);
            }

            else if (lineId == '|') { //End of game
                result.add(new Game(numPlayers, newTable, info, cardLocs, currentMoves));
                cardLocs = new ArrayList<>();
                newTable = setupTable();
                currentMoves = new ArrayList<>();
                info = FXCollections.observableArrayList();
            }
        }
        reader.close();
        return result;
    }

    private Card getCard(String line) {
        String[] parts = line.split("\\|");
        Card ret = new Card();
        for (String part : parts) {
            String[] attrs = part.split("-");
            ret.addAttribute(attrs[1],attrs[0]);
        }
        return ret;
    }

    private Move lastMove(ArrayList<Move> moves) {
        return moves.get(moves.size()-1);
    }

    private Location getLocation(String line, Table newTable) {
        char id = line.charAt(0);
        if (id == 't') { //table
            Cards cards = newTable.getTableCards(line.substring(1));
            if (cards == null) {
                newTable.addNewTableGroup(line.substring(1));
            }
            return new Location(newTable, line.substring(1));
        }
        else if (id == 'p') { //player
            int playerId = Character.getNumericValue(line.charAt(1));
            Player p = newTable.getPlayer(playerId);
            if (p != null) {
                return new Location(newTable, line.substring(2), playerId);
            }
            else {
                error("bad player: " + playerId);
            }
        }
        else {
            error("unknown line: " + line);
        }
        return null;
    }

    private File getDataFile() {
        FileChooser chooser = new FileChooser();
        chooser.setTitle("Select test data");
        return chooser.showOpenDialog(null);
    }

    private Table setupTable() {
        Table ret = new Table();
        for (int i = 0; i < numPlayers; i++) {
            ret.addPlayer(new Player(i));
        }
        return ret;
    }

    private void error(String text) {
        errorField.setText(text);
        System.out.println(text);
    }
}
