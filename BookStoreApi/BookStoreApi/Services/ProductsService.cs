using BookStoreApi.Dtos;
using BookStoreApi.Interfaces;
using BookStoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Services;

/// <summary>
/// Сервис товаров
/// </summary>
public class ProductsService: IProductsService
{
    private readonly StoreContext _dbContext;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="ProductsService"/>
    /// </summary>
    public ProductsService(StoreContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public IEnumerable<ProductFullDto> GetProducts(FilterDto? filter)
    {
        var products = _dbContext.Products.AsNoTracking()
            .Include(p => p.ProductImages)
            .Include(p => p.ProductPriceChanges).AsQueryable();

        if (filter != null)
        {
            if (!string.IsNullOrWhiteSpace(filter.ProductName))
            {
                products = products.Where(p => p.Name.Contains(filter.ProductName));
            }
            if (filter.PriceFrom != null)
            {
                products = products
                    .Select(p => new
                    {
                        Product = p,
                        LastPrice = p.ProductPriceChanges
                            .OrderByDescending(pc => pc.ChangeDateTime)
                            .Select(pc => pc.Price)
                            .FirstOrDefault()
                    })
                    .Where(x => x.LastPrice >= filter.PriceFrom)
                    .Select(x => x.Product);
            }
            if (filter.PriceTo != null)
            {
                products = products
                    .Select(p => new
                    {
                        Product = p,
                        LastPrice = p.ProductPriceChanges
                            .OrderByDescending(pc => pc.ChangeDateTime)
                            .Select(pc => pc.Price)
                            .FirstOrDefault()
                    })
                    .Where(x => x.LastPrice <= filter.PriceTo)
                    .Select(x => x.Product);
            }
            if (filter.OnlyInStock == null || filter.OnlyInStock.Value)
            {
                products = products.Where(p => !p.Archived && p.NumberInStock > 0);
            }
        }

        var result = products
            .Select(p => new
            {
                Product = p,
                LastPrice = p.ProductPriceChanges
                    .OrderByDescending(pc => pc.ChangeDateTime)
                    .Select(pc => pc.Price)
                    .FirstOrDefault()
            })
            .Select(p => new ProductFullDto
            {
                Id = p.Product.Id,
                Name = p.Product.Name,
                ImageGuids = p.Product.ProductImages.Select(i => i.Guid),
                Price = p.LastPrice
            }).ToList();

        return result;
    }
}