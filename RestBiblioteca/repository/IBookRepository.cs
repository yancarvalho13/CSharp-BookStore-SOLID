using RestBiblioteca.model;

namespace RestBiblioteca.repository;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task CreateAsync(Book book);
    Task<Book?> GetByIdAsync(Guid id);
    void Update(Book book);
    Task DeleteAsync(Guid id);
    
    Task SaveChangesAsync();
}