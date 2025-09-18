// Сервис для работы с пользователями
public interface IUserService
{
    string GetUserName(int userId);
}

public class UserService : IUserService
{
    public string GetUserName(int userId)
    {
        return userId == 1 ? "Администратор" : "Пользователь";
    }
}

// Сервис для логирования
public interface ILoggerService
{
    void Log(string message);
}

public class ConsoleLoggerService : ILoggerService
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
    }
}

// Основной класс приложения
public class Application
{
    private readonly IUserService _userService;
    private readonly ILoggerService _logger;

    public Application(IUserService userService, ILoggerService logger)
    {
        _userService = userService;
        _logger = logger;
    }

    public void Run()
    {
        _logger.Log("Приложение запущено");

        var userName = _userService.GetUserName(1);
        Console.WriteLine($"Текущий пользователь: {userName}");

        _logger.Log("Приложение завершает работу");
    }
}

class Program
{
    static void Main()
    {
        // Создаем экземпляры сервисов
        ILoggerService logger = new ConsoleLoggerService();
        IUserService userService = new UserService();

        // Внедряем зависимости через конструктор
        var app = new Application(userService, logger);
        app.Run();
    }
}