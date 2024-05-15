using LearnWpf.SharingData.MVVM.ViewModels;

namespace LearnWpf.SharingData.Services;

interface IWindowManager
{
    // Creates and shows a window for a viewmodel
    void ShowWindow(ViewModelBase viewModel);

    // Callback on window closed
    void CloseWindow();
}