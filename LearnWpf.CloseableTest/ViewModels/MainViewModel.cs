using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearnWpf.CloseableTest.Services;

namespace LearnWpf.CloseableTest.ViewModels
{
    internal partial class MainViewModel : ObservableObject
    {
        private readonly WindowManager _windowManager;

        public MainViewModel(WindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        [RelayCommand]
        private void OpenSettings()
        {
            _windowManager.OpenWindow<SettingsViewModel>();
        }
    }
}
