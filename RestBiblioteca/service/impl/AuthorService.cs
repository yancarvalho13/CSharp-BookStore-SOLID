using RestBiblioteca.model;
using RestBiblioteca.repository;
using RestBiblioteca.repository.impl;

namespace RestBiblioteca.service.impl;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }


    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _authorRepository.GetAllAsync();   
    }

    public async Task<Author?> GetByIdAsync(long id)
    {
        return await _authorRepository.GetByIdAsync(id);  
    }

    public async Task<Author> CreateAsync(Author author)
    {
        await _authorRepository.CreateAsync(author);
        await _authorRepository.SaveChangesAsync();
        return author;
    }

    public async Task<Author?> UpdateAsync(long id, Author author)
    {
        var existing = await _authorRepository.GetByIdAsync(id);
        if(existing == null) return null;
        existing.Update(author);
        _authorRepository.Update(existing);
        await _authorRepository.SaveChangesAsync();
        return author;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        _authorRepository.DeleteAsync(id);
        await _authorRepository.SaveChangesAsync();
        return true;
    }
}