namespace BookStoreApi.Constants;

/// <summary>
/// Константы для дискриминатора в модели "Заказ".
/// </summary>
public abstract class OrderDiscriminators
{
    /// <summary>
    /// Строка для обозначения столбца дискриминатора.
    /// </summary>
    public const string Discriminator = "Discriminator";

    /// <summary>
    /// Дискриминатор для обозначения заказа.
    /// </summary>
    public const string Order = "Order";

    /// <summary>
    /// Дискриминатор для обозначения корзины товаров.
    /// </summary>
    public const string Cart = "Cart";
}