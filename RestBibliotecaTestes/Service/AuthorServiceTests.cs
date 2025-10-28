using FluentAssertions;
using Moq;
using RestBiblioteca.Exceptions;
using RestBiblioteca.model;
using RestBiblioteca.repository;
using RestBiblioteca.service.impl;

namespace RestBibliotecaTestes.Service;

public class AuthorServiceTests
{
    private readonly AuthorService _service;
    private readonly Mock<IAuthorRepository> _repo = new ();
    
    public AuthorServiceTests()
    {
     _service = new AuthorService(_repo.Object);   
    }

    [Fact]
    public async Task CreateShouldCallRepositoryAndReturnAuthor()
    {
        var expectedAuthor = new Author(
            "Florestan Fernandes",
            new DateTime(1920, 07, 22),
            "Brasil");

        var result = await _service.Create(expectedAuthor);
        
        _repo.Verify(repo => repo.Create(expectedAuthor), Times.Once);
        _repo.Verify(repo => repo.SaveChanges(), Times.Once);
        result.Should().BeEquivalentTo(expectedAuthor);
    }
    
    [Fact]
    public async Task CreateShouldReturnInvalidExceptionWhenAuthorBornDateIsInvalid()
    {
        var expectedAuthor = new Author(
            "Florestan Fernandes",
            new DateTime(2099, 07, 22),
            "Brasil");

        await Assert.ThrowsAnyAsync<InvalidBornDateException>(() => _service.Create(expectedAuthor));
        _repo.Verify(repo => repo.Create(It.IsAny<Author>()), Times.Never);
        _repo.Verify(repo => repo.SaveChanges(), Times.Never);
    }

    [Fact]
    public async Task GetByIdShouldReturnAuthorWhenIdExistInRepository()
    {
        var expectedAuthor = new Author(
            "Florestan Fernandes",
            new DateTime(2099, 07, 22),
            "Brasil");
        _repo.Setup(repo => repo.GetById(1L)).ReturnsAsync(expectedAuthor);
        var result = await _service.GetById(1L);
        result.Should().BeEquivalentTo(expectedAuthor);
        _repo.Verify(repo => repo.GetById(1L), Times.Once);
    }

    [Fact]
    public async Task GetByIdShouldReturnAuthorDontExistExceptionWhenIdDontExistInRepository()
    {
        var expectedAuthor = new Author(
            "Florestan Fernandes",
            new DateTime(2099, 07, 22),
            "Brasil");
        _repo.Setup(repo => repo.GetById(1L)).ReturnsAsync((Author?)null);
        Func<Task> action = async () => await _service.GetById(1L);
        await action.Should().ThrowAsync<AuthorDontExistException>();
        _repo.Verify(repo => repo.GetById(1L), Times.Once);
    }

    [Fact]
    public async Task UpdateShouldReturnNullWheAuthorDoesntExist()
    {
        var expectedAuthor = new Author(
            "Florestan Fernandes",
            new DateTime(2099, 07, 22),
            "Brasil");
        
        _repo.Setup(repo => repo.GetById(1)).ReturnsAsync((Author?)null);
        var result = await _service.Update(1, expectedAuthor);
        result.Should().BeNull();
        _repo.Verify(repo => repo.GetById(1), Times.Once);
        _repo.Verify(repo => repo.SaveChanges(), Times.Never);

    }
    
    [Fact]
    public async Task DeleteShouldReturnTrueWhenAuthorExistsAndIsDeleted()
    {
        var expectedAuthor = new Author(
            "Florestan Fernandes",
            new DateTime(2099, 07, 22),
            "Brasil");
        
        _repo.Setup(repo => repo.GetById(1)).ReturnsAsync(expectedAuthor);
        var result = await _service.Delete(1);
        result.Should().BeTrue();
        _repo.Verify(repo => repo.GetById(1), Times.Once);
        _repo.Verify(repo => repo.Delete(expectedAuthor), Times.Once);
        _repo.Verify(repo => repo.SaveChanges(), Times.Once);
        
    }

    [Fact]
    public async Task DeleteShouldReturnFalseWhenAuthorDoesntExist()
    {
        _repo.Setup(repo => repo.GetById(1)).ReturnsAsync((Author?)null);
        var result = await _service.Delete(1);
        result.Should().BeFalse();
        _repo.Verify(repo => repo.GetById(1), Times.Once);
        _repo.Verify(repo => repo.Delete(new Author()), Times.Never);
        _repo.Verify(repo => repo.SaveChanges(), Times.Never);
    }
    
}