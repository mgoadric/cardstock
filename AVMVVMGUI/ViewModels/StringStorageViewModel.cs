using System;
using System.Collections.ObjectModel;
using AVMVVMGUI.Models;
using AVMVVMGUI.Models.CardEngine;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AVMVVMGUI.ViewModels;

/// <summary>
/// This is a ViewModel which represents a <see cref="Models.ToDoItem"/>
/// </summary>
public partial class StringStorageViewModel : ViewModelBase
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
    private string _value;

    /// <summary>
    /// Creates a new ToDoItemViewModel for the given <see cref="Models.ToDoItem"/>
    /// </summary>
    /// <param name="item">The item to load</param>
    public StringStorageViewModel(string name, string value)
    {
        // Init the properties with the given values
        Name = name;
        Value = value;
    }
}