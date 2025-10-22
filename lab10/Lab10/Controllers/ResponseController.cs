using Microsoft.AspNetCore.Mvc;

namespace Lab10.Controllers;

/// Контроллер демонстрирует различные типы ответов в ASP.NET Core
[ApiController]
[Route("api/[controller]")]
public class ResponseController : ControllerBase
{
    //Пример возвращения HTML-страницы
    [HttpGet("html")]
    public IActionResult GetHtml()
    {
        var html = @"
            <html>
                <head><title>Пример HTML ответа</title></head>
                <body>
                    <h1>HTML ответ</h1>
                    <p>Этот ответ возвращён как HTML-страница.</p>
                    <a href='/api/response/json'>Посмотреть JSON ответ</a>
                </body>
            </html>";
        return Content(html, "text/html; charset=utf-8");
    }

    //Пример возвращения JSON-объекта
    [HttpGet("json")]
    public IActionResult GetJson()
    {
        var data = new
        {
            Message = "Это пример JSON ответа",
            Date = DateTime.Now,
            Items = new[] { "Ноутбук", "Планшет", "Телефон" }
        };
        return Ok(data);
    }

    //Пример возвращения текстового ответа
    [HttpGet("text")]
    public IActionResult GetText()
    {
        return Content("Простой текстовый ответ от сервера.");
    }

    //Пример возвращения файла
    [HttpGet("file")]
    public IActionResult GetFile()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "example.txt");

        // Создаём файл, если он отсутствует
        if (!System.IO.File.Exists(filePath))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
            System.IO.File.WriteAllText(filePath, "Это пример содержимого файла, возвращаемого сервером.");
        }

        var fileBytes = System.IO.File.ReadAllBytes(filePath);
        return File(fileBytes, "text/plain", "example.txt");
    }

    //Пример возвращения статуса без тела
    [HttpGet("status")]
    public IActionResult GetStatus()
    {
        return NoContent(); // Возвращает статус 204 без тела ответа
    }
}