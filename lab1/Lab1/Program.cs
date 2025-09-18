public class Program
{
    public static void Main(string[] args)
    {
        // Создание и настройка билдера
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        // Главная страница
        app.MapGet("/", () =>
            Results.Text(@"<html><body>
                <h1>Главная страница лабораторной работы</h1>
                <p>Это главная страница</p>
                <a href='/about'>О проекте</a>
                <a href='/contact'>Контакты</a>
            </body></html>",
            "text/html; charset=utf-8")
            );

        // Страница "О проекте"
        app.MapGet("/about", () =>
            Results.Text(@"<html><body>
                <h1>Информация о проекте</h1>
                <p>Простое веб-приложение на ASP.NET с использованием WebApplication</p>
                <a href='/'>Главная</a>
            </body></html>",
            "text/html; charset=utf-8")
            );

        // Страница "Контакты"
        app.MapGet("/contact", () =>
            Results.Text(@"<html><body>
                <h1>Контактная информация</h1>
                <p>Код проекта представлен в листинге</p>
                <a href='/'>Главная</a>
            </body></html>",
            "text/html; charset=utf-8")
            );

        // Запуск приложения
        app.Run();
    }
}