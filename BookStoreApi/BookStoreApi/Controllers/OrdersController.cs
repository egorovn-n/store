using BookStoreApi.Interfaces;
using BookStoreApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

/// <summary>
/// Контроллер заказов.
/// </summary>
[Authorize]
public class OrdersController: AppControllerBase
{
    private readonly IOrdersService _ordersService;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="OrdersController"/>.
    /// </summary>
    public OrdersController(IOrdersService ordersService)
    {
        _ordersService = ordersService;
    }

    /// <summary>
    /// Получение заказов.
    /// </summary>
    /// <returns>Список заказов.</returns>
    /// <response code="200">Список заказов получен.</response>
    /// <response code="401">Пользователь не авторизован.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IEnumerable<Order> GetOrders()
    {
        return _ordersService.GetOrders();
    }

    /// <summary>
    /// Получение заказов.
    /// </summary>
    /// <returns>Список заказов.</returns>
    /// <response code="200">Список заказов получен.</response>
    /// <response code="401">Пользователь не авторизован.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public Order GetOrderById(int id)
    {
        return _ordersService.GetOrderById(id);
    }
}