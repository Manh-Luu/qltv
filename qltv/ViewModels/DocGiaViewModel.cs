using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using qltv.Models;
using qltv.Data;

namespace qltv.ViewModels;

public partial class DocGiaViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<DocGia> docGiaList = new();

    [ObservableProperty]
    DocGia? selectedDocGia;

    public DocGiaViewModel()
    {
        SelectedDocGia = new DocGia();
        // dữ liệu mẫu
        docGiaList.Add(new DocGia
        {
            MaDocGia = "DG01",
            TenDocGia = "Nguyễn Văn A",
            SoDienThoai = "0909123456",
            Email = "a@gmail.com"
        });
    }

    // =======================
    // THÊM ĐỘC GIẢ
    // =======================
    [RelayCommand]
    async Task ThemDocGia()
    {
        if (string.IsNullOrWhiteSpace(SelectedDocGia?.MaDocGia) ||
            string.IsNullOrWhiteSpace(SelectedDocGia?.TenDocGia))
        {
            await Shell.Current.DisplayAlert(
                "Lỗi",
                "Vui lòng nhập Mã và Tên độc giả",
                "OK");
            return;
        }

        DocGiaList.Add(new DocGia
        {
            MaDocGia = SelectedDocGia.MaDocGia,
            TenDocGia = SelectedDocGia.TenDocGia,
            SoDienThoai = SelectedDocGia.SoDienThoai,
            Email = SelectedDocGia.Email
        });

        await Shell.Current.DisplayAlert("OK", "Đã thêm độc giả", "OK");
            
        SelectedDocGia = null;

        SelectedDocGia = new DocGia();
    }


    // =======================
    // SỬA
    // =======================
    [RelayCommand]
    async Task SuaDocGia()
    {
        if (SelectedDocGia == null)
        {
            await Shell.Current.DisplayAlert("Lỗi", "Chọn độc giả cần sửa", "OK");
            return;
        }

        await Shell.Current.DisplayAlert("OK", "Đã cập nhật độc giả", "OK");
        SelectedDocGia = null;

        // ⭐ TẠO FORM TRỐNG
        SelectedDocGia = new DocGia();
    }

    // =======================
    // XÓA
    // =======================
    [RelayCommand]
    async Task XoaDocGia()
    {
        if (SelectedDocGia == null)
            return;

        bool confirm = await Shell.Current.DisplayAlert(
            "Xác nhận",
            $"Xóa {SelectedDocGia.TenDocGia} ?",
            "Có",
            "Không");

        if (confirm)
        {
            DocGiaList.Remove(SelectedDocGia);
            SelectedDocGia = null;
        }
        SelectedDocGia = null;

        SelectedDocGia = new DocGia();
    }
}
