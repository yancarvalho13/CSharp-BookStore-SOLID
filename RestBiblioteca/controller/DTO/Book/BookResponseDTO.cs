using RestBiblioteca.model;

namespace RestBiblioteca.controller.DTO;

public record BookResponseDTO(long id, string Name, string Author, Category Category, string Publisher);