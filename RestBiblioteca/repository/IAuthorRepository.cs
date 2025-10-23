using RestBiblioteca.model;

namespace RestBiblioteca.repository;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAsync();
    Task CreateAsync(Author author);
    Task<Author?> GetByIdAsync(long id);
    void Update(Author author);
    Task DeleteAsync(long id);
    Task SaveChangesAsync();
    
}