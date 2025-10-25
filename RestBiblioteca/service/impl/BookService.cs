using RestBiblioteca.model;
using RestBiblioteca.repository;

namespace RestBiblioteca.service.impl;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<Book>> GetAll()
    {
        return await _bookRepository.GetAll();
    }

    public async Task<Book?> GetById(long id)
    {
        return await _bookRepository.GetById(id);
    }

    public async Task<Book> Create(Book book)
    {
        await _bookRepository.Create(book);
        await _bookRepository.SaveChanges();
        return book;
    }

    public async Task<Book?> Update(long id, Book book)
    {
        var existing = await _bookRepository.GetById(id);
        if (existing == null) return null;
        existing.Update(book);
        _bookRepository.Update(existing);
        await _bookRepository.SaveChanges();
        return existing;

    }

    public async Task<bool> Delete(long id)
    {
        await _bookRepository.Delete(id);
        await _bookRepository.SaveChanges();
        return true;
    }
}