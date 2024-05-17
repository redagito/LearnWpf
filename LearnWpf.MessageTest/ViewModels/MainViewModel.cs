using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LearnWpf.MessageTest.Messages;
using LearnWpf.MessageTest.Services;
using System.Collections.ObjectModel;

namespace LearnWpf.MessageTest.ViewModels
{
    partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<string> _items;

        public ObservableCollection<string> Messages { get; set; } = new();

        private ItemService _itemService;

        public MainViewModel(ItemService itemService)
        {
            _itemService = itemService;

            Items = _itemService.GetItems();
            _itemService.ItemsChanged += () =>
            {
                Items = new(_itemService.GetItems());
            };

            WeakReferenceMessenger.Default.Register<SampleMessage>(this, (r, m) =>
            {
                Messages.Add("Sample Message");
            });
        }

        [RelayCommand]
        private void AddItem()
        {
            _itemService.AddItem("main item");
        }
    }
}
