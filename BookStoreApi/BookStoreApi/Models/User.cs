using BookStoreApi.Enums;

namespace BookStoreApi.Models;

/// <summary>
/// Модель пользователя.
/// </summary>
public class User
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Почта пользователя.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Роль пользователя.
    /// </summary>
    public RolesEnum Role { get; set; }

    /// <summary>
    /// Заказы.
    /// </summary>
    public IEnumerable<Cart> Orders { get; set; }
}