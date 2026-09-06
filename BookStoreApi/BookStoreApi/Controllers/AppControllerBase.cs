using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

/// <summary>
/// Базовый контроллер, от которого должны наследовать все остальные контроллеры в приложении
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public class AppControllerBase: ControllerBase { }