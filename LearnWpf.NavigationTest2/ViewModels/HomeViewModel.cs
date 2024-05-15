using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearnWpf.NavigationTest2.Services;

namespace LearnWpf.NavigationTest2.ViewModels
{
    internal partial class HomeViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        private void NavigateSettings()
        {
            _navigationService.NavigateTo<SettingsViewModel>();
        }
    }
}
