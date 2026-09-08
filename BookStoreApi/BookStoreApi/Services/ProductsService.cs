using BookStoreApi.Dtos;
using BookStoreApi.Interfaces;

namespace BookStoreApi.Services;

/// <summary>
/// Сервис товаров
/// </summary>
public class ProductsService: IProductsService
{
    /// <inheritdoc />
    public IEnumerable<ProductFullDto> GetProducts(FilterDto? filter)
    {
        throw new NotImplementedException();
    }
}