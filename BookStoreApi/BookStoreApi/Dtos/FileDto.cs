namespace BookStoreApi.Dtos;

/// <summary>
/// Dto файла
/// </summary>
public class FileDto
{
    /// <summary>
    /// Гуид
    /// </summary>
    public Guid Guid { get; set; }

    /// <summary>
    /// Байты
    /// </summary>
    public IEnumerable<byte> Bytes { get; set; }
}