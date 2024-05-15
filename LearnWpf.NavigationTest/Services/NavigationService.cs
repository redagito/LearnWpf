using LearnWpf.NavigationTest.Core;

namespace LearnWpf.NavigationTest.Services
{
    internal class NavigationService : ObservableObject, INavigationService
    {
        private readonly Func<Type, ViewModel> _viewModelFactory;
        private ViewModel? _currentViewModel = null;

        public NavigationService(Func<Type, ViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public ViewModel? CurrentViewModel
        {
            get => _currentViewModel;
            private set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModel
        {
            CurrentViewModel = _viewModelFactory(typeof(TViewModel));
        }
    }
}
