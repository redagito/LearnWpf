using LearnWpf.SharingData.MVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace LearnWpf.SharingData.Services
{
    /// <summary>
    /// Access to viewmodels
    /// </summary>
    class ViewModelLocator
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewModelLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public MainViewModel GetMainViewModel() => _serviceProvider.GetRequiredService<MainViewModel>();
        public SettingsViewModel GetSettingsViewModel() => _serviceProvider.GetRequiredService<SettingsViewModel>();
    }
}
