using System.Collections.ObjectModel;
using AVMVVMGUI.Models.CardEngine;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AVMVVMGUI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<ToDoItemViewModel> ToDoItems { get; } = [];
    public ObservableCollection<PlayerViewModel> Players { get; } = [];

    public CardGame game = new();

    /// <summary>
    /// Gets or set the content for new Items to add. If this string is not empty, the AddItemCommand will be enabled automatically
    /// </summary>
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddItemCommand))] // This attribute will invalidate the command each time this property changes
    private string? _newItemContent;

    public MainWindowViewModel()
    {
        game.AddPlayers(5);
        foreach (Owner owner in game.players)
        {
            Players.Add(new PlayerViewModel(owner));
        }
        ToDoItems.Add(new ToDoItemViewModel()
        {
            Content = "table",
            XPos = 350,
            YPos = 400
        });
    }

    /// <summary>
    /// Returns if a new Item can be added. We require to have the NewItem some Text
    /// </summary>
    private bool CanAddItem() => !string.IsNullOrWhiteSpace(NewItemContent);

    /// <summary>
    /// This command is used to add a new Item to the List
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanAddItem))]
    private void AddItem()
    {
        // Add a new item to the list
        ToDoItems.Add(new ToDoItemViewModel(new Models.ToDoItem()
        {
            Content = NewItemContent
        }, ToDoItems.Count));

        // reset the NewItemContent
        NewItemContent = null;
    }
    
    /// <summary>
    /// Removes the given Item from the list
    /// </summary>
    /// <param name="item">the item to remove</param>
    [RelayCommand]
    private void RemoveItem(ToDoItemViewModel item)
    {
        // Remove the given item from the list
        ToDoItems.Remove(item);
    }
}
