namespace qltv;
using Microsoft.Maui.Controls;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            MessageLabel.Text = "Vui lòng nhập đầy đủ thông tin";
            return;
        }

        if (username == "admin" && password == "123456")
        {
            MessageLabel.TextColor = Colors.Green;
            MessageLabel.Text = "Đăng nhập thành công";

            // Chuyển sang MainPage (đã được định nghĩa Route="home" trong AppShell.xaml)
            // Dấu "//" giúp xóa lịch sử trang Login, người dùng không thể nhấn Back quay lại
            await Shell.Current.GoToAsync("//home");
        }
        else
        {
            MessageLabel.TextColor = Colors.Red;
            MessageLabel.Text = "Sai tài khoản hoặc mật khẩu";
        }
    }
}