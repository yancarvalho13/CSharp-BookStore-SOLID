
using RestBiblioteca.model;

namespace RestBiblioteca.service;

public interface IBookService
{
    Task<IEnumerable<Book>> GetAll();
    Task<Book?> GetById(long id);
    Task<Book> Create(Book book);
    Task<Book?> Update(long id, Book book);
    Task<bool> Delete(long id);
}