using Microsoft.AspNetCore.Mvc;
using ProyectoNApi.Services;
using ProyectoNApi.Models.Dtos;

namespace ProyectoNApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUserById([FromRoute] int id)
    {
        var user = await _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

}