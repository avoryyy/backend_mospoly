using Lab12.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab12.Data;

/// Контекст базы данных для работы с Entity Framework
public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        // Автоматическое создание базы при первом запуске
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Инициализация базы начальными данными
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Ноутбук", Price = 55000 },
            new Product { Id = 2, Name = "Смартфон", Price = 32000 },
            new Product { Id = 3, Name = "Монитор", Price = 18000 }
        );
    }
}