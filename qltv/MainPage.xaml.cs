using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using qltv.ViewModels;

namespace qltv

{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LibraryManagerViewModel();
        }

        //public MainPage(LibraryManagerViewModel ViewModels)
        //{
        //    InitializeComponent();

        //    // Gán ViewModel nhận được vào BindingContext
        //    this.BindingContext = ViewModels;
        //}

        /// <summary>
        /// Xử lý sự kiện khi nút "Cập Nhật" được nhấn.
        /// Chức năng: Thêm mới, Sửa, Xóa dữ liệu sách
        /// </summary>
        /// 

        private async void BtnCapNhat_Clicked(object sender, EventArgs e)
        {
            // Ví dụ: Hiển thị thông báo
            await DisplayAlert("Thông báo", "Chức năng Cập Nhật đang được thực hiện.", "OK");

            // **Thêm code logic của bạn tại đây:**
            // Ví dụ: Lưu dữ liệu từ các Entry vào cơ sở dữ liệu.
        }

        /// <summary>
        /// Xử lý sự kiện khi nút "Quản Lý Độc Giả" được nhấn.
        /// Chức năng: Chuyển sang trang Quản lý Độc giả.
        /// </summary>
        private async void BtnQuanLyDocGia_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Thông báo", "Chuyển sang màn hình Quản Lý Độc Giả.", "OK");

            // **Thêm code điều hướng của bạn tại đây:**
            // await Shell.Current.GoToAsync("//DocGiaPage"); 
        }

        /// <summary>
        /// Xử lý sự kiện khi nút "Quản Lý Tác Giả" được nhấn.
        /// Chức năng: Chuyển sang trang Quản lý Tác giả.
        /// </summary>
        private async void BtnQuanLyTacGia_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Thông báo", "Chuyển sang màn hình Quản Lý Tác Giả.", "OK");
        }

        /// <summary>
        /// Xử lý sự kiện khi nút "Quản Lý Mượn Trả" được nhấn.
        /// Chức năng: Chuyển sang trang Quản lý Mượn Trả.
        /// </summary>
        private async void BtnQuanLyMuonTra_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Thông báo", "Chuyển sang màn hình Quản Lý Mượn Trả.", "OK");
        }

        /// <summary>
        /// Xử lý sự kiện khi nút "Tìm Kiếm" được nhấn.
        /// Chức năng: Thực hiện logic tìm kiếm sách.
        /// </summary>
        private async void BtnTimKiem_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Thông báo", "Thực hiện chức năng Tìm Kiếm.", "OK");

            // **Thêm code logic tìm kiếm của bạn tại đây:**
            // Ví dụ: Lọc dữ liệu hiển thị trong Danh Sách (Grid/ListView).
        }

        /// <summary>
        /// Xử lý sự kiện khi nút "Kết Thúc" được nhấn.
        /// Chức năng: Đóng ứng dụng hoặc quay về màn hình chính.
        /// </summary>
        private async void BtnKetThuc_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Xác nhận", "Bạn có chắc muốn kết thúc ứng dụng không?", "Có", "Không");

            if (answer)
            {
                // MAUI không có hàm đóng ứng dụng trực tiếp dễ dàng như WinForms/WPF.
                // Để kết thúc ứng dụng trên Android/iOS/Windows, bạn thường dùng:
                // Application.Current.Quit(); // Chỉ hoạt động trên Windows/Mac

                // Đối với đa nền tảng, cách đơn giản là quay về màn hình chính:
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
