using LearnWpf.SharingData2.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace LearnWpf.SharingData2.Services;

/// <summary>
/// Access to view models
/// Basically a factory?
/// </summary>
class ViewModelLocator : IViewModelLocator
{
    private readonly IServiceProvider _serviceProvider;

    public ViewModelLocator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public MainViewModel GetMainViewModel() => _serviceProvider.GetRequiredService<MainViewModel>();

    public SettingsViewModel GetSettingsViewModel() => _serviceProvider.GetRequiredService<SettingsViewModel>();
}
