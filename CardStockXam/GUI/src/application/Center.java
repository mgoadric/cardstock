package application;

import javafx.scene.control.TextField;
import javafx.scene.shape.Circle;

import java.util.ArrayList;

public class Center {
    private Circle circle;
    private ArrayList<TextField> fields;
    private Cards cards;

    public Center() {
        setupCircle();
        fields = new ArrayList<>();
        cards = new Cards(true);
    }

    public Center(ArrayList<TextField> fields) {
        setupCircle();
        this.fields = fields;
    }

    private void setupCircle() {
        this.circle = new Circle();
        circle.setCenterX(400);
        circle.setCenterY(250);
        circle.setRadius(50);
    }

    public void addField(TextField field) {
        field.setEditable(false);
        field.setScaleX(field.getScaleX()*2);
        field.setScaleY(field.getScaleY()*1.3);
        fields.add(field);
        cards.add("");
    }

    public void setLocs() {
        double rads = -1 * (2 * Math.PI) / fields.size();
        int i = 0;
        for (TextField field : fields) {
            double angle = rads * i + (Math.PI / 2);
            double x = circle.getCenterX() + (circle.getRadius() * Math.sin(angle));
            double y = circle.getCenterY() + (circle.getRadius() * Math.cos(angle));
            field.setLayoutX(x);
            field.setLayoutY(y);
            i++;
        }
    }

    public void setCenter(double x, double y) {
        circle.setLayoutX(x);
        circle.setLayoutY(y);
    }

    public ArrayList<TextField> getAll() {
        return fields;
    }
}
