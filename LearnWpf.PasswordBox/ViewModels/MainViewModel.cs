using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearnWpf.PasswordBox.Services;

namespace LearnWpf.PasswordBox.ViewModels
{
    /// <summary>
    /// Login
    /// </summary>
    internal partial class MainViewModel : ObservableObject
    {
        private readonly LoginService _loginService;

        public MainViewModel(LoginService loginService)
        {
            _loginService = loginService;
        }

        [ObservableProperty]
        private string _userName = "";

        [ObservableProperty]
        private string _errorMessage = "";

        [ObservableProperty]
        private string _loginInformation = "";

        [RelayCommand]
        private void Login(IPasswordHolder passwordHolder)
        {
            var user = UserName;
            var pass = passwordHolder.GetPassword();
            var ok = _loginService.Login(user, pass);

            // Clear form
            ErrorMessage = "";
            UserName = "";
            passwordHolder.ClearPassword();

            // Check
            if (ok)
            {
                LoginInformation = $"Logged in as {user}";
            }
            else
            {
                ErrorMessage = "Failed to login";
            }
        }
    }
}
