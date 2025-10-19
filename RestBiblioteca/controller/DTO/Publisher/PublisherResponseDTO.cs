namespace RestBiblioteca.controller.DTO.Publisher;

public record PublisherResponseDTO(Guid Id, string Name, string Country, IEnumerable<BookResponseDTO> Books);