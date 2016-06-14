package model;

import javafx.scene.shape.Rectangle;

import java.util.HashMap;

public class Card {
    public HashMap<String, Object> attributes;
    public Rectangle rect;

    public Card() {
        attributes = new HashMap<>();
    }

    public Card(String k, Object v) {
        attributes = new HashMap<>();
        addAttribute(k,v);
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
}
