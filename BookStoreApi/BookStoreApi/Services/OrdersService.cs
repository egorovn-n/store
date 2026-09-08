using BookStoreApi.Interfaces;
using BookStoreApi.Models;

namespace BookStoreApi.Services;

/// <summary>
/// Сервис заказов
/// </summary>
public class OrdersService: IOrdersService
{
    private readonly StoreContext _dbContext;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="OrdersService"/>
    /// </summary>
    public OrdersService(StoreContext dbContext)
    {
        _dbContext = dbContext;
    }

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