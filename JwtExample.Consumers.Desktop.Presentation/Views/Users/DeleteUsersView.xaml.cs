namespace JwtExample.Consumers.Desktop.Presentation.Views.Users;

public partial class DeleteUsersView : UserControl
{
    public DeleteUsersView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<DeleteUsersViewModel>();
    }
}