using BookStoreApi.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Models;

/// <inheritdoc />
public sealed class StoreContext : DbContext
{
    /// <summary>
    /// Строка для поиска подключения к Postgre в ConnectionStrings.
    /// </summary>
    public const string PostgreSqlString = "PostgreSQL";

    /// <summary>
    /// Таблица "Пользователи".
    /// </summary>
    public DbSet<User> Users { get; set; } = null!;

    /// <summary>
    /// Таблица "Товары".
    /// </summary>
    public DbSet<Product> Products { get; set; } = null!;

    /// <summary>
    /// Таблица "Заказы".
    /// </summary>
    public DbSet<Order> Orders { get; set; } = null!;

    /// <summary>
    /// Таблица "Изменения цен товаров".
    /// </summary>
    public DbSet<ProductPriceChange> ProductPriceChanges { get; set; } = null!;

    /// <summary>
    /// Таблица "Корзины товаров".
    /// </summary>
    public DbSet<Cart> Carts { get; set; } = null!;

    /// <summary>
    /// Таблица "Картинки товаров".
    /// </summary>
    public DbSet<ProductImage> ProductImages { get; set; } = null!;

    /// <summary>
    /// Таблица для связи "Заказ-Товар".
    /// </summary>
    public DbSet<OrderProduct> OrderProducts { get; set; } = null!;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="StoreContext"/>.
    /// </summary>
    public StoreContext (DbContextOptions<StoreContext> options) : base(options) { }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройка составного первичного ключа для OrderProducts
        modelBuilder.Entity<OrderProduct>()
            .HasKey(cp => new { cp.OrderId, cp.ProductId });

        modelBuilder
            .Entity<User>()
            .Property(e => e.Role)
            .HasConversion<string>();

        modelBuilder
            .Entity<Order>()
            .Property(e => e.OrderStatuses)
            .HasConversion<string>();

