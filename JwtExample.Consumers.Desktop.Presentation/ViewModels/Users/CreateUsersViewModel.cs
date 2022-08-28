namespace JwtExample.Consumers.Desktop.Presentation.ViewModels.Users;

internal sealed class CreateUsersViewModel : BaseCreateViewModel
{
    #region Dependencies

    private readonly IUserAppService _userService;

    #endregion

    #region Accessors

    public string Username
    {
        get => _username ?? string.Empty;
        set
        {
            int maxLenght = 25;

            if (value.Equals(value: string.Empty))
            {
                _username = null;

                OnPropertyChanged(propertyName: nameof(Username));

                return;
            }

            if (value.Any())
            {
                if (value.Length > maxLenght) return;

                value = value.Replace(oldValue: " ", newValue: string.Empty);
            }

            _username = value;

            OnPropertyChanged(propertyName: nameof(Username));
        }
    }

    public string Password
    {
        get => _password ?? string.Empty;
        set
        {
            int maxLenght = 50;

            if (value.Equals(value: string.Empty))
            {
                _password = null;

                OnPropertyChanged(propertyName: nameof(Password));

                return;
            }

            if (value.Any())
            {
                if (value.Length > maxLenght) return;

                value = value.Replace(oldValue: " ", newValue: string.Empty);
            }

            _password = value;

            OnPropertyChanged(propertyName: nameof(Password));
        }
    }

    #endregion

    #region Private

    private string? _username;

    private string? _password;

    #endregion

    public CreateUsersViewModel(
        IUserAppService userService)
    {
        _userService = userService;

        InitializeCommands();
    }

    #region Command Logic

    protected override bool CanExecuteCreateCommand(object obj) =>
        new string[] { Username, Password }.AllIsNotNullOrWhiteSpace();

    protected override async void ExecuteCreateCommand(object obj)
    {
        User user = new(username: Username, password: Password, role: "User");

        await _userService.CreateAsync(entity: user);

        MessageBox.Show(
           messageBoxText: "The create was successful",
           caption: "Success",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        Clear();
    }

    #endregion

    #region Other Logic

    private void Clear()
    {
        Username = string.Empty;

        Password = string.Empty;
    }

    private void InitializeCommands()
    {
        CreateCommand = new RelayCommand(executeAction: ExecuteCreateCommand,
            canExecuteFunc: CanExecuteCreateCommand);
    }

    #endregion
}