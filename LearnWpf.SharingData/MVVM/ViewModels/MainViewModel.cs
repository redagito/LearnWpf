using LearnWpf.SharingData.Core;
using LearnWpf.SharingData.Services;

namespace LearnWpf.SharingData.MVVM.ViewModels;

class MainViewModel : ViewModelBase
{
    // The items
    public IItemService ItemService { get; }

    // Open settings
    public RelayCommand OpenSettingsWindowCommand { get; set; }

    private IWindowManager _windowManager;
    private ViewModelLocator _viewLocator;

    public MainViewModel(IItemService itemService, IWindowManager windowManager, ViewModelLocator viewLocator)
    {
        ItemService = itemService;

        _windowManager = windowManager;
        _viewLocator = viewLocator;

        OpenSettingsWindowCommand = new RelayCommand(o =>
        {
            var settingsViewModel = _viewLocator.GetSettingsViewModel();
            _windowManager.ShowWindow(settingsViewModel);
        }, o => true);
    }
}
