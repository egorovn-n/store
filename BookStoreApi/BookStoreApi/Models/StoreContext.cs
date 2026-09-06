using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Models;

/// <inheritdoc />
public sealed class StoreContext : DbContext
{
    /// <summary>
    /// Строка для поиска подключения к Postgre в ConnectionStrings
    /// </summary>
    public const string PostgreSqlString = "PostgreSQL";

    /// <summary>
    /// Таблица "Пользователи"
    /// </summary>
    public DbSet<User> Users { get; set; } = null!;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="StoreContext"/>
    /// </summary>
    public StoreContext (DbContextOptions<StoreContext> options) : base(options) { }
}