using BookStoreApi.Dtos;
using BookStoreApi.Interfaces;

namespace BookStoreApi.Services;

/// <summary>
/// Сервис корзины покупок
/// </summary>
public class CartService: ICartService
{
    /// <inheritdoc />
    public void AddProduct(int productId)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public IEnumerable<ProductFullDto> GetCartItems()
    {
        throw new NotImplementedException();
    }
}