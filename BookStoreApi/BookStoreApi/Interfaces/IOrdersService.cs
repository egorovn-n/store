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
    /// <param name="username">Уникальное имя пользователя.</param>
    /// <returns>Список заказов.</returns>
    public IEnumerable<OrderDto> GetOrderDtos(string username);

    /// <summary>
    /// Получение заказов.
    /// </summary>
    /// <param name="username">Уникальное имя пользователя.</param>
    /// <param name="orderId">Идентификатор заказа.</param>
    /// <returns>Список заказов.</returns>
    public OrderDto GetOrderDtoById(string username, int orderId);
}