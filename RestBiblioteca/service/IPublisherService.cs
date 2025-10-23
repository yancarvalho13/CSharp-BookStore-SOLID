using RestBiblioteca.model;

namespace RestBiblioteca.service;

public interface IPublisherService
{
    Task<IEnumerable<Publisher>> GetAllAsync();
    Task<Publisher?> GetByIdAsync(long id);
    Task<Publisher> CreateAsync(Publisher publisher);
    Task<Publisher?> UpdateAsync(long id, Publisher publisher);
    Task<bool> DeleteAsync(long id);
}