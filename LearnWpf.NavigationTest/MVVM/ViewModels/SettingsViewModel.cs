using LearnWpf.NavigationTest.Core;
using LearnWpf.NavigationTest.Services;
using System.Windows.Input;

namespace LearnWpf.NavigationTest.MVVM.ViewModels
{
    internal class SettingsViewModel : ViewModel
    {
        public ICommand NavigateHomeCommand { get; set; }

        private INavigationService _navigationService;

        public SettingsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateHomeCommand = new RelayCommand(o => true, o => _navigationService.NavigateTo<HomeViewModel>());
        }
    }
}
