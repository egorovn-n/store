namespace BookStoreApi.Exceptions;

/// <summary>
/// Исключение "Корзина не найдена".
/// </summary>
public class CartNotFoundException: Exception
{
    private const string CartNotFoundExceptionString = "Корзина пользователя {0} не найдена.";

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="CartNotFoundException"/>.
    /// </summary>
    public CartNotFoundException(string username) : base(string.Format(CartNotFoundExceptionString, username)) { }
}