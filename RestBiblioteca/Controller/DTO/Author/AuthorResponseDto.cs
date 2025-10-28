namespace RestBiblioteca.controller.DTO;

public record AuthorResponseDto(long id,string Name, DateTime BirthDate, string Nationality,IEnumerable<BookResponseDTO> Books);