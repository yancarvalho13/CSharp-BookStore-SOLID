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


    public async Task<IEnumerable<Author>> GetAll()
    {
        return await _authorRepository.GetAll();   
    }

    public async Task<Author?> GetById(long id)
    {
        return await _authorRepository.GetById(id);  
    }

    public async Task<Author> Create(Author author)
    {
        await _authorRepository.Create(author);
        await _authorRepository.SaveChanges();
        return author;
    }

    public async Task<Author?> Update(long id, Author author)
    {
        var existing = await _authorRepository.GetById(id);
        if(existing == null) return null;
        existing.Update(author);
        _authorRepository.Update(existing);
        await _authorRepository.SaveChanges();
        return author;
    }

    public async Task<bool> Delete(long id)
    {
        _authorRepository.Delete(id);
        await _authorRepository.SaveChanges();
        return true;
    }
}