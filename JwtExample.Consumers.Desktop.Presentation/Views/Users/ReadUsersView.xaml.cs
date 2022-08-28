namespace JwtExample.Consumers.Desktop.Presentation.Views.Users;

public partial class ReadUsersView : UserControl
{
    public ReadUsersView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<ReadUsersViewModel>();
    }
}