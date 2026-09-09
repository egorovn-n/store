using BookStoreApi.Dtos;
using BookStoreApi.Models;

namespace BookStoreApi.Extensions;

/// <summary>
/// Расширение для маппинга модели "Связь заказа и товара"
/// </summary>
public static class OrderProductMappingExtension
{
    /// <summary>
    /// Маппинг связи заказа и товара в Dto товара с его количеством.
    /// </summary>
    /// <param name="orderProduct">Связь заказа и товара.</param>
    /// <returns>Dto товара с его количеством.</returns>
    public static ProductAndNumberDto MapToProductAndNumberDto(this OrderProduct orderProduct)
    {
        return new ProductAndNumberDto
        {
            Product = orderProduct.Product.MapToFullDto(),
            ProductNumber = orderProduct.ProductsNumber
        };
    }

    /// <summary>
    /// Маппинг связи заказа и товара в Dto товара с его количеством.
    /// </summary>
    /// <param name="orderProduct">Связь заказа и товара.</param>
    /// <param name="purchaseDateTime">Дата и время покупки. Нужно для получения цены, актуальной на время покупки.</param>
    /// <returns>Dto товара с его количеством.</returns>
    public static ProductAndNumberDto MapToProductAndNumberDto(this OrderProduct orderProduct, DateTime purchaseDateTime)
    {
        return new ProductAndNumberDto
        {
            Product = orderProduct.Product.MapToFullDto(purchaseDateTime),
            ProductNumber = orderProduct.ProductsNumber
        };
    }
}