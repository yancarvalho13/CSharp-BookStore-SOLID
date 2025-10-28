using RestBiblioteca.Exceptions;
using RestBiblioteca.model;
using RestBiblioteca.repository;
using RestBiblioteca.repository.impl;

namespace RestBiblioteca.service.impl;

internal class AuthorService : IAuthorService
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
        var authorDb =  await _authorRepository.GetById(id)
            ?? throw new AuthorDontExistException();
        return authorDb;
    }

    public async Task<Author> Create(Author author)
    {
        if (author.BirthDate > DateTime.Now) throw new InvalidBornDateException();
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
        var authorDb = await _authorRepository.GetById(id);
        if(authorDb == null) return false;
        await _authorRepository.Delete(authorDb);
        await _authorRepository.SaveChanges();
        return true;
    }
}