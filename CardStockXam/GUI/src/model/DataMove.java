package model;

public class DataMove {
    public String toUpdate;

    public DataMove(String toUpdate) {
        this.toUpdate = toUpdate;
    }

    public void execute() {
//        performAction(value);
    }

    public void revert() {
//        performAction(value * -1);
    }

//    private void performAction(int currentVal) {
//        Pair<ObservableList, Integer> temp = location.getAttribute();
//        String line = (String) temp.first.get(temp.second);
//        Pair<String, Integer> pair = getValue(line);
//        int tempVal = pair.second + currentVal;
//        String newText = pair.first + String.valueOf(tempVal);
//        temp.first.set(temp.second, newText);
//    }
    
    private Pair<String, Integer> getValue(String text) {
        String[] both = text.split(": ");
        String str = both[1] + ": ";
        int snd = Integer.parseInt(both[1]);
        return new Pair<>(str, snd);
    }
}
