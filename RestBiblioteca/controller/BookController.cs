using Microsoft.AspNetCore.Mvc;
using RestBiblioteca.model;
using RestBiblioteca.service;

namespace RestBiblioteca.controller;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await _bookService.GetAllAsync();
        return Ok(books);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Book? book)
    {
        if (book is null)
        {
            return BadRequest(new { message = "Book is null" });
        }

        var created = await _bookService.CreateAsync(book);
        return Ok(created);
    }
    
}