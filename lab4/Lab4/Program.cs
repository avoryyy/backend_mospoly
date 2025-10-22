var builder = WebApplication.CreateBuilder(args);

// Добавляем поддержку контроллеров
builder.Services.AddControllers();

var app = builder.Build();

// Включаем маршрутизацию контроллеров
app.MapControllers();

// Дополнительно можно добавить маршрут по умолчанию
app.MapGet("/", () => "Добро пожаловать в приложение с маршрутизацией!");

app.Run();