using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers;

[Route("home")]
public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return Content(@"
            <h1>Главная страница</h1>
            <ul>
                <li><a href='/home/about'>О приложении</a></li>
                <li><a href='/home/contact'>Контакты</a></li>
                <li><a href='/products'>Продукты</a></li>
            </ul>
        ", "text/html; charset=utf-8");
    }

    [HttpGet("about")]
    public IActionResult About()
    {
        return Content(@"
            <h1>О приложении</h1>
            <p>Это демонстрация маршрутизации в ASP.NET Core.</p>
            <a href='/home'>Назад на главную</a>
        ", "text/html; charset=utf-8");
    }

    [HttpGet("contact/{name?}")]
    public IActionResult Contact(string? name)
    {
        var message = string.IsNullOrEmpty(name)
            ? "Страница контактов"
            : $"Страница контактов пользователя: {name}";
        return Content($@"
            <h1>Контакты</h1>
            <p>{message}</p>
            <a href='/home'>Назад на главную</a>
        ", "text/html; charset=utf-8");
    }
}