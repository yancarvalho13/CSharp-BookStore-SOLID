using Microsoft.EntityFrameworkCore;
using RestBiblioteca.model;

namespace RestBiblioteca.repository.impl;

internal sealed class BookRepository : IBookRepository
{
    private readonly AppDbContext _dbContext;

    public BookRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Book>> GetAll()
    {
        return await _dbContext.Books
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .ToListAsync();
    }

    public async Task Create(Book book)
    {
        await _dbContext.Books.AddAsync(book);
        
    }

    public async Task<Book?> GetById(long id)
    {
        return await _dbContext.Books
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public void Update(Book book)
    {
        _dbContext.Books.Update(book);

    }

    public async Task Delete(Book book)
    {
        
             _dbContext.Books.Remove(book);
        
    }

    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }
}