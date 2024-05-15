using CommunityToolkit.Mvvm.ComponentModel;

namespace LearnWpf.NavigationTest2.Services
{
    internal partial class NavigationService : ObservableObject, INavigationService
    {
        [ObservableProperty]
        private ObservableObject? _currentViewModel = null;

        // Factory method
        private readonly Func<Type, ObservableObject> _viewModelFactory;

        public NavigationService(Func<Type, ObservableObject> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<ViewModelType>() where ViewModelType : ObservableObject
        {
            CurrentViewModel = _viewModelFactory(typeof(ViewModelType));
        }
    }
}
