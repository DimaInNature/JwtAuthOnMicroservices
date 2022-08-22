namespace JwtExample.Consumers.Desktop.Presentation.Views;

public partial class MainView : Window
{
    public MainView() => InitializeComponent();

    private void OpenCreateSection(object sender, RoutedEventArgs e) =>
        SetFrame(source: new CreateMenuView());

    private void OpenUpdateSection(object sender, RoutedEventArgs e) =>
        SetFrame(source: new UpdateMenuView());

    private void OpenReadSection(object sender, RoutedEventArgs e) =>
        SetFrame(source: new ReadMenuView());

    private void OpenDeleteSection(object sender, RoutedEventArgs e) =>
        SetFrame(source: new DeleteMenuView());

    private void SetFrame(ContentControl source)
    {
        ArgumentNullException.ThrowIfNull(argument: source);

        CollapseBody();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseBody() => MenuBody.Visibility = Visibility.Collapsed;
}