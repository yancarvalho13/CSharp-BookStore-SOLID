namespace RestBiblioteca.controller.DTO;

public record AuthorResponseDTO(long id,string Name, DateTime BirthDate, string Nationality,IEnumerable<BookResponseDTO> Books);