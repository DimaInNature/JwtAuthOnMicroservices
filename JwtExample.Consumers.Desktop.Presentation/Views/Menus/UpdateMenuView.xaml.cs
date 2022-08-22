namespace JwtExample.Consumers.Desktop.Presentation.Views.Menus;

public partial class UpdateMenuView : UserControl
{
    public UpdateMenuView() => InitializeComponent();

    private void OpenUpdateUser(object sender, RoutedEventArgs e) =>
        SetFrame(source: new UpdateUsersView());

    private void OpenUpdateProduct(object sender, RoutedEventArgs e) =>
        SetFrame(source: new UpdateProductsView());

    private void SetFrame(ContentControl source)
    {
        ArgumentNullException.ThrowIfNull(argument: source);

        CollapseBody();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseBody() => MenuBody.Visibility = Visibility.Collapsed;
}