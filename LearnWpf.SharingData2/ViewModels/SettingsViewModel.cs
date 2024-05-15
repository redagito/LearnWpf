using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearnWpf.SharingData2.Models;

namespace LearnWpf.SharingData2.ViewModels;

/// <summary>
/// Provides functionality for modifying the items collection but not view it
/// Also can clear the whole collection
/// </summary>
partial class SettingsViewModel : ObservableObject
{
    private readonly ItemsModel _items;

    public SettingsViewModel(ItemsModel items)
    {
        _items = items;
    }

    [RelayCommand]
    private void AddItem()
    {
        _items.AddItem("Settings Item");
    }

    [RelayCommand]
    private void RemoveLastItem()
    {
        _items.RemoveLastItem();
    }

    [RelayCommand]
    private void ClearItems()
    {
        _items.Clear();
    }
}
