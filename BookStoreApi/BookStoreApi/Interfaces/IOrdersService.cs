using BookStoreApi.Dtos;

namespace BookStoreApi.Interfaces;

/// <summary>
/// Интерфейс для сервиса заказов
/// </summary>
public interface IOrdersService
{
    /// <summary>
    /// Получение заказов.
    /// </summary>
    /// <param name="email">Почта пользователя.</param>
    /// <returns>Список заказов.</returns>
    public IEnumerable<OrderDto> GetOrderDtos(string email);

    /// <summary>
    /// Получение заказов.
    /// </summary>
    /// <param name="email">Почта пользователя.</param>
    /// <param name="orderId">Идентификатор заказа.</param>
    /// <returns>Список заказов.</returns>
    public OrderDto GetOrderDtoById(string email, int orderId);
}