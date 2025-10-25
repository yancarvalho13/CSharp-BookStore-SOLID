using RestBiblioteca.model;

namespace RestBiblioteca.repository;

public interface IPublisherRepository
{
    Task<IEnumerable<Publisher>> GetAll();
    Task Create(Publisher publisher);
    Task<Publisher?> GetById(long id);
    void Update(Publisher publisher);
    Task Delete(long id);
    Task SaveChanges();
}