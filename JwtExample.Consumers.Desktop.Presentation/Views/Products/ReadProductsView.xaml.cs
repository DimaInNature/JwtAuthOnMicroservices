namespace JwtExample.Consumers.Desktop.Presentation.Views.Products;

public partial class ReadProductsView : UserControl
{
    public ReadProductsView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<ReadProductsViewModel>();
    }
}