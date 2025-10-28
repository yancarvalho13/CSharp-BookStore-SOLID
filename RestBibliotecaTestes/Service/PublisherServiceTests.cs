using FluentAssertions;
using Moq;
using RestBiblioteca.Exceptions;
using RestBiblioteca.model;
using RestBiblioteca.repository;
using RestBiblioteca.service.impl;

namespace RestBibliotecaTestes.Service;

public class PublisherServiceTests
{
    private readonly Mock<IPublisherRepository> _repo = new ();
    private readonly PublisherService _service;
    
    public PublisherServiceTests()
    {
     _service = new PublisherService(_repo.Object);   
    }

    [Fact]
    public async Task CreateShouldCallRepositoryAndReturnPublisher()
    {
        var expectedPublisher = new Publisher(
            "Editora Boitempo",
            "Brasil");
        
        var result = await _service.Create(expectedPublisher);
        
        _repo.Verify(repo => repo.Create(expectedPublisher), Times.Once);
        _repo.Verify(repo => repo.SaveChanges(), Times.Once);

        result.Should().BeEquivalentTo(expectedPublisher,
            opt => opt.Excluding(p => p.Id));
    }

    [Fact]
    public async Task GetByIdShouldReturnPublisherWhenIdExistInRepository()
    {
        var expectedPublisher = new Publisher(
            "Editora Boitempo",
            "Brasil");

        _repo.Setup(repo => repo.GetById(1L)).ReturnsAsync(expectedPublisher);
        var result = await _service.GetById(1L);
        result.Should().BeEquivalentTo(expectedPublisher);
        _repo.Verify(repo => repo.GetById(1L), Times.Once);
    }

    [Fact]
    public async Task GetByIdShouldReturnPublisherDontExistExceptionWhenIdDontExistInRepository()
    {
        
        _repo.Setup(repo => repo.GetById(1L)).ReturnsAsync((Publisher?)null);
        Func<Task> action = async () => await _service.GetById(1L);
        action.Should().ThrowAsync<PublisherDontExistException>();
        _repo.Verify(repo => repo.GetById(1L), Times.Once);
    }
    
    [Fact]
    public async Task UpdateShouldReturnNullWhePublisherDoesntExist()
    {
        _repo.Setup(r => r.GetById(1)).ReturnsAsync((Publisher?)null);
        
        var result = await _service.Update(1, new Publisher("Editora Boitempo", "Brasil"));
        result.Should().BeNull();
        _repo.Verify(repo => repo.GetById(1), Times.Once);
        _repo.Verify(repo => repo.SaveChanges(), Times.Never);
    }

    [Fact]
    public async Task DeleteShouldReturnTrueWhenPublisherExistsAndIsDeleted()
    {
        var expectedPublisher = new Publisher(
            "Editora Boitempo",
            "Brasil");
        
        _repo.Setup((repo => repo.GetById(1))).ReturnsAsync(expectedPublisher);
        
        var result = await _service.Delete(1);
        
        result.Should().BeTrue();
        _repo.Verify(repo => repo.GetById(1), Times.Once);
        _repo.Verify(repo => repo.Delete(expectedPublisher), Times.Once);
        _repo.Verify(repo => repo.SaveChanges(), Times.Once);
    }

    [Fact]
    public async Task GetAllShouldReturnEmptyListIfNoPublishersWherePersisted()
    {
        _repo.Setup(repo => repo.GetAll()).ReturnsAsync(new List<Publisher>());
        
        var result = await _service.GetAll();
        result.Should().BeEmpty();
        
        _repo.Verify(repo => repo.GetAll(), Times.Once);
    }
}