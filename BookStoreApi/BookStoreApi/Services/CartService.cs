using BookStoreApi.Dtos;
using BookStoreApi.Interfaces;
using BookStoreApi.Models;

namespace BookStoreApi.Services;

/// <summary>
/// Сервис корзины покупок
/// </summary>
public class CartService: ICartService
{
    private readonly StoreContext _dbContext;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="CartService"/>
    /// </summary>
    public CartService(StoreContext dbContext)
    {
        _dbContext = dbContext;
    }

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