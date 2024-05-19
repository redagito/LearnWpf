using LearnWpf.PasswordBox.Services;
using System.Windows;

namespace LearnWpf.PasswordBox.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, IPasswordHolder
{
    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Extracts and returns password string from wpf password box
    /// Ok in code behind
    /// </summary>
    /// <returns></returns>
    public string GetPassword()
    {
        return Password.Password;
    }

    public void ClearPassword() 
    {
        Password.Clear();
    }
}