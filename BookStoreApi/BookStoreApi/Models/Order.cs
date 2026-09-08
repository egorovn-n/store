using System.ComponentModel.DataAnnotations.Schema;
using BookStoreApi.Enums;

namespace BookStoreApi.Models;

/// <summary>
/// Заказ.
/// </summary>
/// <remarks>Используется подход TPH для наследования "заказов" от "корзины".</remarks>
[Table("Orders")]
public class Order: Cart
{
    /// <summary>
    /// Статус заказа.
    /// </summary>
    public OrderStatusEnum OrderStatus { get; set; }

    /// <summary>
    /// Тип заказа.
    /// </summary>
    public OrderTypeEnum OrderType { get; set; }

    /// <summary>
    /// Дата и время заказа.
    /// </summary>
    public DateTime OrderDateTime { get; set; }
}