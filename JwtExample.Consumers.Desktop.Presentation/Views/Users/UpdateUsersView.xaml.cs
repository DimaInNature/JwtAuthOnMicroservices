namespace JwtExample.Consumers.Desktop.Presentation.Views.Users;

public partial class UpdateUsersView : UserControl
{
    public UpdateUsersView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<UpdateUsersViewModel>();
    }
}