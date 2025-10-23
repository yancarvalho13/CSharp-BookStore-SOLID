using RestBiblioteca.model;
using RestBiblioteca.repository;

namespace RestBiblioteca.service.impl;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;

    public PublisherService(IPublisherRepository publisherRepository)
    {
        _publisherRepository = publisherRepository;
    }

    public async Task<IEnumerable<Publisher>> GetAllAsync()
    {
        return await _publisherRepository.GetAllAsync();
    }

    public async Task<Publisher?> GetByIdAsync(long id)
    {
        return await _publisherRepository.GetByIdAsync(id);
    }

    public async Task<Publisher> CreateAsync(Publisher publisher)
    {
        await _publisherRepository.CreateAsync(publisher);
        await _publisherRepository.SaveChangesAsync();
        return publisher;   
    }

    public async Task<Publisher?> UpdateAsync(long id, Publisher publisher)
    {
        var existing = await _publisherRepository.GetByIdAsync(id);
        if(existing == null) return null;
        existing.Update(publisher);
        _publisherRepository.Update(existing); 
        await _publisherRepository.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        await _publisherRepository.DeleteAsync(id);
        await _publisherRepository.SaveChangesAsync();
        return true;   
    }
}