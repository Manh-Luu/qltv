using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using qltv.Models;
using qltv.Data;

namespace qltv.ViewModels;

public partial class MuonTraViewModel : ObservableObject
{
    private readonly MuonTraDatabase _db;

    [ObservableProperty]
    ObservableCollection<MuonTra> muonTraList = new();

    [ObservableProperty]
    MuonTra? selectedMuonTra;

    public MuonTraViewModel(MuonTraDatabase db)
    {
        _db = db;
        LoadData();
    }

    async void LoadData()
    {
        var list = await _db.GetAllAsync();
        MuonTraList = new ObservableCollection<MuonTra>(list);
    }
    async Task LoadDataAsync()
    {
        var list = await _db.GetAllAsync();

        MuonTraList.Clear();
        foreach (var item in list)
            MuonTraList.Add(item);
    }


    // Tạo phiếu mượn mới
    [RelayCommand]
    void Moi()
    {
        SelectedMuonTra = new MuonTra();
    }

    [RelayCommand]
    async Task Sua()
    {
        if (SelectedMuonTra == null || SelectedMuonTra.Id == 0)
        {
            await Shell.Current.DisplayAlert(
                "Lỗi",
                "Vui lòng chọn phiếu mượn cần sửa",
                "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(SelectedMuonTra.MaDocGia) ||
            string.IsNullOrWhiteSpace(SelectedMuonTra.MaSach))
        {
            await Shell.Current.DisplayAlert(
                "Lỗi",
                "Mã độc giả và Mã sách không được để trống",
                "OK");
            return;
        }

        // Cập nhật DB
        await _db.SaveAsync(SelectedMuonTra);

        await Shell.Current.DisplayAlert(
            "Thành công",
            "Đã cập nhật thông tin mượn trả",
            "OK");


        if (SelectedMuonTra.DaTra)
        {
            await Shell.Current.DisplayAlert(
                "Thông báo",
                "Phiếu này đã trả sách, không thể sửa",
                "OK");
            return;
        }

        // Refresh danh sách
        await LoadDataAsync();

    }


    // Lưu (mượn hoặc trả)
    [RelayCommand]
    async Task Luu()
    {
        if (SelectedMuonTra == null ||
            string.IsNullOrWhiteSpace(SelectedMuonTra.MaDocGia) ||
            string.IsNullOrWhiteSpace(SelectedMuonTra.MaSach) ||
            string.IsNullOrWhiteSpace(SelectedMuonTra.TenDocGia))
        {
            await Shell.Current.DisplayAlert("Lỗi", "Thiếu thông tin", "OK");
            return;
        }

        await _db.SaveAsync(SelectedMuonTra);
        LoadData();

        await Shell.Current.DisplayAlert("OK", "Đã lưu", "OK");

        SelectedMuonTra = null;
    }

    // Xóa
    [RelayCommand]
    async Task Xoa()
    {
        if (SelectedMuonTra == null) return;

        await _db.DeleteAsync(SelectedMuonTra);
        LoadData();
        SelectedMuonTra = null;
    }

    // Trả sách
    [RelayCommand]
    async Task TraSach()
    {
        if (SelectedMuonTra == null) return;

        SelectedMuonTra.DaTra = true;
        SelectedMuonTra.NgayTra = DateTime.Today;

        await _db.SaveAsync(SelectedMuonTra);
        LoadData();
    }
}
