using CommunityToolkit.Mvvm.ComponentModel;
using LearnWpf.NavigationTest2.Services;
using LearnWpf.NavigationTest2.ViewModels;
using LearnWpf.NavigationTest2.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace LearnWpf.NavigationTest2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            // Configure DI container
            IServiceCollection services = new ServiceCollection();

            // Main window creation requires additional logic
            services.AddSingleton(p => new MainWindow
            {
                DataContext = p.GetRequiredService<MainViewModel>()
            });

            // Viewmodels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<SettingsViewModel>();

            // Viewmodel factory
            services.AddSingleton<Func<Type, ObservableObject>>(p => viewModelType => (ObservableObject)p.GetRequiredService(viewModelType));

            // Navigation
            services.AddSingleton<INavigationService, NavigationService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Initial window shell created directly
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}
