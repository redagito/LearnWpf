using LearnWpf.MessageTest.Services;
using LearnWpf.MessageTest.ViewModels;
using LearnWpf.MessageTest.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace LearnWpf.MessageTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<SettingsViewModel>();
            
            services.AddSingleton<MainWindow>();
            services.AddSingleton<SettingsWindow>();

            services.AddSingleton<ItemService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var window = _serviceProvider.GetRequiredService<MainWindow>();
            window.DataContext = _serviceProvider.GetRequiredService<MainViewModel>();
            window.Show();

            var settings = _serviceProvider.GetRequiredService<SettingsWindow>();
            settings.DataContext = _serviceProvider.GetRequiredService<SettingsViewModel>();
            settings.Show();

            base.OnStartup(e);
        }
    }

}
