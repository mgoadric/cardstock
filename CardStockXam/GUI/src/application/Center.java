package application;

import javafx.scene.control.TextArea;
import javafx.scene.shape.Circle;

import java.util.ArrayList;

public class Center {
    private Circle circle;
    private ArrayList<TextArea> fields;
    private Cards cards;

    public Center() {
        setupCircle();
        fields = new ArrayList<>();
        cards = new Cards(true);
    }

    public Center(ArrayList<TextArea> fields) {
        setupCircle();
        this.fields = fields;
    }

    private void setupCircle() {
        this.circle = new Circle();
        circle.setRadius(50);
    }

    public void addField(TextArea field) {
        field.setEditable(false);
        field.setPrefColumnCount(20);
        field.setPrefRowCount(6);
        field.setWrapText(true);
        fields.add(field);
    }

    public void setLocs() {
        double rads = -1 * (2 * Math.PI) / fields.size();
        int i = 0;
        for (TextArea field : fields) {
            double angle = rads * i + (Math.PI / 2);
            double x = circle.getCenterX() + (circle.getRadius() * Math.sin(angle));
            double y = circle.getCenterY() + (circle.getRadius() * Math.cos(angle));
            field.setLayoutX(x);
            field.setLayoutY(y);
            i++;
        }
    }

    public void setCenter(double x, double y) {
        circle.setCenterX(x);
        circle.setCenterY(y);
    }

    public ArrayList<TextArea> getAll() {
        return fields;
    }
}
