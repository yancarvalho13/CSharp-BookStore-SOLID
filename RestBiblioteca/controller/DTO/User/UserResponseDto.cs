namespace RestBiblioteca.controller.DTO.User;

public record UserResponseDto(long Id,
    string Email,
    string Username,
    string Role,
    DateTime BirthDate,
    AdressDto Adress 
    );