using Microsoft.AspNetCore.Mvc;

namespace Lab14.Controllers;

/// Контроллер для демонстрации работы CORS
[ApiController]
[Route("api/[controller]")]
public class DataController : ControllerBase
{
    // Пример GET-запроса, который может вызываться с другого домена
    [HttpGet("info")]
    public IActionResult GetInfo()
    {
        return Ok(new
        {
            message = "Запрос выполнен успешно! Доступ разрешён политикой CORS.",
            time = DateTime.Now.ToString("HH:mm:ss")
        });
    }

    // Пример POST-запроса для проверки CORS при отправке данных
    [HttpPost("submit")]
    public IActionResult Submit([FromBody] dynamic payload)
    {
        return Ok(new
        {
            status = "Получено",
            data = payload,
            time = DateTime.Now.ToString("HH:mm:ss")
        });
    }
}