using LearnWpf.CloseableTest.Services;
using System.Windows;

namespace LearnWpf.CloseableTest.Views
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window, ICloseable
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }
    }
}
