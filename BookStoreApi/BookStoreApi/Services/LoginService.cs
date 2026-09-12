using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BookStoreApi.Dtos;
using BookStoreApi.Enums;
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
    public LoginResponseDto Login(string email, string password)
    {
        var user = GetUserByEmail(email);
        if (user == null)
        {
            throw new LoginException($"Пользователя с почтой {email} не существует в БД.");
        }

        if (user.Password != password)
        {
            _logger.LogWarning($"Неудачная попытка входа в профиль {email}.");
            throw new LoginException($"Введен неправильный пароль.");
        }

        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.Issuer,
            audience: AuthOptions.Audience,
            claims: [
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            ],
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        if (encodedJwt == null)
        {
            _logger.LogWarning($"Создан пустой jwt токен при попытке входа в профиль {email}.");
            throw new LoginException($"Ошибка при создании jwt токена.");
        }

        _logger.LogInformation($"Успешный вход в профиль {email}.");
        return new LoginResponseDto
        {
            AccessToken = encodedJwt,
            Email = email,
            Role = user.Role
        };
    }

    /// <inheritdoc />
    public void Register(string email, string password)
    {
        var user = GetUserByEmail(email);
        if (user != null)
        {
            _logger.LogInformation($"Попытка регистрации на уже зарегистрированную почту {email}");
            throw new RegistrationException($"Почта \"{email}\" уже зарегистрирована.");
        }

        _dbContext.Users.Add(new User
        {
            Email = email,
            Password = password,
            Role = RolesEnum.User
        });
        _dbContext.SaveChanges();
        _logger.LogInformation($"Произведена регистрация пользователя {email}");
    }

    /// <summary>
    /// Получить пользователя по почте.
    /// </summary>
    /// <param name="email">Почта пользователя.</param>
    /// <returns>Пользователь или null.</returns>
    private User? GetUserByEmail(string email)
    {
        return _dbContext.Users.AsNoTracking().FirstOrDefault(u => u.Email == email);
    }
    // TODO: сделать логаут
}