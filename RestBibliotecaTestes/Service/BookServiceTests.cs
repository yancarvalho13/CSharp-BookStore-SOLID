using FluentAssertions;
using Moq;
using RestBiblioteca.Exceptions;
using RestBiblioteca.model;
using RestBiblioteca.repository;
using RestBiblioteca.service.impl;

namespace RestBibliotecaTestes.Service;

public class BookServiceTests
{
    private readonly BookService _service;
    private readonly Mock<IBookRepository> _bookRepository = new ();
    private readonly Mock<IAuthorRepository> _authorRepository = new ();
    private readonly Mock<IPublisherRepository> _publisherRepository = new ();
    private readonly Author _author =  new Author(
        "Florestan Fernandes",
    new DateTime(2099, 07, 22),
        "Brasil");
    private readonly Publisher _publisher = new Publisher(
        "Editora Boitempo",
        "Brasil");

    private readonly Book _book = new Book(
        "Poder e contrapoder na América Latina",
        1L, 1L, Category.Politica);

    public BookServiceTests()
    {
        _service = new BookService(
            _bookRepository.Object,
            _authorRepository.Object,
            _publisherRepository.Object);
    }

    [Fact]
    public async Task CreateShouldCallRepositoryAndReturnBook()
    {
        _authorRepository.Setup(repo => repo.GetById(1L)).ReturnsAsync(_author);
        _publisherRepository.Setup(repo => repo.GetById(1L)).ReturnsAsync(_publisher);
        
        var result = await _service.Create(_book);

        result.Should().BeEquivalentTo(_book);
        _bookRepository.Verify(repo => repo.Create(_book), Times.Once);
        _bookRepository.Verify(repo => repo.SaveChanges(), Times.Once);
        _authorRepository.Verify(repo => repo.GetById(1L), Times.Once);
        _publisherRepository.Verify(repo => repo.GetById(1L), Times.Once);
        
    }

    [Fact]
    public async Task CreateShouldReturnAuthorDontExistExceptionWhenAuthorDoesntExist()
    {
        _authorRepository.Setup(repo => repo.GetById(1L)).ReturnsAsync((Author?)null);
        
        Func<Task> action = async () => await _service.Create(_book);
        
        await action.Should().ThrowAsync<AuthorDontExistException>();
        _authorRepository.Verify(repo => repo.GetById(1L), Times.Once);
        _bookRepository.Verify(repo => repo.Create(_book), Times.Never);
        _bookRepository.Verify(repo => repo.SaveChanges(), Times.Never);
    }
    
    [Fact]
    public async Task CreateShouldReturnPublisherDontExistWhenPublisherDoesntExist()
    {
        _authorRepository.Setup(repo => repo.GetById(1L)).ReturnsAsync(_author);
        _publisherRepository.Setup(repo => repo.GetById(1L)).ReturnsAsync((Publisher?)null);
        
        Func<Task> action = async () => await _service.Create(_book);
        
        await action.Should().ThrowAsync<PublisherDontExistException>();
        _publisherRepository.Verify(repo => repo.GetById(1L), Times.Once);
        _bookRepository.Verify(repo => repo.Create(_book), Times.Never);
        _bookRepository.Verify(repo => repo.SaveChanges(), Times.Never);
    }

    [Fact]
    public async Task GetByIdShouldReturnBookWhenIdExistInRepository()
    {
        _bookRepository.Setup(repo => repo.GetById(1L)).ReturnsAsync(_book);
        var result = await _service.GetById(1L);
        result.Should().BeEquivalentTo(_book);
        _bookRepository.Verify(repo => repo.GetById(1L), Times.Once);
        
    }

    [Fact]
    public async Task GetByIdShouldReturnBookDontExistExceptionWhenIdDontExistInRepository()
    {
        _bookRepository.Setup(repo => repo.GetById(1L)).ReturnsAsync((Book?)null);
        Func<Task> action = async () => await _service.GetById(1L);
        await action.Should().ThrowAsync<BookDontExistExcpetion>();
        _bookRepository.Verify(repo => repo.GetById(1L), Times.Once);
    }
    
    [Fact]
    public async Task UpdateShouldUpdateBookWithNewValues()
    {
        var newBook =  new Book(
        "As Veias Abertas da América Latina",
        1L, 1L, Category.Politica);
        
        _bookRepository.Setup(repo => repo.GetById(1L)).ReturnsAsync(_book);
        _bookRepository.Setup(repo => repo.Update(_book));
        
        var result = await _service.Update(1L, newBook);
        
        result.Should().BeEquivalentTo(newBook);
        _bookRepository.Verify(repo => repo.GetById(1L), Times.Once);
        _bookRepository.Verify(repo => repo.Update(_book), Times.Once);
        _bookRepository.Verify(repo => repo.SaveChanges(), Times.Once);
    }

    [Fact]
    public async Task UpdateShouldThrowBookDontExistExceptionWhenIdDontExistInRepository()
    {
        _bookRepository.Setup(repo => repo.GetById(1L)).ReturnsAsync((Book?)null);
        Func<Task> action = async () => await _service.Update(1L, _book);
        await action.Should().ThrowAsync<BookDontExistExcpetion>();
        _bookRepository.Verify(repo => repo.GetById(1L), Times.Once);
        _bookRepository.Verify(repo => repo.Update(_book), Times.Never);
        _bookRepository.Verify(repo => repo.SaveChanges(), Times.Never);
    }

    [Fact]
    public async Task DeleteShouldThrowBookDontExistExceptionWhenIdDontExistInRepository()
    {
        _bookRepository.Setup(repo => repo.GetById(1L)).ReturnsAsync((Book?)null);
        Func<Task> action = async () => await _service.Delete(1L);
        await action.Should().ThrowAsync<BookDontExistExcpetion>();
        _bookRepository.Verify(repo => repo.GetById(1L), Times.Once);
        _bookRepository.Verify(repo => repo.SaveChanges(), Times.Never);
    }
    
    [Fact]
    public async Task DeleteShouldReturnTrueIfBookIsDeleted()
    {
        _bookRepository.Setup(repo => repo.GetById(1L)).ReturnsAsync(_book);
        
        var result = await _service.Delete(1L);
        
        result.Should().BeTrue();
        _bookRepository.Verify(repo => repo.GetById(1L), Times.Once);
        _bookRepository.Verify(repo => repo.Delete(_book), Times.Once);
        _bookRepository.Verify(repo => repo.SaveChanges(), Times.Once); 
    }
    
    
}