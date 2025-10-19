namespace RestBiblioteca.controller.DTO;

public record AuthorResponseDTO(Guid id,string Name, DateTime BirthDate, string Nationality,IEnumerable<BookResponseDTO> Books);