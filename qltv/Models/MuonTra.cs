using SQLite;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace qltv.Models;

public partial class MuonTra : ObservableObject
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }



    [ObservableProperty]
    private string maDocGia;

    [ObservableProperty]
    private string tenDocGia;

    [ObservableProperty]
    private string maSach;

    [ObservableProperty]
    private DateTime ngayMuon = DateTime.Today;

    [ObservableProperty]
    private DateTime? ngayTra;

    [ObservableProperty]
    private bool daTra;
}
