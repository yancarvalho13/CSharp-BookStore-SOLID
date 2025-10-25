namespace RestBiblioteca.controller.DTO.AdressFinder;

public record ViaCepDto(string cep,
    string logradouro,
    string bairro,
    string localidade,
    string uf,
    string estado,
    string regiao,
    int ddd
    );