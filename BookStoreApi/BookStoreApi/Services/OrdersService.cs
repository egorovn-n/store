using BookStoreApi.Interfaces;
using BookStoreApi.Models;

namespace BookStoreApi.Services;

/// <summary>
/// Сервис заказов
/// </summary>
public class OrdersService: IOrdersService
{
    /// <inheritdoc />
    public IEnumerable<Order> GetOrders()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Order GetOrderById(int id)
    {
        throw new NotImplementedException();
    }
}