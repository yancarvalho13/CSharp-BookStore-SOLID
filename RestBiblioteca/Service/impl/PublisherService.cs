using RestBiblioteca.Exceptions;
using RestBiblioteca.model;
using RestBiblioteca.repository;

namespace RestBiblioteca.service.impl;

internal class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;

    public PublisherService(IPublisherRepository publisherRepository)
    {
        _publisherRepository = publisherRepository;
    }

    public async Task<IEnumerable<Publisher>> GetAll()
    {
        return await _publisherRepository.GetAll();
    }

    public async Task<Publisher?> GetById(long id)
    {
        var publisherDb =  await _publisherRepository.GetById(id)
            ?? throw new PublisherDontExistException();
        return publisherDb;  
    }

    public async Task<Publisher> Create(Publisher publisher)
    {
        await _publisherRepository.Create(publisher);
        await _publisherRepository.SaveChanges();
        return publisher;   
    }

    public async Task<Publisher?> Update(long id, Publisher publisher)
    {
        var existing = await _publisherRepository.GetById(id);
        if(existing == null) return null;
        existing.Update(publisher);
        _publisherRepository.Update(existing); 
        await _publisherRepository.SaveChanges();
        return existing;
    }

    public async Task<bool> Delete(long id)
    {
        var publisherDb = await _publisherRepository.GetById(id);
        if(publisherDb == null) return false;
        await _publisherRepository.Delete(publisherDb);
        await _publisherRepository.SaveChanges();
        return true;   
    }
}