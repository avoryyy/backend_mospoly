namespace Lab1;

/// Реализация IMessageService, управляющая сообщениями
public class MessageService : IMessageService
{
    private string _storedMessage = "Привет из MessageService!";

    public string GetMessage()
    {
        return _storedMessage;
    }

    public void SaveMessage(string message)
    {
        _storedMessage = message;
    }
}