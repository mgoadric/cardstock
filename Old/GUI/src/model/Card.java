package model;

import javafx.scene.Scene;
import javafx.scene.control.TextArea;
import javafx.scene.input.MouseButton;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.VBox;
import javafx.scene.text.Text;
import javafx.stage.Modality;
import javafx.stage.Stage;

import java.util.HashMap;

public class Card {
    private HashMap<String, Object> attributes;
    TextArea rect;
    Cards owner;

    public Card() {
        attributes = new HashMap<>();
        setupRect();
        setText();
    }

    public Card(HashMap<String, Object> map) {
        attributes = map;
    }

    public void addAttribute(String k, Object v) {
        attributes.put(k,v);
        setText();
    }

    public Object getValue(String k) {
        return attributes.get(k);
    }

    public void setupRect() {
        rect = new TextArea();
        rect.setEditable(false);
        rect.setPrefWidth(75);
        rect.setPrefHeight(100);
        rect.setOnContextMenuRequested(event -> makePopup());
        rect.addEventFilter(MouseEvent.MOUSE_RELEASED, event -> {
            if (event.getButton() == MouseButton.PRIMARY) {
                owner.switchExpandMode();
            }
        });
    }

    public void setText() {
        String text = "";
        for (String key : attributes.keySet()) {
            text += getValue(key) + ": " + key + "\n";
        }
        rect.setText(text);
    }
    public String toString() {
        return rect.getText();
    }
    public String toShortString() {
        String text = "";
        for (String key : attributes.keySet()) {
            text += getValue(key) + ": " + key + " ";
        }
        return text;
    }

    public boolean hasAttribute(Object value) {
        for (String key : attributes.keySet()) {
            if (getValue(key).equals(value)) {
                return true;
            }
        }
        return false;
    }

    public void setCenter(double x, double y) {
        rect.setLayoutX(x);
        rect.setLayoutY(y);
    }

    public boolean matches(Card c) {
        return c.toMatchingString().equals(toMatchingString());
    }

    void setOwner(Cards owner) {
        this.owner = owner;
    }

    private String toMatchingString() {
        String text = "";
        for (String key : attributes.keySet()) {
            if (key != "reward") {
                text += getValue(key) + ": " + key + "\n";
            }
        }
        return text;
    }

    private void makePopup() {
        final Stage dialog = new Stage();
        dialog.initModality(Modality.APPLICATION_MODAL);
        VBox dialogVbox = new VBox(20);
        dialogVbox.getChildren().add(new Text(rect.getText()));
        Scene dialogScene = new Scene(dialogVbox, 150, 200);
        dialog.setScene(dialogScene);
        dialog.show();
    }
}
