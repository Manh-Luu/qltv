using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qltv.Models; // Đảm bảo đúng namespace của Model Book

namespace qltv.Services
{
    public class BookService
    {
        // Giả lập danh sách sách (thay thế bằng kết nối CSDL thực tế)
        private static List<Book> _books = new List<Book>
        {
            new Book { MaSach = "TIN001", TenSach = "Nhập môn C#", MaLoaiSach = "TIN", SoLuong = 5, MaTacGia = "TG001" },
            new Book { MaSach = "VH002", TenSach = "Văn học 12", MaLoaiSach = "VH", SoLuong = 3, MaTacGia = "TG003" }
        };

        // Phương thức chính để kiểm tra sự tồn tại của sách
        public Task<bool> CheckIfBookExistsAsync(string maSach)
        {
            if (string.IsNullOrWhiteSpace(maSach))
            {
                return Task.FromResult(false);
            }

            // Tìm sách trong danh sách (giả lập truy vấn CSDL)
            bool exists = _books.Any(b => b.MaSach.Equals(maSach, StringComparison.OrdinalIgnoreCase));

            // Trả về kết quả dưới dạng Task<bool> (bất đồng bộ)
            return Task.FromResult(exists);
        }

        // Phương thức Thêm sách (cần thiết cho CapNhatCommand)
        public Task InsertBookAsync(Book book)
        {
            // Logic thêm sách vào CSDL
            _books.Add(book);
            return Task.CompletedTask;
        }

        // Phương thức Cập nhật sách (cần thiết cho CapNhatCommand)
        public Task UpdateBookAsync(Book book)
        {
            // Logic tìm và thay thế sách trong CSDL
            var existingBook = _books.FirstOrDefault(b => b.MaSach.Equals(book.MaSach, StringComparison.OrdinalIgnoreCase));
            if (existingBook != null)
            {
                // Cập nhật các trường
                existingBook.TenSach = book.TenSach;
                existingBook.MaLoaiSach = book.MaLoaiSach;
                existingBook.SoLuong = book.SoLuong;
                existingBook.MaTacGia = book.MaTacGia;
            }
            return Task.CompletedTask;
        }

        // Phương thức Tải tất cả sách (cần thiết cho LoadBooksAsync trong ViewModel)
        public Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return Task.FromResult<IEnumerable<Book>>(_books);
        }
    }
}