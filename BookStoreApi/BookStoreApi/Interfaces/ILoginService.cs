using BookStoreApi.Dtos;
using BookStoreApi.Exceptions.Login;

namespace BookStoreApi.Interfaces;

/// <summary>
/// Сервис для входа пользователя в приложение.
/// </summary>
public interface ILoginService
{
    /// <summary>
    /// Вход пользователя.
    /// </summary>
    /// <param name="email">Почта пользователя.</param>
    /// <param name="password">Пароль.</param>
    /// <returns>Dto ответа с jwt токеном и именем пользователя.</returns>
    /// <exception cref="LoginException">Ошибка входа в систему.</exception>
    public LoginResponseDto Login(string email, string password);

    /// <summary>
    /// Регистрация пользователя в приложение.
    /// </summary>
    /// <param name="email">Почта пользователя.</param>
    /// <param name="password">Пароль.</param>
    /// <exception cref="RegistrationException">Почта уже зарегистрирована.</exception>
    public void Register(string email, string password);
}