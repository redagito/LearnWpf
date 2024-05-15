using LearnWpf.SharingData2.ViewModels;

namespace LearnWpf.SharingData2.Services;

internal interface IViewModelLocator
{
    MainViewModel GetMainViewModel();
    SettingsViewModel GetSettingsViewModel();
}