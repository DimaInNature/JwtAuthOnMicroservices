namespace JwtExample.Consumers.Desktop.Presentation.Views.Menus;

public partial class CreateMenuView : UserControl
{
    public CreateMenuView() => InitializeComponent();

    private void OpenCreateUser(object sender, RoutedEventArgs e) =>
        SetFrame(source: new CreateUsersView());

    private void OpenCreateProduct(object sender, RoutedEventArgs e) =>
        SetFrame(source: new CreateProductsView());

    private void SetFrame(ContentControl source)
    {
        ArgumentNullException.ThrowIfNull(argument: source);

        CollapseBody();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseBody() => MenuBody.Visibility = Visibility.Collapsed;
}