using Microsoft.Extensions.DependencyInjection;
using LearnWpf.PasswordBox.Services;
using LearnWpf.PasswordBox.ViewModels;
using LearnWpf.PasswordBox.Views;
using System.Windows;

namespace LearnWpf.PasswordBox
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

            services.AddSingleton<LoginService>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>(p => new MainWindow { DataContext = p.GetRequiredService<MainViewModel>() });

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var window = _serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }
    }

}
