namespace JwtExample.Consumers.Desktop.Presentation.ViewModels.Products;

internal sealed class CreateProductsViewModel : BaseCreateViewModel
{
    #region Dependencies

    private readonly IProductAppService _productService;

    private readonly UserSessionService _userSessionService;

    #endregion

    #region Accessors

    public string Name
    {
        get => _name ?? string.Empty;
        set
        {
            int maxLenght = 25;

            if (value.Equals(value: string.Empty))
            {
                _name = null;

                OnPropertyChanged(propertyName: nameof(Name));

                return;
            }

            if (value.Any())
            {
                if (value.Length > maxLenght) return;

                value = value.Replace(oldValue: " ", newValue: string.Empty);
            }

            _name = value;

            OnPropertyChanged(propertyName: nameof(Name));
        }
    }

    public string Description
    {
        get => _description ?? string.Empty;
        set
        {
            int maxLenght = 50;

            if (value.Equals(value: string.Empty))
            {
                _description = null;

                OnPropertyChanged(propertyName: nameof(Description));

                return;
            }

            if (value.Any())
            {
                if (value.Length > maxLenght) return;

                value = value.Replace(oldValue: " ", newValue: string.Empty);
            }

            _description = value;

            OnPropertyChanged(propertyName: nameof(Description));
        }
    }

    #endregion

    #region Private

    private string? _name;

    private string? _description;

    #endregion

    public CreateProductsViewModel(
        IProductAppService productService,
        UserSessionService userSessionService)
    {
        _productService = productService;

        _userSessionService = userSessionService;

        InitializeCommands();
    }

    #region Command Logic

    protected override bool CanExecuteCreateCommand(object obj) =>
        new string[] { Name, Description }.AllIsNotNullOrWhiteSpace();

    protected override async void ExecuteCreateCommand(object obj)
    {
        Product product = new(name: Name, description: Description);

        await _productService.CreateAsync(
            entity: product,
            token: _userSessionService.JwtToken ?? string.Empty);

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
        Name = string.Empty;

        Description = string.Empty;
    }

    private void InitializeCommands()
    {
        CreateCommand = new RelayCommand(executeAction: ExecuteCreateCommand,
            canExecuteFunc: CanExecuteCreateCommand);
    }

    #endregion
}