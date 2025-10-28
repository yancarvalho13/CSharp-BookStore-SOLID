using Moq;
using RestBiblioteca.controller.DTO.AdressFinder;
using RestBiblioteca.controller.DTO.User;
using RestBiblioteca.Exceptions;
using RestBiblioteca.model;
using RestBiblioteca.repository;
using RestBiblioteca.service;
using RestBiblioteca.service.impl;

namespace RestBibliotecaTestes.Service;


public class UserServiceTests
{
    [Fact]
    public async Task ShouldReturnUserResponseWhenCepIsValid()
    {
        var mockRepo = new Mock<IUserRepository>();
        var mockFinder = new Mock<IAdressFinder>();
        var expectedAdressDto = new ViaCepDto(
            "40727800",
            "Rua da Areia",
            "Periperi",
            "Salvador",
            "BA",
            "Bahia",
            "Nordeste",
            71
        );
        mockFinder.Setup(f => f.findAdressAsync("40727800"))
            .ReturnsAsync(expectedAdressDto);
        
        var service = new UserService(mockRepo.Object, mockFinder.Object);
        var request = new UserRequestDto(
            "yansilva303@gmail.com",
            "yansilva303",
            "123456",
            new DateTime(1999, 12, 12),
            "40727800");

        var result = await service.create(request);
        Assert.Equal(request.Email, result.Email);
        Assert.Equal(request.Username, result.Username);
        Assert.Equal(request.BirthDate, result.BirthDate);
        Assert.Equal(expectedAdressDto.cep, result.Adress.cep);
        Assert.Equal(expectedAdressDto.bairro, result.Adress.Neighborhood);
        Assert.Equal(expectedAdressDto.logradouro, result.Adress.Street);
        Assert.Equal(expectedAdressDto.localidade, result.Adress.City);
        Assert.Equal(expectedAdressDto.uf, result.Adress.Uf);
        Assert.Equal(expectedAdressDto.regiao, result.Adress.Region);
        Assert.Equal(expectedAdressDto.ddd, result.Adress.Ddd);
        
        mockRepo.Verify(r => r.Create(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task ShouldThrowInvalidExceptionWhenCepIsInvalid()
    {
        var mockRepo = new Mock<IUserRepository>();
        var mockCepFinder = new Mock<IAdressFinder>();

        mockCepFinder.Setup(f => f.findAdressAsync("00000000"))
            .ThrowsAsync(new InvalidCepException());

        var service = new UserService(mockRepo.Object, mockCepFinder.Object);
        var request = new UserRequestDto(
            "yansilva303@gmail.com",
            "yansilva303",
            "123456",
            new DateTime(1999, 12, 12),
            "00000000"
        );
        
        await Assert.ThrowsAsync<InvalidCepException>(() => service.create(request));
        mockRepo.Verify(repo => repo.Create(It.IsAny<User>()), Times.Never);
    }
}