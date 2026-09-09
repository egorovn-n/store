namespace BookStoreApi.Dtos;

/// <summary>
/// Dto для отправки товара и его количества.
/// </summary>
public class ProductAndNumberDto
{
    /// <summary>
    /// Товар.
    /// </summary>
    public ProductFullDto Product { get; set; }

    /// <summary>
    /// Количество товара.
    /// </summary>
    public int ProductNumber { get; set; }
}