namespace Lab12.Models;


/// Модель данных, описывающая товар
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}