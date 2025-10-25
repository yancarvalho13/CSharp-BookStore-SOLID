using Microsoft.AspNetCore.Mvc;
using RestBiblioteca.controller.DTO.User;
using RestBiblioteca.service;

namespace RestBiblioteca.controller;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserRequestDto? request)
    {
        if (request is null)
        {
            return BadRequest(new { message = "User is null" });
        }

        var created = await _userService.create(request);
        return Ok(created);

    }
}