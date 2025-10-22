using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Lab4.Controllers;

[Route("products")]
public class ProductController : Controller
{
    // Простейший "репозиторий" продуктов для демонстрации
    private static readonly List<Product> Products = new List<Product>
    {
        new Product { Id = 1, Name = "Ноутбук", Price = 50000 },
        new Product { Id = 2, Name = "Смартфон", Price = 30000 },
        new Product { Id = 3, Name = "Планшет", Price = 20000 }
    };

    [HttpGet("")]
    public IActionResult Index()
    {
        var html = "<h1>Список продуктов</h1><ul>";
        foreach (var p in Products)
        {
            html += $"<li><a href='/products/details/{p.Id}'>{p.Name} - {p.Price} руб.</a></li>";
        }
        html += "</ul><a href='/home'>На главную</a>";
        return Content(html, "text/html; charset=utf-8");
    }

    [HttpGet("details/{id:int}")]
    public IActionResult Details(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return Content($"<h1>Продукт не найден</h1><a href='/products'>Назад к продуктам</a>", "text/html; charset=utf-8");
        }

        var html = $@"
            <h1>Детали продукта</h1>
            <p>Название: {product.Name}</p>
            <p>Цена: {product.Price} руб.</p>
            <a href='/products'>Назад к продуктам</a>
        ";
        return Content(html, "text/html; charset=utf-8");
    }

    [HttpGet("filter/{minPrice:int?}")]
    public IActionResult Filter(int? minPrice)
    {
        var filtered = minPrice.HasValue
            ? Products.Where(p => p.Price >= minPrice.Value).ToList()
            : Products;

        var html = "<h1>Фильтрованные продукты</h1><ul>";
        foreach (var p in filtered)
        {
            html += $"<li>{p.Name} - {p.Price} руб.</li>";
        }
        html += "</ul><a href='/products'>Назад к продуктам</a>";
        return Content(html, "text/html; charset=utf-8");
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
}