using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniThesis.Application.Abstractions;
using UniThesis.Domain.Common;
using UniThesis.Domain.Users;

namespace UniThesis.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUnitOfWork _uow;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthController(IUnitOfWork uow, IJwtTokenService jwtTokenService)
    {
        _uow = uow;
        _jwtTokenService = jwtTokenService;
    }

    public record RegisterRequest(string UserName, string Password, UserRole Role);
    public record LoginRequest(string UserName, string Password);

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var existing = await _uow.Users.ObterPorUserNameAsync(request.UserName);
        if (existing is not null)
            return BadRequest("Usuário já existe.");

        var user = UserAccount.Criar(request.UserName, request.Password, request.Role);

        await _uow.Users.AdicionarAsync(user);
        await _uow.CompleteAsync();

        return CreatedAtAction(nameof(Register), new { userName = user.UserName }, null);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _uow.Users.ObterPorUserNameAsync(request.UserName);
        if (user is null || !user.VerificarSenha(request.Password))
            return Unauthorized("Usuário ou senha inválidos.");

        var token = _jwtTokenService.GerarToken(
            user.Id,
            user.UserName,
            user.Role.ToString());

        return Ok(new
        {
            token,
            id = user.Id,
            name = user.UserName,
            role = user.Role.ToString()
        });
    }

    [HttpGet("me")]
    [Authorize]
    public IActionResult Me()
    {
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var name = User.Identity?.Name;
        var role = User.FindFirstValue(ClaimTypes.Role);

        if (id is null)
            return Unauthorized();

        return Ok(new
        {
            id,
            name,
            role
        });
    }
}
