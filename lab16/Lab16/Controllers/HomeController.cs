using Microsoft.AspNetCore.Mvc;

namespace Lab16.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content(@"
                <html>
                    <head>
                        <title>Практическое занятие №16</title>
                        <link rel='stylesheet' href='/css/style.css' />
                    </head>
                    <body>
                        <h1>Пример подключения CSS и JS</h1>
                        <button id='clickButton'>Нажми меня</button>
                        <script src='/js/script.js'></script>
                    </body>
                </html>", "text/html; charset=utf-8");
        }
    }
}
