using BookStoreApi.Enums;

namespace BookStoreApi.Interfaces;

/// <summary>
/// Интерфейс для сервиса картинок.
/// </summary>
public interface IImagesService
{
    /// <summary>
    /// Получить изображение.
    /// </summary>
    /// <param name="guid">Гуид картинки.</param>
    /// <param name="imageVariant">Запрашиваемый вариант картинки.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Пара гуид-картинка.</returns>
    public Task<byte[]> GetImageAsync(Guid guid, ImageVariantsEnum imageVariant, CancellationToken cancellationToken);

    /// <summary>
    /// Получить ContentType в зависимости от выбранного варианта картинки.
    /// </summary>
    /// <param name="imageVariant">Вариант картинки.</param>
    /// <returns>ContentType для указанного типа картинки.</returns>
    public string GetContentTypeByImageVariant(ImageVariantsEnum imageVariant);

    /// <summary>
    /// Получить имя файла с расширением по указанному варианту.
    /// </summary>
    /// <param name="imageVariant">Вариант картинки.</param>
    /// <returns>Имя файла.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Неизвестный вариант.</exception>
    public string GetFileNameWithExtensionByImageVariant(ImageVariantsEnum imageVariant);
}