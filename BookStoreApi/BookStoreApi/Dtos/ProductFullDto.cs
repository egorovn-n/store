namespace BookStoreApi.Dtos;

/// <summary>
/// Dto товара со всей информацией
/// </summary>
public class ProductFullDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Ссылки на картинки товара
    /// </summary>
    public IEnumerable<string> ImageUrls { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    public double Price { get; set; }
}