namespace JwtExample.Consumers.Desktop.Presentation.Views.Products;

public partial class DeleteProductsView : UserControl
{
    public DeleteProductsView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<DeleteProductsViewModel>();
    }
}