using BookStoreApi.Enums;
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
    /// <param name="guid">Гуид картинки.</param>
    /// <param name="imageVariant">Запрашиваемый вариант картинки.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Файл картинки.</returns>
    /// <response code="200">Картинка получена.</response>
    /// <response code="400">Картинка не найдена.</response>
    [HttpGet]
    [Route("{guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetImageAsync([FromRoute] Guid guid,
        [FromQuery] ImageVariantsEnum imageVariant = ImageVariantsEnum.Original,
        CancellationToken cancellationToken = default)
    {
        var fileBytes = await _imagesService.GetImageAsync(guid, imageVariant, cancellationToken);

        return File(fileBytes.ToArray(), _imagesService.GetContentTypeByImageVariant(imageVariant),
            $"{guid.ToString()}_{_imagesService.GetFileNameWithExtensionByImageVariant(imageVariant)}");
    }
}