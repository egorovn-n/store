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
    /// Идентификатор роли.
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Роль пользователя.
    /// </summary>
    public Role Role { get; set; }

    /// <summary>
    /// Корзина товаров.
    /// </summary>
    public Cart Cart { get; set; }

    /// <summary>
    /// Заказы.
    /// </summary>
    public IEnumerable<Order> Orders { get; set; }
}