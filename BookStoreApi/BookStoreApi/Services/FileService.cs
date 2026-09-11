using BookStoreApi.Interfaces;

namespace BookStoreApi.Services;

/// <summary>
/// Сервис для работы с файлами
/// </summary>
public class FileService: IFileService
{
    /// <inheritdoc />
    public async Task<byte[]> GetFileBytesByGuidAsync(string filePath, CancellationToken cancellationToken = default)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException(filePath);
        }

        var bytes = await File.ReadAllBytesAsync(filePath, cancellationToken);

        return bytes;
    }
}