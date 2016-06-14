package model;

import javafx.collections.ObservableList;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.paint.Color;
import javafx.scene.shape.Circle;

import java.util.ArrayList;

public class Player {
    public int id;
    private Circle circle;
    private ArrayList<TextField> fields;
    private TableView table;
    private TextField name;
    private Cards cards;

    public Player(int id) {
        fields = new ArrayList<>();
        cards = new Cards(true);
        this.id = id;
        setupCircle();
    }

    public Player(int id, ArrayList<TextField> fields) {
        this.id = id;
        this.fields = fields;
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

    public void addField(TextField field) {
        field.setScaleX(field.getScaleX()*1.5);
        field.setScaleY(field.getScaleY()*1.3);
        field.setEditable(false);
        field.toFront();
        fields.add(field);
    }

    public void addRawInfo(String info) {
        table.getItems().add(info);
    }

    public void setLocs() {
        double rads = (2 * Math.PI) / fields.size();
        int i = 0;
        for (TextField field : fields) {
            double angle = rads * i;
            double x = circle.getCenterX() + (circle.getRadius() * Math.sin(angle));
            double y = circle.getCenterY() + (circle.getRadius() * Math.cos(angle));
            field.setLayoutX(x);
            field.setLayoutY(y);
            i++;
        }
        addNameField();
    }

    public void setCenter(double x, double y) {
        circle.setCenterX(x);
        circle.setCenterY(y);
    }

    public ArrayList<TextField> getAll() {
        ArrayList<TextField> temp = fields;
        temp.add(name);
        return temp;
    }

    public Circle getCircle() {
        return circle;
    }

    public Pair<ObservableList, Integer> getAttr(String attr) {
        ObservableList items = table.getItems();
        for (int i = 0; i < items.size(); i++) {
            String curr = (String) items.get(i);
            if (curr == attr) {
                return new Pair<>(items, i);
            }
        }
        return null;
    }
}
