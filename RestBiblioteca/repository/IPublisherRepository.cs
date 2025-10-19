using RestBiblioteca.model;

namespace RestBiblioteca.repository;

public interface IPublisherRepository
{
    Task<IEnumerable<Publisher>> GetAllAsync();
    Task CreateAsync(Publisher publisher);
    Task<Publisher?> GetByIdAsync(Guid id);
    void Update(Publisher publisher);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync();
}