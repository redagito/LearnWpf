using CommunityToolkit.Mvvm.ComponentModel;

namespace LearnWpf.NavigationTest2.Services
{
    internal interface INavigationService
    {
        void NavigateTo<ViewModelType>() where ViewModelType : ObservableObject;

        ObservableObject? CurrentViewModel { get; }
    }
}
