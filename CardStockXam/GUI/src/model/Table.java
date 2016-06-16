package model;

import javafx.scene.control.TextInputControl;
import javafx.scene.layout.AnchorPane;
import javafx.scene.paint.Color;
import javafx.scene.shape.Circle;

import java.util.ArrayList;
import java.util.stream.Collectors;

public class Table {
    private Circle circle;
    private ArrayList<Player> players;
    private Center center;


    public Table() {
        setupCircle();
        players = new ArrayList<>();
        center = new Center();
    }

    private void setupCircle() {
        this.circle = new Circle();
        circle.setCenterX(600);
        circle.setCenterY(450);
        circle.setRadius(300);
        circle.setFill(Color.RED);
        circle.setVisible(false);
    }

    public void addPlayer(Player p) {
        players.add(p);
        setLocs();
    }

    public void addToTable(Cards tempDeck) {
        center.addCardGroup(tempDeck);
    }

    public Cards getTableCards(String string) {
        return center.getCards(string);
    }

    public Cards getPlayerCards(int playerId, String cardId) {
        for (Player p : players) {
            if (p.matchesWith(playerId)) {
                return p.getCards(cardId);
            }
        }
        return null;
    }

    public Player getPlayer(int playerId) {
        if (playerId < players.size() && playerId >=0) {
            return players.get(playerId);
        }
        return null;
    }

    public void setLocs() {
        double rads = -1 * (2 * Math.PI) / players.size() + 2 * Math.PI;
        int i = 0;
        for (Player player : players) {
            double angle = rads * i;
            double x = circle.getCenterX() + (circle.getRadius() * Math.sin(angle));
            double y = circle.getCenterY() + (circle.getRadius() * Math.cos(angle));
            player.setCenter(x, y);
            player.setLocs();
            i++;
        }
        center.setCenter(circle.getCenterX(), circle.getCenterY());
        center.setLocs();
    }

    public ArrayList<TextInputControl> getAll() {
        ArrayList<TextInputControl> ret = new ArrayList<>();
        for (Player p : players) {
            ret.addAll(p.getAll());
        }
        ret.addAll(center.getAll());
        return ret;
    }
    public ArrayList<Circle> getCircles() {
        ArrayList<Circle> ret = players.stream().map(Player::getCircle).collect(Collectors.toCollection(ArrayList::new));
        ret.add(circle);
        return ret;
    }

    public void paint(AnchorPane pane) {
        pane.getChildren().addAll(getCircles());
        pane.getChildren().addAll(getAll());
    }

    public void addNewTableGroup(String str) {
        center.addNewGroup(str);
    }

    public void addToTable(Card newCard, String loc) {
        center.addCard(newCard, loc);
    }

    public void addValueToCards(String key, String value, String v) {
        center.addValueToCards(key, value, v);
        for (Player p : players) {
            p.addValueToCards(key, value, v);
        }
    }

    public void paintCurrentTurn(int oldTurn, int turn) {
        for (Player p : players) {
            if (p.id == turn) {
                p.setColor(Color.RED);
            }
            else if (p.id == oldTurn) {
                p.setColor(Color.CYAN);
            }
        }
    }
}
