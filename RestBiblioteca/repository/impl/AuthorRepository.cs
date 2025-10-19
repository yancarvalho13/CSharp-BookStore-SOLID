using Microsoft.EntityFrameworkCore;
using RestBiblioteca.model;

namespace RestBiblioteca.repository.impl;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _dbContext;

    public AuthorRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _dbContext.Authors
            .Include(a => a.Books)
            .ThenInclude(b => b.Publisher)
            .ToListAsync();
    }

    public async Task CreateAsync(Author author)
    {
        await _dbContext.Authors.AddAsync(author);
    }

    public async Task<Author?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Authors.FindAsync(id);
    }

    public void Update(Author author)
    {
        _dbContext.Authors.Update(author);
    }

    public async Task DeleteAsync(Guid id)
    {
        var authorDb = await _dbContext.Authors.FindAsync(id);
        if (authorDb != null)
        {
            _dbContext.Authors.Remove(authorDb);
        }
    }

    public async Task SaveChangesAsync()
    {
       await _dbContext.SaveChangesAsync();
    }
}