using RestBiblioteca.model;

namespace RestBiblioteca.service;

internal interface IPublisherService
{
    Task<IEnumerable<Publisher>> GetAll();
    Task<Publisher?> GetById(long id);
    Task<Publisher> Create(Publisher publisher);
    Task<Publisher?> Update(long id, Publisher publisher);
    Task<bool> Delete(long id);
}