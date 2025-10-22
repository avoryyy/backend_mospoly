using Microsoft.AspNetCore.Mvc;

namespace Lab15.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content(@"
                <html>
                    <body>
                        <h1>Главная страница</h1>
                        <ul>
                            <li><a href='/Admin/Index'>Страница для админа</a></li>
                            <li><a href='/Account/Login'>Вход в аккаунт</a></li>
                        </ul>
                    </body>
                </html>", "text/html; charset=utf-8");
        }
    }
}
