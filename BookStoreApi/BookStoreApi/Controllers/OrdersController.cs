using BookStoreApi.Dtos;
using BookStoreApi.Interfaces;
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
    public IEnumerable<OrderDto> GetOrders()
    {
        CheckIsUserAuthorized(User);
        return _ordersService.GetOrderDtos(User.Identity!.Name!);
    }

    /// <summary>
    /// Получение заказов.
    /// </summary>
    /// <param name="orderId">Идентификатор заказа.</param>
    /// <returns>Список заказов.</returns>
    /// <response code="200">Список заказов получен.</response>
    /// <response code="401">Пользователь не авторизован.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public OrderDto GetOrderById(int orderId)
    {
        CheckIsUserAuthorized(User);
        return _ordersService.GetOrderDtoById(User.Identity!.Name!, orderId);
    }
}