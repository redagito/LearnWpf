using LearnWpf.SharingData.MVVM.ViewModels;
using LearnWpf.SharingData.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace LearnWpf.SharingData
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<SettingsViewModel>();

            services.AddSingleton<ViewModelLocator>();
            services.AddSingleton<WindowMapper>();
            services.AddSingleton<IWindowManager, WindowManager>();
            services.AddSingleton<IItemService, ItemService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var windowManager = _serviceProvider.GetRequiredService<IWindowManager>();
            // TODO Should actually use ViewModelLocator service
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();

            windowManager.ShowWindow(mainViewModel);
            base.OnStartup(e);
        }
    }

}
