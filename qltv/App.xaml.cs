namespace qltv
{

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new AppShell();
            //MainPage = new NavigationPage(new LoginPage());
        }
        protected override async void OnStart()
        {
            base.OnStart();
            // Đợi App khởi tạo xong hoàn toàn rồi mới điều hướng
            if (Shell.Current != null)
            {
                await Shell.Current.GoToAsync("//login");
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Quan trọng: Gán AppShell vào MainPage của Window
            var shell = new AppShell();
            return new Window(new AppShell());
        }


    }
}