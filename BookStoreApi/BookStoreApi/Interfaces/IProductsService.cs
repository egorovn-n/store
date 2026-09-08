using BookStoreApi.Dtos;

namespace BookStoreApi.Interfaces;

/// <summary>
/// Сервис товаров
/// </summary>
public interface IProductsService
{
    /// <summary>
    /// Получить товары по фильтру.
    /// </summary>
    /// <param name="filter">Фильтр.</param>
    /// <returns>Отфильтрованные товары.</returns>
    public IEnumerable<ProductFullDto> GetProducts(FilterDto? filter);
}