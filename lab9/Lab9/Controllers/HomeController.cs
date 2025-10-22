using Microsoft.AspNetCore.Mvc;
using System;

namespace Lab9.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content(@"
                <html>
                    <head><title>Практическое занятие №9</title></head>
                    <body>
                        <h1>Обработка ошибок в ASP.NET Core</h1>
                        <ul>
                            <li><a href='/Home/ThrowException'>Симулировать исключение</a></li>
                            <li><a href='/Home/NotFoundTest'>Вызвать 404 ошибку</a></li>
                        </ul>
                    </body>
                </html>", "text/html; charset=utf-8");
        }

        public IActionResult ThrowException()
        {
            throw new InvalidOperationException("Пример внутренней ошибки!");
        }

        public IActionResult NotFoundTest()
        {
            return NotFound("Такой страницы не существует!");
        }

        [Route("Home/Error")]
        public IActionResult Error()
        {
            var html = @"
                <html>
                    <head><title>Ошибка</title></head>
                    <body style='font-family:Arial;'>
                        <h1 style='color:red;'>Произошла ошибка!</h1>
                        <p>Что-то пошло не так. Пожалуйста, попробуйте позже.</p>
                        <a href='/'>Вернуться на главную</a>
                    </body>
                </html>";
            return Content(html, "text/html; charset=utf-8");
        }

        [Route("Home/StatusCode")]
        public IActionResult StatusCodeHandler(int code)
        {
            string message = code switch
            {
                404 => "Страница не найдена (404)",
                500 => "Внутренняя ошибка сервера (500)",
                _ => $"Ошибка: {code}"
            };

            var html = $@"
                <html>
                    <head><title>Ошибка {code}</title></head>
                    <body style='font-family:Arial;'>
                        <h1>Ошибка {code}</h1>
                        <p>{message}</p>
                        <a href='/'>Вернуться на главную</a>
                    </body>
                </html>";
            return Content(html, "text/html; charset=utf-8");
        }
    }
}