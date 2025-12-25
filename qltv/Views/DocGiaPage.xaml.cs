using qltv.ViewModels;

namespace qltv.Views;

public partial class DocGiaPage : ContentPage
{
    public DocGiaPage(DocGiaViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
