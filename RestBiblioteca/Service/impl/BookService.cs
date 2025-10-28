using RestBiblioteca.Exceptions;
using RestBiblioteca.model;
using RestBiblioteca.repository;

namespace RestBiblioteca.service.impl;

internal class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IPublisherRepository _publisherRepository;


    public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IPublisherRepository publisherRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _publisherRepository = publisherRepository;
    }

    public async Task<IEnumerable<Book>> GetAll()
    {
        return await _bookRepository.GetAll();
    }

    public async Task<Book?> GetById(long id)
    {
        var bookDb = await _bookRepository.GetById(id)
            ?? throw new BookDontExistExcpetion();
        return bookDb;
    }

    public async Task<Book> Create(Book book)
    {
        var authorDb = await _authorRepository.GetById(book.AuthorId);
        var publisherDb = await _publisherRepository.GetById(book.PublisherId);

        if (authorDb is null) throw new AuthorDontExistException();
        if(publisherDb is null) throw new PublisherDontExistException();
        
        await _bookRepository.Create(book);
        await _bookRepository.SaveChanges();
        return book;
    }

    public async Task<Book?> Update(long id, Book book)
    {
        var existing = await _bookRepository.GetById(id);
        if (existing == null) throw new BookDontExistExcpetion();
        existing.Update(book);
         _bookRepository.Update(existing);
        await _bookRepository.SaveChanges();
        return existing;

    }
    

    public async Task<bool> Delete(long id)
    {
        var bookDb = await _bookRepository.GetById(id);
        if(bookDb is null) throw new BookDontExistExcpetion();
        await _bookRepository.Delete(bookDb);
        await _bookRepository.SaveChanges();
        return true;
    }
}