using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lab13.Models;

namespace Lab13.Controllers;

/// Контроллер для регистрации и входа пользователей
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private static readonly List<User> Users = new();

    private readonly IConfiguration _config;

    public AuthController(IConfiguration config)
    {
        _config = config;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterModel model)
    {
        if (Users.Any(u => u.Username == model.Username))
            return BadRequest("Пользователь с таким именем уже существует.");

        Users.Add(new User
        {
            Username = model.Username,
            Password = model.Password,
            Role = model.Role
        });

        return Ok("Регистрация успешна.");
    }

    [HttpPost("login")]
    public IActionResult Login(LoginModel model)
    {
        var user = Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
        if (user == null)
            return Unauthorized("Неверное имя пользователя или пароль.");

        var token = GenerateJwtToken(user);
        return Ok(new { token });
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}