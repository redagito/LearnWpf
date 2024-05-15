using LearnWpf.SharingData.MVVM.ViewModels;
using LearnWpf.SharingData.MVVM.Views;
using System.Windows;

namespace LearnWpf.SharingData.Services
{
    /// <summary>
    /// Maps a viewmodel to its window
    /// </summary>
    class WindowMapper
    {
        private readonly Dictionary<Type, Type> _mappings = new();

        public WindowMapper()
        {
            RegisterMapping<MainViewModel, MainWindow>();
            RegisterMapping<SettingsViewModel, SettingsWindow>();
        }

        public void RegisterMapping<TViewModel, TWindow>() where TViewModel : ViewModelBase where TWindow : Window
        {
            _mappings[typeof(TViewModel)] = typeof(TWindow);
        }

        public Type GetWindowTypeForViewModel(Type viewModelType)
        {
            // No error checking done in original
            // _mappings.TryGetValue(viewModelType, out var windowType);
            // Just let it throw on error
            return _mappings[viewModelType];
        }
    }
}
