using CommunityToolkit.Mvvm.ComponentModel;

namespace LearnWpf.SharingData2.Services;

internal interface IWindowManager
{
    void CloseWindow();
    void ShowWindow(ObservableObject viewModel);
}