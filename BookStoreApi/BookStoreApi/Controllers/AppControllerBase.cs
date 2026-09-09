using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

/// <summary>
/// Базовый контроллер, от которого должны наследовать все остальные контроллеры в приложении
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public class AppControllerBase : ControllerBase
{
    /// <summary>
    /// Проверка, авторизован ли пользователь. Если нет, то будет выброшена ошибка.
    /// </summary>
    /// <exception cref="UnauthorizedAccessException">Пользователь не авторизован.</exception>
    protected void CheckIsUserAuthorized(ClaimsPrincipal? claimsPrincipal)
    {
        if (!(claimsPrincipal?.Identity?.IsAuthenticated ?? false))
        {
            throw new UnauthorizedAccessException();
        }
    }
}