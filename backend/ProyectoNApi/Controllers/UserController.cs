using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using ProyectoNApi.Services;
using ProyectoNApi.Models.Dtos;

namespace ProyectoNApi.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [Authorize] // User must be authenticated, returns 401 if not
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