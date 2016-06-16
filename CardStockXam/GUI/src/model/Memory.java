package model;

public class Memory implements BasicMemory {
    private String key;
    private Card card;

    public Memory(String key, Card card) {
        this.key = key;
        this.card = card;
    }

    public String getKey() {
        return key;
    }

    public Card getCard() {
        return card;
    }
    public String toString() {
        return key + " " + card.toString();
    }

    @Override
    public String toMatchingString() {
        return key;
    }

    @Override
    public boolean matches(BasicMemory m) {
        return this.toMatchingString().equals(m.toMatchingString());
    }
}