        modelBuilder
            .Entity<Order>()
            .Property(e => e.OrderTypes)
            .HasConversion<string>();
    
        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// Добавить данные в БД по умолчанию для тестирования.
    /// </summary>
    public static void SeedData(StoreContext dbContext)
    {
        var user = new User
        {
            Email = "qwe",
            Password = "qwe",
            Role = RolesEnum.User
        };
        var admin = new User
        {
            Email = "admin",
            Password = "admin",
            Role = RolesEnum.Admin
        };
        dbContext.Users.AddRange(user, admin);

        var defaultImage = new ProductImage
        {
            Guid = Guid.Empty
        };
        dbContext.ProductImages.Add(defaultImage);

        var product1 = new Product
        {
            Name = "Картошка",
            NumberInStock = 100,
            Archived = false,
            ProductImages = [defaultImage],
            ProductPriceChanges = [new ProductPriceChange
                {
                    Price = 100,
                    ChangeDateTime = DateTime.UtcNow.AddDays(-1),
                }, new ProductPriceChange
                {
                    Price = 90,
                    ChangeDateTime = DateTime.UtcNow,
                }
            ]
        };
        var product2 = new Product
        {
            Name = "огурец",
            NumberInStock = 100,
            Archived = false,
            ProductImages = [defaultImage],
            ProductPriceChanges = [new ProductPriceChange
                {
                    Price = 80,
                    ChangeDateTime = DateTime.UtcNow.AddDays(-1),
                }
            ]
        };
        var product3 = new Product
        {
            Name = "колбаса",
            NumberInStock = 100,
            Archived = false,
            ProductImages = [defaultImage],
            ProductPriceChanges = [new ProductPriceChange
                {
                    Price = 50,
                    ChangeDateTime = DateTime.UtcNow.AddDays(-1),
                }
            ]
        };
        var product4 = new Product
        {
            Name = "квас",
            NumberInStock = 100,
            Archived = false,
            ProductImages = [defaultImage],
            ProductPriceChanges = [new ProductPriceChange
                {
                    Price = 30,
                    ChangeDateTime = DateTime.UtcNow.AddDays(-1),
                }, new ProductPriceChange
                {
                    Price = 90,
                    ChangeDateTime = DateTime.UtcNow,
                }
            ]
        };
        var product5 = new Product
        {
            Name = "яйца",
            NumberInStock = 100,
            Archived = false,
            ProductImages = [defaultImage],
            ProductPriceChanges = [new ProductPriceChange
                {
                    Price = 1100,
                    ChangeDateTime = DateTime.UtcNow.AddDays(-1),
                }, new ProductPriceChange
                {
                    Price = 190,
                    ChangeDateTime = DateTime.UtcNow,
                }
            ]
        };
        var product6 = new Product
        {
            Name = "майонез",
            NumberInStock = 100,
            Archived = false,
            ProductImages = [defaultImage],
            ProductPriceChanges = [new ProductPriceChange
                {
                    Price = 80,
                    ChangeDateTime = DateTime.UtcNow.AddDays(-1),
                }, new ProductPriceChange
                {
                    Price = 81,
                    ChangeDateTime = DateTime.UtcNow,
                }
            ]
        };
        var product7 = new Product
        {
            Name = "морковь",
            NumberInStock = 100,
            Archived = false,
            ProductImages = [defaultImage],
            ProductPriceChanges = [new ProductPriceChange
                {
                    Price = 40,
                    ChangeDateTime = DateTime.UtcNow.AddDays(-1),
                }
            ]
        };
        var product8 = new Product
        {
            Name = "лук",
            NumberInStock = 100,
            Archived = false,
            ProductImages = [defaultImage],
            ProductPriceChanges = [new ProductPriceChange
                {
                    Price = 20,
                    ChangeDateTime = DateTime.UtcNow.AddDays(-1),
                }
            ]
        };
        var product9 = new Product
        {
            Name = "свёкла",
            NumberInStock = 100,
            Archived = false,
            ProductImages = [defaultImage],
            ProductPriceChanges = [new ProductPriceChange
                {
                    Price = 55,
                    ChangeDateTime = DateTime.UtcNow.AddDays(-1),
                }
            ]
        };
        var product10 = new Product
        {
            Name = "чеснок",
            NumberInStock = 100,
            Archived = true,
            ProductImages = [defaultImage],
            ProductPriceChanges = [new ProductPriceChange
                {
                    Price = 111,
                    ChangeDateTime = DateTime.UtcNow.AddDays(-1),
                }
            ]
        };
        dbContext.Products.AddRange(product1, product2, product3, product4, product5, product6, product7, product8,
            product9, product10);

        dbContext.Carts.AddRange(new Cart
        {
            User = user
        }, new Cart
        {
            User = admin
        });

        dbContext.Orders.AddRange(new Order
            {
                OrderStatuses = OrderStatusesEnum.NotPaid,
                OrderTypes = OrderTypesEnum.Delivery,
                OrderDateTime = DateTime.UtcNow,
                OrderProducts = [new OrderProduct
                    {
                        ProductsNumber = 1,
                        Product = product1
                    }
                ],
                User = user
            }, new Order
            {
                OrderStatuses = OrderStatusesEnum.Canceled,
                OrderTypes = OrderTypesEnum.Pickup,
                OrderDateTime = DateTime.UtcNow,
                OrderProducts = [new OrderProduct
                    {
                        ProductsNumber = 1,
                        Product = product1
                    }
                ],
                User = user
            }, new Order
            {
                OrderStatuses = OrderStatusesEnum.Canceled,
                OrderTypes = OrderTypesEnum.Delivery,
                OrderDateTime = DateTime.UtcNow,
                OrderProducts = [new OrderProduct
                    {
                        ProductsNumber = 1,
                        Product = product1
                    }
                ],
                User = user
            }
        );

        dbContext.SaveChanges();
    }
}