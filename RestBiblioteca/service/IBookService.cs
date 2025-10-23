
using RestBiblioteca.model;

namespace RestBiblioteca.service;

public interface IBookService
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(long id);
    Task<Book> CreateAsync(Book book);
    Task<Book?> UpdateAsync(long id, Book book);
    Task<bool> DeleteAsync(long id);
}