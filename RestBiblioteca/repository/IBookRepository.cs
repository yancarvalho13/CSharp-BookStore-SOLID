using RestBiblioteca.model;

namespace RestBiblioteca.repository;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task CreateAsync(Book book);
    Task<Book?> GetByIdAsync(long id);
    void Update(Book book);
    Task DeleteAsync(long id);
    
    Task SaveChangesAsync();
}