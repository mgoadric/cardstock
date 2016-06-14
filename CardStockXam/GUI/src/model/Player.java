package model;

import javafx.collections.ObservableList;
import javafx.scene.control.TableView;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;
import javafx.scene.paint.Color;
import javafx.scene.shape.Circle;

import java.util.ArrayList;

public class Player {
    public int id;
    private Circle circle;
    private TableView rawData;
    private TextField name;
    private ArrayList<Cards> playerCards;

    public Player(int id) {
        playerCards = new ArrayList<>();
        this.id = id;
        setupCircle();
        addNameField();
    }

    private void setupCircle() {
        this.circle = new Circle();
        circle.setRadius(150);
        circle.setFill(Color.CYAN);
    }

    private void addNameField(){
        name = new TextField();
        name.setEditable(false);
        name.setText("Player " + id);
        name.setLayoutX(circle.getCenterX() - 75);
        name.setLayoutY(circle.getCenterY() - 12.5);
    }

    public void addRawInfo(String info) {
        rawData.getItems().add(info);
    }

    public void setLocs() {
        double rads = (2 * Math.PI) / playerCards.size();
        int i = 0;
        for (Cards groups : playerCards) {
            double angle = rads * i;
            double x = circle.getCenterX() + (circle.getRadius() * Math.sin(angle));
            double y = circle.getCenterY() + (circle.getRadius() * Math.cos(angle));
            groups.setCenter(x,y);
            i++;
        }
        addNameField();
    }

    public void setCenter(double x, double y) {
        circle.setCenterX(x);
        circle.setCenterY(y);
    }

    public ArrayList<TextArea> getAll() {
        ArrayList<TextArea> ret = new ArrayList<>();
        for (Cards groups : playerCards) {
            ret.addAll(groups.getAll());
        }
        return ret;
    }

    private ArrayList<TextField> copy(ArrayList<TextField> fields) {
        ArrayList<TextField> ret = new ArrayList<>();
        for (TextField item : fields) {
            ret.add(item);
        }
        return ret;
    }

    public Circle getCircle() {
        return circle;
    }

    public Pair<ObservableList, Integer> getAttr(String attr) {
        ObservableList items = rawData.getItems();
        for (int i = 0; i < items.size(); i++) {
            String curr = (String) items.get(i);
            if (curr == attr) {
                return new Pair<>(items, i);
            }
        }
        return null;
    }

    public Cards getCards(String toMatch) {
        for (Cards group : playerCards) {
            if (group.name.equals(toMatch)) {
                return group;
            }
        }
        Cards newCards = new Cards(toMatch, true);
        playerCards.add(newCards);
        return newCards;
    }
}
