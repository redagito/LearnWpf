using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearnWpf.SharingData2.Models;
using LearnWpf.SharingData2.Services;
using System.Collections.ObjectModel;

namespace LearnWpf.SharingData2.ViewModels;

/// <summary>
/// Provides functionality to view and modify the items collection
/// and opening the settings window
/// </summary>
partial class MainViewModel : ObservableObject
{
    private IWindowManager _windowManager;
    private IViewModelLocator _viewModelLocator;
    private ItemsModel _items;

    public ObservableCollection<string> Items { get => _items.Items; }

    public MainViewModel(ItemsModel items, IWindowManager windowManager, IViewModelLocator viewModelLocator)
    {
        _items = items;
        _windowManager = windowManager;
        _viewModelLocator = viewModelLocator;
    }

    [RelayCommand]
    private void AddItem()
    {
        _items.AddItem("Main Item");
    }

    [RelayCommand]
    private void RemoveLastItem()
    {
        _items.RemoveLastItem();
    }

    [RelayCommand]
    private void OpenSettings()
    {
        var settingsViewModel = _viewModelLocator.GetSettingsViewModel();
        _windowManager.ShowWindow(settingsViewModel);
    }
}
