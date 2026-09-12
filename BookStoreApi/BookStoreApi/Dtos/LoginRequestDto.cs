namespace BookStoreApi.Dtos;

/// <summary>
/// Dto запроса логина.
/// </summary>
public class LoginRequestDto
{
    /// <summary>
    /// Почта пользователя.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; }
}