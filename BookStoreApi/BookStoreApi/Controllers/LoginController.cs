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
    /// <param name="loginRequestDto">Почта и пароль пользователя.</param>
    /// <returns>Dto ответа с jwt токеном и именем пользователя.</returns>
    /// <response code="200">Успешная аутентификация, выслан токен.</response>
    /// <response code="400">Неверная почта или пароль.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public LoginResponseDto Login(LoginRequestDto loginRequestDto)
    {
        var responseDto = _loginService.Login(loginRequestDto.Email, loginRequestDto.Password);
        return responseDto;
    }

    /// <summary>
    /// Регистрация пользователя.
    /// </summary>
    /// <param name="loginRequestDto">Почта и пароль пользователя.</param>
    /// <response code="200">Успешная регистрация.</response>
    /// <response code="400">Почта уже зарегистрирована.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void Register(LoginRequestDto loginRequestDto)
    {
        _loginService.Register(loginRequestDto.Email, loginRequestDto.Password);
    }
}