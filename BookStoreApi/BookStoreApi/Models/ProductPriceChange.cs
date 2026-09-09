namespace BookStoreApi.Models;

/// <summary>
/// Изменение цены товара.
/// </summary>
public class ProductPriceChange
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор товара.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Цена.
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Дата и время изменения.
    /// </summary>
    public DateTime ChangeDateTime { get; set; }

    /// <summary>
    /// Товар.
    /// </summary>
    public Product Product { get; set; }
}