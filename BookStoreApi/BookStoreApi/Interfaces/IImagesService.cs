using BookStoreApi.Dtos;

namespace BookStoreApi.Interfaces;

/// <summary>
/// Интерфейс для сервиса картинок.
/// </summary>
public interface IImagesService
{
    /// <summary>
    /// Получить изображение.
    /// </summary>
    /// <param name="imageGuids">Гуиды картинок.</param>
    /// <returns>Пары гуид-картинка.</returns>
    public IEnumerable<ImageDto> GetImages(IEnumerable<Guid> imageGuids);
}