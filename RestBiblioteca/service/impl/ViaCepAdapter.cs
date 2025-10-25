using RestBiblioteca.controller.DTO.AdressFinder;

namespace RestBiblioteca.service.impl;

public class ViaCepAdapter : IAdressFinder
{
    private readonly HttpClient _httpClient;

    public ViaCepAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<ViaCepDto?> findAdressAsync(string adress)
    {
        using HttpResponseMessage response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{adress}/json/");
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadFromJsonAsync<ViaCepDto>();
        return jsonResponse;
    }
}