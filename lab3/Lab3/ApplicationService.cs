namespace Lab1;

/// Основной сервис приложения, использующий внедрённые зависимости
public class ApplicationService
{
    private readonly IMessageService _messageService;

    public ApplicationService(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Run()
    {
        Console.WriteLine("Текущее сообщение: " + _messageService.GetMessage());

        Console.WriteLine("Введите новое сообщение:");
        var input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input))
        {
            _messageService.SaveMessage(input);
        }

        Console.WriteLine("Ваше замещённое сообщение из ApplicationService: " + _messageService.GetMessage());
    }
}