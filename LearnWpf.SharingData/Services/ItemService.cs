using System.Collections.ObjectModel;

namespace LearnWpf.SharingData.Services
{
    class ItemService : IItemService
    {
        public ObservableCollection<string> Items { get; } = new();

        public void AddItem()
        {
            Items.Add("Item");
        }
    }
}
