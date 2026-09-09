using BookStoreApi.Dtos;
using BookStoreApi.Models;

namespace BookStoreApi.Extensions;

/// <summary>
/// Расширения с маппингом модели товара в Dto.
/// </summary>
public static class ProductMappingExtension
{
    /// <summary>
    /// Маппинг товара в полное Dto.
    /// </summary>
    /// <param name="product">Товар.</param>
    /// <returns>Полное Dto товара.</returns>
    public static ProductFullDto MapToFullDto(this Product product)
    {
        return new ProductFullDto
        {
            Id = product.Id,
            Name = product.Name,
            ImageGuids = product.ProductImages.Select(i => i.Guid),
            Price = product.ProductPriceChanges
                .OrderByDescending(pc => pc.ChangeDateTime)
                .Select(pc => pc.Price)
                .FirstOrDefault()
        };
    }

    /// <summary>
    /// Маппинг товара в полное Dto.
    /// </summary>
    /// <param name="product">Товар.</param>
    /// <param name="purchaseDateTime">Дата и время покупки. Нужно для получения цены, актуальной на время покупки.</param>
    /// <returns>Полное Dto товара.</returns>
    public static ProductFullDto MapToFullDto(this Product product, DateTime purchaseDateTime)
    {
        return new ProductFullDto
        {
            Id = product.Id,
            Name = product.Name,
            ImageGuids = product.ProductImages.Select(i => i.Guid),
            Price = product.ProductPriceChanges
                .Where(pc => pc.ChangeDateTime <= purchaseDateTime)
                .OrderByDescending(pc => pc.ChangeDateTime)
                .Select(pc => pc.Price)
                .FirstOrDefault()
        };
    }
}