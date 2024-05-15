using System.Collections.ObjectModel;

namespace LearnWpf.SharingData.Services;

interface IItemService
{
    public ObservableCollection<string> Items { get; }
    void AddItem();
}
