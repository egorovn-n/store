using BookStoreApi.Dtos;
using BookStoreApi.Interfaces;

namespace BookStoreApi.Services;

/// <summary>
/// Сервис картинок
/// </summary>
public class ImagesService: IImagesService
{
    /// <inheritdoc />
    public IEnumerable<ImageDto> GetImages(IEnumerable<Guid> imageGuids)
    {
        throw new NotImplementedException();
    }
}