using ClientesApi.DTOs;
using ClientesApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var token = _authService.Login(request);

        if (token == null)
        {
            return Unauthorized(new
            {
                mensagem = "Utilizador ou password inválidos."
            });
        }

        return Ok(new
        {
            token
        });
    }
}