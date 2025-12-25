using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qltv.Models
{
    public partial class DocGia : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ObservableProperty] private string maDocGia;
        [ObservableProperty] private string tenDocGia;
        [ObservableProperty] private string soDienThoai;
        [ObservableProperty] private string email;
    }
}
