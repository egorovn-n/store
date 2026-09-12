using BookStoreApi.Dtos;

namespace BookStoreApi.Interfaces;

/// <summary>
/// Интерфейс для сервиса корзины покупок
/// </summary>
public interface ICartService
{
    /// <summary>
    /// Добавить товар в корзину пользователя.
    /// </summary>
    /// <param name="email">Почта пользователя.</param>
    /// <param name="productId">Идентификатор товара.</param>
    /// <param name="productsNumber">
    /// Количество добавляемого товара. Если отрицательное число, то товар уменьшается
    /// из корзины на заданное количество.
    /// </param>
    public void AddProduct(string email, int productId, int productsNumber = 1);

    /// <summary>
    /// Установить количество товара в корзине пользователя.
    /// </summary>
    /// <param name="email">Почта пользователя.</param>
    /// <param name="productId">Идентификатор товара.</param>
    /// <param name="productsNumber">Количество товара в корзине, которое будет после изменения.</param>
    public void SetProductNumber(string email, int productId, int productsNumber);

    /// <summary>
    /// Получить все товары в корзине пользователя и их количество.
    /// </summary>
    /// <param name="email">Почта.</param>
    /// <returns>Товары в корзине и их количество.</returns>
    public IEnumerable<ProductAndNumberDto> GetCartItems(string email);
}