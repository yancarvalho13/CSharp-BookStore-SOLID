using RestBiblioteca.model;

namespace RestBiblioteca.repository;

internal interface IBookRepository
{
    Task<IEnumerable<Book>> GetAll();
    Task Create(Book book);
    Task<Book?> GetById(long id);
    void Update(Book book);
    Task Delete(Book book);
    
    Task SaveChanges();
}