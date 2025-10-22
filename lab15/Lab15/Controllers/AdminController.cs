using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab15.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return Content("<h1>Панель администратора</h1><p>Только для пользователей с ролью Admin</p>", "text/html; charset=utf-8");
        }
    }
}
