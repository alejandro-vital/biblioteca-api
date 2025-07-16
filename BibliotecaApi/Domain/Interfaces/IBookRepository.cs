using System;
using BibliotecaApi.Domain.Entities;

namespace BibliotecaApi.Domain.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int id);
    Task<Book> CreateAsync(Book book);
    Task<Book> UpdateAsync(Book book);
    Task<bool> DeleteAsync(Book book);
}
