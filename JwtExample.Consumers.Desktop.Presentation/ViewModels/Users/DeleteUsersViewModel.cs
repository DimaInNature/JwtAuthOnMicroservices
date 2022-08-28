namespace JwtExample.Consumers.Desktop.Presentation.ViewModels.Users;

internal sealed class DeleteUsersViewModel : BaseDeleteViewModel<User>
{
    private readonly IUserAppService _userService;

    private readonly UserSessionService _userSessionService;

    public DeleteUsersViewModel(
        IUserAppService userService,
        UserSessionService userSessionService)
    {
        _userService = userService;

        _userSessionService = userSessionService;

        InitializeCommands();

        Task.Run(function: () => InitializeData());
    }

    #region Command Logic

    protected override bool CanExecuteDeleteCommand(object obj) =>
        SelectedGeneralValue is not null;

    protected override async void ExecuteDeleteCommand(object obj)
    {
        if (SelectedGeneralValue is null) return;

        await _userService.DeleteAsync(
            id: SelectedGeneralValue.Id,
            token: _userSessionService.JwtToken ?? string.Empty);

        MessageBox.Show(
           messageBoxText: "The delete was successful",
           caption: "Success",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        await InitializeData();

        Clear();
    }

    #endregion

    #region Other Logic

    protected override async void Find(string filter)
    {
        var products = await _userService.GetAllAsync(
            token: _userSessionService.JwtToken ?? string.Empty);

        GeneralDataList = products.Where(
            predicate: message => message.Username.ToLower()
            .Contains(value: filter.ToLower()))
            .ToList();
    }

    protected async override Task UpdateData() => await InitializeData();

    protected override void SelectGeneralValue() { }

    private void InitializeCommands()
    {
        DeleteCommand = new RelayCommand(executeAction: ExecuteDeleteCommand,
            canExecuteFunc: CanExecuteDeleteCommand);
    }

    private async Task InitializeData()
    {
        var response = await _userService.GetAllAsync(
            token: _userSessionService.JwtToken ?? string.Empty);

        GeneralDataList = response.ToList();
    }

    #endregion
}