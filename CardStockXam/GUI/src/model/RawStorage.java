package model;

public class RawStorage {
    private String loc;
    private String key;
    private String value;

    public RawStorage(String loc, String key, String value) {
        this.loc = loc;
        this.key = key;
        this.value = value;
    }

    public String toString() {
        return loc + " " + key + " " + value;
    }

    public String getLoc() {
        return loc;
    }

    public String getKey() {
        return key;
    }

    public String getValue() {
        return value;
    }
}
