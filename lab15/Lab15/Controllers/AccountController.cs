using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lab15.Controllers
{
    public class AccountController : Controller
    {
        // Вход пользователя
        [HttpGet]
        public IActionResult Login()
        {
            return Content(@"
                <html>
                    <body>
                        <h1>Вход</h1>
                        <form method='post'>
                            Логин: <input name='username' /><br/>
                            Пароль: <input name='password' type='password' /><br/>
                            <button type='submit'>Войти</button>
                        </form>
                        <p>Доступные логины: admin / user (пароль любой)</p>
                    </body>
                </html>", "text/html; charset=utf-8");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Простая проверка в памяти
            string role = username.ToLower() == "admin" ? "Admin" : "User";

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return Redirect("/");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        public IActionResult AccessDenied()
        {
            return Content("<h1>Доступ запрещён</h1><p>У вас нет прав для просмотра этой страницы.</p><a href='/'>На главную</a>", "text/html; charset=utf-8");
        }
    }
}
