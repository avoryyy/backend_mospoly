using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Lab8.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // Устанавливаем cookie, если она ещё не задана
        if (!Request.Cookies.ContainsKey("VisitTime"))
        {
            Response.Cookies.Append("VisitTime", DateTime.Now.ToString());
        }

        // Работа с сессией
        int counter = HttpContext.Session.GetInt32("Counter") ?? 0;
        counter++;
        HttpContext.Session.SetInt32("Counter", counter);

        var cookieValue = Request.Cookies["VisitTime"];
        var sessionValue = HttpContext.Session.GetInt32("Counter");

        var html = $@"
        <!DOCTYPE html>
        <html lang='ru'>
        <head>
            <meta charset='UTF-8'>
            <title>Практическое занятие №8</title>
            <script>
                // Работа с localStorage и sessionStorage
                if (!localStorage.getItem('username')) {{
                    localStorage.setItem('username', 'Гость');
                }}
                sessionStorage.setItem('lastVisit', new Date().toLocaleString('ru-RU'));

                function showClientStorage() {{
                    document.getElementById('local').innerText = localStorage.getItem('username');
                    document.getElementById('session').innerText = sessionStorage.getItem('lastVisit');
                }}

                function clearClientStorage() {{
                    localStorage.clear();
                    sessionStorage.clear();
                    alert('LocalStorage и SessionStorage очищены!');
                    location.reload();
                }}
            </script>
        </head>
        <body onload='showClientStorage()'>
            <h1>Демонстрация состояний в ASP.NET Core</h1>
            <p><b>Cookie (время первого визита):</b> {cookieValue}</p>
            <p><b>Session (счётчик посещений):</b> {sessionValue}</p>
            <p><b>LocalStorage (имя пользователя):</b> <span id='local'></span></p>
            <p><b>SessionStorage (последний визит):</b> <span id='session'></span></p>
            <button onclick='clearClientStorage()'>Очистить все данные</button>
        </body>
        </html>
        ";

        // Возвращаем HTML в правильной кодировке
        Response.ContentType = "text/html; charset=utf-8";
        return Content(html, "text/html", Encoding.UTF8);
    }
}
