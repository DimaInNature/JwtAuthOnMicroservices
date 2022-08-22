namespace JwtExample.Consumers.Desktop.Presentation.ViewModels.Products;

internal sealed class ReadProductsViewModel : BaseReadViewModel<Product>
{
    private readonly IProductAppService _productService;

    private readonly UserSessionService _userSessionService;

    public ReadProductsViewModel(
        IProductAppService productService,
        UserSessionService userSessionService)
    {
        _productService = productService;

        _userSessionService = userSessionService;

        Task.Run(function: () => InitializeData());
    }

    #region Other Logic

    protected override async void Find(string filter)
    {
        var products = await _productService.GetAllAsync(
            token: _userSessionService.JwtToken ?? string.Empty);

        GeneralDataList = products.Where(
            predicate: message => message.Name.ToLower()
            .Contains(value: filter.ToLower()))
            .ToList();
    }

    protected async override Task UpdateData() => await InitializeData();

    private async Task InitializeData()
    {
        var response = await _productService.GetAllAsync(
            token: _userSessionService.JwtToken ?? string.Empty);

        GeneralDataList = response.ToList();
    }

    #endregion
}