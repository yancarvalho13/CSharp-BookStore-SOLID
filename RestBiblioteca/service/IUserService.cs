using RestBiblioteca.controller.DTO.User;

namespace RestBiblioteca.service;

public interface IUserService
{
    public  Task<UserResponseDto> create(UserRequestDto userRequest);

    public UserResponseDto update(long id, UserRequestDto userRequest);
}