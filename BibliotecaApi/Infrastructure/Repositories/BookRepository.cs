using System;
using System.Data.Common;
using BibliotecaApi.Domain.Entities;
using BibliotecaApi.Domain.Interfaces;
using BibliotecaApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApi.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private ApplicationDbContext _db;

    public BookRepository(ApplicationDbContext db)
    {
        _db = db;
    }


    public async Task<Book> CreateAsync(Book book)
    {
        await _db.Books.AddAsync(book);
        await _db.SaveChangesAsync();

        return book;
    }

    public async Task<bool> DeleteAsync(Book book)
    {
        _db.Books.Remove(book);

        var eliminatedBook = await _db.SaveChangesAsync();

        return eliminatedBook > 0;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _db.Books.ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _db.Books.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<Book> UpdateAsync(Book book)
    {
       await _db.SaveChangesAsync();

        return book;
    }
}
