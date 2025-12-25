using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using qltv.Models;
using qltv.Views;
using System.Collections.ObjectModel;

namespace qltv.ViewModels;

public partial class LibraryManagerViewModel : ObservableObject
{


    [ObservableProperty]
    ObservableCollection<Book> bookList = new();

    [ObservableProperty]
    Book? selectedBook;

    public LibraryManagerViewModel()
    {
        BookList = new ObservableCollection<Book>();

        SelectedBook = new Book();


    }


    [RelayCommand]
    async Task ThemSach()
    {
        if (SelectedBook == null)
            return;

        if (string.IsNullOrWhiteSpace(SelectedBook.MaSach) ||
            string.IsNullOrWhiteSpace(SelectedBook.TenSach))
        {
            await Shell.Current.DisplayAlert(
                "Lỗi",
                "Mã sách và Tên sách không được để trống",
                "OK");
            return;
        }

        BookList.Add(SelectedBook);
        SelectedBook = new Book();

        await Shell.Current.DisplayAlert(
            "Thành công",
            "Đã thêm sách",
            "OK");
        SelectedBook = null;


        SelectedBook = new Book();
    }




    [RelayCommand]
    async Task SuaSach()
    {
        if (SelectedBook == null)
        {
            await Shell.Current.DisplayAlert(
                "Thông báo",
                "Vui lòng chọn sách cần sửa",
                "OK");
            return;
        }

        await Shell.Current.DisplayAlert(
            "Thành công",
            "Đã cập nhật thông tin sách",
            "OK");

        SelectedBook = null;

        SelectedBook = new Book();
    }


    [RelayCommand]
    async Task XoaSach()
    {
        if (SelectedBook == null)
        {
            await Shell.Current.DisplayAlert(
                "Thông báo",
                "Vui lòng chọn sách cần xóa",
                "OK");
            return;
        }

        bool confirm = await Shell.Current.DisplayAlert(
            "Xác nhận",
            $"Xóa sách: {SelectedBook.TenSach} ?",
            "Có",
            "Không");

        if (confirm)
        {
            BookList.Remove(SelectedBook);
            SelectedBook = null;
        }
        SelectedBook = null;

    
        SelectedBook = new Book();
    }

 
    [RelayCommand]
    async Task CapNhat()
    {
        if (SelectedBook == null)
            return;

        if (string.IsNullOrWhiteSpace(SelectedBook.MaSach) ||
            string.IsNullOrWhiteSpace(SelectedBook.TenSach))
        {
            await Shell.Current.DisplayAlert(
                "Lỗi",
                "Mã sách và Tên sách không được để trống",
                "OK");
            return;
        }

        if (!BookList.Contains(SelectedBook))
        {
            BookList.Add(SelectedBook);
        }

        await Shell.Current.DisplayAlert(
            "Thành công",
            "Đã lưu sách",
            "OK");
    }

    [RelayCommand]
    async Task QuanLyDocGia()
    {
        await Shell.Current.GoToAsync(nameof(DocGiaPage));
    }

    [RelayCommand]
    async Task QuanLyMuonTra()
    {
        await Shell.Current.GoToAsync(nameof(MuonTraPage));
    }

    [RelayCommand]
    void KetThuc()
    {
        Application.Current?.Quit();
    }
}
