using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWT.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly DataContext _context;

    public AuthController(IAuthService authService, DataContext context)
    {
        _authService = authService;
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<User>> RegisterUser(UserDto request)
    {
        var addingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
        if (addingUser == null)
        {
            var response = await _authService.RegisterUser(request);
            return Ok(response);
        }
        else {
            return BadRequest();
            }
    }

    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(UserDto request)
    {
        var response = await _authService.Login(request);
        if (response.Success)
            return Ok(response);

        return BadRequest(response.Message);
    }

    [HttpPost("refresh-token")]
    public async Task<ActionResult<string>> RefreshToken()
    {
        var response = await _authService.RefreshToken();
        if (response.Success)
            return Ok(response);

        return BadRequest(response.Message);
    }

    [HttpGet, Authorize(Roles = "User,Admin")]
    public ActionResult<string> Aloha()
    {
        return Ok("Aloha! You're authorized!");
    }
}
