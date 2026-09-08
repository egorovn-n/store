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
    /// Получить изображение.
    /// </summary>
    /// <param name="imageGuids">Гуиды картинок.</param>
    /// <returns>Пары гуид-картинка.</returns>
    /// <response code="200">Картинки получены.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ImageDto> GetImages(IEnumerable<Guid> imageGuids)
    {
        return _imagesService.GetImages(imageGuids);
    }
}