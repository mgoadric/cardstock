using System;
using AVMVVMGUI.Models;
using AVMVVMGUI.Models.CardEngine;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AVMVVMGUI.ViewModels;

/// <summary>
/// This is a ViewModel which represents a <see cref="Models.ToDoItem"/>
/// </summary>
public partial class PlayerViewModel : ViewModelBase
{
    /// <summary>
    /// Gets or sets the checked status of each item
    /// </summary>
    [ObservableProperty]
    private string _name;

    /// <summary>
    /// Gets or sets the content of the to-do item
    /// </summary>
    [ObservableProperty]
    private int _index;

    [ObservableProperty]
    private int _xPos;

    [ObservableProperty]
    private string _color = "Blue";

    [ObservableProperty]
    private int _yPos;


    /// <summary>
    /// Creates a new ToDoItemViewModel for the given <see cref="Models.ToDoItem"/>
    /// </summary>
    /// <param name="item">The item to load</param>
    public PlayerViewModel(Owner owner)
    {
        // Init the properties with the given values
        Name = owner.name;
        Index = owner.id;
        XPos = (int)(350 + -200 * Math.Sin(2 * Math.PI * Index / 8));
        YPos = (int)(400 + 300 * Math.Cos(2 * Math.PI * Index / 8));
        Console.WriteLine(XPos + "," + YPos);
    }

    public void ResetColor()
    {
        Color = "Red";
    }
}