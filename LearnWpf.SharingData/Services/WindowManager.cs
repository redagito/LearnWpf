using LearnWpf.SharingData.MVVM.ViewModels;
using System.Windows;

namespace LearnWpf.SharingData.Services
{
    /// <summary>
    /// Global window manager for creating windows for view models
    /// </summary>
    class WindowManager : IWindowManager
    {
        private readonly WindowMapper _windowMapper;

        public WindowManager(WindowMapper windowMapper)
        {
            _windowMapper = windowMapper;
        }

        public void ShowWindow(ViewModelBase viewModel)
        {
            // Assumed to never be null, throws on error
            var windowType = _windowMapper.GetWindowTypeForViewModel(viewModel.GetType());
            var window = Activator.CreateInstance(windowType) as Window;

            // Fail on null
            if (window == null) throw new Exception("Failed to create window");
            
            window.DataContext = viewModel;

            // Closed handler
            window.Closed += (sender, args) => CloseWindow();

            window.Show();
        }

        public void CloseWindow()
        {
            MessageBox.Show("Window was closed", "Closed");
        }
    }
}
