using LearnWpf.SharingData.Core;
using LearnWpf.SharingData.Services;

namespace LearnWpf.SharingData.MVVM.ViewModels
{
    class SettingsViewModel : ViewModelBase
    {
        public IItemService ItemService { get; }

        public RelayCommand AddItemCommand { get; }

        public SettingsViewModel(IItemService itemService)
        {
            ItemService = itemService;
            AddItemCommand = new RelayCommand(o => ItemService.AddItem(), o => true);
        }
    }
}
