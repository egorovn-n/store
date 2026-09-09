namespace BookStoreApi.Models;

/// <summary>
/// Картинка товара.
/// </summary>
public class ProductImage
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Гуид картинки.
    /// </summary>
    public Guid Guid { get; set; }

    /// <summary>
    /// Товары.
    /// </summary>
    public IEnumerable<Product> Products { get; set; }
}