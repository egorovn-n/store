using BookStoreApi.Dtos;

namespace BookStoreApi.Interfaces;

/// <summary>
/// Интерфейс для сервиса корзины покупок
/// </summary>
public interface ICartService
{
    /// <summary>
    /// Добавить товар в корзину.
    /// </summary>
    /// <param name="productId">Идентификатор товара</param>
    public void AddProduct(int productId);

    /// <summary>
    /// Получить все товары в корзине
    /// </summary>
    /// <returns>Товары в корзины</returns>
    public IEnumerable<ProductFullDto> GetCartItems();
}