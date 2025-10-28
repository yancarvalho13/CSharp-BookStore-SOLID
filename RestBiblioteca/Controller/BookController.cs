using Microsoft.AspNetCore.Mvc;
using RestBiblioteca.controller.DTO;
using RestBiblioteca.model;
using RestBiblioteca.service;

namespace RestBiblioteca.controller;

[ApiController]
[Route("api/[controller]")]
internal class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await _bookService.GetAll();
        var response = books
            .Select(b => new BookResponseDTO(
                b.Id, b.Name, b.Author.Name, b.Category, b.Publisher.Name)).ToList();
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BookRequestDTO? request)
    {
        if (request is null)
        {
            return BadRequest(new { message = "Book is null" });
        }

        var created = await _bookService.Create(new Book(
            request.Name, request.AuthorId,request.PublisherId, request.Category));
        
        return Ok();
    }

    [HttpGet("{id}")]
    public async  Task<IActionResult> GetById(long id)
    {
        var book = await _bookService.GetById(id);
        if (book is null)
        {
            return NotFound();
        }

        return Ok(new BookResponseDTO(
             book.Id,
             book.Name,
             book.GetAuthorName(),
             book.Category,
             book.GetPublisherName())
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBYId(long id)
    {
        var book = await _bookService.GetById(id);
        if (book is null)
        {
            return NotFound();
        }
        await _bookService.Delete(id);
        return Ok(book);
    }
    
}