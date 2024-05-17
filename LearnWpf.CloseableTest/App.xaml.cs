using CommunityToolkit.Mvvm.ComponentModel;
using LearnWpf.CloseableTest.Services;
using LearnWpf.CloseableTest.ViewModels;
using LearnWpf.CloseableTest.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace LearnWpf.CloseableTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<SettingsWindow>();
            services.AddSingleton<SettingsViewModel>();

            services.AddSingleton<WindowManager>();
            // Factory
            services.AddSingleton<Func<Type, ObservableObject>>(p => viewModelType => (ObservableObject)p.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var windowManager = _serviceProvider.GetRequiredService<WindowManager>();
            windowManager.OpenWindow<MainViewModel>();

            base.OnStartup(e);
        }
    }

}
