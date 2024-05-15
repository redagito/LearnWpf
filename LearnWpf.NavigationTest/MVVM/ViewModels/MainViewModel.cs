using LearnWpf.NavigationTest.Core;
using LearnWpf.NavigationTest.Services;

namespace LearnWpf.NavigationTest.MVVM.ViewModels
{
    internal class MainViewModel : ViewModel
    {
        private INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateHomeCommand = new RelayCommand(o => { return true; },
                o =>
                {
                    NavigationService.NavigateTo<HomeViewModel>();
                });

            NavigateSettingsCommand = new RelayCommand(o => { return true; },
                o =>
                {
                    NavigationService.NavigateTo<SettingsViewModel>();
                });

            // Default view is home
            NavigationService.NavigateTo<HomeViewModel>();
        }

        public RelayCommand NavigateHomeCommand { get; set; }
        public RelayCommand NavigateSettingsCommand { get; set; }

        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }
    }
}
