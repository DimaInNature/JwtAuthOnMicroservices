namespace JwtExample.Consumers.Desktop.Presentation.ViewModels.Users;

internal sealed class ReadUsersViewModel : BaseReadViewModel<User>
{
    private readonly IUserAppService _userService;

    private readonly UserSessionService _userSessionService;

    public ReadUsersViewModel(
        IUserAppService userService,
        UserSessionService userSessionService)
    {
        _userService = userService;

        _userSessionService = userSessionService;

        Task.Run(function: () => InitializeData());
    }

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

    private async Task InitializeData()
    {
        var response = await _userService.GetAllAsync(
            token: _userSessionService.JwtToken ?? string.Empty);

        GeneralDataList = response.ToList();
    }

    #endregion
}