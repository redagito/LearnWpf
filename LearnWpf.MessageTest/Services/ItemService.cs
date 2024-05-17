using System.Collections.Concurrent;
using System.Data;

namespace LearnWpf.MessageTest.Services
{
    /// <summary>
    /// Item service provides callback when internal collection changes
    /// </summary>
    class ItemService
    {
        public delegate void NotifyItemsChangedEventHandler();

        public event NotifyItemsChangedEventHandler? ItemsChanged;

        private Mutex _mutex = new();
        private List<string> _items = new();

        private async void UpdateWorker()
        {
            await Task.Run(async () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(TimeSpan.FromSeconds(5));
                    AddItem("Async add");
                }
            });
        }

        public ItemService()
        {
            _items.Add("foo");
            _items.Add("bar");
            _items.Add("foobar");

            UpdateWorker();
        }

        public List<string> GetItems() 
        { 
            _mutex.WaitOne();
            var l = new List<string>(_items);
            _mutex.ReleaseMutex();
            return l;
        }

        public void AddItem(string s)
        {
            _mutex.WaitOne();
            _items.Add(s);
            _mutex.ReleaseMutex();
            ItemsChanged?.Invoke();
        }
    }
}
