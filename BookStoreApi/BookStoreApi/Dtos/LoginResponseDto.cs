using BookStoreApi.Enums;

namespace BookStoreApi.Dtos;

/// <summary>
/// Dto для ответа на вход в профиль.
/// </summary>
public class LoginResponseDto
{
    /// <summary>
    /// Jwt токен доступа.
    /// </summary>
    public string AccessToken { get; set; }

    /// <summary>
    /// Почта пользователя.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Роль пользователя.
    /// </summary>
    public RolesEnum Role { get; set; }
}