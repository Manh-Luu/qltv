using qltv.ViewModels;

namespace qltv.Views;

public partial class MuonTraPage : ContentPage
{
    public MuonTraPage(MuonTraViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}