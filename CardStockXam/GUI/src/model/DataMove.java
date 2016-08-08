package model;

import javafx.scene.control.TableView;

public class DataMove<T extends BasicMemory> {
    private TableView<T> table;
    private T toUpdate;
    private T revertTo;
    private boolean shouldRemove = false;

    public DataMove(TableView<T> table, T toUpdate) {
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
        if (shouldRemove) {
            return remove(toUpdate);
        }
        else if (replaceOrAdd(revertTo)) {
            return "Replaced " + revertTo.toString();
        }
        return "Error: revert failed to replace";
    }

    private boolean replaceOrAdd(T toAdd) {
        int i = 0;
        for (T item : table.getItems()) {
            if (item.matches(toAdd)) {
                revertTo = table.getItems().get(i);
                table.getItems().set(i, toAdd);
                return true;
            }
            i++;
        }
        shouldRemove = true;
        table.getItems().add(toAdd);
        return false;
    }

    private String remove(T toRemove) {
        int i = 0;
        for (T item : table.getItems()) {
            if (item.matches(toRemove)) {
                table.getItems().remove(i);
                return "Removed " + toRemove.toString();
            }
            i++;
        }
        return "Failed to remove " + toUpdate;
    }
}
