namespace JwtExample.Consumers.Desktop.Presentation.Views.Products;

public partial class UpdateProductsView : UserControl
{
    public UpdateProductsView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<UpdateProductsViewModel>();
    }
}