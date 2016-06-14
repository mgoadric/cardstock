package model;

import javafx.scene.control.TextArea;

import java.util.HashMap;

public class Card {
    public HashMap<String, Object> attributes;
    public TextArea rect;
    public double x,y;

    public Card() {
        attributes = new HashMap<>();
        rect = new TextArea();
    }

    public Card(String k, Object v) {
        attributes = new HashMap<>();
        addAttribute(k,v);
        rect = new TextArea();
    }

    public Card(HashMap<String, Object> map) {
        attributes = map;
    }

    public void addAttribute(String k, Object v) {
        attributes.put(k,v);
    }

    public Object getValue(String k) {
        return attributes.get(k);
    }

    public void setText() {
        String text = "";
        for (String key : attributes.keySet()) {
            text += getValue(key) + ": " + key + "\n";
        }
        rect.setText(text);
    }
    public String toString() {
        String ret = "";
        for (String key : attributes.keySet()) {
            ret += key + ": " + getValue(key) + " ";
        }
        return ret.trim();
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
        this.x = x;
        this.y = y;
    }
}
