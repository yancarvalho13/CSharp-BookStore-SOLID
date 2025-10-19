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

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _bookRepository.GetAllAsync();
    }

    public async Task<Book?> GetByIdAsync(Guid id)
    {
        return await _bookRepository.GetByIdAsync(id);
    }

    public async Task<Book> CreateAsync(Book book)
    {
        await _bookRepository.CreateAsync(book);
        await _bookRepository.SaveChangesAsync();
        return book;
    }

    public async Task<Book?> UpdateAsync(Guid id, Book book)
    {
        var existing = await _bookRepository.GetByIdAsync(id);
        if (existing == null) return null;
        existing.Update(book);
        _bookRepository.Update(existing);
        await _bookRepository.SaveChangesAsync();
        return existing;

    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        await _bookRepository.DeleteAsync(id);
        await _bookRepository.SaveChangesAsync();
        return true;
    }
}