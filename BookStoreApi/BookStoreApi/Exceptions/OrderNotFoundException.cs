namespace BookStoreApi.Exceptions;

/// <summary>
/// Исключение "Заказ не найден"
/// </summary>
public class OrderNotFoundException: Exception
{
    private const string OrderNotFoundExceptionString = "Заказ с идентификатором {0} не найден.";

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="OrderNotFoundException"/>.
    /// </summary>
    public OrderNotFoundException(int id) : base(string.Format(OrderNotFoundExceptionString, id)) { }
}