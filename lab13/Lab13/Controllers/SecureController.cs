using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lab13.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        // Доступ только для авторизованных пользователей
        [Authorize]
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            // Находим роль безопасно через ClaimTypes.Role
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            return Ok(new
            {
                message = "Доступ разрешён. Вы авторизованы!",
                user = User.Identity?.Name,
                role = role
            });
        }

        // Доступ только для админов
        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult AdminAccess()
        {
            return Ok("Доступ разрешён только для администратора!");
        }
    }
}