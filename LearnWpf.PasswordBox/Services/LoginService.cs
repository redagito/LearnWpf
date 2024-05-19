namespace LearnWpf.PasswordBox.Services
{
    internal class LoginService
    {
        public bool Login(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                return true;
            }
            return false;
        }
    }
}
