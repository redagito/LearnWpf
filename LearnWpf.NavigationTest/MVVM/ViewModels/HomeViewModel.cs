using LearnWpf.NavigationTest.Core;
using LearnWpf.NavigationTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearnWpf.NavigationTest.MVVM.ViewModels
{
    internal class HomeViewModel : ViewModel
    {
        public ICommand NavigateSettingsCommand { get; set; }

        private INavigationService _navigationService;

        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateSettingsCommand = new RelayCommand(o => true, o => _navigationService.NavigateTo<SettingsViewModel>());
        }
    }
}
