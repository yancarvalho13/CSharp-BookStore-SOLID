using RestBiblioteca.controller.DTO.User;
using RestBiblioteca.Exceptions;
using RestBiblioteca.model;
using RestBiblioteca.repository;

namespace RestBiblioteca.service.impl;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IAdressFinder _adressFinder;

    public UserService(IUserRepository repository, IAdressFinder adressFinder)
    {
        _repository = repository;
        _adressFinder = adressFinder;
    }


    public async Task<UserResponseDto> create(UserRequestDto userRequest)
    {
        var adressInfo = await _adressFinder.findAdressAsync(userRequest.Cep);
        if (adressInfo is null)
        {
            throw new InvalidCepException();
        }

        var validAdress = new Adress(adressInfo.cep.Replace("-",""),
            adressInfo.logradouro,
            adressInfo.bairro,
            adressInfo.localidade,
            Enum.Parse<State>(adressInfo.uf, ignoreCase:true),
            Enum.Parse<State>(adressInfo.uf, ignoreCase:true),
            adressInfo.regiao,
            adressInfo.ddd);
        
        
        var user = new User(userRequest.Email,
            userRequest.Username,
            userRequest.Password,
            Role.User,
            userRequest.BirthDate,
            validAdress);

        
        _repository.Create(user);
        return new UserResponseDto(user.Id,
            user.Email,
            user.Username,
            user.Role.ToString(),
            user.BirthDate,
            new AdressDto(user.GetCep(),
                user.GetStreet(),
                user.GetNeighborhood(),
                user.GetCity(),
                user.GetUf().ToString(),
                user.GetState().ToString(),
                user.GetRegion(),
                user.GetDdd())
            );
    }

    public UserResponseDto update(long id, UserRequestDto userRequest)
    {
        throw new NotImplementedException();
    }
}