using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using qltv.Models;

namespace qltv.Data;

public class LibraryDatabase
{
    private readonly SQLiteAsyncConnection _database;

    public LibraryDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Book>().Wait();
    }

    // LẤY DANH SÁCH
    public Task<List<Book>> GetBooksAsync() =>
        _database.Table<Book>().ToListAsync();

    // THÊM / CẬP NHẬT
    public Task<int> SaveBookAsync(Book book)
    {
        if (book.Id != 0)
            return _database.UpdateAsync(book);

        return _database.InsertAsync(book);
    }

    // XÓA
    public Task<int> DeleteBookAsync(Book book) =>
        _database.DeleteAsync(book);
}
