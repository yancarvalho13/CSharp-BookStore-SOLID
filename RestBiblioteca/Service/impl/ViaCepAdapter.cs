using RestBiblioteca.controller.DTO.AdressFinder;
using RestBiblioteca.Exceptions;

namespace RestBiblioteca.service.impl;

internal sealed class ViaCepAdapter : IAdressFinder
{
    private readonly HttpClient _httpClient;

    public ViaCepAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<ViaCepDto?> findAdressAsync(string adress)
    {
        using HttpResponseMessage response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{adress}/json/");
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidCepException("CEP inválido ou não encontrado.");
        }
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadFromJsonAsync<ViaCepDto>();
        
        if (jsonResponse == null)
        {
            throw new InvalidCepException("CEP inexistente.");
        }
        return jsonResponse;
    }
}