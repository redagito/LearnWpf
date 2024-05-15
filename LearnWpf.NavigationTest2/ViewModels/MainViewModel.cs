using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearnWpf.NavigationTest2.Services;

namespace LearnWpf.NavigationTest2.ViewModels
{
    /// <summary>
    /// Provides navigation and current view
    /// </summary>
    internal partial class MainViewModel : ObservableObject
    {
        public INavigationService NavigationService { get; }

        public MainViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            // Initial view is home
            NavigationService.NavigateTo<HomeViewModel>();
        }

        [RelayCommand]
        private void NavigateHome()
        {
            NavigationService.NavigateTo<HomeViewModel>();
        }

        [RelayCommand]
        private void NavigateSettings()
        {
            NavigationService.NavigateTo<SettingsViewModel>();
        }
    }
}
