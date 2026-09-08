using BookStoreApi.Dtos;

namespace BookStoreApi.Interfaces;

/// <summary>
/// Интерфейс сервиса для работы с файлами.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Получить файл по гуиду.
    /// </summary>
    /// <param name="guid">Гуид.</param>
    /// <returns>Гуид и байты файла.</returns>
    public Task<FileDto?> GetFileBytesByGuidAsync(Guid guid);

    /// <summary>
    /// Получить файлы по гуидам.
    /// </summary>
    /// <param name="guids">Список гуидов.</param>
    /// <returns>Список гуидов и байтов файла.</returns>
    public Task<IEnumerable<FileDto>> GetFilesBytesByGuidsAsync(IEnumerable<Guid> guids);
}