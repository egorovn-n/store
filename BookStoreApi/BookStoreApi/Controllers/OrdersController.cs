using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

/// <summary>
/// Контроллер заказов
/// </summary>
[Authorize]
public class OrdersController: AppControllerBase
{
    private readonly ILogger<OrdersController> _logger;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="OrdersController"/>
    /// </summary>
    /// <param name="logger">Класс для логирования.</param>
    public OrdersController(ILogger<OrdersController> logger)
    {
        _logger = logger;
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
    public IEnumerable<string> GetOrders()
    {
        _logger.LogInformation("Заказы получены");
        return ["one", "two", "three"];
    }
}