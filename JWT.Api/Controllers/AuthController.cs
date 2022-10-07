using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<ActionResult<string>> Login(UserDto request)
    {
        string token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiVG9ueSBTdGFyayIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6Iklyb24gTWFuIiwiZXhwIjozMTY4NTQwMDAwfQ.IbVQa1lNYYOzwso69xYfsMOHnQfO3VLvVqV2SOXS7sTtyyZ8DEf5jmmwz2FGLJJvZnQKZuieHnmHkg7CGkDbvA";
        return token;
    }

    //[HttpPost]
    //public async Task<ActionResult<User>> RegisterUser(UserDto request)
    //{
    //    var response = await _authService.RegisterUser(request);
    //    return Ok(response);
    //}

    //[HttpPost("login")]
    //public async Task<ActionResult<User>> Login(UserDto request)
    //{
    //    var response = await _authService.Login(request);
    //    if (response.Success)
    //        return Ok(response);

    //    return BadRequest(response.Message);
    //}

    //[HttpPost("refresh-token")]
    //public async Task<ActionResult<string>> RefreshToken()
    //{
    //    var response = await _authService.RefreshToken();
    //    if (response.Success)
    //        return Ok(response);

    //    return BadRequest(response.Message);
    //}

    //[HttpGet, Authorize(Roles = "User,Admin")]
    //public ActionResult<string> Aloha()
    //{
    //    return Ok("Aloha! You're authorized!");
    //}
}
