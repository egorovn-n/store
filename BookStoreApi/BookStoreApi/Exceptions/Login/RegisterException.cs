namespace BookStoreApi.Exceptions.Login;

/// <summary>
/// Ошибка при регистрации
/// </summary>
public class RegistrationException: Exception
{
    private const string RegistrationExceptionString = "Ошибка при регистрации. ";

    /// <summary>
    /// Инициализирует класс <see cref="RegistrationException"/>
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    public RegistrationException(string message): base(RegistrationExceptionString + message) { }
}