using LearnWpf.NavigationTest.Core;
using LearnWpf.NavigationTest.MVVM.ViewModels;
using LearnWpf.NavigationTest.MVVM.Views;
using LearnWpf.NavigationTest.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace LearnWpf.NavigationTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            // Main window shell
            services.AddSingleton(p => new MainWindow
            {
                DataContext = p.GetRequiredService<MainViewModel>()
            });

            // View models
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<SettingsViewModel>();

            // View model factory
            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));

            // Navigation
            services.AddSingleton<INavigationService, NavigationService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}
