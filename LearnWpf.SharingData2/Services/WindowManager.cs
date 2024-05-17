using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;

namespace LearnWpf.SharingData2.Services;

/// <summary>
/// Viewmodel based windows management
/// </summary>
class WindowManager : IWindowManager
{
    private readonly WindowMapper _windowMapper;

    public WindowManager(WindowMapper windowMapper)
    {
        _windowMapper = windowMapper;
    }

    /// <summary>
    /// Shows a window for a viewmodel
    /// </summary>
    /// <param name="viewModel"></param>
    public void ShowWindow(ObservableObject viewModel)
    {
        // Get the mapped window type
        var type = _windowMapper.GetWindowTypeForViewModel(viewModel.GetType());

        // Create and set view model
        var window = Activator.CreateInstance(type) as Window;
        if (window == null) throw new Exception($"Failed to create window type {type} for view model type {viewModel.GetType()}");
        window.DataContext = viewModel;

        // Set on close callback
        window.Closing += (sender, args) => CloseWindow();

        // Open
        window.Show();
    }

    public void CloseWindow()
    {
        // Called on close
        MessageBox.Show("Closed window", "Closed");
    }
}
