namespace BookStoreApi.Exceptions;

/// <summary>
/// Базовое исключение приложения.
/// </summary>
public abstract class BaseAppException: Exception
{
    /// <summary>
    /// Статус код ошибки.
    /// </summary>
    public virtual int StatusCode { get; }

    /// <summary>
    /// Сообщение, которое будет видно в логах перед сообщением message.
    /// </summary>
    public virtual string MessageForLogs { get; }

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="BaseAppException"/>.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="statusCode"></param>
    public BaseAppException(string message, int statusCode = StatusCodes.Status400BadRequest)
        : base(message)
    {
        StatusCode = statusCode;
        MessageForLogs = string.Empty;
    }
}