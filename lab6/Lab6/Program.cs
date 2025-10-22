using Lab06.Models;

var builder = WebApplication.CreateBuilder(args);

// Настройка конфигурации для разных сред
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables(); // поддержка переменных среды

// Привязка конфигурации к классу
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Добавляем контроллеры и Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();