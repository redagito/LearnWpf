using CommunityToolkit.Mvvm.ComponentModel;
using LearnWpf.SharingData2.ViewModels;
using LearnWpf.SharingData2.Views;
using System.Windows;

namespace LearnWpf.SharingData2.Services;

/// <summary>
/// Stores and resolves mappings between viewmodel and view
/// </summary>
class WindowMapper
{
    private Dictionary<Type, Type> _mappings = new();

    public WindowMapper() 
    {
        // Initial mappings
        RegisterMapping<MainViewModel, MainWindow>();
        RegisterMapping<SettingsViewModel, SettingsWindow>();
    }

    public void RegisterMapping<ViewModelType, WindowType>() where ViewModelType : ObservableObject where WindowType : Window
    {
        _mappings[typeof(ViewModelType)] = typeof(WindowType);
    }

    /// <summary>
    /// Throws when mapping does not exist
    /// </summary>
    /// <param name="viewModelType"></param>
    /// <returns></returns>
    public Type GetWindowTypeForViewModel(Type viewModelType)
    {
        return _mappings[viewModelType];
    }
}
