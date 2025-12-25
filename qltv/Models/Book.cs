

using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace qltv.Models;

public partial class Book : ObservableObject
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [ObservableProperty] private string maSach;
    [ObservableProperty] private string tenSach;
    [ObservableProperty] private string maLoaiSach;
    [ObservableProperty] private int soLuong;
    [ObservableProperty] private string maTacGia;
}





