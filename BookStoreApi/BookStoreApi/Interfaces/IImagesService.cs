using BookStoreApi.Dtos;

namespace BookStoreApi.Interfaces;

/// <summary>
/// Интерфейс для сервиса картинок.
/// </summary>
public interface IImagesService
{
    /// <summary>
    /// Получить изображение по идентификаторам товаров.
    /// </summary>
    /// <param name="productIds">Идентификаторы товаров.</param>
    /// <returns>Пары гуид-картинка.</returns>
    public Task<IEnumerable<FileDto>> GetImagesByProductIdsAsync(IEnumerable<int> productIds);
}