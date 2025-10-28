using RestBiblioteca.model;

namespace RestBiblioteca.controller.DTO;

public record BookRequestDTO(string Name, long AuthorId, Category Category, long PublisherId);