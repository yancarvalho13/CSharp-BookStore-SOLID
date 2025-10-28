namespace RestBiblioteca.controller.DTO.User;

public record AdressDto(string cep,
    string Street,
    string Neighborhood,
    string City,
    string Uf,
    string State,
    string Region,
    int Ddd);