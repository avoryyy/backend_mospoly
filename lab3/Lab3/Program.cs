using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lab1;

/// Главный класс программы, настраивающий внедрение зависимостей и запускающий приложение
class Program
{
    static void Main(string[] args)
    {
        // Создание хоста с настройкой служб
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // Регистрация зависимостей
                services.AddSingleton<IMessageService, MessageService>();
                services.AddSingleton<ApplicationService>();
            })
            .Build();

        // Получаем основной сервис приложения
        var app = host.Services.GetRequiredService<ApplicationService>();
        app.Run();
    }
}