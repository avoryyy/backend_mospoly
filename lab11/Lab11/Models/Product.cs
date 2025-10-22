namespace Lab11.Models;

/// Модель данных для демонстрации CRUD операций через API
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}