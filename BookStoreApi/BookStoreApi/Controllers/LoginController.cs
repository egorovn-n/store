using BookStoreApi.Dtos;
using BookStoreApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

/// <summary>
/// Контроллер входа в систему.
/// </summary>
public class LoginController: AppControllerBase
{
    private readonly ILoginService _loginService;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="LoginController"/>.
    /// </summary>
    /// <param name="loginService">Сервис входа в систему.</param>
    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    /// <summary>
    /// Вход пользователя в систему.
    /// </summary>
    /// <param name="username">Имя пользователя.</param>
    /// <param name="password">Пароль.</param>
    /// <returns>Dto ответа с jwt токеном и именем пользователя.</returns>
    /// <response code="200">Успешная аутентификация, выслан токен.</response>
    /// <response code="400">Неверное имя пользователя или пароль.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public LoginResponseDto Login(string username, string password)
    {
        var responseDto = _loginService.Login(username, password);
        return responseDto;
    }

    /// <summary>
    /// Регистрация пользователя.
    /// </summary>
    /// <param name="username">Имя пользователя.</param>
    /// <param name="password">Пароль.</param>
    /// <response code="200">Успешная регистрация.</response>
    /// <response code="400">Имя пользователя занято.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void Register(string username, string password)
    {
        _loginService.Register(username, password);
    }
}