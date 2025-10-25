using Microsoft.EntityFrameworkCore;
using RestBiblioteca.model;

namespace RestBiblioteca.repository.impl;

public class PublisherRepository : IPublisherRepository
{
    private readonly AppDbContext _dbContext;

    public PublisherRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Publisher>> GetAll()
    { 
       return await _dbContext.Publishers
            .Include(p => p.Books)
            .ThenInclude(b=> b.Author)
            .ToListAsync();
    }

    public async Task Create(Publisher publisher)
    {
        await _dbContext.Publishers.AddAsync(publisher);
    }

    public async Task<Publisher?> GetById(long id)
    {
        return await _dbContext.Publishers.FindAsync(id);
    }

    public void Update(Publisher publisher)
    {
        _dbContext.Publishers.Update(publisher);
    }

    public async Task Delete(long id)
    {
        var publisherDb = await _dbContext.Publishers.FindAsync(id);
        if (publisherDb != null)
        {
            _dbContext.Publishers.Remove(publisherDb);
        }
    }

    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }
}