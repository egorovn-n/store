using Microsoft.AspNetCore.Authentication;

namespace BookStoreApi.Exceptions.Login;

/// <summary>
/// Ошибка входа в систему
/// </summary>
public class LoginException: Exception
{
    private const string LoginExceptionString = "Ошибка при входе в систему. ";

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="LoginException"/>.
    /// </summary>
    public LoginException(string? message) : base(LoginExceptionString + message) { }
}