using Microsoft.AspNetCore.Mvc;
using RestBiblioteca.controller.DTO;
using RestBiblioteca.model;
using RestBiblioteca.service;

namespace RestBiblioteca.controller;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll ()
    {
        var authors = await _authorService.GetAllAsync();
        var response = authors
            .Select(a => new AuthorResponseDTO(
                a.Id, a.Name, a.BirthDate, a.Nationality, a.Books.Select(
                    b => new BookResponseDTO(
                        b.Id,b.Name, a.Name,b.Category, b.Publisher.Name))
                )).ToList();
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AuthorRequestDTO? dto)
    {
        if (dto is null)
        {
            return BadRequest();
        }
        var author = new Author(dto.Name, dto.BirthDate, dto.Nationality);
        await _authorService.CreateAsync(author);
        
        return Ok(new AuthorResponseDTO(author.Id, author.Name, author.BirthDate, author.Nationality, new List<BookResponseDTO>()));
    }
}