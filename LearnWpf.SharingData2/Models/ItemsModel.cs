using System.Collections.ObjectModel;

namespace LearnWpf.SharingData2.Models;

/// <summary>
/// Represents items model for storing and manipulating items
/// </summary>
class ItemsModel
{
    public ObservableCollection<string> Items { get; } = new();

    public void AddItem(string item)
    {
        Items.Add(item);
    }

    public void RemoveLastItem()
    {
        Items.RemoveAt(Items.Count - 1);
    }

    public void Clear()
    {
        Items.Clear();
    }
}
