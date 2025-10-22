using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // Возвращаем простую HTML-страницу с подключением CSS и изображений
        var html = @"
            <html>
            <head>
                <title>Практическое занятие №5</title>
                <link rel='stylesheet' href='/css/styles.css'>
            </head>
            <body>
                <h1>Добро пожаловать в демонстрацию статических файлов</h1>
                <p>Это страница, которая использует CSS и изображения из папки wwwroot.</p>
                <img src='/images/example.png' alt='Пример изображения' width='300'/>
                <script src='/js/script.js'></script>
            </body>
            </html>
        ";
        return Content(html, "text/html; charset=utf-8");
    }
}
