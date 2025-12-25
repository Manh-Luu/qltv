using SQLite;
using qltv.Models;

namespace qltv.Data
{
    public class DocGiaDatabase
    {
        private readonly SQLiteAsyncConnection _db;

        public DocGiaDatabase(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<DocGia>().Wait();
        }

        // L?Y DANH SÁCH
        public Task<List<DocGia>> GetAllAsync()
            => _db.Table<DocGia>().ToListAsync();

        // THÊM / C?P NH?T
        public Task<int> SaveAsync(DocGia docGia)
        {
            if (docGia.Id != 0)
                return _db.UpdateAsync(docGia);

            return _db.InsertAsync(docGia);
        }

        // XÓA
        public Task<int> DeleteAsync(DocGia docGia)
            => _db.DeleteAsync(docGia);
    }
}
