using BookStoreApi.Dtos;
using BookStoreApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

/// <summary>
/// Контроллер товаров.
/// </summary>
public class ProductsController: AppControllerBase
{
    private readonly IProductsService _productsService;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="ProductsController"/>.
    /// </summary>
    public ProductsController(IProductsService productsService)
    {
        _productsService = productsService;
    }

    /// <summary>
    /// Получить товары по фильтру.
    /// </summary>
    /// <param name="filter">Фильтр.</param>
    /// <returns>Отфильтрованные товары.</returns>
    /// <response code="200">Товары получены.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ProductFullDto> GetProducts(FilterDto? filter)
    {
        return _productsService.GetProducts(filter);
    }
}