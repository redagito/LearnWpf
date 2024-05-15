using LearnWpf.NavigationTest.Core;

namespace LearnWpf.NavigationTest.Services
{
    internal interface INavigationService
    {
        ViewModel? CurrentViewModel { get; }

        void NavigateTo<T>() where T : ViewModel;
    }
}
