namespace BookStoreApi.Exceptions.Login;

/// <summary>
/// Ошибка при регистрации.
/// </summary>
public class RegistrationException: Exception
{
    private const string RegistrationExceptionString = "Ошибка при регистрации. ";

    /// <summary>
    /// Инициализирует класс <see cref="RegistrationException"/>.
    /// </summary>
    public RegistrationException(string message): base(RegistrationExceptionString + message) { }
}