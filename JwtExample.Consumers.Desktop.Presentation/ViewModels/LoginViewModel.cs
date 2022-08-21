namespace JwtExample.Consumers.Desktop.Presentation.ViewModels;

internal sealed class LoginViewModel : BaseViewModel
{
    private readonly IAuthenticationAppService _authenticationService;

    private readonly UserSessionService _userSessionService;

    #region Acessors

    public ICommand? LoginCommand { get; private set; }

    public ICommand? RegistrationCommand { get; private set; }

    public string Username
    {
        get => _username ?? string.Empty;
        set
        {
            int maxLenght = 25;

            if (value.Equals(value: string.Empty))
            {
                _username = null;

                OnPropertyChanged(nameof(Username));

                return;
            }

            if (value.Length > 0)
            {
                if (value.Length > maxLenght) return;

                value = value.Replace(oldValue: " ", newValue: string.Empty);
            }

            _username = value;

            OnPropertyChanged(propertyName: nameof(Username));
        }
    }

    public SecureString SecurePassword
    {
        get => _securePassword ?? new();
        set
        {
            _securePassword = value;

            OnPropertyChanged(propertyName: nameof(SecurePassword));
            OnPropertyChanged(propertyName: nameof(Password));
        }
    }

    public unsafe string Password
    {
        [SecurityCritical]
        get => new(value: (char*)(void*)Marshal.SecureStringToBSTR(s: SecurePassword));
        [SecurityCritical]
        set
        {
            value ??= string.Empty;

            using SecureString secureString = new();

            foreach (char c in value) secureString.AppendChar(c);

            _password = value;
            IsPasswordWatermarkVisible = string.IsNullOrEmpty(_password);
        }
    }

    public bool IsPasswordWatermarkVisible
    {
        get => _isPasswordWatermarkVisible;
        set
        {
            if (value.Equals(obj: _isPasswordWatermarkVisible)) return;

            _isPasswordWatermarkVisible = value;

            OnPropertyChanged(propertyName: nameof(IsPasswordWatermarkVisible));
        }
    }

    #endregion

    #region Private

    private string? _username;

    private SecureString? _securePassword;

    private string? _password;

    private bool _isPasswordWatermarkVisible = true;

    #endregion

    public bool IsConnectionStopped = false;

    public LoginViewModel(
        UserSessionService userSessionService,
        IAuthenticationAppService authenticationService)
    {
        _authenticationService = authenticationService;

        _userSessionService = userSessionService;

        InitializationCommands();
    }

    private async void ExecuteLogin(object obj)
    {
        var authRequest = await _authenticationService
            .AuthorizeAsync(request: new(Username, Password));

        if (authRequest is
        { SecurityToken: default(string) or "" } or
        { User.Username: default(string) or "" } or
        { User.Username: default(string) or "" })
        {
            MessageBox.Show(
                messageBoxText: "Authorization failed.",
                caption: "Fail.",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);

            IsConnectionStopped = true;

            return;
        }

        if (authRequest?.User?.Role is not "Admin" and not "Employee")
        {
            MessageBox.Show(
                messageBoxText: "You don't have access rights.",
                caption: "Security system.",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);

            IsConnectionStopped = true;

            return;
        }

        _userSessionService.StartSession(authRequest);

        new MainView().Show();

        (obj as Window)?.Close();

        IsConnectionStopped = true;
    }

    private bool CanExecuteLogin(object obj) =>
        new string[] { Username, Password }.AnyIsNotNullOrWhiteSpace();

    private async void ExecuteRegistration(object obj)
    {
        (obj as MainView)?.Show();

        (obj as Window)?.Close();
    }

    private bool CanExecuteRegistration(object obj) =>
        new string[] { Username, Password }.AnyIsNotNullOrWhiteSpace();

    private void InitializationCommands()
    {
        LoginCommand = new RelayCommand(executeAction: ExecuteLogin,
            canExecuteFunc: CanExecuteLogin);

        RegistrationCommand = new RelayCommand(executeAction: ExecuteRegistration,
            canExecuteFunc: CanExecuteRegistration);
    }
}