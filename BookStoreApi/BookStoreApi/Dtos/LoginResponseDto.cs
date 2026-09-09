using System.Text.Json.Serialization;

namespace BookStoreApi.Dtos;

/// <summary>
/// Dto для ответа на вход в профиль.
/// </summary>
public class LoginResponseDto
{
    /// <summary>
    /// Jwt токен доступа
    /// </summary>
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    [JsonPropertyName("username")]
    public string Username { get; set; }
}