using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearnWpf.NavigationTest2.Services;

namespace LearnWpf.NavigationTest2.ViewModels
{
    internal partial class SettingsViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        public SettingsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        private void NavigateHome()
        {
            _navigationService.NavigateTo<HomeViewModel>();
        }
    }
}
