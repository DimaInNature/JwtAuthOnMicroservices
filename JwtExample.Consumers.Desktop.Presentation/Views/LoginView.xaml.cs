namespace JwtExample.Consumers.Desktop.Presentation.Views;

public partial class LoginView : Window
{
    private readonly LoginViewModel _viewModel = ViewModelConnector.Connect<LoginViewModel>();

    public LoginView()
    {
        InitializeComponent();

        DataContext = _viewModel;
    }

    private void Register(object sender, RoutedEventArgs e)
    {
        _viewModel.IsConnectionStopped = false;

        LoginButton.IsEnabled = RegisterButton.IsEnabled = false;

        Task.Run(action: () =>
        {
            while (_viewModel.IsConnectionStopped is false) { }

            Dispatcher.Invoke(callback: () => LoginButton.IsEnabled = RegisterButton.IsEnabled = true);
        });
    }

    private void EnterPasswordPasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        _viewModel.Password = PasswordPB.Password;

        _viewModel.SecurePassword = PasswordPB.SecurePassword;
    }

    private void Login(object sender, RoutedEventArgs e)
    {
        _viewModel.IsConnectionStopped = false;

        LoginButton.IsEnabled = RegisterButton.IsEnabled = false;

        Task.Run(action: () =>
        {
            while (_viewModel.IsConnectionStopped is false) { }

            Dispatcher.Invoke(callback: () => LoginButton.IsEnabled = RegisterButton.IsEnabled = true);
        });
    }
}