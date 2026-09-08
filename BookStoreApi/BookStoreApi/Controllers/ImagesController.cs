using BookStoreApi.Dtos;
using BookStoreApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

/// <summary>
/// Контроллер картинок.
/// </summary>
public class ImagesController: AppControllerBase
{
    private readonly IImagesService _imagesService;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="ImagesController"/>.
    /// </summary>
    public ImagesController(IImagesService imagesService)
    {
        _imagesService = imagesService;
    }

    /// <summary>
    /// Получить изображение по идентификаторам товаров.
    /// </summary>
    /// <param name="productIds">Идентификаторы товаров.</param>
    /// <returns>Пары гуид-картинка.</returns>
    /// <response code="200">Картинки получены.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<FileDto>> GetImagesByProductIds(IEnumerable<int> productIds)
    {
        return await _imagesService.GetImagesByProductIdsAsync(productIds);
    }
}