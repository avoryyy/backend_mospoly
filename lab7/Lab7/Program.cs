using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Конфигурация Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // лог в консоль
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day) // лог в файл
    .CreateLogger();

builder.Host.UseSerilog(); // Используем Serilog вместо стандартного логгера

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