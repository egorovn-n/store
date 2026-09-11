namespace BookStoreApi.Enums;

/// <summary>
/// Статус заказа
/// </summary>
public enum OrderStatusesEnum
{
    /// <summary>
    /// Не оплачено
    /// </summary>
    NotPaid,

    /// <summary>
    /// Ожидание оплаты
    /// </summary>
    WaitingForPayment,

    /// <summary>
    /// Заказ принят
    /// </summary>
    Accepted,

    /// <summary>
    /// Сборка заказа
    /// </summary>
    Assembly,

    /// <summary>
    /// В пути или Готово к выдаче
    /// </summary>
    OnTheWay,

    /// <summary>
    /// Заказ выполнен
    /// </summary>
    Completed,

    /// <summary>
    /// Заказ отменен
    /// </summary>
    Canceled
}