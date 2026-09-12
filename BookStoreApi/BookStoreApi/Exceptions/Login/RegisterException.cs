namespace BookStoreApi.Exceptions.Login;

/// <summary>
/// Ошибка при регистрации.
/// </summary>
public class RegistrationException: BaseAppException
{
    /// <inheritdoc />
    public override string MessageForLogs { get; } = "Ошибка при регистрации. ";

    /// <summary>
    /// Инициализирует класс <see cref="RegistrationException"/>.
    /// </summary>
    public RegistrationException(string message): base(message) { }
}