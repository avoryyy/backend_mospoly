namespace lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Создание и настройка хоста приложения
            var host = Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
            {
                // Регистрация сервиса в контейнере зависимостей как Singleton
                services.AddSingleton<INotificationService, NotificationService>();
                // Регистрация основного приложения
                services.AddSingleton<Application>();
            }).Build();

            // Получение экземпляра основного приложения из контейнера зависимостей
            var app = host.Services.GetRequiredService<Application>();
            // Запуск основного приложения
            app.Run();
        }
    }

    public interface INotificationService
    {
        string GetMessage();
    }

    public class NotificationService : INotificationService
    {
        public string GetMessage()
        {
            return "Some Message";
        }
    }

    public class Application
    {
        // Приватное поле для хранения зависимости
        private readonly INotificationService _notificationService;

        // Конструктор с внедрением зависимости
        public Application(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void Run()
        {
            // Использование внедренного сервиса для получения и вывода сообщения
            Console.WriteLine(_notificationService.GetMessage());
        }
    }
}
