namespace BookStoreApi.Models;

/// <summary>
/// Товар.
/// </summary>
public class Product
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Количество товаров в наличии.
    /// </summary>
    public int NumberInStock { get; set; }

    /// <summary>
    /// Был ли архивирован товар.
    /// </summary>
    public bool Archived { get; set; }

    /// <summary>
    /// Связь товара и заказа корзины.
    /// </summary>
    public IEnumerable<OrderProduct> OrderProducts { get; set; }

    /// <summary>
    /// Ссылки на картинки товара.
    /// </summary>
    public IEnumerable<ProductImage> ProductImages { get; set; }

    /// <summary>
    /// Изменения цен для товара.
    /// </summary>
    public IEnumerable<ProductPriceChange> ProductPriceChanges { get; set; }
}