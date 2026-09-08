namespace BookStoreApi.Enums;

/// <summary>
/// Тип заказа
/// </summary>
public enum OrderTypeEnum
{
    /// <summary>
    /// Не выбрано
    /// </summary>
    None,

    /// <summary>
    /// Самовывоз
    /// </summary>
    Pickup,

    /// <summary>
    /// Доставка
    /// </summary>
    Delivery
}