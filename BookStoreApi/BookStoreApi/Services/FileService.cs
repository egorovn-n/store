using BookStoreApi.Dtos;
using BookStoreApi.Interfaces;

namespace BookStoreApi.Services;

/// <summary>
/// Сервис для работы с файлами
/// </summary>
public class FileService: IFileService
{
    private const string ImagesString = "Images";
    private static readonly string ImagesPath = Path.Combine(Directory.GetCurrentDirectory(), ImagesString);

    /// <inheritdoc />
    public async Task<FileDto?> GetFileBytesByGuidAsync(Guid guid)
    {
        var path = Path.Combine(ImagesPath, $"{guid}.jpg");
        if (!File.Exists(path))
        {
            return null;
        }

        var bytes = await File.ReadAllBytesAsync(path);

        return new FileDto
        {
            Guid = guid,
            Bytes = bytes
        };
    }

    /// <inheritdoc />
    public async Task<IEnumerable<FileDto>> GetFilesBytesByGuidsAsync(IEnumerable<Guid> guids)
    {
        var tasks = guids.Select(GetFileBytesByGuidAsync);

        var results = await Task.WhenAll(tasks);

        return results.Where(x => x != null)!;
    }
}