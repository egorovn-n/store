using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BookStoreApi.Dtos;
using BookStoreApi.Exceptions.Login;
using BookStoreApi.Interfaces;
using BookStoreApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BookStoreApi.Services;

/// <summary>
/// Сервис входа в систему
/// </summary>
public class LoginService: ILoginService
{
    private readonly StoreContext _dbContext;
    private readonly ILogger<LoginService> _logger;

    /// <summary>
    /// Инициализирует класс <see cref="LoginService"/>
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    /// <param name="logger">Класс для логирования</param>
    public LoginService(StoreContext dbContext, ILogger<LoginService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    /// <inheritdoc />
    public LoginResponseDto Login(string username, string password)
    {
        if (!CheckUserExists(username))
        {
            throw new LoginException($"Пользователя с именем {username} не существует в БД.");
        }

        if (!CheckPassword(username, password))
        {
            _logger.LogWarning($"Неудачная попытка входа в профиль {username}.");
            throw new LoginException($"Введен неправильный пароль.");
        }

        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.Issuer,
            audience: AuthOptions.Audience,
            claims: [
                new Claim(ClaimTypes.Name, username)
            ],
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        if (encodedJwt == null)
        {
            _logger.LogWarning($"Создан пустой jwt токен при попытке входа в профиль {username}.");
            throw new LoginException($"Ошибка при создании jwt токена.");
        }

        _logger.LogInformation($"Успешный вход в профиль {username}.");
        return new LoginResponseDto
        {
            AccessToken = encodedJwt,
            Username = username
        };
    }

    /// <inheritdoc />
    public void Register(string username, string password)
    {
        if (CheckUserExists(username))
        {
            _logger.LogInformation($"Попытка регистрации на существующее имя пользователя {username}");
            throw new RegistrationException($"Имя пользователя \"{username}\" уже занято.");
        }

        _dbContext.Users.Add(new User
        {
            Name = username,
            Password = password
        });
        _dbContext.SaveChanges();
        _logger.LogInformation($"Произведена регистрация пользователя {username}");
    }

    /// <summary>
    /// Проверка на то, что пользователь уже существует в БД
    /// </summary>
    /// <param name="username">Имя пользователя</param>
    /// <returns>True, если существует</returns>
    private bool CheckUserExists(string username)
    {
        return _dbContext.Users.AsNoTracking().Any(u => u.Name == username);
    }

    /// <summary>
    /// Проверка пароля для пользователя
    /// </summary>
    /// <param name="username">Имя пользователя</param>
    /// <param name="password">Пароль</param>
    /// <returns>True, если пароль подходит к имени пользователя</returns>
    private bool CheckPassword(string username, string password)
    {
        return _dbContext.Users.AsNoTracking().Any(u => u.Name == username && u.Password == password);
    }
    // TODO: сделать логаут
}