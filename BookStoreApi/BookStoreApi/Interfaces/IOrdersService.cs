using BookStoreApi.Models;

namespace BookStoreApi.Interfaces;

/// <summary>
/// Интерфейс для сервиса заказов
/// </summary>
public interface IOrdersService
{
    /// <summary>
    /// Получение заказов.
    /// </summary>
    /// <returns>Список заказов.</returns>
    public IEnumerable<Order> GetOrders();

    /// <summary>
    /// Получение заказов.
    /// </summary>
    /// <returns>Список заказов.</returns>
    public Order GetOrderById(int id);
}