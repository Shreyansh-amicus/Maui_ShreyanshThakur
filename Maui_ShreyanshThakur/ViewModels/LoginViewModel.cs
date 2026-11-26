
using System.Text.RegularExpressions;
using Maui_ShreyanshThakur.Commands;

namespace Maui_ShreyanshThakur.ViewModels;

public class LoginViewModel : BaseViewModel
{
    // Hardcoded credentials for this assignment.
    private const string ValidEmail = "inspector@example.com";
    private const string ValidPassword = "Password123";

    private string _email = string.Empty;
    private string _password = string.Empty;
    private string _loginError = string.Empty;

    private bool _hasEmailBeenEdited;
    private bool _hasPasswordBeenEdited;

    public AsyncRelayCommand LoginCommand { get; }

    public string Email
    {
        get => _email;
        set
        {
            if (SetProperty(ref _email, value))
            {
                _hasEmailBeenEdited = true;
                LoginError = string.Empty;
                RefreshValidation();
            }
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            if (SetProperty(ref _password, value))
            {
                _hasPasswordBeenEdited = true;
                LoginError = string.Empty;
                RefreshValidation();
            }
        }
    }

    public bool IsEmailValid =>
        !string.IsNullOrWhiteSpace(Email) &&
        Regex.IsMatch(
            Email.Trim(),
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

    public bool IsPasswordValid =>
        !string.IsNullOrEmpty(Password) &&
        Password.Length >= 8;

    public bool IsLoginEnabled =>
        IsEmailValid && IsPasswordValid;

    public string EmailError
    {
        get
        {
            if (string.IsNullOrWhiteSpace(Email))
                return "Email is required.";

            if (!IsEmailValid)
                return "Please enter a valid email address.";

            return string.Empty;
        }
    }

    public string PasswordError
    {
        get
        {
            if (string.IsNullOrEmpty(Password))
                return "Password is required.";

            if (!IsPasswordValid)
                return "Password must contain at least 8 characters.";

            return string.Empty;
        }
    }

    public bool IsEmailErrorVisible =>
        _hasEmailBeenEdited && !IsEmailValid;

    public bool IsPasswordErrorVisible =>
        _hasPasswordBeenEdited && !IsPasswordValid;

    public string LoginError
    {
        get => _loginError;
        private set
        {
            if (SetProperty(ref _loginError, value))
            {
                OnPropertyChanged(nameof(IsLoginErrorVisible));
            }
        }
    }

    public bool IsLoginErrorVisible =>
        !string.IsNullOrWhiteSpace(LoginError);

    public LoginViewModel()
    {
        LoginCommand = new AsyncRelayCommand(
            LoginAsync,
            () => IsLoginEnabled);
    }

    private void RefreshValidation()
    {
        OnPropertyChanged(nameof(IsEmailValid));
        OnPropertyChanged(nameof(IsPasswordValid));
        OnPropertyChanged(nameof(IsLoginEnabled));

        OnPropertyChanged(nameof(EmailError));
        OnPropertyChanged(nameof(PasswordError));

        OnPropertyChanged(nameof(IsEmailErrorVisible));
        OnPropertyChanged(nameof(IsPasswordErrorVisible));

        // Refresh the command's CanExecute state.
        LoginCommand.NotifyCanExecuteChanged();
    }

    private async Task LoginAsync()
    {
        if (!IsLoginEnabled)
            return;

        bool credentialsMatch =
            string.Equals(
                Email.Trim(),
                ValidEmail,
                StringComparison.OrdinalIgnoreCase) &&
            Password == ValidPassword;

        if (!credentialsMatch)
        {
            LoginError = "Incorrect email or password.";
            return;
        }

        LoginError = string.Empty;

        try
        {
            // Navigate to the registered dashboard route.
            await Shell.Current.GoToAsync("//main/dashboard");
        }
        catch (Exception ex)
        {
            LoginError = $"Unable to open dashboard: {ex.Message}";
        }
    }
}
