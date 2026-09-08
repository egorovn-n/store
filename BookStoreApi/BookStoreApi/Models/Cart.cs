using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Models;

/// <summary>
/// Корзина товаров.
/// </summary>
/// <remarks>Используется подход TPH для наследования "заказов" от "корзины".</remarks>
[Table("Orders")]
public class Cart
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор владельца корзины.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Дискриминатор для различия Cart и Order. Только для чтения.
    /// </summary>
    public string Discriminator { get; set; }

    /// <summary>
    /// Связь корзины с товаром.
    /// </summary>
    public IEnumerable<OrderProduct> OrderProducts { get; set; }

    /// <summary>
    /// Владелец корзины.
    /// </summary>
    public User User { get; set; }
}