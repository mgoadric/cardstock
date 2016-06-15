package model;

import javafx.scene.control.TextArea;

import java.util.HashMap;

public class Card {
    private HashMap<String, Object> attributes;
    TextArea rect;

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

    public boolean matches(String s) {
        return s.equals(toMatchingString());
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
}
