using System;
using System.Collections.ObjectModel;
using AVMVVMGUI.Models;
using AVMVVMGUI.Models.CardEngine;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AVMVVMGUI.ViewModels;

/// <summary>
/// This is a ViewModel which represents a <see cref="Models.ToDoItem"/>
/// </summary>
public partial class PlayerViewModel : ViewModelBase
{
    private Owner owner;

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

    public ObservableCollection<StorageViewModel> IntBins { get; } = [];
    public ObservableCollection<StringStorageViewModel> StrBins { get; } = [];


    /// <summary>
    /// Creates a new ToDoItemViewModel for the given <see cref="Models.ToDoItem"/>
    /// </summary>
    /// <param name="item">The item to load</param>
    public PlayerViewModel(Owner owner)
    {
        // Init the properties with the given values
        this.owner = owner;
        Update();
    }

    public void ResetColor()
    {
        Color = "Red";
    }

    public void Update()
    {
        Name = owner.name;
        Index = owner.id;
        XPos = (int)(350 + -200 * Math.Sin(2 * Math.PI * Index / 5));
        YPos = (int)(300 + 200 * Math.Cos(2 * Math.PI * Index / 5));
        Console.WriteLine(XPos + "," + YPos);
        IntBins.Clear();
        foreach (string key in owner.intBins.Keys())
        {
            IntBins.Add(new StorageViewModel(key, owner.intBins[key]));
            Console.WriteLine("Adding " + key);
        }
        StrBins.Clear();
        foreach (string key in owner.stringBins.Keys())
        {
            StrBins.Add(new StringStorageViewModel(key, owner.stringBins[key]));
            Console.WriteLine("Adding " + key);
        }
    }
}