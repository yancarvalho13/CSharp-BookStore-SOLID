using RestBiblioteca.controller.DTO.AdressFinder;
using RestBiblioteca.model;

namespace RestBiblioteca.service;

public interface IAdressFinder
{
    public  Task<ViaCepDto?> findAdressAsync(string adress);
}