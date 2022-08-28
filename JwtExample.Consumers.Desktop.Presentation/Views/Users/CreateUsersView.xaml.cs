namespace JwtExample.Consumers.Desktop.Presentation.Views.Users;

public partial class CreateUsersView : UserControl
{
    public CreateUsersView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<CreateUsersViewModel>();
    }
}