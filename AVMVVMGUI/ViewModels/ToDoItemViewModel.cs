using System;
using AVMVVMGUI.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AVMVVMGUI.ViewModels;

/// <summary>
/// This is a ViewModel which represents a <see cref="Models.ToDoItem"/>
/// </summary>
public partial class ToDoItemViewModel : ViewModelBase
{
    /// <summary>
    /// Gets or sets the checked status of each item
    /// </summary>
    [ObservableProperty]
    private bool _isChecked;

    /// <summary>
    /// Gets or sets the content of the to-do item
    /// </summary>
    [ObservableProperty]
    private string? _content;

    [ObservableProperty]
    private int _xPos;

    [ObservableProperty]
    private int _yPos;

    /// <summary>
    /// Creates a new blank ToDoItemViewModel
    /// </summary>
    public ToDoItemViewModel()
    {
        // empty
    }

    /// <summary>
    /// Creates a new ToDoItemViewModel for the given <see cref="Models.ToDoItem"/>
    /// </summary>
    /// <param name="item">The item to load</param>
    public ToDoItemViewModel(ToDoItem item, int index)
    {
        // Init the properties with the given values
        IsChecked = item.IsChecked;
        Content = item.Content;
        XPos = (int)(325 + 175 * Math.Sin(2 * Math.PI * index/8));
        YPos = (int)(310 + 200 * Math.Cos(2 * Math.PI * index/8));
        Console.WriteLine(XPos + "," + YPos);
    }

    /// <summary>
    /// Gets a ToDoItem of this ViewModel
    /// </summary>
    /// <returns>The ToDoItem</returns>
    public ToDoItem GetToDoItem()
    {
        return new ToDoItem()
        {
            IsChecked = this.IsChecked,
            Content = this.Content,
            XPos = this.XPos,
            YPos = this.YPos
        };
    }
}