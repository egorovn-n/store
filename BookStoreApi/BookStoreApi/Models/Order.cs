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
    public OrderStatusesEnum OrderStatuses { get; set; }

    /// <summary>
    /// Тип заказа.
    /// </summary>
    public OrderTypesEnum OrderTypes { get; set; }

    /// <summary>
    /// Дата и время заказа.
    /// </summary>
    public DateTime OrderDateTime { get; set; }
}