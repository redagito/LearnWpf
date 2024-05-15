using LearnWpf.SharingData2.Models;
using LearnWpf.SharingData2.Services;
using LearnWpf.SharingData2.ViewModels;
using LearnWpf.SharingData2.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace LearnWpf.SharingData2;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IServiceProvider _serviceProvider;

    public App()
    {
        IServiceCollection services = new ServiceCollection();

        // Views
        services.AddSingleton<MainWindow>();
        services.AddSingleton<SettingsWindow>();

        // View models
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<SettingsViewModel>();

        // Models
        services.AddSingleton<ItemsModel>();

        // Additional services
        services.AddSingleton<IViewModelLocator, ViewModelLocator>();
        services.AddSingleton<IWindowManager, WindowManager>();
        services.AddSingleton<WindowMapper>();

        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var windowManager = _serviceProvider.GetRequiredService<IWindowManager>();
        var locator = _serviceProvider.GetRequiredService<IViewModelLocator>();

        // Main window with viewmodel
        var mainViewModel = locator.GetMainViewModel();
        windowManager.ShowWindow(mainViewModel);

        base.OnStartup(e);
    }
}
