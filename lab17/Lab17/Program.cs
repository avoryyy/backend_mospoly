using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы контроллеров и кеширования
builder.Services.AddControllers();
builder.Services.AddMemoryCache();              // внутренний кэш (in-memory)
builder.Services.AddDistributedMemoryCache();   // распределённый кэш (имитация через память)

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
