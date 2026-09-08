namespace BookStoreApi.Dtos;

/// <summary>
/// Dto фильтра
/// </summary>
public class FilterDto
{
    /// <summary>
    /// Наименование товара
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// Цена от
    /// </summary>
    public double PriceFrom { get; set; }

    /// <summary>
    /// Цена до
    /// </summary>
    public double PriceTo { get; set; }

    /// <summary>
    /// Получать только товары в наличии
    /// </summary>
    public bool OnlyInStock { get; set; }
}