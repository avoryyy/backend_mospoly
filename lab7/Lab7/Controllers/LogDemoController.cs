using Microsoft.AspNetCore.Mvc;

namespace Lab07.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LogDemoController : ControllerBase
{
    private readonly ILogger<LogDemoController> _logger;

    public LogDemoController(ILogger<LogDemoController> logger)
    {
        _logger = logger;
    }

    [HttpGet("info")]
    public IActionResult InfoLog()
    {
        _logger.LogInformation("Информационное сообщение для InfoLog");
        return Ok("Информационный лог записан");
    }

    [HttpGet("warning")]
    public IActionResult WarningLog()
    {
        _logger.LogWarning("Предупреждение для WarningLog");
        return Ok("Warning лог записан");
    }

    [HttpGet("error")]
    public IActionResult ErrorLog()
    {
        _logger.LogError("Ошибка для ErrorLog");
        return Ok("Error лог записан");
    }
}