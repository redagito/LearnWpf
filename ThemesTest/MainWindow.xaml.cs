using System.Windows;

namespace ThemesTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Light theme active by default
        private bool _isLightTheme = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for toggle theme buttom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnToggleButtonCheckedOrUnchecked(object sender, RoutedEventArgs e)
        {
            _isLightTheme = !_isLightTheme;
            var newThemePath = _isLightTheme ? "LightTheme.xaml" : "DarkTheme.xaml";

            // Load new theme resource from xaml
            var newTheme = (ResourceDictionary)Application.LoadComponent(new Uri(newThemePath, UriKind.Relative));
            // First element in merged dictionaries was old theme
            Application.Current.Resources.MergedDictionaries.RemoveAt(0);
            // Replace with new theme
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }
    }
}