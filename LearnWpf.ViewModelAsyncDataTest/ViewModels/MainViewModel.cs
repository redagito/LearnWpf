using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearnWpf.ViewModelAsyncDataTest.Models;
using System.Collections.ObjectModel;

namespace LearnWpf.ViewModelAsyncDataTest.ViewModels
{
    internal partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Customer> _customers = new();

        [ObservableProperty]
        private string _status = "";

        [RelayCommand]
        private async Task LoadAsync()
        {
            Status = "Loading..";

            await Task.Delay(TimeSpan.FromSeconds(5));
            Customers = new ObservableCollection<Customer>()
            {
                new Customer() { Id = 1, Name = "Hugo", Address = "Foo street"},
                new Customer() { Id = 2, Name = "Mark", Address = "Bar street"},
                new Customer() { Id = 3, Name = "Max", Address = "Blub street"}
            };

            Status = "Loaded";
        }
    }
}
