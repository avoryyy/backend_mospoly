using Microsoft.AspNetCore.Mvc;
using Lab11.Models;

namespace Lab11.Controllers;

/// Контроллер для CRUD операций с продуктами
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> Products = new()
    {
        new Product { Id = 1, Name = "Ноутбук", Price = 55000 },
        new Product { Id = 2, Name = "Монитор", Price = 18000 },
        new Product { Id = 3, Name = "Смартфон", Price = 35000 }
    };

    //GET — получение всех продуктов
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Products);
    }

    //GET — получение продукта по Id
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound(new { message = $"Продукт с Id = {id} не найден." });
        return Ok(product);
    }

    //POST — добавление нового продукта
    [HttpPost]
    public IActionResult Create(Product newProduct)
    {
        newProduct.Id = Products.Any() ? Products.Max(p => p.Id) + 1 : 1;
        Products.Add(newProduct);
        return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
    }

    //PUT — обновление существующего продукта
    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Product updatedProduct)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound(new { message = $"Продукт с Id = {id} не найден." });

        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        return Ok(product);
    }

    //DELETE — удаление продукта
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound(new { message = $"Продукт с Id = {id} не найден." });

        Products.Remove(product);
        return NoContent();
    }
}