namespace JwtExample.Consumers.Desktop.Presentation.Views.Products;

public partial class CreateProductsView : UserControl
{
    public CreateProductsView()
    {
        InitializeComponent();

        DataContext = ViewModelConnector.Connect<CreateProductsViewModel>();
    }
}