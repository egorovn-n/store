namespace BookStoreApi.Dtos;

/// <summary>
/// Dto картинки
/// </summary>
public class ImageDto
{
    /// <summary>
    /// Гуид картинки
    /// </summary>
    public Guid ImageGuid { get; set; }

    /// <summary>
    /// Байты картинки
    /// </summary>
    public IEnumerable<byte> ImageBytes { get; set; }
}