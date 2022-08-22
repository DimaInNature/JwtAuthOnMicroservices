namespace JwtExample.Consumers.Desktop.Presentation.Views.Menus;

public partial class ReadMenuView : UserControl
{
    public ReadMenuView() => InitializeComponent();

    private void OpenReadUser(object sender, RoutedEventArgs e) =>
        SetFrame(source: new ReadUsersView());

    private void OpenReadProduct(object sender, RoutedEventArgs e) =>
        SetFrame(source: new ReadProductsView());

    private void SetFrame(ContentControl source)
    {
        ArgumentNullException.ThrowIfNull(argument: source);

        CollapseBody();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseBody() => MenuBody.Visibility = Visibility.Collapsed;
}