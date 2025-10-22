using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Lab06.Models;

namespace Lab06.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConfigController : ControllerBase
{
    private readonly AppSettings _settings;

    public ConfigController(IOptions<AppSettings> options)
    {
        _settings = options.Value;
    }

    [HttpGet("info")]
    public IActionResult GetConfig()
    {
        return Ok(new
        {
            _settings.AppName,
            _settings.Version,
            _settings.Environment,
            _settings.DebugMode
        });
    }
}