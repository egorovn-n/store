using BookStoreApi.Dtos;
using BookStoreApi.Exceptions;
using BookStoreApi.Extensions;
using BookStoreApi.Interfaces;
using BookStoreApi.Models;
using Microsoft.EntityFrameworkCore;

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
    public IEnumerable<OrderDto> GetOrderDtos(string email)
    {
        var orders = _dbContext.Orders.AsNoTracking()
            .Include(o => o.User)
            .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                    .ThenInclude(p => p.ProductPriceChanges)
            .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                    .ThenInclude(p => p.ProductImages)
            .Where(o => o.User != null && o.User.Email == email);

        if (!orders.Any())
        {
            return [];
        }

        var result = orders.Select(o => o.MapToOrderDto()).ToList();
        foreach (var orderDto in result)
        {
            orderDto.CalculateTotalPrice();
        }

        return result;
    }

    /// <inheritdoc />
    public OrderDto GetOrderDtoById(string email, int orderId)
    {
        var order = _dbContext.Orders.AsNoTracking()
            .Include(o => o.User)
            .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                    .ThenInclude(p => p.ProductPriceChanges)
            .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                    .ThenInclude(p => p.ProductImages)
            .FirstOrDefault(o => o.User != null && o.Id == orderId && o.User.Email == email);

        if (order == null)
        {
            throw new OrderNotFoundException(orderId);
        }

        var result = order.MapToOrderDto();
        result.CalculateTotalPrice();

        return result;
    }
}