using BookStoreApi.Dtos;
using BookStoreApi.Interfaces;
using BookStoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Services;

/// <summary>
/// Сервис картинок
/// </summary>
public class ImagesService: IImagesService
{
    private readonly StoreContext _dbContext;
    private readonly IFileService _fileService;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="ImagesService"/>
    /// </summary>
    public ImagesService(StoreContext dbContext, IFileService fileService)
    {
        _dbContext = dbContext;
        _fileService = fileService;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<FileDto>> GetImagesByProductIdsAsync(IEnumerable<int> productIds)
    {
        var images = _dbContext.Products.AsNoTracking()
            .Include(p => p.ProductImages)
            .Where(p => productIds.Contains(p.Id))
            .SelectMany(p => p.ProductImages)
            .ToList();

        if (images.Count == 0)
        {
            return [];
        }

        var result = await _fileService.GetFilesBytesByGuidsAsync(images.Select(i => i.Guid));

        return result;
    }
}