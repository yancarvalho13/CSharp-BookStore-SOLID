namespace RestBiblioteca.controller.DTO.Publisher;

public record PublisherResponseDTO(long Id, string Name, string Country, IEnumerable<BookResponseDTO> Books);