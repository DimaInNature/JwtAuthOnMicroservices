namespace JwtExample.Consumers.Desktop.Presentation.Views.Menus;

public partial class DeleteMenuView : UserControl
{
    public DeleteMenuView() => InitializeComponent();

    private void OpenDeleteUser(object sender, RoutedEventArgs e) =>
        SetFrame(source: new DeleteUsersView());

    private void OpenDeleteProduct(object sender, RoutedEventArgs e) =>
        SetFrame(source: new DeleteProductsView());

    private void SetFrame(ContentControl source)
    {
        ArgumentNullException.ThrowIfNull(argument: source);

        CollapseBody();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseBody() => MenuBody.Visibility = Visibility.Collapsed;
}