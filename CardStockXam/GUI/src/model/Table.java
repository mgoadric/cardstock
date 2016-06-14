package model;

import javafx.scene.control.TextArea;
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

    public Table(ArrayList<Player> players) {
        setupCircle();
        this.players = players;
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

    public void addToCenter(TextArea field) {
        center.addField(field);
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

    public Player getPlayer(int playerId) {
        if (playerId < players.size() && playerId >=0) {
            return players.get(playerId);
        }
        return null;
    }

    public Cards getCards(String string) {
        return center.getCards(string);
    }
}
