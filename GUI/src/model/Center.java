package model;

import javafx.scene.control.TextInputControl;
import javafx.scene.shape.Circle;

import java.util.ArrayList;

public class Center {
    private Circle circle;
    private ArrayList<Cards> tableCards;
    private Table owner;

    public Center(Table owner) {
        this.owner = owner;
        setupCircle();
        tableCards = new ArrayList<>();
    }

    private void setupCircle() {
        this.circle = new Circle();
        circle.setRadius(100);
    }

    public void setLocs() {
        double rads = -1 * (2 * Math.PI) / tableCards.size();
        int i = 0;
        for (Cards cards : tableCards) {
            double angle = rads * i + (Math.PI);
            double x = circle.getCenterX() + (circle.getRadius() * Math.sin(angle));
            double y = circle.getCenterY() + (circle.getRadius() * Math.cos(angle)) - 50;
            cards.setCenter(x,y);
            cards.alignCards();
            i++;
        }
    }

    public void setCenter(double x, double y) {
        circle.setCenterX(x);
        circle.setCenterY(y);
        setLocs();
    }

    public Cards getCards(String toMatch) {
        for (Cards group : tableCards) {
            if (group.matchesWith(toMatch)) {
                return group;
            }
        }
        return null;
    }

    public ArrayList<TextInputControl> getAll() {
        ArrayList<TextInputControl> ret = new ArrayList<>();
        for (Cards groups : tableCards) {
            ret.addAll(groups.getAll());
        }
        return ret;
    }

    public void addCardGroup(Cards tempDeck) {
        tableCards.add(tempDeck);
        setLocs();
    }

    public void addNewGroup(String str) {
        tableCards.add(new Cards(str, false, owner));
    }

    public void addCard(Card newCard, String loc) {
        boolean cond = addHelper(newCard, loc);
        if (!cond) {
            addNewGroup(loc);
            addHelper(newCard,loc);
        }
    }
    private boolean addHelper(Card newCard, String loc) {
        for (Cards group : tableCards) {
            if (group.matchesWith(loc)) {
                group.add(newCard);
                return true;
            }
        }
        return false;
    }

    public void addValueToCards(String key, String value, String v) {
        for (Cards cs : tableCards) {
            cs.addValueToCard(key, value, v);
        }
    }
}
