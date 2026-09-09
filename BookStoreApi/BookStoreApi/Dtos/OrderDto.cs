using BookStoreApi.Enums;

namespace BookStoreApi.Dtos;

/// <summary>
/// Дто заказа
/// </summary>
public class OrderDto
{
    /// <summary>
    /// Статус заказа.
    /// </summary>
    public OrderStatusEnum OrderStatus { get; set; }

    /// <summary>
    /// Тип заказа.
    /// </summary>
    public OrderTypeEnum OrderType { get; set; }

    /// <summary>
    /// Дата и время заказа.
    /// </summary>
    public DateTime OrderDateTime { get; set; }

    /// <summary>
    /// Итоговая цена
    /// </summary>
    public double TotalPrice { get; set; }

    /// <summary>
    /// Коллекция пар "Продукт-Количество"
    /// </summary>
    public IEnumerable<ProductAndNumberDto> ProductsAndNumbers { get; set; }

    /// <summary>
    /// Рассчитать итоговую цену заказа.
    /// </summary>
    public void CalculateTotalPrice()
    {
        TotalPrice = ProductsAndNumbers.Sum(pn => pn.ProductNumber * pn.Product.Price);
    }
}