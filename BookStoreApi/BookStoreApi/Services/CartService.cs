using BookStoreApi.Constants;
using BookStoreApi.Dtos;
using BookStoreApi.Exceptions;
using BookStoreApi.Extensions;
using BookStoreApi.Interfaces;
using BookStoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Services;

/// <summary>
/// Сервис корзины покупок
/// </summary>
public class CartService: ICartService
{
    private readonly StoreContext _dbContext;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="CartService"/>
    /// </summary>
    public CartService(StoreContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public void AddProduct(string username, int productId, int productsNumber = 1)
    {
        if (productsNumber == 0)
        {
            return;
        }

        var cart = GetCartByUsername(username) ?? GetCartByUsername(username);

        if (cart == null)
        {
            throw new CartNotFoundException(username);
        }

        if (cart.OrderProducts.Any(op => op.ProductId == productId))
        {
            var foundOp = cart.OrderProducts.First(op => op.ProductId == productId);
            var resultProductsNumber = foundOp.ProductsNumber + productsNumber;
            if (resultProductsNumber < 1)
            {
                _dbContext.OrderProducts.Remove(foundOp);
            }
            else
            {
                _dbContext.OrderProducts
                    .First(op => op.OrderId == foundOp.OrderId && op.ProductId == foundOp.ProductId)
                    .ProductsNumber = resultProductsNumber;
            }
        }
        else
        {
            if (productsNumber < 1)
            {
                return;
            }

            var newOp = new OrderProduct
            {
                OrderId = cart.Id,
                ProductId = productId,
                ProductsNumber = productsNumber
            };

            _dbContext.OrderProducts.Add(newOp);
        }

        _dbContext.SaveChanges();
    }

    /// <inheritdoc />
    public void SetProductNumber(string username, int productId, int productsNumber)
    {
        if (productsNumber < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(productsNumber));
        }

        var cart = GetCartByUsername(username) ?? GetCartByUsername(username);

        if (cart == null)
        {
            throw new CartNotFoundException(username);
        }

        if (cart.OrderProducts.Any(op => op.ProductId == productId))
        {
            var foundOp = cart.OrderProducts.First(op => op.ProductId == productId);
            _dbContext.OrderProducts
                .First(op => op.OrderId == foundOp.OrderId && op.ProductId == foundOp.ProductId)
                .ProductsNumber = productsNumber;
        }
        else
        {
            var newOp = new OrderProduct
            {
                OrderId = cart.Id,
                ProductId = productId,
                ProductsNumber = productsNumber
            };

            _dbContext.OrderProducts.Add(newOp);
        }

        _dbContext.SaveChanges();
    }

    /// <inheritdoc />
    public IEnumerable<ProductAndNumberDto> GetCartItems(string username)
    {
        var cart = _dbContext.Carts.AsNoTracking()
            .Include(c => c.User)
            .Include(c => c.OrderProducts)
                .ThenInclude(op => op.Product)
                    .ThenInclude(p => p.ProductPriceChanges)
            .Include(c => c.OrderProducts)
                .ThenInclude(op => op.Product)
                    .ThenInclude(p => p.ProductImages)
            .SingleOrDefault(c => c.User.Name == username && c.Discriminator == OrderDiscriminators.Cart);

        if (cart == null)
        {
            throw new CartNotFoundException(username);
        }

        var products = cart.OrderProducts.Select(op => op.MapToProductAndNumberDto()).ToList();

        return products;
    }

    /// <summary>
    /// Получить корзину товаров включая пользователя и связь с идентификаторами товаров по имени пользователя.
    /// </summary>
    /// <param name="username">Имя пользователя.</param>
    /// <returns>Корзина товаров или null.</returns>
    private Cart? GetCartByUsername(string username)
    {
        var cart = _dbContext.Carts.AsNoTracking()
            .Include(c => c.User)
            .Include(c => c.OrderProducts)
            .SingleOrDefault(c => c.User.Name == username && c.Discriminator == OrderDiscriminators.Cart);

        return cart;
    }
}