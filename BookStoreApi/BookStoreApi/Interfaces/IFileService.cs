namespace BookStoreApi.Interfaces;

/// <summary>
/// Интерфейс сервиса для работы с файлами.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Получить файл.
    /// </summary>
    /// <param name="filePath">Полный путь к файлу.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Байты файла.</returns>
    /// <exception cref="FileNotFoundException">Файл не найден.</exception>
    public Task<byte[]> GetFileBytesByGuidAsync(string filePath, CancellationToken cancellationToken);
}