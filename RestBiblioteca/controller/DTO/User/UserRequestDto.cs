namespace RestBiblioteca.controller.DTO.User;

public record UserRequestDto(string Email,
    string Username,
    string Password,
    DateTime BirthDate,
    string Cep);