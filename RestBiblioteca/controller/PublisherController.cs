using Microsoft.AspNetCore.Mvc;
using RestBiblioteca.controller.DTO;
using RestBiblioteca.controller.DTO.Publisher;
using RestBiblioteca.model;
using RestBiblioteca.service;

namespace RestBiblioteca.controller;

[ApiController]
[Route("api/[controller]")]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublisherController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll ()
    {
        var publishers = await _publisherService.GetAllAsync();
        var response = publishers.Select(p => new PublisherResponseDTO(
            p.Id, p.Name, p.Country,
            p.Books.Select(b => new BookResponseDTO(
                b.Id, b.Name, b.Author.Name, b.Category, b.Publisher.Name)).ToList()
        )).ToList();
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PublisherRequestDTO? request)
    {
        if (request is null)
        {
            return BadRequest(new { message = "Publisher is null" });
        }

        var publisher = await _publisherService.CreateAsync(new Publisher(
            request.Name, request.Country));
        var response = new PublisherResponseDTO(
            publisher.Id, publisher.Name, publisher.Country, new List<BookResponseDTO>());
        return Ok(response);
    }
    
}