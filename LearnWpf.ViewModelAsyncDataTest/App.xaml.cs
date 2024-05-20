using LearnWpf.ViewModelAsyncDataTest.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace LearnWpf.ViewModelAsyncDataTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var win = new MainWindow() { DataContext = new MainViewModel() };
            win.Show();
            base.OnStartup(e);
        }
    }

}
