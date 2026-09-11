using BookStoreApi.Dtos;
using BookStoreApi.Models;

namespace BookStoreApi.Extensions;

/// <summary>
/// Расширение для маппинга модели "Заказ".
/// </summary>
public static class OrderMappingExtension
{
    /// <summary>
    /// Маппинг модели заказа в Dto заказа.
    /// </summary>
    /// <param name="order">Модель заказа.</param>
    /// <returns>Dto заказа.</returns>
    public static OrderDto MapToOrderDto(this Order order)
    {
        return new OrderDto
        {
            OrderStatuses = order.OrderStatuses,
            OrderTypes = order.OrderTypes,
            OrderDateTime = order.OrderDateTime,
            ProductsAndNumbers = order.OrderProducts.Select(op => op.MapToProductAndNumberDto(order.OrderDateTime))
        };
    }
}