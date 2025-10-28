using Microsoft.AspNetCore.Mvc;
using RestBiblioteca.controller.DTO;
using RestBiblioteca.model;
using RestBiblioteca.service;

namespace RestBiblioteca.controller;

[ApiController]
[Route("api/[controller]")]
internal class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll ()
    {
        var authors = await _authorService.GetAll();
        var response = authors
            .Select(a => new AuthorResponseDto(
                a.Id, a.Name, a.BirthDate, a.Nationality, a.Books.Select(
                    b => new BookResponseDTO(
                        b.Id,b.Name, a.Name,b.Category, b.Publisher.Name))
                )).ToList();
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AuthorRequestDto? dto)
    {
        if (dto is null)
        {
            return BadRequest();
        }
        var author = new Author(dto.Name, dto.BirthDate, dto.Nationality);
        await _authorService.Create(author);
        
        return Ok(new AuthorResponseDto(author.Id, author.Name, author.BirthDate, author.Nationality, new List<BookResponseDTO>()));
    }
}