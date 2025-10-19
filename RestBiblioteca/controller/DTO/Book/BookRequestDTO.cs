using RestBiblioteca.model;

namespace RestBiblioteca.controller.DTO;

public record BookRequestDTO(string Name, Guid AuthorId, Category Category, Guid PublisherId);