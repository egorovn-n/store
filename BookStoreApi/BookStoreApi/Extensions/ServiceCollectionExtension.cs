using BookStoreApi.Interfaces;
using BookStoreApi.Models;
using BookStoreApi.Services;

namespace BookStoreApi.Extensions;

using Microsoft.EntityFrameworkCore;

/// <summary>
/// Расширение для коллекции сервисов.
/// </summary>
public static class ServiceCollectionExtension
{
    /// <summary>
    /// Добавить сервисы, необходимые для приложения.
    /// </summary>
    /// <param name="services">Сервисы builder.Services.</param>
    /// <param name="configuration">Конфигурация.</param>
    public static void AddStoreServices(this IServiceCollection services,  IConfiguration configuration)
    {
        services.AddDbContext<StoreContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(StoreContext.PostgreSqlString));
        });
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<IOrdersService, OrdersService>();
        services.AddScoped<IProductsService, ProductsService>();
        services.AddScoped<IFileService, FileService>();
    }
}