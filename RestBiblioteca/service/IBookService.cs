
using RestBiblioteca.model;

namespace RestBiblioteca.service;

public interface IBookService
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(Guid id);
    Task<Book> CreateAsync(Book book);
    Task<Book?> UpdateAsync(Guid id, Book book);
    Task<bool> DeleteAsync(Guid id);
}