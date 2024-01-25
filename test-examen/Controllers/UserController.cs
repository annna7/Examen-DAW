using Microsoft.AspNetCore.Mvc;
using test_examen.Models;
using test_examen.Models.Dto;
using test_examen.Services;

namespace test_examen.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = (await _userService.GetAllUsers()).ToList();
        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        try
        {
            var user = await _userService.GetUser(id);
            return Ok(user);
        }
        catch
        {
            return NotFound("User " + id + " not found!");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
        var user = await _userService.CreateUser(createUserDto);
        return Ok(user);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        try
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
        catch
        {
            return NotFound("User " + id + " not found!");
        }
    }
}