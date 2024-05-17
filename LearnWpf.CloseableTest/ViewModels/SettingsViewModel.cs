using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearnWpf.CloseableTest.Services;

namespace LearnWpf.CloseableTest.ViewModels
{
    internal partial class SettingsViewModel : ObservableObject
    {
        [RelayCommand]
        private void Close(ICloseable closeable)
        {
            closeable.Close();
        }
    }
}
