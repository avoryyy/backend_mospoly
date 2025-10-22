namespace Lab1;

/// Интерфейс сервиса для работы с сообщениями
public interface IMessageService
{
    string GetMessage();
    void SaveMessage(string message);
}