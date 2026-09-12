namespace BookStoreApi.Exceptions.Login;

/// <summary>
/// Ошибка входа в систему
/// </summary>
public class LoginException: BaseAppException
{
    /// <inheritdoc />
    public override string MessageForLogs { get; } = "Ошибка при входе в систему. ";

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="LoginException"/>.
    /// </summary>
    public LoginException(string? message) : base(message) { }
}