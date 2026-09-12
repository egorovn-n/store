using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Exceptions;

/// <summary>
/// Обработчик кастомных ошибок приложения.
/// </summary>
public class AppExceptionHandler : IExceptionHandler
{
    private readonly ILogger<AppExceptionHandler> _logger;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="AppExceptionHandler"/>.
    /// </summary>
    /// <param name="logger"></param>
    public AppExceptionHandler(ILogger<AppExceptionHandler> logger)
    {
        _logger = logger;
    }

    /// <inheritdoc />
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        // Обрабатываем только кастомные исключения.
        if (exception is not BaseAppException appEx)
        {
            return false;
        }

        _logger.LogWarning(appEx, appEx.MessageForLogs + appEx.Message, appEx.Message);

        var problemDetails = new ProblemDetails
        {
            Status = appEx.StatusCode,
            Title = appEx.Message,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
        };

        httpContext.Response.StatusCode = appEx.StatusCode;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}