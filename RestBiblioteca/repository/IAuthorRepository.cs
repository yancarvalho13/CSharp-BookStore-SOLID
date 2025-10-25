using RestBiblioteca.model;

namespace RestBiblioteca.repository;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAll();
    Task Create(Author author);
    Task<Author?> GetById(long id);
    void Update(Author author);
    Task Delete(long id);
    Task SaveChanges();
    
}