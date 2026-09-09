using BookStoreApi.Dtos;
using BookStoreApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

/// <summary>
/// Контроллер корзины покупок.
/// </summary>
[Authorize]
public class CartController: AppControllerBase
{
    private readonly ICartService _cartService;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="CartController"/>.
    /// </summary>
    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    /// <summary>
    /// Добавить товар в корзину.
    /// </summary>
    /// <param name="productId">Идентификатор товара.</param>
    /// <response code="201">Товар добавлен в корзину.</response>
    /// <response code="400">Продукт не найден в БД.</response>
    /// <response code="401">Пользователь не авторизован.</response>
    /// <exception cref="UnauthorizedAccessException">Пользователь не авторизован.</exception>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public void AddProduct(int productId)
    {
        CheckIsUserAuthorized(User);
        _cartService.AddProduct(User.Identity!.Name!, productId);
    }

    /// <summary>
    /// Получить все товары в корзине.
    /// </summary>
    /// <returns>Товары в корзины.</returns>
    /// <response code="200">Товары получены.</response>
    /// <response code="401">Пользователь не авторизован.</response>
    /// <exception cref="UnauthorizedAccessException">Пользователь не авторизован.</exception>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IEnumerable<ProductAndNumberDto> GetCartItems()
    {
        CheckIsUserAuthorized(User);
        return _cartService.GetCartItems(User.Identity!.Name!);
    }
}