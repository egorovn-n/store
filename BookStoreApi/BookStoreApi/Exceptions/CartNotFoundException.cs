namespace BookStoreApi.Exceptions;

/// <summary>
/// Исключение "Корзина не найдена".
/// </summary>
public class CartNotFoundException: BaseAppException
{
    /// <inheritdoc />
    public override int StatusCode { get; } = StatusCodes.Status404NotFound;

    private const string CartNotFoundExceptionString = "Корзина пользователя {0} не найдена.";

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="CartNotFoundException"/>.
    /// </summary>
    public CartNotFoundException(string email) : base(string.Format(CartNotFoundExceptionString, email)) { }
}