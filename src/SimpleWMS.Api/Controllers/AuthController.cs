using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWMS.Api.Dtos;
using SimpleWMS.Application.Abstractions;
using SimpleWMS.Domain.Entities;
using SimpleWMS.Persistence;

namespace SimpleWMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly SimpleWmsDbContext _dbContext;
    private readonly IJwtTokenService _tokenService;
    
    public AuthController(SimpleWmsDbContext dbContext, IJwtTokenService tokenService)
    {
        _dbContext = dbContext;
        _tokenService = tokenService;
    }
    
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        if (await _dbContext.Users.AnyAsync(u => u.UserName == registerDto.UserName))
            return Conflict("User exists");
        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = registerDto.UserName,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
            Role = "Worker"
        };
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return Created();
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.UserName == loginDto.UserName);
        
        if (user is null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            return Unauthorized();
        
        var token = _tokenService.Generate(user);
        
        return Ok(new { token });
    }
}