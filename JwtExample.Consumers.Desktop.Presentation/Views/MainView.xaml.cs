namespace JwtExample.Consumers.Desktop.Presentation.Views;

public partial class MainView : Window
{
    public MainView() => InitializeComponent();

    private void OpenHomeSection(object sender, RoutedEventArgs e) =>
        CollapseFrame();

    private void OpenCreateSection(object sender, RoutedEventArgs e) =>
        SetFrame(source: new CreateMenuView());

    private void OpenUpdateSection(object sender, RoutedEventArgs e) =>
        SetFrame(source: new UpdateMenuView());

    private void OpenReadSection(object sender, RoutedEventArgs e) =>
        SetFrame(source: new ReadMenuView());

    private void OpenDeleteSection(object sender, RoutedEventArgs e) =>
        SetFrame(source: new DeleteMenuView());

    private void Logout(object sender, RoutedEventArgs e)
    {
        new LoginView().Show();

        Close();
    }

    private void SetFrame(ContentControl source)
    {
        if (source is null) throw new NullReferenceException(message: nameof(source));

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseFrame() =>
        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Collapsed, default);
}