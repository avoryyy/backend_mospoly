var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // Поддержка контроллеров и представлений

var app = builder.Build();

// Включаем поддержку статических файлов
app.UseStaticFiles();

// Настраиваем маршрутизацию
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();