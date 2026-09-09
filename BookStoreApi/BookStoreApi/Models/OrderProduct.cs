namespace BookStoreApi.Models;

/// <summary>
/// Таблица для связи "Корзины - Товары". Или "Заказы - Товары",
/// т.к. используется подход TPH для наследования "заказов" от "корзины".
/// </summary>
public class OrderProduct
{
    /// <summary>
    /// Идентификатор корзины.
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// Идентификатор товара.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Количество товаров этого типа.
    /// </summary>
    public int ProductsNumber { get; set; }

    /// <summary>
    /// Корзина (или заказ).
    /// </summary>
    public Cart Order { get; set; }

    /// <summary>
    /// Товар.
    /// </summary>
    public Product Product { get; set; }
}