namespace LearnWpf.PasswordBox.Services
{
    /// <summary>
    /// UI with single password implement this interface to provide password retrieveal
    /// </summary>
    internal interface IPasswordHolder
    {
        string GetPassword();
        void ClearPassword();
    }
}
