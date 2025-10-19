using Microsoft.AspNetCore.Mvc;
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
        return Ok(await _publisherService.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Publisher? publisher)
    {
        if (publisher is null)
        {
            return BadRequest(new { message = "Publisher is null" });
        }
        return Ok(await _publisherService.CreateAsync(publisher));
    }
    
}