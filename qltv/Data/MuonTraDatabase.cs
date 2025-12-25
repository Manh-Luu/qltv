using SQLite;
using qltv.Models;

namespace qltv.Data;

public class MuonTraDatabase
{
    private readonly SQLiteAsyncConnection _db;

    public MuonTraDatabase(string path)
    {
        _db = new SQLiteAsyncConnection(path);
        _db.CreateTableAsync<MuonTra>().Wait();
    }

    public Task<List<MuonTra>> GetAllAsync() =>
        _db.Table<MuonTra>().ToListAsync();

    public Task<int> SaveAsync(MuonTra item) =>
        item.Id == 0 ? _db.InsertAsync(item) : _db.UpdateAsync(item);

    public Task<int> DeleteAsync(MuonTra item) =>
        _db.DeleteAsync(item);
}
