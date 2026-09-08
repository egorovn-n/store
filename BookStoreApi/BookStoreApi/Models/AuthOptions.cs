using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BookStoreApi.Models;

/// <summary>
/// Настройки для аутентификации.
/// </summary>
public static class AuthOptions
{
    /// <summary>
    /// Ключ для шифрования.
    /// </summary>
    private const string Key = "mysupersecret_secretsecretsecretkey!123";

    /// <summary>
    /// Издатель токена.
    /// </summary>
    public const string Issuer = "StoreAuthServer";

    /// <summary>
    /// Потребитель токена.
    /// </summary>
    public const string Audience = "StoreWebClient";

    /// <summary>
    /// Получить ключ безопасности.
    /// </summary>
    /// <returns>Ключ безопасности.</returns>
    public static SymmetricSecurityKey GetSymmetricSecurityKey() => new(Encoding.UTF8.GetBytes(Key));
}