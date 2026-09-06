using Microsoft.AspNetCore.Authentication;

namespace BookStoreApi.Exceptions.Login;

/// <summary>
/// Ошибка входа в систему
/// </summary>
public class LoginException: AuthenticationFailureException
{
    private const string LoginExceptionString = "Ошибка при входе в систему. ";

    /// <inheritdoc />
    public LoginException(string? message) : base(LoginExceptionString + message)
    {
    }

    /// <inheritdoc />
    public LoginException(string? message, Exception? innerException) : base(LoginExceptionString + message, innerException)
    {
    }
}