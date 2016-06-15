package model;

import javafx.scene.control.TableView;

public class DataMove {
    private TableView<RawStorage> table;
    private RawStorage toUpdate;
    private RawStorage revertTo;

    public DataMove(TableView<RawStorage> table, RawStorage toUpdate) {
        this.table = table;
        this.toUpdate = toUpdate;
    }

    public String execute() {
        if (replaceOrAdd(toUpdate)) {
            return "Replaced " + toUpdate.toString();
        }
        return "Added " + toUpdate.toString();
    }

    public String revert() {
        if (replaceOrAdd(revertTo)) {
            return "Replaced " + revertTo.toString();
        }
        return "Error: revert failed to replace";
    }

    private boolean replaceOrAdd(RawStorage toAdd) {
        int i = 0;
        for (RawStorage item : table.getItems()) {
            if (item.getLoc().equals(toAdd.getLoc())) {
                if (item.getKey().equals(toAdd.getKey())) {
                    table.getItems().remove(i);
                    if (i == table.getItems().size()) {table.getItems().add(toAdd);}
                    else {table.getItems().set(i, toAdd);}
                    return true;
                }
            }
            i++;
        }
        table.getItems().add(toAdd);
        return false;

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
