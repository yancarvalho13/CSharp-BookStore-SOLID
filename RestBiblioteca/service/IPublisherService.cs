using RestBiblioteca.model;

namespace RestBiblioteca.service;

public interface IPublisherService
{
    Task<IEnumerable<Publisher>> GetAllAsync();
    Task<Publisher?> GetByIdAsync(Guid id);
    Task<Publisher> CreateAsync(Publisher publisher);
    Task<Publisher?> UpdateAsync(Guid id, Publisher publisher);
    Task<bool> DeleteAsync(Guid id);
}