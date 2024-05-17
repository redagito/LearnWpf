using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LearnWpf.MessageTest.Messages;

namespace LearnWpf.MessageTest.ViewModels
{
    internal partial class SettingsViewModel : ObservableObject
    {
        [RelayCommand]
        private void SendMessage()
        {
            WeakReferenceMessenger.Default.Send<SampleMessage>();
        }

    }
}
