using Microsoft.EntityFrameworkCore;
using RestBiblioteca.model;

namespace RestBiblioteca.repository.impl;

internal sealed class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _dbContext;

    public AuthorRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Author>> GetAll()
    {
        return await _dbContext.Authors
            .Include(a => a.Books)
            .ThenInclude(b => b.Publisher)
            .ToListAsync();
    }

    public async Task Create(Author author)
    {
        await _dbContext.Authors.AddAsync(author);
    }

    public async Task<Author?> GetById(long id)
    {
        return await _dbContext.Authors.FindAsync(id);
    }

    public void Update(Author author)
    {
        _dbContext.Authors.Update(author);
    }

    public async Task Delete(Author author)
    {
       
            _dbContext.Authors.Remove(author);
        
    }

    public async Task SaveChanges()
    {
       await _dbContext.SaveChangesAsync();
    }
}