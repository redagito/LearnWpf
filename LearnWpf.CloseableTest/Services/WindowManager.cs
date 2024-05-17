using CommunityToolkit.Mvvm.ComponentModel;
using LearnWpf.CloseableTest.ViewModels;
using LearnWpf.CloseableTest.Views;
using System.Windows;

namespace LearnWpf.CloseableTest.Services
{
    /// <summary>
    /// View model based winow manager
    /// </summary>
    internal class WindowManager
    {
        // Mapping
        private Dictionary<Type, Type> _viewModelTypeToWindowType = new();
        // Factory
        private Func<Type, ObservableObject> _factoy;

        public WindowManager(Func<Type, ObservableObject> factoy)
        {
            _factoy = factoy;

            // Defaul mappings
            RegisterMapping<MainViewModel, MainWindow>();
            RegisterMapping<SettingsViewModel, SettingsWindow>();
        }

        public void OpenWindow<ViewModelType>()
        {
            var viewModel = _factoy(typeof(ViewModelType));
            OpenWindow(viewModel);
        }

        public void OpenWindow(ObservableObject viewModel)
        {
            var windowType = _viewModelTypeToWindowType[viewModel.GetType()];
            var window = Activator.CreateInstance(windowType) as Window;
            if (window == null) throw new Exception("Failed to create window");
            window.DataContext = viewModel;

            window.Show();
        }

        public void RegisterMapping<ViewModelType, WindowType>() where ViewModelType : ObservableObject where WindowType : Window
        {
            _viewModelTypeToWindowType[typeof(ViewModelType)] = typeof(WindowType);
        }
    }
}
