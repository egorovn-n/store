using BookStoreApi.Enums;
using BookStoreApi.Interfaces;

namespace BookStoreApi.Services;

/// <summary>
/// Сервис картинок
/// </summary>
public class ImagesService: IImagesService
{
    private readonly IFileService _fileService;

    private const string ImagesDirectoryString = "Images";
    private const string UploadedDirectoryString = "Uploaded";

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="ImagesService"/>
    /// </summary>
    public ImagesService(IFileService fileService)
    {
        _fileService = fileService;
    }

    /// <inheritdoc />
    public async Task<byte[]> GetImageAsync(Guid guid, ImageVariantsEnum imageVariant,
        CancellationToken cancellationToken = default)
    {
        var fileName = GetFileNameWithExtensionByImageVariant(imageVariant);
        var path = Path.Combine(
            Directory.GetCurrentDirectory(),
            ImagesDirectoryString,
            UploadedDirectoryString,
            guid.ToString(),
            fileName);
        var result = await _fileService.GetFileBytesByGuidAsync(path, cancellationToken);

        return result;
    }

    /// <inheritdoc />
    public string GetContentTypeByImageVariant(ImageVariantsEnum imageVariant)
    {
        return imageVariant switch
        {
            ImageVariantsEnum.Original => "image/jpeg",
            _ => "image/webp"
        };
    }

    /// <inheritdoc />
    public string GetFileNameWithExtensionByImageVariant(ImageVariantsEnum imageVariant)
    {
        return $"{GetFileNameByImageVariant(imageVariant)}.{GetImageExtensionByImageVariant(imageVariant)}"; 
    }

    /// <summary>
    /// Получить имя файла без расширения по указанному варианту.
    /// </summary>
    /// <param name="imageVariant">Вариант картинки.</param>
    /// <returns>Имя файла.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Неизвестный вариант.</exception>
    private string GetFileNameByImageVariant(ImageVariantsEnum imageVariant)
    {
        return imageVariant switch
        {
            ImageVariantsEnum.Original => "original",
            ImageVariantsEnum.Thumb200 => "thumb200",
            ImageVariantsEnum.Thumb400 => "thumb400",
            ImageVariantsEnum.Thumb800 => "thumb800",
            _ => throw new ArgumentOutOfRangeException(nameof(imageVariant), imageVariant, "Неизвестный вариант.")
        };
    }

    /// <summary>
    /// Получить расширение файла в зависимости от выбранного варианта картинки.
    /// </summary>
    /// <param name="imageVariant">Вариант картинки.</param>
    /// <returns>Расширение файла картинки. Jpg для оригинала и webp для остального.</returns>
    private string GetImageExtensionByImageVariant(ImageVariantsEnum imageVariant)
    {
        return imageVariant switch
        {
            ImageVariantsEnum.Original => "jpg",
            _ => "webp"
        };
    }
}