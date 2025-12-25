using qltv.Views;

namespace qltv
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute(nameof(DocGiaPage), typeof(DocGiaPage));
            Routing.RegisterRoute(nameof(MuonTraPage), typeof(MuonTraPage));
        }
    }
}
